﻿namespace KClinic2._1.View.HeThongBaoCao
{
    partial class BaoCaoDoanhThuPhongKham
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
            this.cbbDoiTuong = new Janus.Windows.EditControls.UIComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbNhanVien = new Janus.Windows.EditControls.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.txtDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.cbbDoiTuong);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.cbbNhanVien);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.btnXem);
            this.panelMain.Controls.Add(this.txtTuNgay);
            this.panelMain.Controls.Add(this.txtDenNgay);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Location = new System.Drawing.Point(45, 52);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(663, 384);
            this.panelMain.TabIndex = 18;
            // 
            // cbbDoiTuong
            // 
            this.cbbDoiTuong.AutoComplete = false;
            this.cbbDoiTuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDoiTuong.Location = new System.Drawing.Point(156, 144);
            this.cbbDoiTuong.Margin = new System.Windows.Forms.Padding(4);
            this.cbbDoiTuong.Name = "cbbDoiTuong";
            this.cbbDoiTuong.Size = new System.Drawing.Size(273, 30);
            this.cbbDoiTuong.Sorted = true;
            this.cbbDoiTuong.TabIndex = 34;
            this.cbbDoiTuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 22);
            this.label6.TabIndex = 33;
            this.label6.Text = "Đối tượng";
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.AutoComplete = false;
            this.cbbNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNhanVien.Location = new System.Drawing.Point(156, 194);
            this.cbbNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(273, 30);
            this.cbbNhanVien.Sorted = true;
            this.cbbNhanVien.TabIndex = 36;
            this.cbbNhanVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 35;
            this.label3.Text = "Nhân viên";
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
            this.btnXem.Location = new System.Drawing.Point(357, 282);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(120, 28);
            this.btnXem.TabIndex = 16;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            this.btnXem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
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
            this.txtTuNgay.Location = new System.Drawing.Point(156, 41);
            this.txtTuNgay.Margin = new System.Windows.Forms.Padding(4);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(273, 30);
            this.txtTuNgay.TabIndex = 13;
            this.txtTuNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
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
            this.txtDenNgay.Location = new System.Drawing.Point(156, 95);
            this.txtDenNgay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(273, 30);
            this.txtDenNgay.TabIndex = 15;
            this.txtDenNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
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
            // BaoCaoDoanhThuPhongKham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 487);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaoCaoDoanhThuPhongKham";
            this.Text = "Báo cáo doanh thu phòng khám";
            this.Load += new System.EventHandler(this.BaoCaoBNChiDinhDichVu_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private Janus.Windows.EditControls.UIComboBox cbbDoiTuong;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.EditControls.UIComboBox cbbNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private Janus.Windows.CalendarCombo.CalendarCombo txtTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo txtDenNgay;
        private System.Windows.Forms.Label label1;
    }
}