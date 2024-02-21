namespace KClinic2._1.View.DanhMuc
{
    partial class Dictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dictionary));
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TamNgung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBacSi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.txtDienGiai5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDienGiai4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDienGiai3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDienGiai2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDienGiai1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDictionary_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDictionary_Name_Id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDictionary_Code = new System.Windows.Forms.TextBox();
            this.lbDictionary_Code = new System.Windows.Forms.Label();
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
            this.pnMain.Size = new System.Drawing.Size(1141, 599);
            this.pnMain.TabIndex = 3;
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.pnGrid);
            this.pnContent.Controls.Add(this.pnThongTin);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 105);
            this.pnContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1141, 494);
            this.pnContent.TabIndex = 2;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.gridDichVu);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 217);
            this.pnGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1141, 277);
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
            this.gridDichVu.Size = new System.Drawing.Size(1141, 277);
            this.gridDichVu.TabIndex = 30;
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
            this.TamNgung,
            this.TenBacSi,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.ID});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridDichVu;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // TamNgung
            // 
            this.TamNgung.Caption = "Tạm Ngưng";
            this.TamNgung.FieldName = "TamNgung";
            this.TamNgung.MinWidth = 27;
            this.TamNgung.Name = "TamNgung";
            this.TamNgung.OptionsColumn.AllowEdit = false;
            this.TamNgung.Visible = true;
            this.TamNgung.VisibleIndex = 0;
            this.TamNgung.Width = 100;
            // 
            // TenBacSi
            // 
            this.TenBacSi.Caption = "Dictionary_Code";
            this.TenBacSi.FieldName = "Dictionary_Code";
            this.TenBacSi.MinWidth = 27;
            this.TenBacSi.Name = "TenBacSi";
            this.TenBacSi.OptionsColumn.AllowEdit = false;
            this.TenBacSi.Visible = true;
            this.TenBacSi.VisibleIndex = 1;
            this.TenBacSi.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Dictionary_Name_Id";
            this.gridColumn1.FieldName = "Dictionary_Name_Id";
            this.gridColumn1.MinWidth = 27;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Dictionary_Name";
            this.gridColumn4.FieldName = "Dictionary_Name";
            this.gridColumn4.MinWidth = 27;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "DienGiai1";
            this.gridColumn3.FieldName = "DienGiai1";
            this.gridColumn3.MinWidth = 27;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "DienGiai2";
            this.gridColumn2.FieldName = "DienGiai2";
            this.gridColumn2.MinWidth = 27;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 100;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "Dictionary_Id";
            this.ID.MinWidth = 27;
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.Width = 100;
            // 
            // pnThongTin
            // 
            this.pnThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(211)))), ((int)(((byte)(144)))));
            this.pnThongTin.Controls.Add(this.txtDienGiai5);
            this.pnThongTin.Controls.Add(this.label7);
            this.pnThongTin.Controls.Add(this.txtDienGiai4);
            this.pnThongTin.Controls.Add(this.label6);
            this.pnThongTin.Controls.Add(this.txtDienGiai3);
            this.pnThongTin.Controls.Add(this.label5);
            this.pnThongTin.Controls.Add(this.txtDienGiai2);
            this.pnThongTin.Controls.Add(this.label4);
            this.pnThongTin.Controls.Add(this.txtDienGiai1);
            this.pnThongTin.Controls.Add(this.label3);
            this.pnThongTin.Controls.Add(this.txtDictionary_Name);
            this.pnThongTin.Controls.Add(this.label1);
            this.pnThongTin.Controls.Add(this.txtDictionary_Name_Id);
            this.pnThongTin.Controls.Add(this.label2);
            this.pnThongTin.Controls.Add(this.txtDictionary_Code);
            this.pnThongTin.Controls.Add(this.lbDictionary_Code);
            this.pnThongTin.Controls.Add(this.cbTamNgung);
            this.pnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThongTin.Location = new System.Drawing.Point(0, 0);
            this.pnThongTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(1141, 217);
            this.pnThongTin.TabIndex = 15;
            // 
            // txtDienGiai5
            // 
            this.txtDienGiai5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDienGiai5.Location = new System.Drawing.Point(709, 176);
            this.txtDienGiai5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDienGiai5.Multiline = true;
            this.txtDienGiai5.Name = "txtDienGiai5";
            this.txtDienGiai5.Size = new System.Drawing.Size(300, 31);
            this.txtDienGiai5.TabIndex = 62;
            this.txtDienGiai5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(597, 180);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 28);
            this.label7.TabIndex = 61;
            this.label7.Text = "DienGiai5";
            // 
            // txtDienGiai4
            // 
            this.txtDienGiai4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDienGiai4.Location = new System.Drawing.Point(709, 137);
            this.txtDienGiai4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDienGiai4.Multiline = true;
            this.txtDienGiai4.Name = "txtDienGiai4";
            this.txtDienGiai4.Size = new System.Drawing.Size(300, 31);
            this.txtDienGiai4.TabIndex = 60;
            this.txtDienGiai4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(597, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 28);
            this.label6.TabIndex = 59;
            this.label6.Text = "DienGiai4";
            // 
            // txtDienGiai3
            // 
            this.txtDienGiai3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDienGiai3.Location = new System.Drawing.Point(709, 97);
            this.txtDienGiai3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDienGiai3.Multiline = true;
            this.txtDienGiai3.Name = "txtDienGiai3";
            this.txtDienGiai3.Size = new System.Drawing.Size(300, 31);
            this.txtDienGiai3.TabIndex = 58;
            this.txtDienGiai3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(597, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 28);
            this.label5.TabIndex = 57;
            this.label5.Text = "DienGiai3";
            // 
            // txtDienGiai2
            // 
            this.txtDienGiai2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDienGiai2.Location = new System.Drawing.Point(709, 58);
            this.txtDienGiai2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDienGiai2.Multiline = true;
            this.txtDienGiai2.Name = "txtDienGiai2";
            this.txtDienGiai2.Size = new System.Drawing.Size(300, 31);
            this.txtDienGiai2.TabIndex = 56;
            this.txtDienGiai2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(597, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 28);
            this.label4.TabIndex = 55;
            this.label4.Text = "DienGiai2";
            // 
            // txtDienGiai1
            // 
            this.txtDienGiai1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDienGiai1.Location = new System.Drawing.Point(709, 18);
            this.txtDienGiai1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDienGiai1.Multiline = true;
            this.txtDienGiai1.Name = "txtDienGiai1";
            this.txtDienGiai1.Size = new System.Drawing.Size(300, 31);
            this.txtDienGiai1.TabIndex = 54;
            this.txtDienGiai1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(597, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 28);
            this.label3.TabIndex = 53;
            this.label3.Text = "DienGiai1";
            // 
            // txtDictionary_Name
            // 
            this.txtDictionary_Name.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDictionary_Name.Location = new System.Drawing.Point(256, 97);
            this.txtDictionary_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDictionary_Name.Multiline = true;
            this.txtDictionary_Name.Name = "txtDictionary_Name";
            this.txtDictionary_Name.Size = new System.Drawing.Size(300, 31);
            this.txtDictionary_Name.TabIndex = 52;
            this.txtDictionary_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 28);
            this.label1.TabIndex = 51;
            this.label1.Text = "Dictionary_Name";
            // 
            // txtDictionary_Name_Id
            // 
            this.txtDictionary_Name_Id.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDictionary_Name_Id.Location = new System.Drawing.Point(256, 58);
            this.txtDictionary_Name_Id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDictionary_Name_Id.Multiline = true;
            this.txtDictionary_Name_Id.Name = "txtDictionary_Name_Id";
            this.txtDictionary_Name_Id.Size = new System.Drawing.Size(300, 31);
            this.txtDictionary_Name_Id.TabIndex = 50;
            this.txtDictionary_Name_Id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 28);
            this.label2.TabIndex = 49;
            this.label2.Text = "Dictionary_Name_Id";
            // 
            // txtDictionary_Code
            // 
            this.txtDictionary_Code.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDictionary_Code.Location = new System.Drawing.Point(256, 18);
            this.txtDictionary_Code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDictionary_Code.Multiline = true;
            this.txtDictionary_Code.Name = "txtDictionary_Code";
            this.txtDictionary_Code.Size = new System.Drawing.Size(300, 31);
            this.txtDictionary_Code.TabIndex = 48;
            this.txtDictionary_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // lbDictionary_Code
            // 
            this.lbDictionary_Code.AutoSize = true;
            this.lbDictionary_Code.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbDictionary_Code.ForeColor = System.Drawing.Color.Black;
            this.lbDictionary_Code.Location = new System.Drawing.Point(47, 22);
            this.lbDictionary_Code.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDictionary_Code.Name = "lbDictionary_Code";
            this.lbDictionary_Code.Size = new System.Drawing.Size(156, 28);
            this.lbDictionary_Code.TabIndex = 47;
            this.lbDictionary_Code.Text = "Dictionary_Code";
            // 
            // cbTamNgung
            // 
            this.cbTamNgung.Location = new System.Drawing.Point(52, 138);
            this.cbTamNgung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTamNgung.Name = "cbTamNgung";
            this.cbTamNgung.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbTamNgung.Properties.Appearance.Options.UseFont = true;
            this.cbTamNgung.Properties.Caption = "Tạm Ngưng";
            this.cbTamNgung.Size = new System.Drawing.Size(181, 32);
            this.cbTamNgung.TabIndex = 46;
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
            this.panelButton.Size = new System.Drawing.Size(1141, 105);
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
            // Dictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 599);
            this.Controls.Add(this.pnMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Dictionary";
            this.Text = "Dictionary";
            this.Load += new System.EventHandler(this.Dictionary_Load);
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
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn TamNgung;
        private DevExpress.XtraGrid.Columns.GridColumn TenBacSi;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private System.Windows.Forms.Panel pnThongTin;
        private System.Windows.Forms.TextBox txtDictionary_Code;
        private System.Windows.Forms.Label lbDictionary_Code;
        private DevExpress.XtraEditors.CheckEdit cbTamNgung;
        private System.Windows.Forms.Panel panelButton;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.TextBox txtDictionary_Name_Id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDienGiai5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDienGiai4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDienGiai3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDienGiai2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDienGiai1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDictionary_Name;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
    }
}