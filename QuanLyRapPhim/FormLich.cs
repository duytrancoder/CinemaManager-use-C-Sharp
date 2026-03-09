using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyRapPhim
{
    public partial class FormLich : Form
    {
        string originalMaLich = "";

        public FormLich()
        {
            InitializeComponent();
            LoadDataLich();
            LoadComboPhim();
            LoadComboPhong();
        }

        private void FormLich_Load(object sender, EventArgs e)
        {
            cboLoaiTimKiem.SelectedIndex = 0;

            // --- TỐI ƯU GIAO DIỆN BẢNG DỮ LIỆU ---
            dgvLich.EnableHeadersVisualStyles = false;
            dgvLich.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
            dgvLich.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLich.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvLich.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // XANH DA TRỜI (DodgerBlue) KHI CLICK
            dgvLich.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvLich.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLich.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

        // --- 1. TẢI DỮ LIỆU VÀ SẮP XẾP MÃ LỊCH CHUẨN ---
        void LoadDataLich()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    // FIX LỖI SẮP XẾP: Sắp xếp theo chiều dài chuỗi trước, sau đó sắp xếp theo chuỗi (L1, L2... L10)
                    string sql = @"SELECT L.MaLich, P.TenPhim, L.NgayChieu, L.GioChieu, L.TenPhong, L.GiaVe 
                                   FROM LichChieu L JOIN Phim P ON L.MaPhim = P.MaPhim
                                   ORDER BY LEN(L.MaLich), L.MaLich";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLich.DataSource = dt;
                    SetupGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lịch: " + ex.Message); }
        }

        void SetupGridView()
        {
            if (dgvLich.Columns.Contains("MaLich"))
            {
                dgvLich.Columns["MaLich"].HeaderText = "Mã Lịch";
                dgvLich.Columns["MaLich"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLich.Columns["MaLich"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvLich.Columns.Contains("TenPhim"))
            {
                dgvLich.Columns["TenPhim"].HeaderText = "Tên Phim";
                dgvLich.Columns["TenPhim"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvLich.Columns.Contains("NgayChieu"))
            {
                dgvLich.Columns["NgayChieu"].HeaderText = "Ngày Chiếu";
                dgvLich.Columns["NgayChieu"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvLich.Columns["NgayChieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLich.Columns["NgayChieu"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvLich.Columns.Contains("GioChieu"))
            {
                dgvLich.Columns["GioChieu"].HeaderText = "Giờ Chiếu";
                dgvLich.Columns["GioChieu"].DefaultCellStyle.Format = @"hh\:mm"; // Ép định dạng 24h
                dgvLich.Columns["GioChieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLich.Columns["GioChieu"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvLich.Columns.Contains("TenPhong"))
            {
                dgvLich.Columns["TenPhong"].HeaderText = "Phòng Chiếu";
                dgvLich.Columns["TenPhong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLich.Columns["TenPhong"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvLich.Columns.Contains("GiaVe"))
            {
                dgvLich.Columns["GiaVe"].HeaderText = "Giá Vé";
                dgvLich.Columns["GiaVe"].DefaultCellStyle.Format = "N0";
                dgvLich.Columns["GiaVe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLich.Columns["GiaVe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // --- 2. BỘ LỌC TÌM KIẾM (KẾT HỢP TỪ KHÓA VÀ NGÀY CHIẾU) ---
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string tieuChi = cboLoaiTimKiem.Text;

            // Xây dựng câu SQL động
            string sql = @"SELECT L.MaLich, P.TenPhim, L.NgayChieu, L.GioChieu, L.TenPhong, L.GiaVe 
                           FROM LichChieu L JOIN Phim P ON L.MaPhim = P.MaPhim WHERE 1=1 ";

            if (!string.IsNullOrEmpty(keyword))
            {
                switch (tieuChi)
                {
                    case "Mã Lịch": sql += " AND L.MaLich LIKE @kw"; break;
                    case "Tên Phim": sql += " AND P.TenPhim LIKE @kw"; break;
                    case "Phòng chiếu": sql += " AND L.TenPhong LIKE @kw"; break;
                    default: sql += " AND (L.MaLich LIKE @kw OR P.TenPhim LIKE @kw OR L.TenPhong LIKE @kw)"; break;
                }
            }

            // Lọc thêm theo ngày nếu CheckBox được tích
            if (chkLocNgay.Checked)
            {
                sql += " AND L.NgayChieu = @ngayLoc";
            }

            sql += " ORDER BY LEN(L.MaLich), L.MaLich";

            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (!string.IsNullOrEmpty(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    if (chkLocNgay.Checked) cmd.Parameters.AddWithValue("@ngayLoc", dtpLocNgay.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLich.DataSource = dt;
                    SetupGridView();

                    if (dt.Rows.Count == 0) MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }

        private void btnHuyTim_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            chkLocNgay.Checked = false;
            LoadDataLich();
        }

        // --- SẮP XẾP PHIM THEO TÊN (A-Z) TRONG COMBOBOX ---
        void LoadComboPhim()
        {
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaPhim, TenPhim FROM Phim ORDER BY TenPhim ASC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboPhim.DataSource = dt;
                cboPhim.DisplayMember = "TenPhim";
                cboPhim.ValueMember = "MaPhim";
            }
        }

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

        private void cboPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhim.SelectedValue == null || cboPhim.SelectedValue is DataRowView) return;
            string maPhim = cboPhim.SelectedValue.ToString();
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT HinhAnh FROM Phim WHERE MaPhim = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", maPhim);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && File.Exists(result.ToString())) picPoster.Image = Image.FromFile(result.ToString());
                    else picPoster.Image = null;
                }
                catch { picPoster.Image = null; }
            }
        }

        private void dgvLich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLich.Rows[e.RowIndex];
                originalMaLich = row.Cells["MaLich"].Value.ToString();
                txtMaLich.Text = originalMaLich;
                cboPhim.Text = row.Cells["TenPhim"].Value.ToString();
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

        // =======================================================================
        // 3. THUẬT TOÁN KIỂM TRA TRÙNG THỜI GIAN CHIẾU (SIÊU CHUẨN)
        // =======================================================================
        private int LayThoiLuongPhim(string maPhim, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT ThoiLuong FROM Phim WHERE MaPhim = @ma", conn);
            cmd.Parameters.AddWithValue("@ma", maPhim);
            object res = cmd.ExecuteScalar();
            return res != DBNull.Value ? Convert.ToInt32(res) : 0;
        }

        // Truyền thêm Connection để dùng chung (tiện cho cả Nhập Excel)
        private bool KiemTraTrungThoiGian(string maLichBoQua, string maPhimMoi, string tenPhong, DateTime ngayChieuMoi, TimeSpan gioChieuMoi, SqlConnection conn)
        {
            bool wasClosed = conn.State == ConnectionState.Closed;
            if (wasClosed) conn.Open();

            int thoiLuongMoi = LayThoiLuongPhim(maPhimMoi, conn);

            // Tính Giờ Bắt đầu và Kết thúc của ca mới (Tự động vắt qua ngày hôm sau nếu quá 24h)
            DateTime startMoi = ngayChieuMoi.Date + gioChieuMoi;
            DateTime endMoi = startMoi.AddMinutes(thoiLuongMoi);

            string sql = @"SELECT L.MaLich, L.NgayChieu, L.GioChieu, P.ThoiLuong 
                           FROM LichChieu L JOIN Phim P ON L.MaPhim = P.MaPhim 
                           WHERE L.TenPhong = @phong";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@phong", tenPhong);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maLichDB = reader["MaLich"].ToString();
                        if (maLichDB == maLichBoQua) continue; // Bỏ qua lịch đang sửa

                        DateTime ngayDB = Convert.ToDateTime(reader["NgayChieu"]).Date;
                        TimeSpan gioDB = (TimeSpan)reader["GioChieu"];
                        int tlDB = Convert.ToInt32(reader["ThoiLuong"]);

                        DateTime startDB = ngayDB + gioDB;
                        DateTime endDB = startDB.AddMinutes(tlDB);

                        // CÔNG THỨC KIỂM TRA CHỒNG CHÉO (OVERLAP)
                        if (startMoi < endDB && endMoi > startDB)
                        {
                            reader.Close();
                            if (wasClosed) conn.Close();
                            return true; // Báo động: Bị trùng!
                        }
                    }
                }
            }
            if (wasClosed) conn.Close();
            return false; // An toàn
        }
        // =======================================================================

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLich.Text == "" || txtGiaVe.Text == "") { MessageBox.Show("Vui lòng nhập đủ thông tin!"); return; }

            string maLichMoi = txtMaLich.Text;
            string phimMoi = cboPhim.SelectedValue.ToString();
            string phongMoi = cboPhong.SelectedValue.ToString();
            DateTime ngayMoi = dtpNgay.Value.Date;

            // FIX Giờ Chiếu: Cắt bỏ Giây bằng cách gán nó bằng 0
            TimeSpan gioMoi = new TimeSpan(dtpGio.Value.Hour, dtpGio.Value.Minute, 0);

            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    conn.Open();

                    // 1. Kiểm tra trùng Mã Lịch
                    SqlCommand checkMaCmd = new SqlCommand("SELECT COUNT(*) FROM LichChieu WHERE MaLich=@ma", conn);
                    checkMaCmd.Parameters.AddWithValue("@ma", maLichMoi);
                    if ((int)checkMaCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Mã lịch chiếu đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Kiểm tra trùng thời gian (Dùng chung connection đang mở)
                    if (KiemTraTrungThoiGian("", phimMoi, phongMoi, ngayMoi, gioMoi, conn))
                    {
                        MessageBox.Show($"Phòng '{phongMoi}' đang có phim được chiếu trong thời gian này!\nVui lòng chọn giờ hoặc phòng khác.",
                                        "Trùng lịch chiếu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. Thêm mới
                    string sql = "INSERT INTO LichChieu (MaLich, MaPhim, NgayChieu, GioChieu, TenPhong, GiaVe) VALUES (@ma, @phim, @ngay, @gio, @phong, @gia)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", maLichMoi);
                    cmd.Parameters.AddWithValue("@phim", phimMoi);
                    cmd.Parameters.AddWithValue("@ngay", ngayMoi);
                    cmd.Parameters.AddWithValue("@gio", gioMoi); // Đã ép mất giây
                    cmd.Parameters.AddWithValue("@phong", phongMoi);
                    cmd.Parameters.AddWithValue("@gia", txtGiaVe.Text);

                    cmd.ExecuteNonQuery();
                    LoadDataLich();
                    MessageBox.Show("Thêm lịch chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalMaLich)) { MessageBox.Show("Vui lòng chọn lịch cần sửa!"); return; }

            string maLichMoi = txtMaLich.Text;
            string phimMoi = cboPhim.SelectedValue.ToString();
            string phongMoi = cboPhong.SelectedValue.ToString();
            DateTime ngayMoi = dtpNgay.Value.Date;
            TimeSpan gioMoi = new TimeSpan(dtpGio.Value.Hour, dtpGio.Value.Minute, 0); // Cắt bỏ giây

            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    conn.Open();

                    if (maLichMoi != originalMaLich)
                    {
                        SqlCommand checkMaCmd = new SqlCommand("SELECT COUNT(*) FROM LichChieu WHERE MaLich=@ma", conn);
                        checkMaCmd.Parameters.AddWithValue("@ma", maLichMoi);
                        if ((int)checkMaCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Mã lịch mới bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (KiemTraTrungThoiGian(originalMaLich, phimMoi, phongMoi, ngayMoi, gioMoi, conn))
                    {
                        MessageBox.Show($"Phòng '{phongMoi}' đang có phim được chiếu trong thời gian này!\nVui lòng chọn giờ hoặc phòng khác.",
                                        "Trùng lịch chiếu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = "UPDATE LichChieu SET MaLich=@newMa, MaPhim=@phim, NgayChieu=@ngay, GioChieu=@gio, TenPhong=@phong, GiaVe=@gia WHERE MaLich=@oldMa";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@newMa", maLichMoi);
                    cmd.Parameters.AddWithValue("@oldMa", originalMaLich);
                    cmd.Parameters.AddWithValue("@phim", phimMoi);
                    cmd.Parameters.AddWithValue("@ngay", ngayMoi);
                    cmd.Parameters.AddWithValue("@gio", gioMoi);
                    cmd.Parameters.AddWithValue("@phong", phongMoi);
                    cmd.Parameters.AddWithValue("@gia", txtGiaVe.Text);

                    cmd.ExecuteNonQuery();
                    LoadDataLich();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    originalMaLich = maLichMoi;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLich.Text)) return;
            if (MessageBox.Show("Xóa lịch chiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    conn.Open();
                    SqlCommand cmdDelVe = new SqlCommand("DELETE FROM Ve WHERE MaLich=@ma", conn);
                    cmdDelVe.Parameters.AddWithValue("@ma", txtMaLich.Text);
                    cmdDelVe.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("DELETE FROM LichChieu WHERE MaLich=@ma", conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaLich.Text);
                    cmd.ExecuteNonQuery();
                    LoadDataLich();
                    btnReload_Click(null, null);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaLich.Clear(); txtGiaVe.Clear(); picPoster.Image = null; originalMaLich = "";
            txtTimKiem.Clear(); chkLocNgay.Checked = false; cboLoaiTimKiem.SelectedIndex = 0;
            LoadDataLich();
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

        // --- 4. XUẤT EXCEL CHUẨN ĐẸP ---
        private void btnXuatEx_Click(object sender, EventArgs e)
        {
            if (dgvLich.Rows.Count == 0) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = "LichChieu.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];

                try
                {
                    int colIndex = 1;
                    for (int i = 0; i < dgvLich.Columns.Count; i++)
                    {
                        if (dgvLich.Columns[i].Visible)
                        {
                            ws.Cells[1, colIndex] = dgvLich.Columns[i].HeaderText;
                            ws.Cells[1, colIndex].Font.Bold = true;
                            ws.Cells[1, colIndex].Interior.Color = Color.LightYellow;
                            // Bật viền cho tiêu đề
                            ws.Cells[1, colIndex].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
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
                                string strVal = "";
                                if (val is DateTime) strVal = ((DateTime)val).ToString("dd/MM/yyyy");
                                else if (val is TimeSpan) strVal = ((TimeSpan)val).ToString(@"hh\:mm");
                                else strVal = val != null ? val.ToString() : "";

                                ws.Cells[i + 2, colIndex] = "'" + strVal; // Đặt nháy đơn để tránh lỗi format excel
                                ws.Cells[i + 2, colIndex].Borders.LineStyle = Excel.XlLineStyle.xlContinuous; // Bật viền ô
                                colIndex++;
                            }
                        }
                    }

                    ws.Columns.AutoFit();
                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
                finally
                {
                    wb.Close(false);
                    app.Quit();
                    Marshal.ReleaseComObject(ws); Marshal.ReleaseComObject(wb); Marshal.ReleaseComObject(app);
                }
            }
        }

        // --- 5. NHẬP EXCEL THÔNG MINH ---
        private void btnNhapEx_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.Title = "Chọn file Excel để nhập (Cột: Mã, Tên Phim, Ngày, Giờ, Phòng, Giá)";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ofd.FileName);
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int success = 0, errMa = 0, errPhim = 0, errGio = 0;

                try
                {
                    using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                    {
                        conn.Open();
                        for (int i = 2; i <= xlRange.Rows.Count; i++) // Dòng 1 là tiêu đề
                        {
                            try
                            {
                                string maLich = xlRange.Cells[i, 1].Value2?.ToString();
                                string tenPhim = xlRange.Cells[i, 2].Value2?.ToString();
                                string phong = xlRange.Cells[i, 5].Value2?.ToString();
                                string giaVe = xlRange.Cells[i, 6].Value2?.ToString();

                                if (string.IsNullOrEmpty(maLich) || string.IsNullOrEmpty(tenPhim)) continue;

                                // 1. TÌM MÃ PHIM TỪ TÊN PHIM TRONG DB
                                string maPhim = "";
                                using (SqlCommand cmdPhim = new SqlCommand("SELECT TOP 1 MaPhim FROM Phim WHERE TenPhim = @ten", conn))
                                {
                                    cmdPhim.Parameters.AddWithValue("@ten", tenPhim);
                                    object res = cmdPhim.ExecuteScalar();
                                    if (res != null) maPhim = res.ToString();
                                    else { errPhim++; continue; } // Không thấy phim trong CSDL -> Bỏ qua
                                }

                                // 2. CHECK TRÙNG MÃ LỊCH
                                using (SqlCommand cmdCheckMa = new SqlCommand("SELECT COUNT(*) FROM LichChieu WHERE MaLich = @ma", conn))
                                {
                                    cmdCheckMa.Parameters.AddWithValue("@ma", maLich);
                                    if ((int)cmdCheckMa.ExecuteScalar() > 0) { errMa++; continue; } // Trùng mã -> Bỏ qua
                                }

                                // 3. PARSE THỜI GIAN
                                DateTime ngayChieu = DateTime.Now;
                                TimeSpan gioChieu = TimeSpan.Zero;

                                // Xử lý ngày từ Excel
                                if (xlRange.Cells[i, 3].Value2 != null)
                                {
                                    double d = 0;
                                    if (double.TryParse(xlRange.Cells[i, 3].Value2.ToString(), out d)) ngayChieu = DateTime.FromOADate(d);
                                    else DateTime.TryParse(xlRange.Cells[i, 3].Value2.ToString(), out ngayChieu);
                                }

                                // Xử lý giờ từ Excel
                                if (xlRange.Cells[i, 4].Value2 != null)
                                {
                                    double t = 0;
                                    if (double.TryParse(xlRange.Cells[i, 4].Value2.ToString(), out t)) gioChieu = DateTime.FromOADate(t).TimeOfDay;
                                    else TimeSpan.TryParse(xlRange.Cells[i, 4].Value2.ToString(), out gioChieu);
                                }

                                // 4. CHECK TRÙNG GIỜ CHIẾU VỚI CÁC PHIM KHÁC TRONG PHÒNG
                                if (KiemTraTrungThoiGian("", maPhim, phong, ngayChieu, gioChieu, conn))
                                {
                                    errGio++; continue; // Bị lấn giờ chiếu phim khác -> Bỏ qua
                                }

                                // 5. INSERT
                                string sql = "INSERT INTO LichChieu VALUES (@ma, @phim, @ngay, @gio, @phong, @gia)";
                                using (SqlCommand cmdIn = new SqlCommand(sql, conn))
                                {
                                    cmdIn.Parameters.AddWithValue("@ma", maLich);
                                    cmdIn.Parameters.AddWithValue("@phim", maPhim);
                                    cmdIn.Parameters.AddWithValue("@ngay", ngayChieu.Date);
                                    cmdIn.Parameters.AddWithValue("@gio", gioChieu);
                                    cmdIn.Parameters.AddWithValue("@phong", phong);
                                    cmdIn.Parameters.AddWithValue("@gia", giaVe);
                                    cmdIn.ExecuteNonQuery();
                                    success++;
                                }
                            }
                            catch { }
                        }
                    }

                    string msg = $"Nhập hoàn tất:\n- Thành công: {success}\n- Lỗi trùng Mã Lịch: {errMa}\n- Lỗi kẹt giờ/phòng: {errGio}\n- Không tìm thấy tên phim: {errPhim}";
                    MessageBox.Show(msg, "Thông báo Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataLich();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi đọc Excel: " + ex.Message); }
                finally
                {
                    xlWorkbook.Close(false); xlApp.Quit();
                    Marshal.ReleaseComObject(xlRange); Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook); Marshal.ReleaseComObject(xlApp);
                    GC.Collect();
                }
            }
        }
    }
}