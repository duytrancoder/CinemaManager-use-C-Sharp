namespace QuanLyRapPhim
{
    partial class FormMain
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.tblMenuBtn = new System.Windows.Forms.TableLayoutPanel();
            this.btnQuanLyPhim = new System.Windows.Forms.Button();
            this.btnLichChieu = new System.Windows.Forms.Button();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.tblMenuBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnlMenu.Controls.Add(this.tblMenuBtn);
            this.pnlMenu.Controls.Add(this.lblLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1257, 85);
            this.pnlMenu.TabIndex = 0;
            // 
            // tblMenuBtn
            // 
            this.tblMenuBtn.ColumnCount = 3;
            this.tblMenuBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblMenuBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblMenuBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblMenuBtn.Controls.Add(this.btnQuanLyPhim, 0, 0);
            this.tblMenuBtn.Controls.Add(this.btnLichChieu, 1, 0);
            this.tblMenuBtn.Controls.Add(this.btnBanVe, 2, 0);
            this.tblMenuBtn.Location = new System.Drawing.Point(380, 0);
            this.tblMenuBtn.Name = "tblMenuBtn";
            this.tblMenuBtn.RowCount = 1;
            this.tblMenuBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tblMenuBtn.Size = new System.Drawing.Size(541, 85);
            this.tblMenuBtn.TabIndex = 0;
            // 
            // btnQuanLyPhim
            // 
            this.btnQuanLyPhim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuanLyPhim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyPhim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyPhim.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyPhim.Location = new System.Drawing.Point(3, 3);
            this.btnQuanLyPhim.Name = "btnQuanLyPhim";
            this.btnQuanLyPhim.Size = new System.Drawing.Size(174, 79);
            this.btnQuanLyPhim.TabIndex = 0;
            this.btnQuanLyPhim.Text = "PHIM";
            this.btnQuanLyPhim.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // btnLichChieu
            // 
            this.btnLichChieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLichChieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichChieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLichChieu.ForeColor = System.Drawing.Color.White;
            this.btnLichChieu.Location = new System.Drawing.Point(183, 3);
            this.btnLichChieu.Name = "btnLichChieu";
            this.btnLichChieu.Size = new System.Drawing.Size(174, 79);
            this.btnLichChieu.TabIndex = 1;
            this.btnLichChieu.Text = "LỊCH CHIẾU";
            this.btnLichChieu.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // btnBanVe
            // 
            this.btnBanVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBanVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanVe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBanVe.ForeColor = System.Drawing.Color.White;
            this.btnBanVe.Location = new System.Drawing.Point(363, 3);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(175, 79);
            this.btnBanVe.TabIndex = 2;
            this.btnBanVe.Text = "BÁN VÉ";
            this.btnBanVe.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.Gold;
            this.lblLogo.Location = new System.Drawing.Point(10, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(335, 46);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "CINEMA MANAGER";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 85);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1257, 662);
            this.pnlContent.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 747);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vvv";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.tblMenuBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMenu, pnlContent;
        private System.Windows.Forms.TableLayoutPanel tblMenuBtn;
        private System.Windows.Forms.Button btnBanVe, btnLichChieu, btnQuanLyPhim;
        private System.Windows.Forms.Label lblLogo;
    }
}