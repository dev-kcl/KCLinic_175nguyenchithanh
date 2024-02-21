namespace KClinic2._1.View.DanhMuc
{
    partial class NoiDungNhomBenh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoiDungNhomBenh));
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNhomBenh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.cbbDichVu = new Janus.Windows.EditControls.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbNhomBenh = new Janus.Windows.EditControls.UIComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.pnMain.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnThongTin.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.pnContent);
            this.pnMain.Controls.Add(this.panelButton);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1208, 514);
            this.pnMain.TabIndex = 4;
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.pnGrid);
            this.pnContent.Controls.Add(this.pnThongTin);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 105);
            this.pnContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1208, 409);
            this.pnContent.TabIndex = 2;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.gridDichVu);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 194);
            this.pnGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1208, 215);
            this.pnGrid.TabIndex = 16;
            // 
            // gridDichVu
            // 
            this.gridDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDichVu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridDichVu.Location = new System.Drawing.Point(0, 0);
            this.gridDichVu.MainView = this.gridView1;
            this.gridDichVu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridDichVu.Name = "gridDichVu";
            this.gridDichVu.Size = new System.Drawing.Size(1208, 215);
            this.gridDichVu.TabIndex = 27;
            this.gridDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaDichVu,
            this.TenDichVu,
            this.TenNhomBenh,
            this.ID});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridDichVu;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TenNhomBenh, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // MaDichVu
            // 
            this.MaDichVu.Caption = "Mã dịch vụ";
            this.MaDichVu.FieldName = "MaDichVu";
            this.MaDichVu.MinWidth = 27;
            this.MaDichVu.Name = "MaDichVu";
            this.MaDichVu.OptionsColumn.AllowEdit = false;
            this.MaDichVu.Visible = true;
            this.MaDichVu.VisibleIndex = 0;
            this.MaDichVu.Width = 100;
            // 
            // TenDichVu
            // 
            this.TenDichVu.Caption = "Tên dịch vụ";
            this.TenDichVu.FieldName = "TenDichVu";
            this.TenDichVu.MinWidth = 27;
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.OptionsColumn.AllowEdit = false;
            this.TenDichVu.Visible = true;
            this.TenDichVu.VisibleIndex = 1;
            this.TenDichVu.Width = 569;
            // 
            // TenNhomBenh
            // 
            this.TenNhomBenh.Caption = "Tên Nhóm Bệnh";
            this.TenNhomBenh.FieldName = "TenNhomBenh";
            this.TenNhomBenh.MinWidth = 27;
            this.TenNhomBenh.Name = "TenNhomBenh";
            this.TenNhomBenh.OptionsColumn.AllowEdit = false;
            this.TenNhomBenh.Visible = true;
            this.TenNhomBenh.VisibleIndex = 2;
            this.TenNhomBenh.Width = 100;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "MapNhomBenhDichVu_Id";
            this.ID.MinWidth = 27;
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 2;
            this.ID.Width = 100;
            // 
            // pnThongTin
            // 
            this.pnThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(211)))), ((int)(((byte)(144)))));
            this.pnThongTin.Controls.Add(this.cbbDichVu);
            this.pnThongTin.Controls.Add(this.label1);
            this.pnThongTin.Controls.Add(this.cbbNhomBenh);
            this.pnThongTin.Controls.Add(this.label4);
            this.pnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThongTin.Location = new System.Drawing.Point(0, 0);
            this.pnThongTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(1208, 194);
            this.pnThongTin.TabIndex = 15;
            // 
            // cbbDichVu
            // 
            this.cbbDichVu.AutoComplete = false;
            this.cbbDichVu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbDichVu.Location = new System.Drawing.Point(184, 102);
            this.cbbDichVu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbDichVu.Name = "cbbDichVu";
            this.cbbDichVu.Size = new System.Drawing.Size(676, 34);
            this.cbbDichVu.Sorted = true;
            this.cbbDichVu.TabIndex = 43;
            this.cbbDichVu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 28);
            this.label1.TabIndex = 42;
            this.label1.Text = "Dịch Vụ";
            // 
            // cbbNhomBenh
            // 
            this.cbbNhomBenh.AutoComplete = false;
            this.cbbNhomBenh.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbNhomBenh.Location = new System.Drawing.Point(184, 41);
            this.cbbNhomBenh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbNhomBenh.Name = "cbbNhomBenh";
            this.cbbNhomBenh.Size = new System.Drawing.Size(676, 34);
            this.cbbNhomBenh.Sorted = true;
            this.cbbNhomBenh.TabIndex = 41;
            this.cbbNhomBenh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(39, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 28);
            this.label4.TabIndex = 40;
            this.label4.Text = "Nhóm Bệnh";
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnThoat);
            this.panelButton.Controls.Add(this.btnXoa);
            this.panelButton.Controls.Add(this.btnHuy);
            this.panelButton.Controls.Add(this.btnLuu);
            this.panelButton.Controls.Add(this.btnSua);
            this.panelButton.Controls.Add(this.btnThem);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButton.Location = new System.Drawing.Point(0, 0);
            this.panelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1208, 105);
            this.panelButton.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnThoat.Appearance.Options.UseBorderColor = true;
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Appearance.Options.UseForeColor = true;
            this.btnThoat.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnThoat.AppearanceDisabled.Options.UseForeColor = true;
            this.btnThoat.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Location = new System.Drawing.Point(659, 15);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 78);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnXoa.Appearance.Options.UseBorderColor = true;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Appearance.Options.UseForeColor = true;
            this.btnXoa.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnXoa.AppearanceDisabled.Options.UseForeColor = true;
            this.btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Location = new System.Drawing.Point(527, 15);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 78);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnHuy.Appearance.Options.UseBorderColor = true;
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Appearance.Options.UseForeColor = true;
            this.btnHuy.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnHuy.AppearanceDisabled.Options.UseForeColor = true;
            this.btnHuy.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Location = new System.Drawing.Point(397, 15);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 78);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLuu.Appearance.Options.UseBorderColor = true;
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Appearance.Options.UseForeColor = true;
            this.btnLuu.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnLuu.AppearanceDisabled.Options.UseForeColor = true;
            this.btnLuu.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.Location = new System.Drawing.Point(269, 15);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 78);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnSua.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSua.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSua.Appearance.Options.UseBorderColor = true;
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Appearance.Options.UseForeColor = true;
            this.btnSua.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnSua.AppearanceDisabled.Options.UseForeColor = true;
            this.btnSua.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Location = new System.Drawing.Point(144, 15);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 78);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnThem.Appearance.Options.UseBorderColor = true;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnThem.AppearanceDisabled.Options.UseForeColor = true;
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Location = new System.Drawing.Point(16, 15);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 78);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            // NoiDungNhomBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 514);
            this.Controls.Add(this.pnMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NoiDungNhomBenh";
            this.Text = "Danh mục nội dung nhóm bệnh";
            this.Load += new System.EventHandler(this.NoiDungNhomBenh_Load);
            this.pnMain.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Panel pnGrid;
        private System.Windows.Forms.Panel pnThongTin;
        private System.Windows.Forms.Panel panelButton;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn TenDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn TenNhomBenh;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private Janus.Windows.EditControls.UIComboBox cbbDichVu;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIComboBox cbbNhomBenh;
        private System.Windows.Forms.Label label4;
    }
}