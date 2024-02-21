namespace KClinic2._1.View.DanhMuc
{
    partial class DM_DichVuCon
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
            Janus.Windows.GridEX.GridEXLayout cbbDichVuCha_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DM_DichVuCon));
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TamNgung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsDichVuCha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CoGiaTriChuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DichVuCha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.cbbDichVuCha = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCoGiaTriChuan = new DevExpress.XtraEditors.CheckEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTamNgung = new DevExpress.XtraEditors.CheckEdit();
            this.txtTenDichVu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaDichVu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.cbbDichVuCha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCoGiaTriChuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTamNgung.Properties)).BeginInit();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.pnContent);
            this.pnMain.Controls.Add(this.panelButton);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1090, 574);
            this.pnMain.TabIndex = 2;
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.pnGrid);
            this.pnContent.Controls.Add(this.pnThongTin);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 105);
            this.pnContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1090, 469);
            this.pnContent.TabIndex = 2;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.gridDichVu);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 303);
            this.pnGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1090, 166);
            this.pnGrid.TabIndex = 16;
            // 
            // gridDichVu
            // 
            this.gridDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDichVu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridDichVu.Location = new System.Drawing.Point(0, 0);
            this.gridDichVu.MainView = this.gridView1;
            this.gridDichVu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridDichVu.Name = "gridDichVu";
            this.gridDichVu.Size = new System.Drawing.Size(1090, 166);
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
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaDichVu,
            this.TenDichVu,
            this.TamNgung,
            this.GiaDichVu,
            this.DVT,
            this.IsDichVuCha,
            this.CoGiaTriChuan,
            this.DichVuCha,
            this.ID});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridDichVu;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.DichVuCha, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // MaDichVu
            // 
            this.MaDichVu.Caption = "Mã dịch vụ";
            this.MaDichVu.FieldName = "MaDichVu";
            this.MaDichVu.MinWidth = 26;
            this.MaDichVu.Name = "MaDichVu";
            this.MaDichVu.OptionsColumn.AllowEdit = false;
            this.MaDichVu.Visible = true;
            this.MaDichVu.VisibleIndex = 0;
            this.MaDichVu.Width = 99;
            // 
            // TenDichVu
            // 
            this.TenDichVu.Caption = "Tên dịch vụ";
            this.TenDichVu.FieldName = "TenDichVu";
            this.TenDichVu.MinWidth = 26;
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.OptionsColumn.AllowEdit = false;
            this.TenDichVu.Visible = true;
            this.TenDichVu.VisibleIndex = 1;
            this.TenDichVu.Width = 569;
            // 
            // TamNgung
            // 
            this.TamNgung.Caption = "Tạm Ngưng";
            this.TamNgung.FieldName = "TamNgung";
            this.TamNgung.MinWidth = 26;
            this.TamNgung.Name = "TamNgung";
            this.TamNgung.OptionsColumn.AllowEdit = false;
            this.TamNgung.Visible = true;
            this.TamNgung.VisibleIndex = 2;
            this.TamNgung.Width = 99;
            // 
            // GiaDichVu
            // 
            this.GiaDichVu.Caption = "Giá Dịch Vụ";
            this.GiaDichVu.FieldName = "GiaDichVu";
            this.GiaDichVu.MinWidth = 26;
            this.GiaDichVu.Name = "GiaDichVu";
            this.GiaDichVu.OptionsColumn.AllowEdit = false;
            this.GiaDichVu.Visible = true;
            this.GiaDichVu.VisibleIndex = 3;
            this.GiaDichVu.Width = 99;
            // 
            // DVT
            // 
            this.DVT.Caption = "ĐVT";
            this.DVT.FieldName = "DVT";
            this.DVT.MinWidth = 26;
            this.DVT.Name = "DVT";
            this.DVT.OptionsColumn.AllowEdit = false;
            this.DVT.Visible = true;
            this.DVT.VisibleIndex = 4;
            this.DVT.Width = 99;
            // 
            // IsDichVuCha
            // 
            this.IsDichVuCha.Caption = "Là Dịch Vụ Cha";
            this.IsDichVuCha.FieldName = "IsDichVuCha";
            this.IsDichVuCha.MinWidth = 26;
            this.IsDichVuCha.Name = "IsDichVuCha";
            this.IsDichVuCha.OptionsColumn.AllowEdit = false;
            this.IsDichVuCha.Visible = true;
            this.IsDichVuCha.VisibleIndex = 5;
            this.IsDichVuCha.Width = 99;
            // 
            // CoGiaTriChuan
            // 
            this.CoGiaTriChuan.Caption = "Có giá trị chuẩn";
            this.CoGiaTriChuan.FieldName = "CoGiaTriChuan";
            this.CoGiaTriChuan.MinWidth = 26;
            this.CoGiaTriChuan.Name = "CoGiaTriChuan";
            this.CoGiaTriChuan.OptionsColumn.AllowEdit = false;
            this.CoGiaTriChuan.Visible = true;
            this.CoGiaTriChuan.VisibleIndex = 6;
            this.CoGiaTriChuan.Width = 99;
            // 
            // DichVuCha
            // 
            this.DichVuCha.Caption = "Dịch vụ cấp trên";
            this.DichVuCha.FieldName = "DichVuCha";
            this.DichVuCha.MinWidth = 26;
            this.DichVuCha.Name = "DichVuCha";
            this.DichVuCha.OptionsColumn.AllowEdit = false;
            this.DichVuCha.Visible = true;
            this.DichVuCha.VisibleIndex = 6;
            this.DichVuCha.Width = 99;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "Dich_Id";
            this.ID.MinWidth = 26;
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 7;
            this.ID.Width = 99;
            // 
            // pnThongTin
            // 
            this.pnThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(211)))), ((int)(((byte)(144)))));
            this.pnThongTin.Controls.Add(this.cbbDichVuCha);
            this.pnThongTin.Controls.Add(this.txtDVT);
            this.pnThongTin.Controls.Add(this.label3);
            this.pnThongTin.Controls.Add(this.cbCoGiaTriChuan);
            this.pnThongTin.Controls.Add(this.label4);
            this.pnThongTin.Controls.Add(this.cbTamNgung);
            this.pnThongTin.Controls.Add(this.txtTenDichVu);
            this.pnThongTin.Controls.Add(this.label1);
            this.pnThongTin.Controls.Add(this.txtMaDichVu);
            this.pnThongTin.Controls.Add(this.label9);
            this.pnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThongTin.Location = new System.Drawing.Point(0, 0);
            this.pnThongTin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(1090, 303);
            this.pnThongTin.TabIndex = 15;
            this.pnThongTin.Click += new System.EventHandler(this.cbbDichVuCha_Click);
            // 
            // cbbDichVuCha
            // 
            this.cbbDichVuCha.AutoComplete = false;
            cbbDichVuCha_DesignTimeLayout.LayoutString = resources.GetString("cbbDichVuCha_DesignTimeLayout.LayoutString");
            this.cbbDichVuCha.DesignTimeLayout = cbbDichVuCha_DesignTimeLayout;
            this.cbbDichVuCha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDichVuCha.Location = new System.Drawing.Point(250, 137);
            this.cbbDichVuCha.Name = "cbbDichVuCha";
            this.cbbDichVuCha.SelectedIndex = -1;
            this.cbbDichVuCha.SelectedItem = null;
            this.cbbDichVuCha.Size = new System.Drawing.Size(675, 30);
            this.cbbDichVuCha.TabIndex = 48;
            this.cbbDichVuCha.Click += new System.EventHandler(this.cbbDichVuCha_Click);
            this.cbbDichVuCha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.cbbDichVuCha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbbDichVuCha_KeyUp);
            // 
            // txtDVT
            // 
            this.txtDVT.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDVT.Location = new System.Drawing.Point(250, 222);
            this.txtDVT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDVT.Multiline = true;
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(295, 31);
            this.txtDVT.TabIndex = 53;
            this.txtDVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(74, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 28);
            this.label3.TabIndex = 52;
            this.label3.Text = "Đơn vị tính";
            // 
            // cbCoGiaTriChuan
            // 
            this.cbCoGiaTriChuan.Location = new System.Drawing.Point(250, 186);
            this.cbCoGiaTriChuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCoGiaTriChuan.Name = "cbCoGiaTriChuan";
            this.cbCoGiaTriChuan.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbCoGiaTriChuan.Properties.Appearance.Options.UseFont = true;
            this.cbCoGiaTriChuan.Properties.Caption = "Có giá trị chuẩn";
            this.cbCoGiaTriChuan.Size = new System.Drawing.Size(195, 32);
            this.cbCoGiaTriChuan.TabIndex = 51;
            this.cbCoGiaTriChuan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(74, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 28);
            this.label4.TabIndex = 49;
            this.label4.Text = "Dịch Vụ Cha";
            // 
            // cbTamNgung
            // 
            this.cbTamNgung.Location = new System.Drawing.Point(539, 186);
            this.cbTamNgung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTamNgung.Name = "cbTamNgung";
            this.cbTamNgung.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbTamNgung.Properties.Appearance.Options.UseFont = true;
            this.cbTamNgung.Properties.Caption = "Tạm Ngưng";
            this.cbTamNgung.Size = new System.Drawing.Size(195, 32);
            this.cbTamNgung.TabIndex = 49;
            this.cbTamNgung.Click += new System.EventHandler(this.cbbDichVuCha_Click);
            this.cbTamNgung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.cbTamNgung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbbDichVuCha_KeyUp);
            // 
            // txtTenDichVu
            // 
            this.txtTenDichVu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenDichVu.Location = new System.Drawing.Point(250, 87);
            this.txtTenDichVu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDichVu.Multiline = true;
            this.txtTenDichVu.Name = "txtTenDichVu";
            this.txtTenDichVu.Size = new System.Drawing.Size(675, 31);
            this.txtTenDichVu.TabIndex = 47;
            this.txtTenDichVu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(74, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 28);
            this.label1.TabIndex = 46;
            this.label1.Text = "Tên Dịch Vụ Con";
            // 
            // txtMaDichVu
            // 
            this.txtMaDichVu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaDichVu.Location = new System.Drawing.Point(250, 42);
            this.txtMaDichVu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaDichVu.Multiline = true;
            this.txtMaDichVu.Name = "txtMaDichVu";
            this.txtMaDichVu.Size = new System.Drawing.Size(263, 31);
            this.txtMaDichVu.TabIndex = 45;
            this.txtMaDichVu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(74, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 28);
            this.label9.TabIndex = 44;
            this.label9.Text = "Mã Dịch Vụ Con";
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
            this.panelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1090, 105);
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
            this.btnThoat.Location = new System.Drawing.Point(658, 15);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(99, 78);
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
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(99, 78);
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
            this.btnHuy.Location = new System.Drawing.Point(398, 15);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(99, 78);
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
            this.btnLuu.Location = new System.Drawing.Point(270, 15);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(99, 78);
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
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(99, 78);
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
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 78);
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
            // DM_DichVuCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 574);
            this.Controls.Add(this.pnMain);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DM_DichVuCon";
            this.Text = "Danh mục dịch vụ con";
            this.Load += new System.EventHandler(this.DM_DichVuCon_Load);
            this.pnMain.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDichVuCha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCoGiaTriChuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTamNgung.Properties)).EndInit();
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
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckEdit cbCoGiaTriChuan;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.CheckEdit cbTamNgung;
        private System.Windows.Forms.TextBox txtTenDichVu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaDichVu;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn TenDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn TamNgung;
        private DevExpress.XtraGrid.Columns.GridColumn GiaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn DVT;
        private DevExpress.XtraGrid.Columns.GridColumn IsDichVuCha;
        private DevExpress.XtraGrid.Columns.GridColumn CoGiaTriChuan;
        private DevExpress.XtraGrid.Columns.GridColumn DichVuCha;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cbbDichVuCha;
    }
}