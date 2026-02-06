using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapPhim
{
    public partial class FormMain : Form
    {
        // Kết nối DB
        public static string connStr = @"Data Source=DESKTOP-4PO6FDP\SSQLSERVER;Initial Catalog=QuanLyRapPhim;Integrated Security=True";

        public FormMain()
        {
            InitializeComponent();
            
            OpenChildForm(new FormPhim());
            SetButtonActive(btnQuanLyPhim);
        }

        private void OpenChildForm(Form childForm)
        {
            if (pnlContent.Controls.Count > 0)
                pnlContent.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void SetButtonActive(Button btn)
        {
            // Reset màu tất cả nút
            btnQuanLyPhim.BackColor = Color.Transparent;
            btnLichChieu.BackColor = Color.Transparent;
            btnBanVe.BackColor = Color.Transparent;

            // Nút active màu Cam 
            btn.BackColor = Color.FromArgb(255, 140, 0);
        }

        private void btnNavigation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SetButtonActive(btn);
                
            if (btn.Text == "PHIM") OpenChildForm(new FormPhim());
            else if (btn.Text == "LỊCH CHIẾU") OpenChildForm(new FormLich());
            else if (btn.Text == "BÁN VÉ") OpenChildForm(new FormVe());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}