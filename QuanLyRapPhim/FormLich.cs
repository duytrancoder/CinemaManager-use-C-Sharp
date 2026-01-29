using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyRapPhim
{
    public partial class FormLich : Form
    {
        string originalMaLich = ""; // QUAN TRỌNG: Lưu mã lịch gốc để sửa

        public FormLich()
        {
            InitializeComponent();
            LoadDataLich();
            LoadComboPhim();
            LoadComboPhong();
        }

        void LoadDataLich()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    string sql = @"SELECT L.MaLich, P.TenPhim, L.NgayChieu, L.GioChieu, L.TenPhong, L.GiaVe 
                                   FROM LichChieu L JOIN Phim P ON L.MaPhim = P.MaPhim";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLich.DataSource = dt;

                    dgvLich.Columns["MaLich"].HeaderText = "Mã Lịch";
                    dgvLich.Columns["TenPhim"].HeaderText = "Tên Phim";
                    dgvLich.Columns["NgayChieu"].HeaderText = "Ngày Chiếu";
                    dgvLich.Columns["GioChieu"].HeaderText = "Giờ Chiếu";
                    dgvLich.Columns["TenPhong"].HeaderText = "Phòng Chiếu";
                    dgvLich.Columns["GiaVe"].HeaderText = "Giá Vé";

                    dgvLich.Columns["NgayChieu"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvLich.Columns["GiaVe"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lịch: " + ex.Message); }
        }

        void LoadComboPhim()
        {
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaPhim, TenPhim FROM Phim", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboPhim.DataSource = dt;
                cboPhim.DisplayMember = "TenPhim";
                cboPhim.ValueMember = "MaPhim";
            }
        }

        // SỰ KIỆN MỚI: KHI CHỌN PHIM -> HIỆN ẢNH TƯƠNG ỨNG
        private void cboPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhim.SelectedValue == null) return;
            // Kiểm tra xem value có phải là DataRowView không (lúc mới load form)
            if (cboPhim.SelectedValue is DataRowView) return;

            string maPhim = cboPhim.SelectedValue.ToString();

            // Query lấy đường dẫn ảnh của phim này
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                string sql = "SELECT HinhAnh FROM Phim WHERE MaPhim = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maPhim);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && !string.IsNullOrEmpty(result.ToString()))
                    {
                        string path = result.ToString();
                        if (File.Exists(path))
                            picPoster.Image = Image.FromFile(path);
                        else
                            picPoster.Image = null;
                    }
                    else
                    {
                        picPoster.Image = null;
                    }
                }
                catch { picPoster.Image = null; }
            }
        }

        private void dgvLich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLich.Rows[e.RowIndex];

                // Lưu Mã Lịch gốc
                originalMaLich = row.Cells["MaLich"].Value.ToString();

                txtMaLich.Text = originalMaLich;
                cboPhim.Text = row.Cells["TenPhim"].Value.ToString();
                // (Khi gán Text cho cboPhim, sự kiện SelectedIndexChanged sẽ chạy và tự load ảnh)

                dtpNgay.Value = Convert.ToDateTime(row.Cells["NgayChieu"].Value);
                if (row.Cells["GioChieu"].Value != DBNull.Value)
                {
                    TimeSpan ts = (TimeSpan)row.Cells["GioChieu"].Value;
                    dtpGio.Value = DateTime.Today.Add(ts);
                }
                cboPhong.SelectedValue = row.Cells["TenPhong"].Value.ToString();
                txtGiaVe.Text = row.Cells["GiaVe"].Value.ToString();
            }
        }

        // SỬA LỊCH: ĐÃ CẬP NHẬT LOGIC DÙNG originalMaLich
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalMaLich))
            {
                MessageBox.Show("Vui lòng chọn lịch cần sửa từ bảng trước!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                try
                {
                    string sql = "UPDATE LichChieu SET MaLich=@newMa, MaPhim=@phim, NgayChieu=@ngay, GioChieu=@gio, TenPhong=@phong, GiaVe=@gia WHERE MaLich=@oldMa";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@newMa", txtMaLich.Text); // Mã mới
                    cmd.Parameters.AddWithValue("@oldMa", originalMaLich); // Mã cũ (để tìm)

                    cmd.Parameters.AddWithValue("@phim", cboPhim.SelectedValue);
                    cmd.Parameters.AddWithValue("@ngay", dtpNgay.Value);
                    cmd.Parameters.AddWithValue("@gio", dtpGio.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@phong", cboPhong.SelectedValue);
                    cmd.Parameters.AddWithValue("@gia", txtGiaVe.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadDataLich();
                    MessageBox.Show("Cập nhật lịch chiếu thành công!");

                    // Cập nhật lại mã gốc
                    originalMaLich = txtMaLich.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa (Có thể trùng Mã Lịch): " + ex.Message);
                }
            }
        }

        // CHỨC NĂNG LÀM MỚI (RESET)
        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaLich.Clear();
            txtGiaVe.Clear();
            picPoster.Image = null; // Xóa ảnh
            originalMaLich = ""; // Reset mã gốc
            LoadDataLich();
        }

        // --- Các phần giữ nguyên ---
        void LoadComboPhong()
        {
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TenPhong FROM Phong", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboPhong.DataSource = dt;
                cboPhong.DisplayMember = "TenPhong";
                cboPhong.ValueMember = "TenPhong";
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            Form inputBox = new Form();
            inputBox.Size = new Size(300, 150);
            inputBox.Text = "Thêm phòng mới";
            inputBox.StartPosition = FormStartPosition.CenterParent;
            Label lbl = new Label() { Left = 20, Top = 20, Text = "Nhập tên phòng:" };
            TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 240 };
            Button btnOk = new Button() { Text = "Lưu", Left = 180, Top = 80, DialogResult = DialogResult.OK };
            inputBox.Controls.Add(lbl); inputBox.Controls.Add(txtInput); inputBox.Controls.Add(btnOk);
            inputBox.AcceptButton = btnOk;

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                string phongMoi = txtInput.Text.Trim();
                if (!string.IsNullOrEmpty(phongMoi))
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO Phong VALUES (@ten)", conn);
                            cmd.Parameters.AddWithValue("@ten", phongMoi);
                            cmd.ExecuteNonQuery();
                        }
                        LoadComboPhong();
                        cboPhong.SelectedValue = phongMoi;
                        MessageBox.Show("Đã thêm phòng: " + phongMoi);
                    }
                    catch { MessageBox.Show("Phòng này đã tồn tại!"); }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLich.Text == "" || txtGiaVe.Text == "") { MessageBox.Show("Vui lòng nhập đủ thông tin!"); return; }
            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    string sql = "INSERT INTO LichChieu (MaLich, MaPhim, NgayChieu, GioChieu, TenPhong, GiaVe) VALUES (@ma, @phim, @ngay, @gio, @phong, @gia)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaLich.Text);
                    cmd.Parameters.AddWithValue("@phim", cboPhim.SelectedValue);
                    cmd.Parameters.AddWithValue("@ngay", dtpNgay.Value);
                    cmd.Parameters.AddWithValue("@gio", dtpGio.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@phong", cboPhong.SelectedValue);
                    cmd.Parameters.AddWithValue("@gia", txtGiaVe.Text);
                    conn.Open(); cmd.ExecuteNonQuery();
                    LoadDataLich();
                    MessageBox.Show("Thêm thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLich.Text)) return;
            if (MessageBox.Show("Xóa lịch chiếu này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    // Xóa dựa trên MaLich đang hiển thị
                    conn.Open();
                    SqlCommand cmdDelVe = new SqlCommand("DELETE FROM Ve WHERE MaLich=@ma", conn);
                    cmdDelVe.Parameters.AddWithValue("@ma", txtMaLich.Text);
                    cmdDelVe.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("DELETE FROM LichChieu WHERE MaLich=@ma", conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaLich.Text);
                    cmd.ExecuteNonQuery();

                    LoadDataLich();
                    btnReload_Click(null, null); // Reset lại ô nhập
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvLich.Rows.Count == 0) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = "LichChieuPhim.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                    Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
                    int colIndex = 1;
                    for (int i = 0; i < dgvLich.Columns.Count; i++)
                    {
                        if (dgvLich.Columns[i].Visible)
                        {
                            ws.Cells[1, colIndex] = dgvLich.Columns[i].HeaderText;
                            ws.Cells[1, colIndex].Font.Bold = true;
                            colIndex++;
                        }
                    }
                    for (int i = 0; i < dgvLich.Rows.Count; i++)
                    {
                        colIndex = 1;
                        for (int j = 0; j < dgvLich.Columns.Count; j++)
                        {
                            if (dgvLich.Columns[j].Visible)
                            {
                                var val = dgvLich.Rows[i].Cells[j].Value;
                                if (val is DateTime) ws.Cells[i + 2, colIndex] = ((DateTime)val).ToString("dd/MM/yyyy");
                                else if (val is TimeSpan) ws.Cells[i + 2, colIndex] = ((TimeSpan)val).ToString(@"hh\:mm");
                                else ws.Cells[i + 2, colIndex] = val != null ? val.ToString() : "";
                                colIndex++;
                            }
                        }
                    }
                    ws.Columns.AutoFit();
                    wb.SaveAs(sfd.FileName);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    MessageBox.Show("Xuất Excel thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }
    }
}