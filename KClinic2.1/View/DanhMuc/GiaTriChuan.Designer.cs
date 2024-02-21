namespace KClinic2._1.View.DanhMuc
{
    partial class GiaTriChuan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaTriChuan));
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TamNgung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaTriDungChung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NamMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NamMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NuMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NuMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TreEmMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TreEmMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNhomDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.txtGiaTriDungChung = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTreEmMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTreEmMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNuMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNuMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbDichVu = new Janus.Windows.EditControls.UIComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTamNgung = new DevExpress.XtraEditors.CheckEdit();
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
            this.pnMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1227, 633);
            this.pnMain.TabIndex = 2;
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.pnGrid);
            this.pnContent.Controls.Add(this.pnThongTin);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 105);
            this.pnContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1227, 528);
            this.pnContent.TabIndex = 2;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.gridDichVu);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 334);
            this.pnGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1227, 194);
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
            this.gridDichVu.Size = new System.Drawing.Size(1227, 194);
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
            this.TenDichVu,
            this.TamNgung,
            this.GiaTriDungChung,
            this.NamMax,
            this.NamMin,
            this.NuMax,
            this.NuMin,
            this.TreEmMax,
            this.TreEmMin,
            this.TenNhomDichVu,
            this.ID});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridDichVu;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TenNhomDichVu, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // TenDichVu
            // 
            this.TenDichVu.Caption = "Tên dịch vụ";
            this.TenDichVu.FieldName = "TenDichVu";
            this.TenDichVu.MinWidth = 27;
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.OptionsColumn.AllowEdit = false;
            this.TenDichVu.Visible = true;
            this.TenDichVu.VisibleIndex = 0;
            this.TenDichVu.Width = 569;
            // 
            // TamNgung
            // 
            this.TamNgung.Caption = "Tạm Ngưng";
            this.TamNgung.FieldName = "TamNgung";
            this.TamNgung.MinWidth = 27;
            this.TamNgung.Name = "TamNgung";
            this.TamNgung.OptionsColumn.AllowEdit = false;
            this.TamNgung.Visible = true;
            this.TamNgung.VisibleIndex = 1;
            this.TamNgung.Width = 100;
            // 
            // GiaTriDungChung
            // 
            this.GiaTriDungChung.Caption = "Giá trị dùng chung";
            this.GiaTriDungChung.FieldName = "GiaTriDungChung";
            this.GiaTriDungChung.MinWidth = 27;
            this.GiaTriDungChung.Name = "GiaTriDungChung";
            this.GiaTriDungChung.Visible = true;
            this.GiaTriDungChung.VisibleIndex = 2;
            this.GiaTriDungChung.Width = 100;
            // 
            // NamMax
            // 
            this.NamMax.Caption = "Nam Max";
            this.NamMax.FieldName = "NamMax";
            this.NamMax.MinWidth = 27;
            this.NamMax.Name = "NamMax";
            this.NamMax.OptionsColumn.AllowEdit = false;
            this.NamMax.Visible = true;
            this.NamMax.VisibleIndex = 3;
            this.NamMax.Width = 100;
            // 
            // NamMin
            // 
            this.NamMin.Caption = "Nam Min";
            this.NamMin.FieldName = "NamMin";
            this.NamMin.MinWidth = 27;
            this.NamMin.Name = "NamMin";
            this.NamMin.OptionsColumn.AllowEdit = false;
            this.NamMin.Visible = true;
            this.NamMin.VisibleIndex = 4;
            this.NamMin.Width = 100;
            // 
            // NuMax
            // 
            this.NuMax.Caption = "Nữ Max";
            this.NuMax.FieldName = "NuMax";
            this.NuMax.MinWidth = 27;
            this.NuMax.Name = "NuMax";
            this.NuMax.OptionsColumn.AllowEdit = false;
            this.NuMax.Visible = true;
            this.NuMax.VisibleIndex = 5;
            this.NuMax.Width = 100;
            // 
            // NuMin
            // 
            this.NuMin.Caption = "Nữ Min";
            this.NuMin.FieldName = "NuMin";
            this.NuMin.MinWidth = 27;
            this.NuMin.Name = "NuMin";
            this.NuMin.OptionsColumn.AllowEdit = false;
            this.NuMin.Visible = true;
            this.NuMin.VisibleIndex = 6;
            this.NuMin.Width = 100;
            // 
            // TreEmMax
            // 
            this.TreEmMax.Caption = "Trẻ em Max";
            this.TreEmMax.FieldName = "TreEmMax";
            this.TreEmMax.MinWidth = 27;
            this.TreEmMax.Name = "TreEmMax";
            this.TreEmMax.OptionsColumn.AllowEdit = false;
            this.TreEmMax.Visible = true;
            this.TreEmMax.VisibleIndex = 7;
            this.TreEmMax.Width = 100;
            // 
            // TreEmMin
            // 
            this.TreEmMin.Caption = "Trẻ em Min";
            this.TreEmMin.FieldName = "TreEmMin";
            this.TreEmMin.MinWidth = 27;
            this.TreEmMin.Name = "TreEmMin";
            this.TreEmMin.OptionsColumn.AllowEdit = false;
            this.TreEmMin.Visible = true;
            this.TreEmMin.VisibleIndex = 8;
            this.TreEmMin.Width = 100;
            // 
            // TenNhomDichVu
            // 
            this.TenNhomDichVu.Caption = "Nhóm Dịch Vụ";
            this.TenNhomDichVu.FieldName = "TenNhomDichVu";
            this.TenNhomDichVu.MinWidth = 27;
            this.TenNhomDichVu.Name = "TenNhomDichVu";
            this.TenNhomDichVu.OptionsColumn.AllowEdit = false;
            this.TenNhomDichVu.Visible = true;
            this.TenNhomDichVu.VisibleIndex = 6;
            this.TenNhomDichVu.Width = 100;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "GiaTriChuan_Id";
            this.ID.MinWidth = 27;
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 9;
            this.ID.Width = 100;
            // 
            // pnThongTin
            // 
            this.pnThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(211)))), ((int)(((byte)(144)))));
            this.pnThongTin.Controls.Add(this.txtGiaTriDungChung);
            this.pnThongTin.Controls.Add(this.label8);
            this.pnThongTin.Controls.Add(this.txtTreEmMin);
            this.pnThongTin.Controls.Add(this.label7);
            this.pnThongTin.Controls.Add(this.txtTreEmMax);
            this.pnThongTin.Controls.Add(this.label6);
            this.pnThongTin.Controls.Add(this.txtNuMin);
            this.pnThongTin.Controls.Add(this.label5);
            this.pnThongTin.Controls.Add(this.txtNuMax);
            this.pnThongTin.Controls.Add(this.label2);
            this.pnThongTin.Controls.Add(this.txtNamMin);
            this.pnThongTin.Controls.Add(this.label1);
            this.pnThongTin.Controls.Add(this.txtNamMax);
            this.pnThongTin.Controls.Add(this.label3);
            this.pnThongTin.Controls.Add(this.cbbDichVu);
            this.pnThongTin.Controls.Add(this.label4);
            this.pnThongTin.Controls.Add(this.cbTamNgung);
            this.pnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThongTin.Location = new System.Drawing.Point(0, 0);
            this.pnThongTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(1227, 334);
            this.pnThongTin.TabIndex = 15;
            // 
            // txtGiaTriDungChung
            // 
            this.txtGiaTriDungChung.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGiaTriDungChung.Location = new System.Drawing.Point(281, 86);
            this.txtGiaTriDungChung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaTriDungChung.Multiline = true;
            this.txtGiaTriDungChung.Name = "txtGiaTriDungChung";
            this.txtGiaTriDungChung.Size = new System.Drawing.Size(640, 101);
            this.txtGiaTriDungChung.TabIndex = 72;
            this.txtGiaTriDungChung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(88, 90);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 28);
            this.label8.TabIndex = 71;
            this.label8.Text = "Giá trị dùng chung";
            // 
            // txtTreEmMin
            // 
            this.txtTreEmMin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTreEmMin.Location = new System.Drawing.Point(639, 284);
            this.txtTreEmMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTreEmMin.Multiline = true;
            this.txtTreEmMin.Name = "txtTreEmMin";
            this.txtTreEmMin.Size = new System.Drawing.Size(283, 31);
            this.txtTreEmMin.TabIndex = 70;
            this.txtTreEmMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(523, 288);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 28);
            this.label7.TabIndex = 69;
            this.label7.Text = "Trẻ Em Min";
            // 
            // txtTreEmMax
            // 
            this.txtTreEmMax.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTreEmMax.Location = new System.Drawing.Point(209, 284);
            this.txtTreEmMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTreEmMax.Multiline = true;
            this.txtTreEmMax.Name = "txtTreEmMax";
            this.txtTreEmMax.Size = new System.Drawing.Size(281, 31);
            this.txtTreEmMax.TabIndex = 68;
            this.txtTreEmMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(88, 288);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 28);
            this.label6.TabIndex = 67;
            this.label6.Text = "Trẻ Em Max";
            // 
            // txtNuMin
            // 
            this.txtNuMin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNuMin.Location = new System.Drawing.Point(639, 239);
            this.txtNuMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNuMin.Multiline = true;
            this.txtNuMin.Name = "txtNuMin";
            this.txtNuMin.Size = new System.Drawing.Size(283, 31);
            this.txtNuMin.TabIndex = 66;
            this.txtNuMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(523, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 28);
            this.label5.TabIndex = 65;
            this.label5.Text = "Nữ Min";
            // 
            // txtNuMax
            // 
            this.txtNuMax.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNuMax.Location = new System.Drawing.Point(209, 239);
            this.txtNuMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNuMax.Multiline = true;
            this.txtNuMax.Name = "txtNuMax";
            this.txtNuMax.Size = new System.Drawing.Size(281, 31);
            this.txtNuMax.TabIndex = 64;
            this.txtNuMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(88, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 28);
            this.label2.TabIndex = 63;
            this.label2.Text = "Nữ Max";
            // 
            // txtNamMin
            // 
            this.txtNamMin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNamMin.Location = new System.Drawing.Point(639, 196);
            this.txtNamMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNamMin.Multiline = true;
            this.txtNamMin.Name = "txtNamMin";
            this.txtNamMin.Size = new System.Drawing.Size(283, 31);
            this.txtNamMin.TabIndex = 62;
            this.txtNamMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(523, 199);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 28);
            this.label1.TabIndex = 61;
            this.label1.Text = "Nam Min";
            // 
            // txtNamMax
            // 
            this.txtNamMax.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNamMax.Location = new System.Drawing.Point(209, 196);
            this.txtNamMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNamMax.Multiline = true;
            this.txtNamMax.Name = "txtNamMax";
            this.txtNamMax.Size = new System.Drawing.Size(281, 31);
            this.txtNamMax.TabIndex = 60;
            this.txtNamMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(88, 199);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 59;
            this.label3.Text = "Nam Max";
            // 
            // cbbDichVu
            // 
            this.cbbDichVu.AutoComplete = false;
            this.cbbDichVu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbDichVu.Location = new System.Drawing.Point(209, 11);
            this.cbbDichVu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbDichVu.Name = "cbbDichVu";
            this.cbbDichVu.Size = new System.Drawing.Size(713, 34);
            this.cbbDichVu.Sorted = true;
            this.cbbDichVu.TabIndex = 58;
            this.cbbDichVu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(88, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 28);
            this.label4.TabIndex = 57;
            this.label4.Text = "Dịch vụ";
            // 
            // cbTamNgung
            // 
            this.cbTamNgung.Location = new System.Drawing.Point(209, 50);
            this.cbTamNgung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTamNgung.Name = "cbTamNgung";
            this.cbTamNgung.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbTamNgung.Properties.Appearance.Options.UseFont = true;
            this.cbTamNgung.Properties.Caption = "Tạm Ngưng";
            this.cbTamNgung.Size = new System.Drawing.Size(181, 32);
            this.cbTamNgung.TabIndex = 56;
            this.cbTamNgung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
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
            this.panelButton.Size = new System.Drawing.Size(1227, 105);
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
            // GiaTriChuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 633);
            this.Controls.Add(this.pnMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GiaTriChuan";
            this.Text = "Giá trị chuẩn";
            this.Load += new System.EventHandler(this.GiaTriChuan_Load);
            this.pnMain.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
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
        private System.Windows.Forms.TextBox txtGiaTriDungChung;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTreEmMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTreEmMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNuMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNuMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamMax;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIComboBox cbbDichVu;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.CheckEdit cbTamNgung;
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn TenDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn TamNgung;
        private DevExpress.XtraGrid.Columns.GridColumn GiaTriDungChung;
        private DevExpress.XtraGrid.Columns.GridColumn NamMax;
        private DevExpress.XtraGrid.Columns.GridColumn NamMin;
        private DevExpress.XtraGrid.Columns.GridColumn NuMax;
        private DevExpress.XtraGrid.Columns.GridColumn NuMin;
        private DevExpress.XtraGrid.Columns.GridColumn TreEmMax;
        private DevExpress.XtraGrid.Columns.GridColumn TreEmMin;
        private DevExpress.XtraGrid.Columns.GridColumn TenNhomDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
    }
}