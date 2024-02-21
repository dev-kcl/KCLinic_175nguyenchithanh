
namespace KClinic2._1.View.HeThong
{
    partial class UserPhongBanKhoDuoc
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
            Janus.Windows.GridEX.GridEXLayout cbbUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPhongBanKhoDuoc));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbUser = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridControlPhongBan = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhongBan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhongBan_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhongBan)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1702, 839);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1702, 760);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gridControlPhongBan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1702, 760);
            this.panel4.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 49);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(219, 22);
            this.labelControl1.TabIndex = 55;
            this.labelControl1.Text = "Làm việc tại các Phòng Ban";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbUser);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.labelControl35);
            this.panel2.Controls.Add(this.btnThoat);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1702, 79);
            this.panel2.TabIndex = 0;
            // 
            // cbbUser
            // 
            cbbUser_DesignTimeLayout.LayoutString = resources.GetString("cbbUser_DesignTimeLayout.LayoutString");
            this.cbbUser.DesignTimeLayout = cbbUser_DesignTimeLayout;
            this.cbbUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbUser.Location = new System.Drawing.Point(444, 5);
            this.cbbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbUser.Name = "cbbUser";
            this.cbbUser.SelectedIndex = -1;
            this.cbbUser.SelectedItem = null;
            this.cbbUser.Size = new System.Drawing.Size(344, 34);
            this.cbbUser.TabIndex = 59;
            this.cbbUser.ValueChanged += new System.EventHandler(this.cbbUser_ValueChanged);
            // 
            // labelControl35
            // 
            this.labelControl35.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl35.Appearance.Options.UseFont = true;
            this.labelControl35.Location = new System.Drawing.Point(276, 15);
            this.labelControl35.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl35.Name = "labelControl35";
            this.labelControl35.Size = new System.Drawing.Size(147, 22);
            this.labelControl35.TabIndex = 54;
            this.labelControl35.Text = "Tên người sử dụng";
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
            this.btnThoat.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Location = new System.Drawing.Point(964, 5);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(142, 38);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
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
            this.btnLuu.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.Location = new System.Drawing.Point(827, 4);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 38);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
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
            // gridControlPhongBan
            // 
            this.gridControlPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPhongBan.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlPhongBan.Location = new System.Drawing.Point(0, 0);
            this.gridControlPhongBan.MainView = this.gridViewPhongBan;
            this.gridControlPhongBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlPhongBan.Name = "gridControlPhongBan";
            this.gridControlPhongBan.Size = new System.Drawing.Size(1702, 760);
            this.gridControlPhongBan.TabIndex = 59;
            this.gridControlPhongBan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhongBan});
            // 
            // gridViewPhongBan
            // 
            this.gridViewPhongBan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaPhongBan,
            this.TenPhongBan,
            this.PhongBan_Id});
            this.gridViewPhongBan.DetailHeight = 431;
            this.gridViewPhongBan.GridControl = this.gridControlPhongBan;
            this.gridViewPhongBan.Name = "gridViewPhongBan";
            this.gridViewPhongBan.OptionsSelection.MultiSelect = true;
            this.gridViewPhongBan.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // MaPhongBan
            // 
            this.MaPhongBan.Caption = "Mã Phòng Ban";
            this.MaPhongBan.FieldName = "MaPhongBan";
            this.MaPhongBan.MinWidth = 23;
            this.MaPhongBan.Name = "MaPhongBan";
            this.MaPhongBan.Visible = true;
            this.MaPhongBan.VisibleIndex = 1;
            this.MaPhongBan.Width = 117;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.Caption = "Tên Phòng Ban";
            this.TenPhongBan.FieldName = "TenPhongBan";
            this.TenPhongBan.MinWidth = 23;
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.Visible = true;
            this.TenPhongBan.VisibleIndex = 2;
            this.TenPhongBan.Width = 264;
            // 
            // PhongBan_Id
            // 
            this.PhongBan_Id.Caption = "PhongBan_Id";
            this.PhongBan_Id.MinWidth = 23;
            this.PhongBan_Id.Name = "PhongBan_Id";
            this.PhongBan_Id.Width = 87;
            // 
            // UserPhongBanKhoDuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1702, 839);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserPhongBanKhoDuoc";
            this.Text = "UserPhongBanKhoDuoc";
            this.Load += new System.EventHandler(this.UserPhongBanKhoDuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhongBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cbbUser;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private DevExpress.XtraGrid.GridControl gridControlPhongBan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn MaPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn TenPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn PhongBan_Id;
    }
}