
namespace KClinic2._1.View.HeThongBaoCao
{
    partial class BaoCaoSuDungDichVuThe
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.txtSoThe = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.txtDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoThe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.txtSoThe);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.btnXem);
            this.panelMain.Controls.Add(this.txtTuNgay);
            this.panelMain.Controls.Add(this.txtDenNgay);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Location = new System.Drawing.Point(47, 51);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(473, 258);
            this.panelMain.TabIndex = 19;
            // 
            // txtSoThe
            // 
            this.txtSoThe.Location = new System.Drawing.Point(120, 148);
            this.txtSoThe.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoThe.Properties.Appearance.Options.UseFont = true;
            this.txtSoThe.Size = new System.Drawing.Size(273, 34);
            this.txtSoThe.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 22);
            this.label6.TabIndex = 33;
            this.label6.Text = "Số thẻ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Từ ngày";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(176, 205);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(120, 28);
            this.btnXem.TabIndex = 10;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.txtTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.txtTuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuNgay.IsNullDate = true;
            this.txtTuNgay.Location = new System.Drawing.Point(120, 44);
            this.txtTuNgay.Margin = new System.Windows.Forms.Padding(4);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(273, 30);
            this.txtTuNgay.TabIndex = 1;
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.txtDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.txtDenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenNgay.IsNullDate = true;
            this.txtDenNgay.Location = new System.Drawing.Point(120, 99);
            this.txtDenNgay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(273, 30);
            this.txtDenNgay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Đến ngày";
            // 
            // BaoCaoSuDungDichVuThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 340);
            this.Controls.Add(this.panelMain);
            this.Name = "BaoCaoSuDungDichVuThe";
            this.Text = "Báo cáo Sử Dụng Dịch Vụ Thẻ";
            this.Load += new System.EventHandler(this.BaoCaoSuDungDichVuThe_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoThe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private Janus.Windows.CalendarCombo.CalendarCombo txtTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo txtDenNgay;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSoThe;
    }
}