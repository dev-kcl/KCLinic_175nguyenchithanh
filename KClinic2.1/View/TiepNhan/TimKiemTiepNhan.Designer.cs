namespace KClinic2._1.View.TiepNhan
{
    partial class TimKiemTiepNhan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridDS = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbPhongTuVan = new Janus.Windows.EditControls.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stn = new System.Windows.Forms.Label();
            this.txtSoTiepNhan = new System.Windows.Forms.TextBox();
            this.dtmDenNgay = new System.Windows.Forms.DateTimePicker();
            this.DenNgay = new System.Windows.Forms.Label();
            this.dtmTuNgay = new System.Windows.Forms.DateTimePicker();
            this.TuNgay = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TenBN = new System.Windows.Forms.Label();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.Label();
            this.txtNamSinh = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaYTe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1345, 561);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridDS);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 263);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1345, 298);
            this.panel3.TabIndex = 1;
            // 
            // gridDS
            // 
            this.gridDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDS.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridDS.Location = new System.Drawing.Point(0, 0);
            this.gridDS.MainView = this.gridView1;
            this.gridDS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridDS.Name = "gridDS";
            this.gridDS.Size = new System.Drawing.Size(1345, 298);
            this.gridDS.TabIndex = 67;
            this.gridDS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.STT,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn6});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridDS;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // STT
            // 
            this.STT.Caption = "STT";
            this.STT.FieldName = "STT";
            this.STT.MinWidth = 80;
            this.STT.Name = "STT";
            this.STT.Visible = true;
            this.STT.VisibleIndex = 0;
            this.STT.Width = 80;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Số tiếp nhận";
            this.gridColumn7.FieldName = "SoTiepNhan";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SoTiepNhan", "Số Lượng: {0}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 153;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ngày tiếp nhận";
            this.gridColumn8.FieldName = "NgayTiepNhan";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 153;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã y tế";
            this.gridColumn1.FieldName = "MaYTe";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 153;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên bệnh nhân";
            this.gridColumn2.FieldName = "TenBenhNhan";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tuổi";
            this.gridColumn5.FieldName = "Tuoi";
            this.gridColumn5.MinWidth = 80;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Năm sinh";
            this.gridColumn3.FieldName = "NamSinh";
            this.gridColumn3.MinWidth = 100;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Số điện thoại";
            this.gridColumn4.FieldName = "SoDienThoai";
            this.gridColumn4.MinWidth = 120;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 120;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Phòng tư vấn";
            this.gridColumn9.FieldName = "PhongTuVan";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Id";
            this.gridColumn6.FieldName = "TiepNhan_Id";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Width = 99;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbPhongTuVan);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.stn);
            this.panel2.Controls.Add(this.txtSoTiepNhan);
            this.panel2.Controls.Add(this.dtmDenNgay);
            this.panel2.Controls.Add(this.DenNgay);
            this.panel2.Controls.Add(this.dtmTuNgay);
            this.panel2.Controls.Add(this.TuNgay);
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TenBN);
            this.panel2.Controls.Add(this.txtTenBN);
            this.panel2.Controls.Add(this.namsinh);
            this.panel2.Controls.Add(this.txtNamSinh);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtMaYTe);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1345, 263);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbbPhongTuVan
            // 
            this.cbbPhongTuVan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbPhongTuVan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPhongTuVan.Location = new System.Drawing.Point(420, 218);
            this.cbbPhongTuVan.Margin = new System.Windows.Forms.Padding(4);
            this.cbbPhongTuVan.Name = "cbbPhongTuVan";
            this.cbbPhongTuVan.Size = new System.Drawing.Size(232, 30);
            this.cbbPhongTuVan.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(278, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 22);
            this.label1.TabIndex = 67;
            this.label1.Text = "Phòng tư vấn";
            // 
            // stn
            // 
            this.stn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stn.AutoSize = true;
            this.stn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stn.ForeColor = System.Drawing.Color.Black;
            this.stn.Location = new System.Drawing.Point(279, 62);
            this.stn.Name = "stn";
            this.stn.Size = new System.Drawing.Size(118, 22);
            this.stn.TabIndex = 41;
            this.stn.Text = "Số Tiếp Nhận";
            // 
            // txtSoTiepNhan
            // 
            this.txtSoTiepNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoTiepNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTiepNhan.Location = new System.Drawing.Point(420, 59);
            this.txtSoTiepNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTiepNhan.Name = "txtSoTiepNhan";
            this.txtSoTiepNhan.Size = new System.Drawing.Size(631, 30);
            this.txtSoTiepNhan.TabIndex = 61;
            this.txtSoTiepNhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // dtmDenNgay
            // 
            this.dtmDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtmDenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmDenNgay.Location = new System.Drawing.Point(668, 16);
            this.dtmDenNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtmDenNgay.Name = "dtmDenNgay";
            this.dtmDenNgay.Size = new System.Drawing.Size(135, 30);
            this.dtmDenNgay.TabIndex = 60;
            this.dtmDenNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // DenNgay
            // 
            this.DenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DenNgay.AutoSize = true;
            this.DenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DenNgay.ForeColor = System.Drawing.Color.Black;
            this.DenNgay.Location = new System.Drawing.Point(574, 22);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Size = new System.Drawing.Size(88, 22);
            this.DenNgay.TabIndex = 60;
            this.DenNgay.Text = "Đến Ngày";
            // 
            // dtmTuNgay
            // 
            this.dtmTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtmTuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmTuNgay.Location = new System.Drawing.Point(420, 16);
            this.dtmTuNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtmTuNgay.Name = "dtmTuNgay";
            this.dtmTuNgay.Size = new System.Drawing.Size(135, 30);
            this.dtmTuNgay.TabIndex = 59;
            // 
            // TuNgay
            // 
            this.TuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TuNgay.AutoSize = true;
            this.TuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TuNgay.ForeColor = System.Drawing.Color.Black;
            this.TuNgay.Location = new System.Drawing.Point(278, 21);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Size = new System.Drawing.Size(79, 22);
            this.TuNgay.TabIndex = 40;
            this.TuNgay.Text = "Từ Ngày";
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(820, 177);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(231, 30);
            this.txtSDT.TabIndex = 65;
            this.txtSDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(672, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 22);
            this.label3.TabIndex = 45;
            this.label3.Text = "Số Điện Thoại";
            // 
            // TenBN
            // 
            this.TenBN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TenBN.AutoSize = true;
            this.TenBN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenBN.ForeColor = System.Drawing.Color.Black;
            this.TenBN.Location = new System.Drawing.Point(278, 140);
            this.TenBN.Name = "TenBN";
            this.TenBN.Size = new System.Drawing.Size(131, 22);
            this.TenBN.TabIndex = 43;
            this.TenBN.Text = "Tên Bệnh Nhân";
            // 
            // txtTenBN
            // 
            this.txtTenBN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenBN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBN.Location = new System.Drawing.Point(420, 138);
            this.txtTenBN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.Size = new System.Drawing.Size(631, 30);
            this.txtTenBN.TabIndex = 63;
            this.txtTenBN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // namsinh
            // 
            this.namsinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.namsinh.AutoSize = true;
            this.namsinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.ForeColor = System.Drawing.Color.Black;
            this.namsinh.Location = new System.Drawing.Point(279, 180);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(87, 22);
            this.namsinh.TabIndex = 44;
            this.namsinh.Text = "Năm Sinh";
            // 
            // txtNamSinh
            // 
            this.txtNamSinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamSinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamSinh.Location = new System.Drawing.Point(420, 177);
            this.txtNamSinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNamSinh.Name = "txtNamSinh";
            this.txtNamSinh.Size = new System.Drawing.Size(231, 30);
            this.txtNamSinh.TabIndex = 64;
            this.txtNamSinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(694, 218);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(229, 32);
            this.btnTimKiem.TabIndex = 66;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txtMaYTe
            // 
            this.txtMaYTe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaYTe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaYTe.Location = new System.Drawing.Point(420, 98);
            this.txtMaYTe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaYTe.Name = "txtMaYTe";
            this.txtMaYTe.Size = new System.Drawing.Size(631, 30);
            this.txtMaYTe.TabIndex = 62;
            this.txtMaYTe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(279, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 42;
            this.label5.Text = "Mã Y Tế";
            // 
            // TimKiemTiepNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 561);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TimKiemTiepNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm Tiếp Nhận";
            this.Load += new System.EventHandler(this.TimKiemTiepNhan_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridDS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TenBN;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.Label namsinh;
        private System.Windows.Forms.TextBox txtNamSinh;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private System.Windows.Forms.TextBox txtMaYTe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label stn;
        private System.Windows.Forms.TextBox txtSoTiepNhan;
        private System.Windows.Forms.DateTimePicker dtmDenNgay;
        private System.Windows.Forms.Label DenNgay;
        private System.Windows.Forms.DateTimePicker dtmTuNgay;
        private System.Windows.Forms.Label TuNgay;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIComboBox cbbPhongTuVan;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}