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
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLich = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
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
            // --- KHAI BÁO MỚI CHO TÌM KIẾM ---
            this.pnlTopSearch = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnHuyTim = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLich)).BeginInit();
            this.panelInput.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.pnlTopSearch.SuspendLayout(); // Init panel
            this.SuspendLayout();

            // 
            // pnlTopSearch (THANH TÌM KIẾM)
            // 
            this.pnlTopSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTopSearch.Controls.Add(this.btnHuyTim);
            this.pnlTopSearch.Controls.Add(this.btnTim);
            this.pnlTopSearch.Controls.Add(this.txtTimKiem);
            this.pnlTopSearch.Controls.Add(this.labelSearch);
            this.pnlTopSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSearch.Location = new System.Drawing.Point(450, 0); // Vị trí logic
            this.pnlTopSearch.Name = "pnlTopSearch";
            this.pnlTopSearch.Size = new System.Drawing.Size(803, 60);
            this.pnlTopSearch.TabIndex = 2;

            // Label "Tìm kiếm"
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelSearch.Location = new System.Drawing.Point(20, 15);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Text = "Tìm kiếm:";

            // txtTimKiem
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(120, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 34);
            this.txtTimKiem.TabIndex = 0;

            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTim.Location = new System.Drawing.Point(440, 10);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 38);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "TÌM";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);

            // btnHuyTim
            // 
            this.btnHuyTim.BackColor = System.Drawing.Color.Gray;
            this.btnHuyTim.ForeColor = System.Drawing.Color.White;
            this.btnHuyTim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuyTim.Location = new System.Drawing.Point(550, 10);
            this.btnHuyTim.Name = "btnHuyTim";
            this.btnHuyTim.Size = new System.Drawing.Size(80, 38);
            this.btnHuyTim.TabIndex = 2;
            this.btnHuyTim.Text = "Hủy";
            this.btnHuyTim.UseVisualStyleBackColor = false;
            this.btnHuyTim.Click += new System.EventHandler(this.btnHuyTim_Click);

            // 
            // dgvLich
            // 
            this.dgvLich.AllowUserToAddRows = false;
            this.dgvLich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLich.BackgroundColor = System.Drawing.Color.White;
            this.dgvLich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLich.Location = new System.Drawing.Point(450, 60); // Né thanh tìm kiếm
            this.dgvLich.Name = "dgvLich";
            this.dgvLich.RowHeadersWidth = 51;
            this.dgvLich.RowTemplate.Height = 35;
            this.dgvLich.Size = new System.Drawing.Size(803, 684);
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
            this.groupBoxInfo.Controls.Add(this.btnExcel);
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

            // ... (Các controls con giữ nguyên như code cũ) ...
            this.picPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.picPoster.Location = new System.Drawing.Point(94, 271); this.picPoster.Size = new System.Drawing.Size(215, 299); this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage; this.picPoster.TabStop = false;
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnReload.BackColor = System.Drawing.Color.Gray; this.btnReload.ForeColor = System.Drawing.Color.White; this.btnReload.Location = new System.Drawing.Point(145, 663); this.btnReload.Size = new System.Drawing.Size(110, 50); this.btnReload.Text = "LÀM MỚI"; this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnExcel.BackColor = System.Drawing.Color.Teal; this.btnExcel.ForeColor = System.Drawing.Color.White; this.btnExcel.Location = new System.Drawing.Point(20, 663); this.btnExcel.Size = new System.Drawing.Size(110, 50); this.btnExcel.Text = "EXCEL"; this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnXoa.BackColor = System.Drawing.Color.Crimson; this.btnXoa.ForeColor = System.Drawing.Color.White; this.btnXoa.Location = new System.Drawing.Point(270, 603); this.btnXoa.Size = new System.Drawing.Size(110, 50); this.btnXoa.Text = "XÓA"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnSua.BackColor = System.Drawing.Color.Orange; this.btnSua.ForeColor = System.Drawing.Color.White; this.btnSua.Location = new System.Drawing.Point(145, 603); this.btnSua.Size = new System.Drawing.Size(110, 50); this.btnSua.Text = "SỬA"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnThem.BackColor = System.Drawing.Color.ForestGreen; this.btnThem.ForeColor = System.Drawing.Color.White; this.btnThem.Location = new System.Drawing.Point(20, 603); this.btnThem.Size = new System.Drawing.Size(110, 50); this.btnThem.Text = "THÊM"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThemPhong.Location = new System.Drawing.Point(360, 172); this.btnThemPhong.Size = new System.Drawing.Size(40, 29); this.btnThemPhong.Text = "+"; this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(20, 210); this.label6.Text = "Giá vé:";
            this.txtGiaVe.Location = new System.Drawing.Point(140, 207); this.txtGiaVe.Size = new System.Drawing.Size(180, 34);
            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(20, 175); this.label5.Text = "Phòng:";
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboPhong.Location = new System.Drawing.Point(140, 172); this.cboPhong.Size = new System.Drawing.Size(210, 36);
            this.dtpGio.Format = System.Windows.Forms.DateTimePickerFormat.Time; this.dtpGio.Location = new System.Drawing.Point(140, 137); this.dtpGio.ShowUpDown = true; this.dtpGio.Size = new System.Drawing.Size(260, 34);
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(20, 140); this.label4.Text = "Giờ chiếu:";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNgay.Location = new System.Drawing.Point(140, 102); this.dtpNgay.Size = new System.Drawing.Size(260, 34);
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 105); this.label3.Text = "Ngày chiếu:";
            this.cboPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboPhim.Location = new System.Drawing.Point(140, 67); this.cboPhim.Size = new System.Drawing.Size(260, 36); this.cboPhim.SelectedIndexChanged += new System.EventHandler(this.cboPhim_SelectedIndexChanged);
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 70); this.label2.Text = "Chọn Phim:";
            this.txtMaLich.Location = new System.Drawing.Point(140, 32); this.txtMaLich.Size = new System.Drawing.Size(260, 34);
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 35); this.label1.Text = "Mã Lịch:";
            this.lblVND.AutoSize = true; this.lblVND.Location = new System.Drawing.Point(330, 210); this.lblVND.Text = "(VNĐ)";

            // 
            // FormLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 744);
            // THỨ TỰ ADD CONTROLS QUAN TRỌNG
            this.Controls.Add(this.dgvLich); // Fill
            this.Controls.Add(this.pnlTopSearch); // Top
            this.Controls.Add(this.panelInput); // Left
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Name = "FormLich";
            this.Text = "Quản lý lịch chiếu";
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
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnExcel, btnReload, btnThemPhong;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, lblVND;

        // CÁC CONTROL MỚI
        private System.Windows.Forms.Panel pnlTopSearch;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim, btnHuyTim;
        private System.Windows.Forms.Label labelSearch;
    }
}