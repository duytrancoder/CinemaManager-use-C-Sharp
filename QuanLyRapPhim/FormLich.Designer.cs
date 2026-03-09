namespace QuanLyRapPhim
{
    partial class FormLich
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
            this.dgvLich = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnXuatEx = new System.Windows.Forms.Button();
            this.btnNhapEx = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiaVe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.dtpGio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPhim = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLich = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVND = new System.Windows.Forms.Label();
            this.pnlTopSearch = new System.Windows.Forms.Panel();
            this.btnHuyTim = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLoaiTimKiem = new System.Windows.Forms.ComboBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.chkLocNgay = new System.Windows.Forms.CheckBox();
            this.dtpLocNgay = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLich)).BeginInit();
            this.panelInput.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.pnlTopSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLich
            // 
            this.dgvLich.AllowUserToAddRows = false;
            this.dgvLich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLich.BackgroundColor = System.Drawing.Color.White;
            this.dgvLich.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLich.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLich.Location = new System.Drawing.Point(450, 100);
            this.dgvLich.Name = "dgvLich";
            this.dgvLich.RowHeadersWidth = 51;
            this.dgvLich.RowTemplate.Height = 35;
            this.dgvLich.Size = new System.Drawing.Size(803, 644);
            this.dgvLich.TabIndex = 1;
            this.dgvLich.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLich_CellClick);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelInput.Controls.Add(this.groupBoxInfo);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(10);
            this.panelInput.Size = new System.Drawing.Size(450, 744);
            this.panelInput.TabIndex = 0;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.picPoster);
            this.groupBoxInfo.Controls.Add(this.btnReload);
            this.groupBoxInfo.Controls.Add(this.btnNhapEx);
            this.groupBoxInfo.Controls.Add(this.btnXuatEx);
            this.groupBoxInfo.Controls.Add(this.btnXoa);
            this.groupBoxInfo.Controls.Add(this.btnSua);
            this.groupBoxInfo.Controls.Add(this.btnThem);
            this.groupBoxInfo.Controls.Add(this.btnThemPhong);
            this.groupBoxInfo.Controls.Add(this.label6);
            this.groupBoxInfo.Controls.Add(this.txtGiaVe);
            this.groupBoxInfo.Controls.Add(this.label5);
            this.groupBoxInfo.Controls.Add(this.cboPhong);
            this.groupBoxInfo.Controls.Add(this.dtpGio);
            this.groupBoxInfo.Controls.Add(this.label4);
            this.groupBoxInfo.Controls.Add(this.dtpNgay);
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.cboPhim);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.txtMaLich);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Controls.Add(this.lblVND);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(430, 724);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "THÔNG TIN LỊCH CHIẾU";
            // 
            // picPoster
            // 
            this.picPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPoster.Location = new System.Drawing.Point(100, 260);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(215, 299);
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPoster.TabIndex = 0;
            this.picPoster.TabStop = false;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(270, 663);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(110, 50);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "LÀM MỚI";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnXuatEx
            // 
            this.btnXuatEx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnXuatEx.FlatAppearance.BorderSize = 0;
            this.btnXuatEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatEx.ForeColor = System.Drawing.Color.White;
            this.btnXuatEx.Location = new System.Drawing.Point(20, 663);
            this.btnXuatEx.Name = "btnXuatEx";
            this.btnXuatEx.Size = new System.Drawing.Size(110, 50);
            this.btnXuatEx.TabIndex = 2;
            this.btnXuatEx.Text = "XUẤT EX";
            this.btnXuatEx.UseVisualStyleBackColor = false;
            this.btnXuatEx.Click += new System.EventHandler(this.btnXuatEx_Click);
            // 
            // btnNhapEx
            // 
            this.btnNhapEx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnNhapEx.FlatAppearance.BorderSize = 0;
            this.btnNhapEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapEx.ForeColor = System.Drawing.Color.White;
            this.btnNhapEx.Location = new System.Drawing.Point(145, 663);
            this.btnNhapEx.Name = "btnNhapEx";
            this.btnNhapEx.Size = new System.Drawing.Size(110, 50);
            this.btnNhapEx.TabIndex = 20;
            this.btnNhapEx.Text = "NHẬP EX";
            this.btnNhapEx.UseVisualStyleBackColor = false;
            this.btnNhapEx.Click += new System.EventHandler(this.btnNhapEx_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(270, 603);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 50);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(145, 603);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 50);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 603);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 50);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnThemPhong.FlatAppearance.BorderSize = 0;
            this.btnThemPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemPhong.ForeColor = System.Drawing.Color.White;
            this.btnThemPhong.Location = new System.Drawing.Point(360, 172);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(40, 36);
            this.btnThemPhong.TabIndex = 6;
            this.btnThemPhong.Text = "+";
            this.btnThemPhong.UseVisualStyleBackColor = false;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 28);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giá vé:";
            // 
            // txtGiaVe
            // 
            this.txtGiaVe.Location = new System.Drawing.Point(140, 207);
            this.txtGiaVe.Name = "txtGiaVe";
            this.txtGiaVe.Size = new System.Drawing.Size(180, 34);
            this.txtGiaVe.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phòng:";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.Location = new System.Drawing.Point(140, 172);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(210, 36);
            this.cboPhong.TabIndex = 10;
            // 
            // dtpGio
            // 
            this.dtpGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGio.CustomFormat = "HH:mm";
            this.dtpGio.Location = new System.Drawing.Point(140, 137);
            this.dtpGio.Name = "dtpGio";
            this.dtpGio.ShowUpDown = true;
            this.dtpGio.Size = new System.Drawing.Size(260, 34);
            this.dtpGio.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Giờ chiếu:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Location = new System.Drawing.Point(140, 102);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(260, 34);
            this.dtpNgay.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ngày chiếu:";
            // 
            // cboPhim
            // 
            this.cboPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhim.Location = new System.Drawing.Point(140, 67);
            this.cboPhim.Name = "cboPhim";
            this.cboPhim.Size = new System.Drawing.Size(260, 36);
            this.cboPhim.TabIndex = 15;
            this.cboPhim.SelectedIndexChanged += new System.EventHandler(this.cboPhim_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Chọn Phim:";
            // 
            // txtMaLich
            // 
            this.txtMaLich.Location = new System.Drawing.Point(140, 32);
            this.txtMaLich.Name = "txtMaLich";
            this.txtMaLich.Size = new System.Drawing.Size(260, 34);
            this.txtMaLich.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã Lịch:";
            // 
            // lblVND
            // 
            this.lblVND.AutoSize = true;
            this.lblVND.Location = new System.Drawing.Point(330, 210);
            this.lblVND.Name = "lblVND";
            this.lblVND.Size = new System.Drawing.Size(73, 28);
            this.lblVND.TabIndex = 19;
            this.lblVND.Text = "(VNĐ)";
            // 
            // pnlTopSearch
            // 
            this.pnlTopSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTopSearch.Controls.Add(this.chkLocNgay);
            this.pnlTopSearch.Controls.Add(this.dtpLocNgay);
            this.pnlTopSearch.Controls.Add(this.btnHuyTim);
            this.pnlTopSearch.Controls.Add(this.btnTim);
            this.pnlTopSearch.Controls.Add(this.txtTimKiem);
            this.pnlTopSearch.Controls.Add(this.cboLoaiTimKiem);
            this.pnlTopSearch.Controls.Add(this.labelSearch);
            this.pnlTopSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSearch.Location = new System.Drawing.Point(450, 0);
            this.pnlTopSearch.Name = "pnlTopSearch";
            this.pnlTopSearch.Size = new System.Drawing.Size(803, 100);
            this.pnlTopSearch.TabIndex = 2;
            // 
            // btnHuyTim
            // 
            this.btnHuyTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnHuyTim.FlatAppearance.BorderSize = 0;
            this.btnHuyTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuyTim.ForeColor = System.Drawing.Color.White;
            this.btnHuyTim.Location = new System.Drawing.Point(630, 10);
            this.btnHuyTim.Name = "btnHuyTim";
            this.btnHuyTim.Size = new System.Drawing.Size(80, 38);
            this.btnHuyTim.TabIndex = 2;
            this.btnHuyTim.Text = "HỦY";
            this.btnHuyTim.UseVisualStyleBackColor = false;
            this.btnHuyTim.Click += new System.EventHandler(this.btnHuyTim_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(520, 10);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 38);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "TÌM";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(260, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 34);
            this.txtTimKiem.TabIndex = 0;
            // 
            // cboLoaiTimKiem
            // 
            this.cboLoaiTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboLoaiTimKiem.Items.AddRange(new object[] {
            "Tất cả",
            "Mã Lịch",
            "Tên Phim",
            "Phòng chiếu"});
            this.cboLoaiTimKiem.Location = new System.Drawing.Point(120, 14);
            this.cboLoaiTimKiem.Name = "cboLoaiTimKiem";
            this.cboLoaiTimKiem.Size = new System.Drawing.Size(130, 33);
            this.cboLoaiTimKiem.TabIndex = 4;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelSearch.Location = new System.Drawing.Point(20, 15);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Text = "Tìm kiếm:";
            // 
            // chkLocNgay
            // 
            this.chkLocNgay.AutoSize = true;
            this.chkLocNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.chkLocNgay.Location = new System.Drawing.Point(24, 55);
            this.chkLocNgay.Name = "chkLocNgay";
            this.chkLocNgay.Text = "Lọc theo ngày:";
            this.chkLocNgay.UseVisualStyleBackColor = true;
            // 
            // dtpLocNgay
            // 
            this.dtpLocNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLocNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpLocNgay.Location = new System.Drawing.Point(190, 52);
            this.dtpLocNgay.Name = "dtpLocNgay";
            this.dtpLocNgay.Size = new System.Drawing.Size(160, 34);
            this.dtpLocNgay.TabIndex = 5;
            // 
            // FormLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 744);
            this.Controls.Add(this.dgvLich);
            this.Controls.Add(this.pnlTopSearch);
            this.Controls.Add(this.panelInput);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Name = "FormLich";
            this.Text = "Quản lý lịch chiếu";
            this.Load += new System.EventHandler(this.FormLich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLich)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.pnlTopSearch.ResumeLayout(false);
            this.pnlTopSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dgvLich;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.TextBox txtMaLich, txtGiaVe;
        private System.Windows.Forms.ComboBox cboPhim, cboPhong;
        private System.Windows.Forms.DateTimePicker dtpNgay, dtpGio;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnReload, btnThemPhong;
        private System.Windows.Forms.Button btnXuatEx, btnNhapEx;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, lblVND;
        private System.Windows.Forms.Panel pnlTopSearch;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim, btnHuyTim;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.ComboBox cboLoaiTimKiem;
        private System.Windows.Forms.CheckBox chkLocNgay;
        private System.Windows.Forms.DateTimePicker dtpLocNgay;
    }
}