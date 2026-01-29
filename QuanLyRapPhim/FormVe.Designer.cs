namespace QuanLyRapPhim
{
    partial class FormVe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cboGio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNgay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPhim = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.flpGhe = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlScreen = new System.Windows.Forms.Panel();
            this.lblScreenText = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGiaVe = new System.Windows.Forms.Label();
            this.panelNote = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pBoxSold = new System.Windows.Forms.PictureBox();
            this.pBoxSelected = new System.Windows.Forms.PictureBox();
            this.pBoxEmpty = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlScreen.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.panelNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxEmpty)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.cboGio);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.cboNgay);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.cboPhim);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 80);
            this.pnlTop.TabIndex = 0;
            // 
            // cboGio
            // 
            this.cboGio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboGio.Location = new System.Drawing.Point(870, 25);
            this.cboGio.Name = "cboGio";
            this.cboGio.Size = new System.Drawing.Size(184, 33);
            this.cboGio.TabIndex = 0;
            this.cboGio.SelectedIndexChanged += new System.EventHandler(this.cboGio_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(790, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "3. Giờ:";
            // 
            // cboNgay
            // 
            this.cboNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboNgay.Location = new System.Drawing.Point(520, 25);
            this.cboNgay.Name = "cboNgay";
            this.cboNgay.Size = new System.Drawing.Size(211, 33);
            this.cboNgay.TabIndex = 2;
            this.cboNgay.SelectedIndexChanged += new System.EventHandler(this.cboNgay_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(440, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Ngày:";
            // 
            // cboPhim
            // 
            this.cboPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhim.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboPhim.Location = new System.Drawing.Point(100, 25);
            this.cboPhim.Name = "cboPhim";
            this.cboPhim.Size = new System.Drawing.Size(300, 33);
            this.cboPhim.TabIndex = 4;
            this.cboPhim.SelectedIndexChanged += new System.EventHandler(this.cboPhim_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "1. Phim:";
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.White;
            this.pnlCenter.Controls.Add(this.flpGhe);
            this.pnlCenter.Controls.Add(this.pnlScreen);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 80);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCenter.Size = new System.Drawing.Size(900, 620);
            this.pnlCenter.TabIndex = 1;
            // 
            // flpGhe
            // 
            this.flpGhe.AutoScroll = true;
            this.flpGhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGhe.Location = new System.Drawing.Point(20, 111);
            this.flpGhe.Name = "flpGhe";
            this.flpGhe.Padding = new System.Windows.Forms.Padding(80, 20, 0, 0);
            this.flpGhe.Size = new System.Drawing.Size(860, 489);
            this.flpGhe.TabIndex = 0;
            // 
            // pnlScreen
            // 
            this.pnlScreen.Controls.Add(this.lblScreenText);
            this.pnlScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScreen.Location = new System.Drawing.Point(20, 20);
            this.pnlScreen.Name = "pnlScreen";
            this.pnlScreen.Size = new System.Drawing.Size(860, 91);
            this.pnlScreen.TabIndex = 1;
            this.pnlScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlScreen_Paint);
            // 
            // lblScreenText
            // 
            this.lblScreenText.AutoSize = true;
            this.lblScreenText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblScreenText.ForeColor = System.Drawing.Color.Gray;
            this.lblScreenText.Location = new System.Drawing.Point(380, 40);
            this.lblScreenText.Name = "lblScreenText";
            this.lblScreenText.Size = new System.Drawing.Size(143, 32);
            this.lblScreenText.TabIndex = 0;
            this.lblScreenText.Text = "MÀN HÌNH";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlRight.Controls.Add(this.btnHuy);
            this.pnlRight.Controls.Add(this.btnThanhToan);
            this.pnlRight.Controls.Add(this.lblTongTien);
            this.pnlRight.Controls.Add(this.label6);
            this.pnlRight.Controls.Add(this.lblGiaVe);
            this.pnlRight.Controls.Add(this.panelNote);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(900, 80);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(300, 620);
            this.pnlRight.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Crimson;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(20, 516);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(260, 60);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy chọn";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(20, 450);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(260, 60);
            this.btnThanhToan.TabIndex = 1;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(20, 340);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(166, 52);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "0 VNĐ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(20, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 40);
            this.label6.TabIndex = 3;
            this.label6.Text = "TỔNG TIỀN:";
            // 
            // lblGiaVe
            // 
            this.lblGiaVe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.lblGiaVe.Location = new System.Drawing.Point(20, 200);
            this.lblGiaVe.Name = "lblGiaVe";
            this.lblGiaVe.Size = new System.Drawing.Size(260, 30);
            this.lblGiaVe.TabIndex = 4;
            this.lblGiaVe.Text = "Giá vé: 0 VNĐ";
            // 
            // panelNote
            // 
            this.panelNote.Controls.Add(this.label9);
            this.panelNote.Controls.Add(this.label8);
            this.panelNote.Controls.Add(this.label7);
            this.panelNote.Controls.Add(this.pBoxSold);
            this.panelNote.Controls.Add(this.pBoxSelected);
            this.panelNote.Controls.Add(this.pBoxEmpty);
            this.panelNote.Location = new System.Drawing.Point(20, 20);
            this.panelNote.Name = "panelNote";
            this.panelNote.Size = new System.Drawing.Size(260, 150);
            this.panelNote.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(50, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Đã bán";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(50, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Đang chọn";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(50, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ghế trống";
            // 
            // pBoxSold
            // 
            this.pBoxSold.BackColor = System.Drawing.Color.Red;
            this.pBoxSold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxSold.Location = new System.Drawing.Point(10, 90);
            this.pBoxSold.Name = "pBoxSold";
            this.pBoxSold.Size = new System.Drawing.Size(30, 30);
            this.pBoxSold.TabIndex = 3;
            this.pBoxSold.TabStop = false;
            // 
            // pBoxSelected
            // 
            this.pBoxSelected.BackColor = System.Drawing.Color.Yellow;
            this.pBoxSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxSelected.Location = new System.Drawing.Point(10, 50);
            this.pBoxSelected.Name = "pBoxSelected";
            this.pBoxSelected.Size = new System.Drawing.Size(30, 30);
            this.pBoxSelected.TabIndex = 4;
            this.pBoxSelected.TabStop = false;
            // 
            // pBoxEmpty
            // 
            this.pBoxEmpty.BackColor = System.Drawing.Color.White;
            this.pBoxEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxEmpty.Location = new System.Drawing.Point(10, 10);
            this.pBoxEmpty.Name = "pBoxEmpty";
            this.pBoxEmpty.Size = new System.Drawing.Size(30, 30);
            this.pBoxEmpty.TabIndex = 5;
            this.pBoxEmpty.TabStop = false;
            // 
            // FormVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Name = "FormVe";
            this.Text = "Bán Vé";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlScreen.ResumeLayout(false);
            this.pnlScreen.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.panelNote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxEmpty)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop, pnlCenter, pnlRight, pnlScreen, panelNote;
        private System.Windows.Forms.FlowLayoutPanel flpGhe;
        private System.Windows.Forms.ComboBox cboPhim, cboNgay, cboGio;
        private System.Windows.Forms.Label label1, label2, label3, lblScreenText, lblGiaVe, label6, lblTongTien, label7, label8, label9;
        private System.Windows.Forms.Button btnThanhToan, btnHuy;
        private System.Windows.Forms.PictureBox pBoxEmpty, pBoxSelected, pBoxSold;
    }
}