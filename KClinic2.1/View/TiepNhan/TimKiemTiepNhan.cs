﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace KClinic2._1.View.TiepNhan
{
    public partial class TimKiemTiepNhan : DevExpress.XtraEditors.XtraForm
    {
        TiepNhan tn;
        public TimKiemTiepNhan(TiepNhan tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemTiepNhan_Load(object sender, EventArgs e)
        {

            DataTable PhongTuVan = Model.DbTiepNhan.CbbPhongTuVan();
            cbbPhongTuVan.DataSource = PhongTuVan;
            cbbPhongTuVan.ValueMember = "FieldCode";
            cbbPhongTuVan.DisplayMember = "FieldName";
            //cbbPhongTuVan.SelectedValue = "4";

            dtmTuNgay.Focus();

            DataTable Search_TiepNhan = Model.db.Search_TiepNhanPhongTuVan( txtSoTiepNhan.Text, dtmTuNgay.Value, dtmDenNgay.Value, txtMaYTe.Text,txtTenBN.Text, txtNamSinh.Text,txtSDT.Text, "null");
            gridDS.DataSource = Search_TiepNhan;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string phongtuvan = "null";
            if (cbbPhongTuVan.SelectedValue != null || cbbPhongTuVan.Text != "")
            {
                phongtuvan = cbbPhongTuVan.SelectedValue.ToString();
            }

            DataTable Search_TiepNhan = Model.db.Search_TiepNhanPhongTuVan(txtSoTiepNhan.Text, dtmTuNgay.Value, dtmDenNgay.Value, txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, phongtuvan);
            gridDS.DataSource = Search_TiepNhan;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string phongtuvan = "null";
                if (cbbPhongTuVan.SelectedValue != null || cbbPhongTuVan.Text != "")
                {
                    phongtuvan = cbbPhongTuVan.SelectedValue.ToString();
                }

                DataTable Search_TiepNhan = Model.db.Search_TiepNhanPhongTuVan(txtSoTiepNhan.Text, dtmTuNgay.Value, dtmDenNgay.Value, txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, phongtuvan);
                gridDS.DataSource = Search_TiepNhan;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                tn.TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
                tn.LoadThongTinBenhNhanDaTiepNhanButton();
                tn.LoadThongTinBenhNhanDaTiepNhan();
                this.Hide();
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void MoveFocusToPreviousTextbox()
        {
            Control currentControl = this.ActiveControl;

            Control[] controls = this.Controls.Cast<Control>().ToArray();

            int currentIndex = Array.IndexOf(controls, currentControl);
            int previousIndex = (currentIndex - 1 + controls.Length) % controls.Length;

            controls[previousIndex].Focus();
        }
    }
}