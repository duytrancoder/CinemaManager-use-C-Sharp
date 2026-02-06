using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices; // Để dùng Marshal
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyRapPhim
{
    public partial class FormPhim : Form
    {
        string pathAnh = "";
        string originalMaPhim = "";

        public FormPhim()
        {
            InitializeComponent();
            LoadData();
        }

        // --- 1. TẢI DỮ LIỆU ---
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
                    SetupGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message); }
        }

        void SetupGridView()
        {
            if (dgvPhim.Columns.Contains("HinhAnh")) dgvPhim.Columns["HinhAnh"].Visible = false; // Ẩn trên Form
            if (dgvPhim.Columns.Contains("MaPhim")) dgvPhim.Columns["MaPhim"].HeaderText = "Mã Phim";
            if (dgvPhim.Columns.Contains("TenPhim")) dgvPhim.Columns["TenPhim"].HeaderText = "Tên Phim";
            if (dgvPhim.Columns.Contains("ThoiLuong")) dgvPhim.Columns["ThoiLuong"].HeaderText = "Thời Lượng (Phút)";
            if (dgvPhim.Columns.Contains("DaoDien")) dgvPhim.Columns["DaoDien"].HeaderText = "Đạo Diễn";
            if (dgvPhim.Columns.Contains("TheLoai")) dgvPhim.Columns["TheLoai"].HeaderText = "Thể Loại";
        }

        // --- 2. XUẤT EXCEL (ĐÃ SỬA: XUẤT CẢ CỘT HÌNH ẢNH) ---
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvPhim.Rows.Count == 0) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = "DanhSachPhim.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;

                try
                {
                    app = new Excel.Application();
                    wb = app.Workbooks.Add(Type.Missing);
                    ws = (Excel.Worksheet)wb.Sheets[1];

                    int colIndex = 1;

                    // 1. XUẤT TIÊU ĐỀ CỘT
                    for (int i = 0; i < dgvPhim.Columns.Count; i++)
                    {
                        // Sửa điều kiện: Xuất nếu cột hiện HOẶC là cột HinhAnh
                        if (dgvPhim.Columns[i].Visible || dgvPhim.Columns[i].Name == "HinhAnh")
                        {
                            if (dgvPhim.Columns[i].Name == "HinhAnh")
                                ws.Cells[1, colIndex] = "Đường dẫn ảnh"; // Đặt tên tiêu đề cho đẹp
                            else
                                ws.Cells[1, colIndex] = dgvPhim.Columns[i].HeaderText;

                            ws.Cells[1, colIndex].Font.Bold = true;
                            ws.Cells[1, colIndex].Interior.Color = Color.LightYellow; // Tô màu nền tiêu đề
                            colIndex++;
                        }
                    }

                    // 2. XUẤT DỮ LIỆU DÒNG
                    for (int i = 0; i < dgvPhim.Rows.Count; i++)
                    {
                        colIndex = 1;
                        for (int j = 0; j < dgvPhim.Columns.Count; j++)
                        {
                            // Sửa điều kiện tương tự: Xuất nếu cột hiện HOẶC là cột HinhAnh
                            if (dgvPhim.Columns[j].Visible || dgvPhim.Columns[j].Name == "HinhAnh")
                            {
                                if (dgvPhim.Rows[i].Cells[j].Value != null)
                                {
                                    // Thêm dấu ' trước dữ liệu để tránh lỗi định dạng Excel (đặc biệt với số 0 ở đầu)
                                    ws.Cells[i + 2, colIndex] = "'" + dgvPhim.Rows[i].Cells[j].Value.ToString();
                                }
                                colIndex++;
                            }
                        }
                    }

                    ws.Columns.AutoFit(); // Tự động dãn cột
                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
                }
                finally
                {
                    // Dọn dẹp bộ nhớ
                    if (ws != null) Marshal.ReleaseComObject(ws);
                    if (wb != null)
                    {
                        wb.Close(false); // Đóng không save lại lần nữa
                        Marshal.ReleaseComObject(wb);
                    }
                    if (app != null)
                    {
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        // --- 3. NHẬP EXCEL (IMPORT) ---
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.Title = "Chọn file Excel để nhập liệu";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = null;
                Excel.Worksheet xlWorksheet = null;
                Excel.Range xlRange = null;

                try
                {
                    xlWorkbook = xlApp.Workbooks.Open(ofd.FileName);
                    xlWorksheet = xlWorkbook.Sheets[1];
                    xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int successCount = 0;
                    int errorCount = 0;
                    string duplicateCodes = "";

                    using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                    {
                        conn.Open();
                        // Bắt đầu đọc từ dòng 2
                        for (int i = 2; i <= rowCount; i++)
                        {
                            try
                            {
                                string ma = xlRange.Cells[i, 1].Value2?.ToString();
                                string ten = xlRange.Cells[i, 2].Value2?.ToString();
                                string tlStr = xlRange.Cells[i, 3].Value2?.ToString();
                                string theLoai = xlRange.Cells[i, 4].Value2?.ToString();
                                string daoDien = xlRange.Cells[i, 5].Value2?.ToString();
                                string anh = xlRange.Cells[i, 6].Value2?.ToString() ?? "";

                                if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
                                    continue;

                                // Check trùng mã
                                string checkSql = "SELECT COUNT(*) FROM Phim WHERE MaPhim = @ma";
                                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                                {
                                    checkCmd.Parameters.AddWithValue("@ma", ma);
                                    int count = (int)checkCmd.ExecuteScalar();
                                    if (count > 0)
                                    {
                                        errorCount++;
                                        duplicateCodes += ma + ", ";
                                        continue;
                                    }
                                }

                                int thoiLuong = 0;
                                int.TryParse(tlStr, out thoiLuong);

                                string sql = "INSERT INTO Phim (MaPhim, TenPhim, ThoiLuong, TheLoai, DaoDien, HinhAnh) " +
                                             "VALUES (@ma, @ten, @tl, @tlai, @dd, @anh)";

                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@ma", ma);
                                    cmd.Parameters.AddWithValue("@ten", ten);
                                    cmd.Parameters.AddWithValue("@tl", thoiLuong);
                                    cmd.Parameters.AddWithValue("@tlai", theLoai ?? "");
                                    cmd.Parameters.AddWithValue("@dd", daoDien ?? "");
                                    cmd.Parameters.AddWithValue("@anh", anh);
                                    cmd.ExecuteNonQuery();
                                    successCount++;
                                }
                            }
                            catch { errorCount++; }
                        }
                    }

                    string msg = $"Đã nhập xong!\n- Thành công: {successCount}";
                    if (errorCount > 0)
                    {
                        msg += $"\n- Lỗi/Trùng mã: {errorCount}";
                        if (!string.IsNullOrEmpty(duplicateCodes))
                        {
                            duplicateCodes = duplicateCodes.TrimEnd(',', ' ');
                            msg += $"\n- Các mã bị trùng: {duplicateCodes}";
                        }
                    }
                    MessageBox.Show(msg, "Kết quả Import");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file Excel: " + ex.Message);
                }
                finally
                {
                    if (xlRange != null) Marshal.ReleaseComObject(xlRange);
                    if (xlWorksheet != null) Marshal.ReleaseComObject(xlWorksheet);
                    if (xlWorkbook != null) { xlWorkbook.Close(); Marshal.ReleaseComObject(xlWorkbook); }
                    if (xlApp != null) { xlApp.Quit(); Marshal.ReleaseComObject(xlApp); }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        // --- 4. TÌM KIẾM ---
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) { LoadData(); return; }
            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    string sql = "SELECT * FROM Phim WHERE MaPhim LIKE @kw OR TenPhim LIKE @kw OR TheLoai LIKE @kw OR DaoDien LIKE @kw";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPhim.DataSource = dt;
                    SetupGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }

        private void btnHuyTim_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadData(); }

        // --- 5. CRUD ---
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
                originalMaPhim = row.Cells["MaPhim"].Value.ToString();
                txtMaPhim.Text = originalMaPhim;
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();
                if (row.Cells["ThoiLuong"].Value != DBNull.Value) numThoiLuong.Value = Convert.ToDecimal(row.Cells["ThoiLuong"].Value);
                if (dgvPhim.Columns.Contains("TheLoai")) txtTheLoai.Text = row.Cells["TheLoai"].Value.ToString();
                txtDaoDien.Text = row.Cells["DaoDien"].Value.ToString();
                if (dgvPhim.Columns.Contains("HinhAnh"))
                {
                    pathAnh = row.Cells["HinhAnh"].Value.ToString();
                    if (File.Exists(pathAnh)) picPoster.Image = Image.FromFile(pathAnh);
                    else picPoster.Image = null;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPhim.Text == "" || txtTenPhim.Text == "") { MessageBox.Show("Vui lòng nhập đủ thông tin!"); return; }
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                try
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(*) FROM Phim WHERE MaPhim = @ma";
                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@ma", txtMaPhim.Text);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Mã phim này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string sql = "INSERT INTO Phim (MaPhim, TenPhim, ThoiLuong, TheLoai, DaoDien, HinhAnh) VALUES (@ma, @ten, @tl, @tlai, @dd, @anh)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaPhim.Text);
                    cmd.Parameters.AddWithValue("@ten", txtTenPhim.Text);
                    cmd.Parameters.AddWithValue("@tl", (int)numThoiLuong.Value);
                    cmd.Parameters.AddWithValue("@tlai", txtTheLoai.Text);
                    cmd.Parameters.AddWithValue("@dd", txtDaoDien.Text);
                    cmd.Parameters.AddWithValue("@anh", pathAnh);
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Thêm thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalMaPhim)) { MessageBox.Show("Vui lòng chọn phim cần sửa!"); return; }
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                try
                {
                    if (txtMaPhim.Text != originalMaPhim)
                    {
                        conn.Open();
                        string checkSql = "SELECT COUNT(*) FROM Phim WHERE MaPhim = @ma";
                        SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                        checkCmd.Parameters.AddWithValue("@ma", txtMaPhim.Text);
                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Mã phim mới bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        conn.Close();
                    }
                    string sql = "UPDATE Phim SET MaPhim=@newMa, TenPhim=@ten, ThoiLuong=@tl, TheLoai=@tlai, DaoDien=@dd, HinhAnh=@anh WHERE MaPhim=@oldMa";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@newMa", txtMaPhim.Text);
                    cmd.Parameters.AddWithValue("@oldMa", originalMaPhim);
                    cmd.Parameters.AddWithValue("@ten", txtTenPhim.Text);
                    cmd.Parameters.AddWithValue("@tl", (int)numThoiLuong.Value);
                    cmd.Parameters.AddWithValue("@tlai", txtTheLoai.Text);
                    cmd.Parameters.AddWithValue("@dd", txtDaoDien.Text);
                    cmd.Parameters.AddWithValue("@anh", pathAnh);
                    conn.Open(); cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");
                    originalMaPhim = txtMaPhim.Text;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhim.Text)) return;
            if (MessageBox.Show("Xóa phim này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    string sql = "DELETE FROM Phim WHERE MaPhim=@ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaPhim.Text);
                    conn.Open(); cmd.ExecuteNonQuery();
                    LoadData();
                    btnReload_Click(null, null);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaPhim.Clear(); txtTenPhim.Clear(); numThoiLuong.Value = 0;
            txtTheLoai.Clear(); txtDaoDien.Clear();
            picPoster.Image = null; pathAnh = ""; originalMaPhim = "";
            txtTimKiem.Clear();
            LoadData();
        }

        private void groupBoxInfo_Enter(object sender, EventArgs e) { }
        private void FormPhim_Load(object sender, EventArgs e) { }
    }
}