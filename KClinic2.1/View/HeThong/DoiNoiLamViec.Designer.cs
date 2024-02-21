namespace KClinic2._1.View.HeThong
{
    partial class DoiNoiLamViec
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
            Janus.Windows.GridEX.GridEXLayout cbbNoilamViec_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiNoiLamViec));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cbbNoilamViec = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbNoilamViec)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 484);
            this.panel1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl2.Controls.Add(this.cbbNoilamViec);
            this.panelControl2.Controls.Add(this.btnHuy);
            this.panelControl2.Controls.Add(this.btnXacNhan);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(126, 92);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(374, 270);
            this.panelControl2.TabIndex = 3;
            // 
            // cbbNoilamViec
            // 
            this.cbbNoilamViec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNoilamViec.AutoComplete = false;
            this.cbbNoilamViec.BackColor = System.Drawing.Color.White;
            this.cbbNoilamViec.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.cbbNoilamViec.ColorScheme = "";
            cbbNoilamViec_DesignTimeLayout.LayoutString = resources.GetString("cbbNoilamViec_DesignTimeLayout.LayoutString");
            this.cbbNoilamViec.DesignTimeLayout = cbbNoilamViec_DesignTimeLayout;
            this.cbbNoilamViec.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(209)))), ((int)(((byte)(55)))));
            this.cbbNoilamViec.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbbNoilamViec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cbbNoilamViec.Location = new System.Drawing.Point(108, 61);
            this.cbbNoilamViec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbNoilamViec.Name = "cbbNoilamViec";
            this.cbbNoilamViec.SelectedIndex = -1;
            this.cbbNoilamViec.SelectedItem = null;
            this.cbbNoilamViec.Size = new System.Drawing.Size(254, 22);
            this.cbbNoilamViec.TabIndex = 8;
            // 
            // btnHuy
            // 
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Location = new System.Drawing.Point(211, 138);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(146, 47);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXacNhan.ImageOptions.SvgImage")));
            this.btnXacNhan.Location = new System.Drawing.Point(30, 138);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(146, 47);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 66);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nơi làm việc";
            // 
            // DoiNoiLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 484);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DoiNoiLamViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi nơi làm việc";
            this.Load += new System.EventHandler(this.DoiNoiLamViec_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbNoilamViec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cbbNoilamViec;
    }
}