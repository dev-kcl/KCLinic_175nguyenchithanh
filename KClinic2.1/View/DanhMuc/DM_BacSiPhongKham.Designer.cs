namespace KClinic2._1.View.DanhMuc
{
    partial class DM_BacSiPhongKham
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
            Janus.Windows.GridEX.GridEXLayout cbbPhongKham_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DM_BacSiPhongKham));
            Janus.Windows.GridEX.GridEXLayout cbbBacSi_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cbbUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBacSi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MapKhamBenh_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.cbbPhongKham = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbBacSi = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbUser = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.label3 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.cbbPhongKham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbBacSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUser)).BeginInit();
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
            this.pnMain.Size = new System.Drawing.Size(1037, 482);
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
            this.pnContent.Size = new System.Drawing.Size(1037, 377);
            this.pnContent.TabIndex = 2;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.gridDichVu);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 254);
            this.pnGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1037, 123);
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
            this.gridDichVu.Size = new System.Drawing.Size(1037, 123);
            this.gridDichVu.TabIndex = 26;
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
            this.UserName,
            this.TenPhongBan,
            this.TenBacSi,
            this.MapKhamBenh_Id});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridDichVu;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // UserName
            // 
            this.UserName.Caption = "UserName";
            this.UserName.FieldName = "UserName";
            this.UserName.MinWidth = 27;
            this.UserName.Name = "UserName";
            this.UserName.OptionsColumn.AllowEdit = false;
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 0;
            this.UserName.Width = 100;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.Caption = "Tên phòng khám";
            this.TenPhongBan.FieldName = "TenPhongBan";
            this.TenPhongBan.MinWidth = 27;
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.OptionsColumn.AllowEdit = false;
            this.TenPhongBan.Visible = true;
            this.TenPhongBan.VisibleIndex = 1;
            this.TenPhongBan.Width = 569;
            // 
            // TenBacSi
            // 
            this.TenBacSi.Caption = "Tên bác sĩ";
            this.TenBacSi.FieldName = "TenBacSi";
            this.TenBacSi.MinWidth = 27;
            this.TenBacSi.Name = "TenBacSi";
            this.TenBacSi.OptionsColumn.AllowEdit = false;
            this.TenBacSi.Visible = true;
            this.TenBacSi.VisibleIndex = 2;
            this.TenBacSi.Width = 100;
            // 
            // MapKhamBenh_Id
            // 
            this.MapKhamBenh_Id.Caption = "ID";
            this.MapKhamBenh_Id.FieldName = "MapKhamBenh_Id";
            this.MapKhamBenh_Id.MinWidth = 27;
            this.MapKhamBenh_Id.Name = "MapKhamBenh_Id";
            this.MapKhamBenh_Id.OptionsColumn.AllowEdit = false;
            this.MapKhamBenh_Id.Width = 100;
            // 
            // pnThongTin
            // 
            this.pnThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(211)))), ((int)(((byte)(144)))));
            this.pnThongTin.Controls.Add(this.cbbPhongKham);
            this.pnThongTin.Controls.Add(this.label2);
            this.pnThongTin.Controls.Add(this.cbbBacSi);
            this.pnThongTin.Controls.Add(this.label1);
            this.pnThongTin.Controls.Add(this.cbbUser);
            this.pnThongTin.Controls.Add(this.label3);
            this.pnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThongTin.Location = new System.Drawing.Point(0, 0);
            this.pnThongTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(1037, 254);
            this.pnThongTin.TabIndex = 15;
            // 
            // cbbPhongKham
            // 
            cbbPhongKham_DesignTimeLayout.LayoutString = resources.GetString("cbbPhongKham_DesignTimeLayout.LayoutString");
            this.cbbPhongKham.DesignTimeLayout = cbbPhongKham_DesignTimeLayout;
            this.cbbPhongKham.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbPhongKham.Location = new System.Drawing.Point(200, 161);
            this.cbbPhongKham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbPhongKham.Name = "cbbPhongKham";
            this.cbbPhongKham.SelectedIndex = -1;
            this.cbbPhongKham.SelectedItem = null;
            this.cbbPhongKham.Size = new System.Drawing.Size(297, 34);
            this.cbbPhongKham.TabIndex = 62;
            this.cbbPhongKham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(37, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 28);
            this.label2.TabIndex = 61;
            this.label2.Text = "Phòng khám";
            // 
            // cbbBacSi
            // 
            cbbBacSi_DesignTimeLayout.LayoutString = resources.GetString("cbbBacSi_DesignTimeLayout.LayoutString");
            this.cbbBacSi.DesignTimeLayout = cbbBacSi_DesignTimeLayout;
            this.cbbBacSi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbBacSi.Location = new System.Drawing.Point(200, 101);
            this.cbbBacSi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbBacSi.Name = "cbbBacSi";
            this.cbbBacSi.SelectedIndex = -1;
            this.cbbBacSi.SelectedItem = null;
            this.cbbBacSi.Size = new System.Drawing.Size(297, 34);
            this.cbbBacSi.TabIndex = 60;
            this.cbbBacSi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 28);
            this.label1.TabIndex = 59;
            this.label1.Text = "Bác sĩ khám";
            // 
            // cbbUser
            // 
            cbbUser_DesignTimeLayout.LayoutString = resources.GetString("cbbUser_DesignTimeLayout.LayoutString");
            this.cbbUser.DesignTimeLayout = cbbUser_DesignTimeLayout;
            this.cbbUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbUser.Location = new System.Drawing.Point(200, 42);
            this.cbbUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbUser.Name = "cbbUser";
            this.cbbUser.SelectedIndex = -1;
            this.cbbUser.SelectedItem = null;
            this.cbbUser.Size = new System.Drawing.Size(297, 34);
            this.cbbUser.TabIndex = 58;
            this.cbbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 28);
            this.label3.TabIndex = 57;
            this.label3.Text = "UserName";
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
            this.panelButton.Size = new System.Drawing.Size(1037, 105);
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
            // DM_BacSiPhongKham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 482);
            this.Controls.Add(this.pnMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DM_BacSiPhongKham";
            this.Text = "Danh mục user - phòng khám - bác sĩ";
            this.Load += new System.EventHandler(this.DM_BacSiPhongKham_Load);
            this.pnMain.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPhongKham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbBacSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUser)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Panel pnGrid;
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn TenPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn TenBacSi;
        private DevExpress.XtraGrid.Columns.GridColumn MapKhamBenh_Id;
        private System.Windows.Forms.Panel pnThongTin;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cbbPhongKham;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cbbBacSi;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cbbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelButton;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
    }
}