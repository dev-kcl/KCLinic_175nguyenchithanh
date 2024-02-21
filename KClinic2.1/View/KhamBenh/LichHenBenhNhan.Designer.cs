namespace KClinic2._1.View.KhamBenh
{
    partial class LichHenBenhNhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichHenBenhNhan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.HenTaiKham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaYTe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBenhNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KhamBenh_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BenhNhan_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TiepNhan_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NoiDungHenTaiKham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Zalo_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DaGui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThoiGianGui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSendZalo = new DevExpress.XtraEditors.SimpleButton();
            this.cbbLoai = new Janus.Windows.EditControls.UIComboBox();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).BeginInit();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1497, 556);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridDichVu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1497, 433);
            this.panel3.TabIndex = 1;
            // 
            // gridDichVu
            // 
            this.gridDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDichVu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridDichVu.Location = new System.Drawing.Point(0, 0);
            this.gridDichVu.MainView = this.gridView1;
            this.gridDichVu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridDichVu.Name = "gridDichVu";
            this.gridDichVu.Size = new System.Drawing.Size(1497, 433);
            this.gridDichVu.TabIndex = 45;
            this.gridDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.HenTaiKham,
            this.MaYTe,
            this.TenBenhNhan,
            this.KhamBenh_Id,
            this.BenhNhan_Id,
            this.TiepNhan_Id,
            this.Tuoi,
            this.SoDienThoai,
            this.NoiDungHenTaiKham,
            this.Zalo_Id,
            this.DaGui,
            this.ThoiGianGui});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridDichVu;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // HenTaiKham
            // 
            this.HenTaiKham.Caption = "Hẹn tái khám";
            this.HenTaiKham.FieldName = "HenTaiKham";
            this.HenTaiKham.MinWidth = 27;
            this.HenTaiKham.Name = "HenTaiKham";
            this.HenTaiKham.OptionsColumn.AllowEdit = false;
            this.HenTaiKham.Visible = true;
            this.HenTaiKham.VisibleIndex = 1;
            this.HenTaiKham.Width = 213;
            // 
            // MaYTe
            // 
            this.MaYTe.Caption = "Mã y tế";
            this.MaYTe.FieldName = "MaYTe";
            this.MaYTe.MinWidth = 27;
            this.MaYTe.Name = "MaYTe";
            this.MaYTe.OptionsColumn.AllowEdit = false;
            this.MaYTe.Visible = true;
            this.MaYTe.VisibleIndex = 3;
            this.MaYTe.Width = 116;
            // 
            // TenBenhNhan
            // 
            this.TenBenhNhan.Caption = "Tên bệnh nhân";
            this.TenBenhNhan.FieldName = "TenBenhNhan";
            this.TenBenhNhan.MinWidth = 27;
            this.TenBenhNhan.Name = "TenBenhNhan";
            this.TenBenhNhan.OptionsColumn.AllowEdit = false;
            this.TenBenhNhan.Visible = true;
            this.TenBenhNhan.VisibleIndex = 2;
            this.TenBenhNhan.Width = 199;
            // 
            // KhamBenh_Id
            // 
            this.KhamBenh_Id.Caption = "KhamBenh_Id";
            this.KhamBenh_Id.FieldName = "KhamBenh_Id";
            this.KhamBenh_Id.MinWidth = 27;
            this.KhamBenh_Id.Name = "KhamBenh_Id";
            this.KhamBenh_Id.Width = 100;
            // 
            // BenhNhan_Id
            // 
            this.BenhNhan_Id.Caption = "BenhNhan_Id";
            this.BenhNhan_Id.FieldName = "BenhNhan_Id";
            this.BenhNhan_Id.MinWidth = 27;
            this.BenhNhan_Id.Name = "BenhNhan_Id";
            this.BenhNhan_Id.Width = 100;
            // 
            // TiepNhan_Id
            // 
            this.TiepNhan_Id.Caption = "TiepNhan_Id";
            this.TiepNhan_Id.FieldName = "TiepNhan_Id";
            this.TiepNhan_Id.MinWidth = 27;
            this.TiepNhan_Id.Name = "TiepNhan_Id";
            this.TiepNhan_Id.Width = 100;
            // 
            // Tuoi
            // 
            this.Tuoi.Caption = "Tuổi";
            this.Tuoi.FieldName = "Tuoi";
            this.Tuoi.MinWidth = 27;
            this.Tuoi.Name = "Tuoi";
            this.Tuoi.OptionsColumn.AllowEdit = false;
            this.Tuoi.Visible = true;
            this.Tuoi.VisibleIndex = 4;
            this.Tuoi.Width = 79;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.Caption = "Số điện thoại";
            this.SoDienThoai.FieldName = "SoDienThoai";
            this.SoDienThoai.MinWidth = 27;
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.OptionsColumn.AllowEdit = false;
            this.SoDienThoai.Visible = true;
            this.SoDienThoai.VisibleIndex = 5;
            this.SoDienThoai.Width = 139;
            // 
            // NoiDungHenTaiKham
            // 
            this.NoiDungHenTaiKham.Caption = "Nội dung hẹn";
            this.NoiDungHenTaiKham.FieldName = "NoiDungHenTaiKham";
            this.NoiDungHenTaiKham.MinWidth = 27;
            this.NoiDungHenTaiKham.Name = "NoiDungHenTaiKham";
            this.NoiDungHenTaiKham.Visible = true;
            this.NoiDungHenTaiKham.VisibleIndex = 6;
            this.NoiDungHenTaiKham.Width = 267;
            // 
            // Zalo_Id
            // 
            this.Zalo_Id.Caption = "Zalo_Id";
            this.Zalo_Id.FieldName = "Zalo_Id";
            this.Zalo_Id.MinWidth = 27;
            this.Zalo_Id.Name = "Zalo_Id";
            this.Zalo_Id.OptionsColumn.AllowEdit = false;
            this.Zalo_Id.Visible = true;
            this.Zalo_Id.VisibleIndex = 7;
            this.Zalo_Id.Width = 157;
            // 
            // DaGui
            // 
            this.DaGui.Caption = "Trạng thái";
            this.DaGui.FieldName = "DaGui";
            this.DaGui.MinWidth = 27;
            this.DaGui.Name = "DaGui";
            this.DaGui.OptionsColumn.AllowEdit = false;
            this.DaGui.Visible = true;
            this.DaGui.VisibleIndex = 8;
            this.DaGui.Width = 157;
            // 
            // ThoiGianGui
            // 
            this.ThoiGianGui.Caption = "Thời gian gửi";
            this.ThoiGianGui.FieldName = "ThoiGianGui";
            this.ThoiGianGui.MinWidth = 27;
            this.ThoiGianGui.Name = "ThoiGianGui";
            this.ThoiGianGui.OptionsColumn.AllowEdit = false;
            this.ThoiGianGui.Visible = true;
            this.ThoiGianGui.VisibleIndex = 9;
            this.ThoiGianGui.Width = 188;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSendZalo);
            this.panel2.Controls.Add(this.cbbLoai);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1497, 123);
            this.panel2.TabIndex = 0;
            // 
            // btnSendZalo
            // 
            this.btnSendZalo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendZalo.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.btnSendZalo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSendZalo.Appearance.Options.UseBorderColor = true;
            this.btnSendZalo.Appearance.Options.UseFont = true;
            this.btnSendZalo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSendZalo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSendZalo.ImageOptions.SvgImage")));
            this.btnSendZalo.Location = new System.Drawing.Point(1275, 68);
            this.btnSendZalo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendZalo.Name = "btnSendZalo";
            this.btnSendZalo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSendZalo.Size = new System.Drawing.Size(207, 37);
            this.btnSendZalo.TabIndex = 48;
            this.btnSendZalo.Text = "Gửi Zalo thủ công";
            this.btnSendZalo.Click += new System.EventHandler(this.btnSendZalo_Click);
            // 
            // cbbLoai
            // 
            this.cbbLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoai.Location = new System.Drawing.Point(295, 30);
            this.cbbLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbLoai.Name = "cbbLoai";
            this.cbbLoai.Size = new System.Drawing.Size(352, 30);
            this.cbbLoai.TabIndex = 31;
            this.cbbLoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(655, 73);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 32);
            this.btnTimKiem.TabIndex = 30;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(295, 73);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(351, 30);
            this.txtTimKiem.TabIndex = 29;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(175, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 22);
            this.label5.TabIndex = 28;
            this.label5.Text = "Nội dung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(175, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "Loại";
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
            // LichHenBenhNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 556);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LichHenBenhNhan";
            this.Text = "Lịch hẹn bệnh nhân";
            this.Load += new System.EventHandler(this.LichHenBenhNhan_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaYTe;
        private DevExpress.XtraGrid.Columns.GridColumn KhamBenh_Id;
        private DevExpress.XtraGrid.Columns.GridColumn BenhNhan_Id;
        private Janus.Windows.EditControls.UIComboBox cbbLoai;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnSendZalo;
        private DevExpress.XtraGrid.Columns.GridColumn HenTaiKham;
        private DevExpress.XtraGrid.Columns.GridColumn TenBenhNhan;
        private DevExpress.XtraGrid.Columns.GridColumn TiepNhan_Id;
        private DevExpress.XtraGrid.Columns.GridColumn Tuoi;
        private DevExpress.XtraGrid.Columns.GridColumn SoDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn Zalo_Id;
        private DevExpress.XtraGrid.Columns.GridColumn DaGui;
        private DevExpress.XtraGrid.Columns.GridColumn ThoiGianGui;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraGrid.Columns.GridColumn NoiDungHenTaiKham;
    }
}