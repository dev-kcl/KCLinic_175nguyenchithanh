namespace KClinic2._1.View.HeThongBaoCao
{
    partial class HeThongBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeThongBaoCao));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelView = new System.Windows.Forms.Panel();
            this.gridDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProcedureBaoCao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTenBaoCao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMaBaoCao = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.treeViewBC = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelMain.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1002, 826);
            this.panelMain.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelView);
            this.panelRight.Controls.Add(this.panelTop);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(270, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(687, 826);
            this.panelRight.TabIndex = 19;
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.gridDanhSach);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 266);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(687, 499);
            this.panelView.TabIndex = 1;
            // 
            // gridDanhSach
            // 
            this.gridDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDanhSach.Location = new System.Drawing.Point(6, 6);
            this.gridDanhSach.MainView = this.gridView1;
            this.gridDanhSach.Name = "gridDanhSach";
            this.gridDanhSach.Size = new System.Drawing.Size(677, 477);
            this.gridDanhSach.TabIndex = 0;
            this.gridDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            //
            this.gridView1.GridControl = this.gridDanhSach;
            this.gridView1.Name = "gridView1";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnExel);
            this.panelTop.Controls.Add(this.simpleButton1);
            this.panelTop.Controls.Add(this.btnThem);
            this.panelTop.Controls.Add(this.flowLayoutPanel1);
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(687, 327);
            this.panelTop.TabIndex = 0;
            // 
            // btnExel
            // 
            this.btnExel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnExel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExel.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExel.Appearance.Options.UseBorderColor = true;
            this.btnExel.Appearance.Options.UseFont = true;
            this.btnExel.Appearance.Options.UseForeColor = true;
            this.btnExel.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnExel.AppearanceDisabled.Options.UseForeColor = true;
            this.btnExel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExel.ImageOptions.Image")));
            this.btnExel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnExel.Location = new System.Drawing.Point(575, 15);
            this.btnExel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExel.Name = "btnExel";
            this.btnExel.Size = new System.Drawing.Size(84, 78);
            this.btnExel.TabIndex = 18;
            this.btnExel.Text = "Xuất Exel";
            this.btnExel.Click += new System.EventHandler(this.btnExel_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.simpleButton1.AppearanceDisabled.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(451, 15);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(84, 78);
            this.simpleButton1.TabIndex = 17;
            this.simpleButton1.Text = "In báo cáo";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnThem.Appearance.Options.UseBorderColor = true;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnThem.AppearanceDisabled.Options.UseForeColor = true;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnThem.Location = new System.Drawing.Point(326, 15);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 78);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Xem báo cáo";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightCyan;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 96);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(677, 202);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblProcedureBaoCao);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblTenBaoCao);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblMaBaoCao);
            this.panel2.Location = new System.Drawing.Point(6, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 96);
            this.panel2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Báo Cáo";
            // 
            // lblProcedureBaoCao
            // 
            this.lblProcedureBaoCao.AutoSize = true;
            this.lblProcedureBaoCao.Location = new System.Drawing.Point(89, 53);
            this.lblProcedureBaoCao.Name = "lblProcedureBaoCao";
            this.lblProcedureBaoCao.Size = new System.Drawing.Size(35, 13);
            this.lblProcedureBaoCao.TabIndex = 6;
            this.lblProcedureBaoCao.Text = "label6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Báo Cáo";
            // 
            // lblTenBaoCao
            // 
            this.lblTenBaoCao.AutoSize = true;
            this.lblTenBaoCao.Location = new System.Drawing.Point(89, 29);
            this.lblTenBaoCao.Name = "lblTenBaoCao";
            this.lblTenBaoCao.Size = new System.Drawing.Size(35, 13);
            this.lblTenBaoCao.TabIndex = 5;
            this.lblTenBaoCao.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Procedure";
            // 
            // lblMaBaoCao
            // 
            this.lblMaBaoCao.AutoSize = true;
            this.lblMaBaoCao.Location = new System.Drawing.Point(89, 7);
            this.lblMaBaoCao.Name = "lblMaBaoCao";
            this.lblMaBaoCao.Size = new System.Drawing.Size(35, 13);
            this.lblMaBaoCao.TabIndex = 4;
            this.lblMaBaoCao.Text = "label4";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.treeViewBC);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(270, 671);
            this.panelLeft.TabIndex = 18;
            // 
            // treeViewBC
            // 
            this.treeViewBC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewBC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.treeViewBC.ImageIndex = 0;
            this.treeViewBC.ImageList = this.imageList1;
            this.treeViewBC.Location = new System.Drawing.Point(3, 12);
            this.treeViewBC.Name = "treeViewBC";
            this.treeViewBC.SelectedImageIndex = 0;
            this.treeViewBC.Size = new System.Drawing.Size(260, 647);
            this.treeViewBC.TabIndex = 19;
            this.treeViewBC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBC_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ImageReport.png");
            // 
            // SaveFileDialog
            //
            this.SaveFileDialog.DefaultExt = "xlsx";
            this.SaveFileDialog.Filter = "Microsoft Excel Worksheet|*.xlsx";
            //
            // HeThongBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 826);
            this.Controls.Add(this.panelMain);
            this.Name = "HeThongBaoCao";
            this.Text = "Hệ thống báo cáo";
            this.Load += new System.EventHandler(this.HeThongBaoCao_Load);
            this.panelMain.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProcedureBaoCao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenBaoCao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMaBaoCao;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelView;
        private DevExpress.XtraGrid.GridControl gridDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TreeView treeViewBC;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnExel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
    }
}