using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyRapPhim
{
    public partial class FormPhim : Form
    {
        string pathAnh = "";
        string originalMaPhim = ""; // BIẾN MỚI QUAN TRỌNG: Lưu mã gốc để sửa

        public FormPhim()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    string sql = "SELECT * FROM Phim";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPhim.DataSource = dt;

                    if (dgvPhim.Columns.Contains("HinhAnh")) dgvPhim.Columns["HinhAnh"].Visible = false;

                    if (dgvPhim.Columns.Contains("MaPhim")) dgvPhim.Columns["MaPhim"].HeaderText = "Mã Phim";
                    if (dgvPhim.Columns.Contains("TenPhim")) dgvPhim.Columns["TenPhim"].HeaderText = "Tên Phim";
                    if (dgvPhim.Columns.Contains("ThoiLuong")) dgvPhim.Columns["ThoiLuong"].HeaderText = "Thời Lượng (Phút)";
                    if (dgvPhim.Columns.Contains("DaoDien")) dgvPhim.Columns["DaoDien"].HeaderText = "Đạo Diễn";
                    if (dgvPhim.Columns.Contains("TheLoai")) dgvPhim.Columns["TheLoai"].HeaderText = "Thể Loại";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message); }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathAnh = ofd.FileName;
                picPoster.Image = Image.FromFile(pathAnh);
            }
        }

        private void dgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhim.Rows[e.RowIndex];

                // Lưu mã gốc vào biến (QUAN TRỌNG ĐỂ SỬA ĐƯỢC MÃ)
                originalMaPhim = row.Cells["MaPhim"].Value.ToString();

                // Hiển thị lên ô nhập
                txtMaPhim.Text = originalMaPhim;
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();

                if (row.Cells["ThoiLuong"].Value != DBNull.Value)
                    numThoiLuong.Value = Convert.ToDecimal(row.Cells["ThoiLuong"].Value);

                if (dgvPhim.Columns.Contains("TheLoai"))
                    txtTheLoai.Text = row.Cells["TheLoai"].Value.ToString();

                txtDaoDien.Text = row.Cells["DaoDien"].Value.ToString();

                if (dgvPhim.Columns.Contains("HinhAnh"))
                {
                    pathAnh = row.Cells["HinhAnh"].Value.ToString();
                    if (File.Exists(pathAnh))
                        picPoster.Image = Image.FromFile(pathAnh);
                    else
                        picPoster.Image = null;
                }
            }
        }

        // CHỨC NĂNG SỬA: ĐÃ CẬP NHẬT ĐỂ SỬA ĐƯỢC MÃ PHIM
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalMaPhim))
            {
                MessageBox.Show("Vui lòng chọn phim cần sửa từ bảng trước!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                try
                {
                    // Cập nhật cả MaPhim mới dựa trên MaPhim cũ (originalMaPhim)
                    string sql = "UPDATE Phim SET MaPhim=@newMa, TenPhim=@ten, ThoiLuong=@tl, TheLoai=@tlai, DaoDien=@dd, HinhAnh=@anh WHERE MaPhim=@oldMa";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@newMa", txtMaPhim.Text); // Mã mới (nếu người dùng sửa)
                    cmd.Parameters.AddWithValue("@oldMa", originalMaPhim); // Mã cũ (để tìm dòng cần sửa)

                    cmd.Parameters.AddWithValue("@ten", txtTenPhim.Text);
                    cmd.Parameters.AddWithValue("@tl", (int)numThoiLuong.Value);
                    cmd.Parameters.AddWithValue("@tlai", txtTheLoai.Text);
                    cmd.Parameters.AddWithValue("@dd", txtDaoDien.Text);
                    cmd.Parameters.AddWithValue("@anh", pathAnh);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");

                    // Cập nhật lại mã gốc sau khi sửa thành công
                    originalMaPhim = txtMaPhim.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa (Có thể trùng Mã Phim mới): " + ex.Message);
                }
            }
        }

        // CHỨC NĂNG LÀM MỚI (RESET)
        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            numThoiLuong.Value = 0;
            txtTheLoai.Clear();
            txtDaoDien.Clear();

            // Xóa ảnh
            picPoster.Image = null;
            pathAnh = "";

            // Reset mã gốc
            originalMaPhim = "";

            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPhim.Text == "" || txtTenPhim.Text == "") { MessageBox.Show("Vui lòng nhập đủ thông tin!"); return; }
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                try
                {
                    string sql = "INSERT INTO Phim (MaPhim, TenPhim, ThoiLuong, TheLoai, DaoDien, HinhAnh) VALUES (@ma, @ten, @tl, @tlai, @dd, @anh)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaPhim.Text);
                    cmd.Parameters.AddWithValue("@ten", txtTenPhim.Text);
                    cmd.Parameters.AddWithValue("@tl", (int)numThoiLuong.Value);
                    cmd.Parameters.AddWithValue("@tlai", txtTheLoai.Text);
                    cmd.Parameters.AddWithValue("@dd", txtDaoDien.Text);
                    cmd.Parameters.AddWithValue("@anh", pathAnh);
                    conn.Open(); cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Thêm thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhim.Text)) return;
            if (MessageBox.Show("Xóa phim này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    // Xóa dựa trên MaPhim đang hiển thị trong ô nhập
                    string sql = "DELETE FROM Phim WHERE MaPhim=@ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaPhim.Text);
                    conn.Open(); cmd.ExecuteNonQuery();
                    LoadData();
                    btnReload_Click(null, null); // Làm mới lại ô nhập sau khi xóa
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvPhim.Rows.Count == 0) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = "DanhSachPhim.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                    Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
                    int colIndex = 1;
                    for (int i = 0; i < dgvPhim.Columns.Count; i++)
                    {
                        if (dgvPhim.Columns[i].Visible)
                        {
                            ws.Cells[1, colIndex] = dgvPhim.Columns[i].HeaderText;
                            ws.Cells[1, colIndex].Font.Bold = true;
                            colIndex++;
                        }
                    }
                    for (int i = 0; i < dgvPhim.Rows.Count; i++)
                    {
                        colIndex = 1;
                        for (int j = 0; j < dgvPhim.Columns.Count; j++)
                        {
                            if (dgvPhim.Columns[j].Visible)
                            {
                                if (dgvPhim.Rows[i].Cells[j].Value != null)
                                    ws.Cells[i + 2, colIndex] = dgvPhim.Rows[i].Cells[j].Value.ToString();
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

        private void picPoster_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}