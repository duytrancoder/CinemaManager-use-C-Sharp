using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapPhim
{
    public partial class FormVe : Form
    {
        string currentMaLich = "";
        decimal currentGiaVe = 0;
        List<string> listGheDangChon = new List<string>();

        public FormVe()
        {
            InitializeComponent();
            LoadPhimCoLichChieu();
        }

        // 1. Tải Phim
        void LoadPhimCoLichChieu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(FormMain.connStr))
                {
                    string sql = @"SELECT DISTINCT P.MaPhim, P.TenPhim 
                                   FROM LichChieu L JOIN Phim P ON L.MaPhim = P.MaPhim 
                                   WHERE L.NgayChieu >= CAST(GETDATE() AS DATE)";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboPhim.DataSource = dt;
                    cboPhim.DisplayMember = "TenPhim";
                    cboPhim.ValueMember = "MaPhim";
                    cboPhim.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải phim: " + ex.Message); }
        }

        // 2. CHỈNH SỬA: Format Ngày hiển thị (dd/MM/yyyy)
        private void cboPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboNgay.DataSource = null; cboGio.DataSource = null;
            flpGhe.Controls.Clear(); lblGiaVe.Text = "Giá vé: 0 VNĐ";
            listGheDangChon.Clear(); UpdateTongTien();

            if (cboPhim.SelectedIndex == -1) return;
            // Bỏ qua nếu đang load form (tránh lỗi DataRowView)
            if (cboPhim.SelectedValue is DataRowView) return;

            string maPhim = cboPhim.SelectedValue.ToString();
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                string sql = @"SELECT DISTINCT NgayChieu FROM LichChieu 
                               WHERE MaPhim = @ma AND NgayChieu >= CAST(GETDATE() AS DATE) ORDER BY NgayChieu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maPhim);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // --- SỬA Ở ĐÂY: Tạo cột hiển thị riêng ---
                dt.Columns.Add("NgayHienThi", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    // Ép kiểu DateTime sang chuỗi chỉ có ngày
                    row["NgayHienThi"] = Convert.ToDateTime(row["NgayChieu"]).ToString("dd/MM/yyyy");
                }

                cboNgay.DataSource = dt;
                cboNgay.DisplayMember = "NgayHienThi"; // Hiện chuỗi sạch (15/02/2026)
                cboNgay.ValueMember = "NgayChieu";     // Giá trị ngầm vẫn là DateTime gốc
                cboNgay.SelectedIndex = -1;
            }
        }

        private void cboNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGio.DataSource = null; flpGhe.Controls.Clear();
            listGheDangChon.Clear(); UpdateTongTien();

            if (cboNgay.SelectedIndex == -1) return;
            if (cboNgay.SelectedValue is DataRowView) return; // Check an toàn

            string maPhim = cboPhim.SelectedValue.ToString();
            // Lấy ValueMember (là NgayChieu gốc) để query chính xác
            DateTime ngay = Convert.ToDateTime(cboNgay.SelectedValue);

            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                string sql = "SELECT MaLich, GioChieu, GiaVe FROM LichChieu WHERE MaPhim = @ma AND NgayChieu = @ngay ORDER BY GioChieu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maPhim);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Format Giờ hiển thị (hh:mm)
                dt.Columns.Add("GioHienThi", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    TimeSpan ts = (TimeSpan)row["GioChieu"];
                    row["GioHienThi"] = ts.ToString(@"hh\:mm");
                }

                cboGio.DataSource = dt;
                cboGio.DisplayMember = "GioHienThi";
                cboGio.ValueMember = "MaLich";
                cboGio.SelectedIndex = -1;
            }
        }

        private void cboGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpGhe.Controls.Clear();
            listGheDangChon.Clear(); UpdateTongTien();

            if (cboGio.SelectedIndex == -1) return;

            DataRowView row = (DataRowView)cboGio.SelectedItem;
            currentMaLich = row["MaLich"].ToString();
            currentGiaVe = Convert.ToDecimal(row["GiaVe"]);

            lblGiaVe.Text = $"Giá vé: {currentGiaVe:N0} VNĐ";
            LoadGhe(currentMaLich);
        }

        // Vẽ ghế 3 dãy (A, B... I) và (1..12)
        void LoadGhe(string maLich)
        {
            List<string> gheDaBan = new List<string>();
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT SoGhe FROM Ve WHERE MaLich = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", maLich);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) gheDaBan.Add(dr["SoGhe"].ToString());
            }

            // Sơ đồ: 9 Hàng (A -> I), 12 Cột
            for (int i = 0; i < 9; i++)
            {
                char rowChar = (char)('A' + i); // A, B, C...
                for (int j = 1; j <= 12; j++) // 12 Cột
                {
                    Button btn = new Button();
                    string gheName = rowChar + j.ToString();
                    btn.Text = gheName;
                    btn.Size = new Size(50, 45);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;

                    // Tạo lối đi sau ghế số 4 và số 8
                    int rightMargin = 5;
                    if (j == 4 || j == 8) rightMargin = 50;
                    btn.Margin = new Padding(5, 5, rightMargin, 5);

                    if (gheDaBan.Contains(gheName))
                    {
                        btn.BackColor = Color.Red;
                        btn.ForeColor = Color.White;
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.Click += BtnGhe_Click;
                    }
                    flpGhe.Controls.Add(btn);
                    if (j == 12) flpGhe.SetFlowBreak(btn, true); // Xuống dòng
                }
            }
        }

        private void pnlScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.DeepPink, 4);
            e.Graphics.DrawArc(pen, 50, 10, pnlScreen.Width - 100, 60, 190, 160);
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.Yellow;
                listGheDangChon.Add(btn.Text);
            }
            else if (btn.BackColor == Color.Yellow)
            {
                btn.BackColor = Color.White;
                listGheDangChon.Remove(btn.Text);
            }
            UpdateTongTien();
        }

        void UpdateTongTien()
        {
            decimal tong = listGheDangChon.Count * currentGiaVe;
            lblTongTien.Text = $"{tong:N0} VNĐ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (listGheDangChon.Count == 0) { MessageBox.Show("Vui lòng chọn ghế!"); return; }

            // 1. Lưu vào Database
            using (SqlConnection conn = new SqlConnection(FormMain.connStr))
            {
                conn.Open();
                foreach (string ghe in listGheDangChon)
                {
                    string sql = "INSERT INTO Ve (MaLich, SoGhe, TrangThai) VALUES (@ma, @so, N'Đã bán')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", currentMaLich);
                    cmd.Parameters.AddWithValue("@so", ghe);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Thanh toán thành công!");

            // 2. Đổi màu ghế trực tiếp trên màn hình (Không load lại gây chớp)
            foreach (Control c in flpGhe.Controls)
            {
                Button btn = c as Button;
                if (btn != null && listGheDangChon.Contains(btn.Text))
                {
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.White;
                    btn.Enabled = false;
                }
            }

            // 3. Reset
            listGheDangChon.Clear();
            UpdateTongTien();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            foreach (Control c in flpGhe.Controls)
            {
                if (c is Button btn && btn.BackColor == Color.Yellow)
                    btn.BackColor = Color.White;
            }
            listGheDangChon.Clear();
            UpdateTongTien();
        }
    }
}