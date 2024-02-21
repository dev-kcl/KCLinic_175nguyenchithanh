namespace KClinic2._1.View.XetNghiem
{
    partial class ImportXetNghiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportXetNghiem));
            this.openFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.txtTenBenhNhan = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_S = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaYTe = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.btnChonAnh = new DevExpress.XtraEditors.SimpleButton();
            this.lbTenFile = new System.Windows.Forms.Label();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1201, 500);
            this.panel1.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pdfViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(429, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 500);
            this.panel3.TabIndex = 21;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(772, 500);
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 500);
            this.panel2.TabIndex = 20;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.txtTenBenhNhan);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btn_S);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.txtMaYTe);
            this.panelMain.Controls.Add(this.btnUpload);
            this.panelMain.Controls.Add(this.btnChonAnh);
            this.panelMain.Controls.Add(this.lbTenFile);
            this.panelMain.Location = new System.Drawing.Point(32, 48);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(357, 436);
            this.panelMain.TabIndex = 19;
            // 
            // txtTenBenhNhan
            // 
            this.txtTenBenhNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTenBenhNhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.txtTenBenhNhan.BorderThickness = 2;
            this.txtTenBenhNhan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBenhNhan.DefaultText = "";
            this.txtTenBenhNhan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenBenhNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenBenhNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenBenhNhan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenBenhNhan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenBenhNhan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenBenhNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtTenBenhNhan.Location = new System.Drawing.Point(9, 118);
            this.txtTenBenhNhan.Margin = new System.Windows.Forms.Padding(5);
            this.txtTenBenhNhan.Name = "txtTenBenhNhan";
            this.txtTenBenhNhan.PasswordChar = '\0';
            this.txtTenBenhNhan.PlaceholderText = "";
            this.txtTenBenhNhan.SelectedText = "";
            this.txtTenBenhNhan.Size = new System.Drawing.Size(264, 36);
            this.txtTenBenhNhan.TabIndex = 34;
            this.txtTenBenhNhan.TabStop = false;
            this.txtTenBenhNhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(4, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 33;
            this.label1.Text = "Tên bệnh nhân";
            // 
            // btn_S
            // 
            this.btn_S.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_S.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btn_S.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_S.Appearance.Options.UseBorderColor = true;
            this.btn_S.Appearance.Options.UseFont = true;
            this.btn_S.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_S.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_S.ImageOptions.SvgImage")));
            this.btn_S.Location = new System.Drawing.Point(289, 46);
            this.btn_S.Margin = new System.Windows.Forms.Padding(4);
            this.btn_S.Name = "btn_S";
            this.btn_S.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_S.Size = new System.Drawing.Size(61, 37);
            this.btn_S.TabIndex = 32;
            this.btn_S.Click += new System.EventHandler(this.btn_S_Click);
            this.btn_S.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(4, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 28);
            this.label5.TabIndex = 31;
            this.label5.Text = "Mã y tế";
            // 
            // txtMaYTe
            // 
            this.txtMaYTe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaYTe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.txtMaYTe.BorderThickness = 2;
            this.txtMaYTe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaYTe.DefaultText = "";
            this.txtMaYTe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaYTe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaYTe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaYTe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaYTe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaYTe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaYTe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtMaYTe.Location = new System.Drawing.Point(9, 47);
            this.txtMaYTe.Margin = new System.Windows.Forms.Padding(5);
            this.txtMaYTe.Name = "txtMaYTe";
            this.txtMaYTe.PasswordChar = '\0';
            this.txtMaYTe.PlaceholderText = "";
            this.txtMaYTe.SelectedText = "";
            this.txtMaYTe.Size = new System.Drawing.Size(264, 36);
            this.txtMaYTe.TabIndex = 30;
            this.txtMaYTe.TabStop = false;
            this.txtMaYTe.TextChanged += new System.EventHandler(this.txtSoTiepNhan_TextChanged);
            this.txtMaYTe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpload.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnUpload.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnUpload.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnUpload.Appearance.Options.UseBorderColor = true;
            this.btnUpload.Appearance.Options.UseFont = true;
            this.btnUpload.Appearance.Options.UseForeColor = true;
            this.btnUpload.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnUpload.AppearanceDisabled.Options.UseForeColor = true;
            this.btnUpload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.ImageOptions.Image")));
            this.btnUpload.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUpload.Location = new System.Drawing.Point(64, 358);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(209, 59);
            this.btnUpload.TabIndex = 24;
            this.btnUpload.Text = "UPLOAD";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            this.btnUpload.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnChonAnh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnChonAnh.Appearance.Options.UseBorderColor = true;
            this.btnChonAnh.Appearance.Options.UseFont = true;
            this.btnChonAnh.Appearance.Options.UseForeColor = true;
            this.btnChonAnh.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnChonAnh.AppearanceDisabled.Options.UseForeColor = true;
            this.btnChonAnh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChonAnh.ImageOptions.Image")));
            this.btnChonAnh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnChonAnh.Location = new System.Drawing.Point(9, 187);
            this.btnChonAnh.Margin = new System.Windows.Forms.Padding(4);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(341, 38);
            this.btnChonAnh.TabIndex = 23;
            this.btnChonAnh.Text = "Chọn file ...";
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            this.btnChonAnh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // lbTenFile
            // 
            this.lbTenFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenFile.ForeColor = System.Drawing.Color.Black;
            this.lbTenFile.Location = new System.Drawing.Point(13, 240);
            this.lbTenFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenFile.Name = "lbTenFile";
            this.lbTenFile.Size = new System.Drawing.Size(337, 82);
            this.lbTenFile.TabIndex = 12;
            // 
            // alertControl1
            // 
            this.alertControl1.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.alertControl1.AppearanceCaption.Options.UseFont = true;
            this.alertControl1.AppearanceText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.alertControl1.AppearanceText.Options.UseFont = true;
            this.alertControl1.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideVertical;
            this.alertControl1.ShowPinButton = false;
            // 
            // ImportXetNghiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 500);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImportXetNghiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportXetNghiem";
            this.Load += new System.EventHandler(this.ImportXetNghiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.XtraOpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMain;
        private DevExpress.XtraEditors.SimpleButton btnChonAnh;
        private System.Windows.Forms.Label lbTenFile;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.SimpleButton btn_S;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtMaYTe;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBenhNhan;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
    }
}