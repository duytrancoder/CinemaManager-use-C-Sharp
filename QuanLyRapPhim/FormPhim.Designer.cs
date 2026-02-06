namespace QuanLyRapPhim
{
    partial class FormPhim
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
            this.dgvPhim = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblPhut = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button(); // KHAI BÁO NÚT MỚI
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnChon = new System.Windows.Forms.Button();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.txtDaoDien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTheLoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numThoiLuong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenPhim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaPhim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTopSearch = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnHuyTim = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).BeginInit();
            this.panelInput.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiLuong)).BeginInit();
            this.pnlTopSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPhim
            // 
            this.dgvPhim.AllowUserToAddRows = false;
            this.dgvPhim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhim.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhim.Location = new System.Drawing.Point(450, 60);
            this.dgvPhim.Name = "dgvPhim";
            this.dgvPhim.RowHeadersWidth = 51;
            this.dgvPhim.RowTemplate.Height = 35;
            this.dgvPhim.Size = new System.Drawing.Size(764, 705);
            this.dgvPhim.TabIndex = 1;
            this.dgvPhim.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhim_CellClick);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelInput.Controls.Add(this.groupBoxInfo);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(10);
            this.panelInput.Size = new System.Drawing.Size(450, 765);
            this.panelInput.TabIndex = 0;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.lblPhut);
            this.groupBoxInfo.Controls.Add(this.btnReload);
            this.groupBoxInfo.Controls.Add(this.btnExcel);
            this.groupBoxInfo.Controls.Add(this.btnImport); // THÊM VÀO GROUPBOX
            this.groupBoxInfo.Controls.Add(this.btnXoa);
            this.groupBoxInfo.Controls.Add(this.btnSua);
            this.groupBoxInfo.Controls.Add(this.btnThem);
            this.groupBoxInfo.Controls.Add(this.btnChon);
            this.groupBoxInfo.Controls.Add(this.picPoster);
            this.groupBoxInfo.Controls.Add(this.txtDaoDien);
            this.groupBoxInfo.Controls.Add(this.label5);
            this.groupBoxInfo.Controls.Add(this.txtTheLoai);
            this.groupBoxInfo.Controls.Add(this.label4);
            this.groupBoxInfo.Controls.Add(this.numThoiLuong);
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.txtTenPhim);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.txtMaPhim);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.Location = new System.Drawing.Point(10, 10);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(430, 745);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "THÔNG TIN PHIM";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.BackColor = System.Drawing.Color.Teal;
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(20, 684);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(110, 50);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "XUẤT";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnImport (NÚT NHẬP EXCEL MỚI)
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(145, 684);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 50);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "NHẬP";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnReload (Dời sang bên phải)
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.BackColor = System.Drawing.Color.Gray;
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(270, 684);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(110, 50);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "LÀM MỚI";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);

            // ... (Các control khác giữ nguyên) ...
            this.lblPhut.AutoSize = true; this.lblPhut.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblPhut.Location = new System.Drawing.Point(270, 130); this.lblPhut.Text = "(Phút)";
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnXoa.BackColor = System.Drawing.Color.Crimson; this.btnXoa.ForeColor = System.Drawing.Color.White; this.btnXoa.Location = new System.Drawing.Point(270, 624); this.btnXoa.Size = new System.Drawing.Size(110, 50); this.btnXoa.Text = "XÓA"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnSua.BackColor = System.Drawing.Color.Orange; this.btnSua.ForeColor = System.Drawing.Color.White; this.btnSua.Location = new System.Drawing.Point(145, 624); this.btnSua.Size = new System.Drawing.Size(110, 50); this.btnSua.Text = "SỬA"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))); this.btnThem.BackColor = System.Drawing.Color.ForestGreen; this.btnThem.ForeColor = System.Drawing.Color.White; this.btnThem.Location = new System.Drawing.Point(20, 624); this.btnThem.Size = new System.Drawing.Size(110, 50); this.btnThem.Text = "THÊM"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnChon.Font = new System.Drawing.Font("Segoe UI", 10F); this.btnChon.Location = new System.Drawing.Point(259, 584); this.btnChon.Size = new System.Drawing.Size(101, 34); this.btnChon.Text = "Chọn ảnh"; this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            this.picPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.picPoster.Location = new System.Drawing.Point(99, 270); this.picPoster.Size = new System.Drawing.Size(214, 297); this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.txtDaoDien.Location = new System.Drawing.Point(140, 217); this.txtDaoDien.Size = new System.Drawing.Size(260, 34);
            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(20, 220); this.label5.Text = "Đạo diễn:";
            this.txtTheLoai.Location = new System.Drawing.Point(140, 172); this.txtTheLoai.Size = new System.Drawing.Size(260, 34);
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(20, 175); this.label4.Text = "Thể loại:";
            this.numThoiLuong.Location = new System.Drawing.Point(140, 128); this.numThoiLuong.Maximum = new decimal(new int[] { 500, 0, 0, 0 }); this.numThoiLuong.Size = new System.Drawing.Size(120, 34);
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 130); this.label3.Text = "Thời lượng:";
            this.txtTenPhim.Location = new System.Drawing.Point(140, 82); this.txtTenPhim.Size = new System.Drawing.Size(260, 34);
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 85); this.label2.Text = "Tên Phim:";
            this.txtMaPhim.Location = new System.Drawing.Point(140, 37); this.txtMaPhim.Size = new System.Drawing.Size(260, 34);
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 40); this.label1.Text = "Mã Phim:";

            // pnlTopSearch
            this.pnlTopSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTopSearch.Controls.Add(this.btnHuyTim);
            this.pnlTopSearch.Controls.Add(this.btnTim);
            this.pnlTopSearch.Controls.Add(this.txtTimKiem);
            this.pnlTopSearch.Controls.Add(this.labelSearch);
            this.pnlTopSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSearch.Location = new System.Drawing.Point(450, 0);
            this.pnlTopSearch.Name = "pnlTopSearch";
            this.pnlTopSearch.Size = new System.Drawing.Size(764, 60);
            this.pnlTopSearch.TabIndex = 2;
            this.labelSearch.AutoSize = true; this.labelSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.labelSearch.Location = new System.Drawing.Point(20, 15); this.labelSearch.Text = "Tìm kiếm:";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F); this.txtTimKiem.Location = new System.Drawing.Point(120, 12); this.txtTimKiem.Size = new System.Drawing.Size(300, 34);
            this.btnTim.BackColor = System.Drawing.Color.SteelBlue; this.btnTim.ForeColor = System.Drawing.Color.White; this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.btnTim.Location = new System.Drawing.Point(440, 10); this.btnTim.Size = new System.Drawing.Size(100, 38); this.btnTim.Text = "TÌM"; this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            this.btnHuyTim.BackColor = System.Drawing.Color.Gray; this.btnHuyTim.ForeColor = System.Drawing.Color.White; this.btnHuyTim.Font = new System.Drawing.Font("Segoe UI", 10F); this.btnHuyTim.Location = new System.Drawing.Point(550, 10); this.btnHuyTim.Size = new System.Drawing.Size(80, 38); this.btnHuyTim.Text = "Hủy"; this.btnHuyTim.Click += new System.EventHandler(this.btnHuyTim_Click);

            // FormPhim
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 765);
            this.Controls.Add(this.dgvPhim);
            this.Controls.Add(this.pnlTopSearch);
            this.Controls.Add(this.panelInput);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Name = "FormPhim";
            this.Text = "Quản lý phim";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiLuong)).EndInit();
            this.pnlTopSearch.ResumeLayout(false);
            this.pnlTopSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        // ... Các biến khác
        private System.Windows.Forms.DataGridView dgvPhim;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Button btnImport; // Nút mới
        private System.Windows.Forms.Button btnChon, btnThem, btnSua, btnXoa, btnExcel, btnReload;
        private System.Windows.Forms.Label lblPhut, label1, label2, label3, label4, label5, labelSearch;
        private System.Windows.Forms.TextBox txtMaPhim, txtTenPhim, txtTheLoai, txtDaoDien, txtTimKiem;
        private System.Windows.Forms.NumericUpDown numThoiLuong;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Panel pnlTopSearch;
        private System.Windows.Forms.Button btnTim, btnHuyTim;
    }
}