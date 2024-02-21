namespace KClinic2._1.View.DanhMuc
{
    partial class DuocTonKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuocTonKho));
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaDuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDuocDayDu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenHoatChat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuongTon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGiaVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenLoaiDuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Duoc_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckTonKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.pnMain.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.pnContent);
            this.pnMain.Controls.Add(this.panelButton);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(851, 517);
            this.pnMain.TabIndex = 4;
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.pnGrid);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 85);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(851, 432);
            this.pnContent.TabIndex = 2;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.gridDichVu);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 0);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(851, 432);
            this.pnGrid.TabIndex = 16;
            // 
            // gridDichVu
            // 
            this.gridDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDichVu.Location = new System.Drawing.Point(0, 0);
            this.gridDichVu.MainView = this.gridView1;
            this.gridDichVu.Name = "gridDichVu";
            this.gridDichVu.Size = new System.Drawing.Size(851, 432);
            this.gridDichVu.TabIndex = 28;
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
            this.MaDuoc,
            this.TenDuocDayDu,
            this.TenHoatChat,
            this.DonViTinh,
            this.SoLuongTon,
            this.DonGia,
            this.DateEnd,
            this.DonGiaVon,
            this.TenLoaiDuoc,
            this.Duoc_Id,
            this.CheckDate,
            this.CheckTonKho});
            this.gridView1.GridControl = this.gridDichVu;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TenLoaiDuoc, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // MaDuoc
            // 
            this.MaDuoc.Caption = "Mã dược";
            this.MaDuoc.FieldName = "MaDuoc";
            this.MaDuoc.Name = "MaDuoc";
            this.MaDuoc.OptionsColumn.AllowEdit = false;
            this.MaDuoc.Visible = true;
            this.MaDuoc.VisibleIndex = 0;
            this.MaDuoc.Width = 60;
            // 
            // TenDuocDayDu
            // 
            this.TenDuocDayDu.Caption = "Tên dược đầy đủ";
            this.TenDuocDayDu.FieldName = "TenDuocDayDu";
            this.TenDuocDayDu.Name = "TenDuocDayDu";
            this.TenDuocDayDu.Visible = true;
            this.TenDuocDayDu.VisibleIndex = 1;
            this.TenDuocDayDu.Width = 255;
            // 
            // TenHoatChat
            // 
            this.TenHoatChat.Caption = "Tên hoạt chất";
            this.TenHoatChat.FieldName = "TenHoatChat";
            this.TenHoatChat.Name = "TenHoatChat";
            this.TenHoatChat.Visible = true;
            this.TenHoatChat.VisibleIndex = 2;
            this.TenHoatChat.Width = 102;
            // 
            // DonViTinh
            // 
            this.DonViTinh.Caption = "ĐVT";
            this.DonViTinh.FieldName = "DonViTinh";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.OptionsColumn.AllowEdit = false;
            this.DonViTinh.Visible = true;
            this.DonViTinh.VisibleIndex = 5;
            this.DonViTinh.Width = 60;
            // 
            // SoLuongTon
            // 
            this.SoLuongTon.Caption = "Số lượng hiện có";
            this.SoLuongTon.FieldName = "SoLuongTon";
            this.SoLuongTon.Name = "SoLuongTon";
            this.SoLuongTon.OptionsColumn.AllowEdit = false;
            this.SoLuongTon.Visible = true;
            this.SoLuongTon.VisibleIndex = 4;
            this.SoLuongTon.Width = 97;
            // 
            // DonGia
            // 
            this.DonGia.Caption = "Đơn giá";
            this.DonGia.FieldName = "DonGia";
            this.DonGia.Name = "DonGia";
            this.DonGia.OptionsColumn.AllowEdit = false;
            this.DonGia.Visible = true;
            this.DonGia.VisibleIndex = 3;
            this.DonGia.Width = 102;
            // 
            // DateEnd
            // 
            this.DateEnd.Caption = "Hạn sử dụng";
            this.DateEnd.FieldName = "DateEnd";
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.OptionsColumn.AllowEdit = false;
            this.DateEnd.Visible = true;
            this.DateEnd.VisibleIndex = 6;
            this.DateEnd.Width = 70;
            // 
            // DonGiaVon
            // 
            this.DonGiaVon.Caption = "Đơn giá vốn";
            this.DonGiaVon.FieldName = "DonGiaVon";
            this.DonGiaVon.Name = "DonGiaVon";
            this.DonGiaVon.OptionsColumn.AllowEdit = false;
            this.DonGiaVon.Visible = true;
            this.DonGiaVon.VisibleIndex = 7;
            this.DonGiaVon.Width = 60;
            // 
            // TenLoaiDuoc
            // 
            this.TenLoaiDuoc.Caption = "Phân loại dược";
            this.TenLoaiDuoc.FieldName = "TenLoaiDuoc";
            this.TenLoaiDuoc.Name = "TenLoaiDuoc";
            this.TenLoaiDuoc.OptionsColumn.AllowEdit = false;
            this.TenLoaiDuoc.Visible = true;
            this.TenLoaiDuoc.VisibleIndex = 6;
            // 
            // Duoc_Id
            // 
            this.Duoc_Id.Caption = "ID";
            this.Duoc_Id.FieldName = "Duoc_Id";
            this.Duoc_Id.Name = "Duoc_Id";
            this.Duoc_Id.OptionsColumn.AllowEdit = false;
            this.Duoc_Id.Width = 20;
            // 
            // CheckDate
            // 
            this.CheckDate.Caption = "CheckDate";
            this.CheckDate.FieldName = "CheckDate";
            this.CheckDate.Name = "CheckDate";
            this.CheckDate.OptionsColumn.AllowEdit = false;
            // 
            // CheckTonKho
            // 
            this.CheckTonKho.Caption = "CheckTonKho";
            this.CheckTonKho.FieldName = "CheckTonKho";
            this.CheckTonKho.Name = "CheckTonKho";
            this.CheckTonKho.OptionsColumn.AllowEdit = false;
            this.CheckTonKho.OptionsColumn.AllowShowHide = false;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnThoat);
            this.panelButton.Controls.Add(this.btnXoa);
            this.panelButton.Controls.Add(this.btnSua);
            this.panelButton.Controls.Add(this.btnThem);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButton.Location = new System.Drawing.Point(0, 0);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(851, 85);
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
            this.btnThoat.Location = new System.Drawing.Point(587, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 63);
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
            this.btnXoa.Location = new System.Drawing.Point(395, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(146, 63);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Cập nhật";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
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
            this.btnSua.Location = new System.Drawing.Point(205, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(149, 63);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Check Date";
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
            this.btnThem.Location = new System.Drawing.Point(12, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(144, 63);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Check Tồn Kho";
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
            // DuocTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 517);
            this.Controls.Add(this.pnMain);
            this.Name = "DuocTonKho";
            this.Text = "Dược tồn kho";
            this.Load += new System.EventHandler(this.DuocTonKho_Load);
            this.pnMain.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Panel pnGrid;
        private System.Windows.Forms.Panel panelButton;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaDuoc;
        private DevExpress.XtraGrid.Columns.GridColumn TenDuocDayDu;
        private DevExpress.XtraGrid.Columns.GridColumn TenHoatChat;
        private DevExpress.XtraGrid.Columns.GridColumn DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuongTon;
        private DevExpress.XtraGrid.Columns.GridColumn DonGia;
        private DevExpress.XtraGrid.Columns.GridColumn DateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn DonGiaVon;
        private DevExpress.XtraGrid.Columns.GridColumn TenLoaiDuoc;
        private DevExpress.XtraGrid.Columns.GridColumn Duoc_Id;
        private DevExpress.XtraGrid.Columns.GridColumn CheckDate;
        private DevExpress.XtraGrid.Columns.GridColumn CheckTonKho;
    }
}