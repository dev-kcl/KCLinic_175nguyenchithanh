using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ExportListDataToExcelInCSharp;

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class BaoCaoXetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public BaoCaoXetNghiem()
        {
            InitializeComponent();
        }
        DataTable DuLieu;
        DataTable TenXetNghiem;
        DataTable PhongTuVan;
        private void BaoCaoXetNghiem_Load(object sender, EventArgs e)
        {
            //panelMain.Location = new Point(
            //this.ClientSize.Width / 2 - panelMain.Size.Width / 2,
            //this.ClientSize.Height / 2 - panelMain.Size.Height / 2);
            //panelMain.Anchor = AnchorStyles.None;


            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;

            PhongTuVan = Model.DbTiepNhan.CbbPhongTuVan();
            cbbPhongTuVan.DataSource = PhongTuVan;
            cbbPhongTuVan.ValueMember = "FieldCode";
            cbbPhongTuVan.DisplayMember = "FieldName";

            TenXetNghiem = Model.dbXetNghiem.CBBTenXetNghiem();
            cbbXetNghiem.DataSource = TenXetNghiem;
            cbbXetNghiem.ValueMember = "FieldCode";
            cbbXetNghiem.DisplayMember = "FieldName";
        }
        public void getDuLieu()
        {
            string TuNgay = "'" + txtTuNgay.Value.ToString("yyyyMMdd") + "'";
            string DenNgay = "'" + txtDenNgay.Value.ToString("yyyyMMdd") + "'";

            string PhongTuVan_ID = "null";
            if (cbbPhongTuVan.SelectedItem != null) { PhongTuVan_ID = cbbPhongTuVan.SelectedValue.ToString(); }

            string XetNghiem_Id = "null";
            if (cbbXetNghiem.SelectedItem != null) { XetNghiem_Id = cbbXetNghiem.Value.ToString(); }



            DuLieu = Model.dbBaoCao.SP_BaoCaoXetNghiem(TuNgay, DenNgay,PhongTuVan_ID,XetNghiem_Id,txtTenBenhNhan.Text,txtMaYTe.Text,txtSoTiepNhan.Text);
            string TrangThai = "1";
            if (DuLieu == null)
            {
                XtraMessageBox.Show("Không có dữ liệu");
                return;
            }
            if (DuLieu.Rows.Count == 0)
            {
                XtraMessageBox.Show("Không có dữ liệu");
                return;
            }
            for (int iColumns = 0; iColumns < DuLieu.Columns.Count; iColumns++)
            {
                TrangThai = "1";
                for (int iRow = 0; iRow < DuLieu.Rows.Count; iRow++)
                {
                    string DuLieuNull = DuLieu.Rows[iRow][iColumns].ToString();
                    if (DuLieuNull != "")
                    {
                        TrangThai = "2";
                        break;
                    }
                }
                if (TrangThai == "1")
                {
                    DuLieu.Columns.RemoveAt(iColumns);
                    iColumns--;
                }

            }
            DataColumn sttColumn = new DataColumn("STT", typeof(int));
            DuLieu.Columns.Add(sttColumn);
            sttColumn.SetOrdinal(0);
            for (int iRow = 0; iRow < DuLieu.Rows.Count; iRow++)
            {
                DuLieu.Rows[iRow]["STT"] = iRow + 1;
            }
            Dictionary<string, string> columnMappings = new Dictionary<string, string>
            {
            { "MaYTe", "Mã y tế" },
            { "TenBenhNhan", "Tên bệnh nhân" },
        // Add more mappings as needed
             };
            RenameHeaders(columnMappings);
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            getDuLieu();
            saveFileDialog1.Title = $"Báo cáo xét nghiệm";
            saveFileDialog1.FileName = $"Báo cáo xét nghiệm_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx";
            saveFileDialog1.Filter = "Excel Files|*.xlsx"; // Chỉ hiển thị các tệp Excel
            saveFileDialog1.FilterIndex = 1;
            var resultFile = saveFileDialog1.ShowDialog();
            if (resultFile == DialogResult.OK && saveFileDialog1.FileName != string.Empty)
            {
                XuatExcelXetNghiem.Run(DuLieu, saveFileDialog1.FileName);
                alertControl1.Show(this, "Thông báo", "Xuất Excel thành công");
            }
        }
        void RenameHeaders(Dictionary<string, string> columnMappings)
        {
            foreach (var mapping in columnMappings)
            {
                if (DuLieu.Columns.Contains(mapping.Key))
                {
                    DuLieu.Columns[mapping.Key].ColumnName = mapping.Value;
                }
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

        private void cbbXetNghiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbXetNghiem.Text;
                if (text == "")
                {
                    DataTable dtResult = TenXetNghiem.AsEnumerable()
                         .Where((row => row.Field<String>("FieldName").ToLower().Trim().Contains(text.ToLower().Trim())
                        || row.Field<String>("MaDichVu").ToLower().Trim().Contains(text.ToLower().Trim()))).CopyToDataTable();
                    cbbXetNghiem.DataSource = dtResult;
                    cbbXetNghiem.DroppedDown = true;
                }
                else
                {
                    if (TenXetNghiem.AsEnumerable()
                        .Where((row => row.Field<String>("FieldName").ToLower().Trim().Contains(text.ToLower().Trim())
                        || row.Field<String>("MaDichVu").ToLower().Trim().Contains(text.ToLower().Trim()))).Count() > 0)
                    {
                        DataTable dtResult = TenXetNghiem.AsEnumerable()
                        .Where((row => row.Field<String>("FieldName").ToLower().Trim().Contains(text.ToLower().Trim())
                        || row.Field<String>("MaDichVu").ToLower().Trim().Contains(text.ToLower().Trim()))).CopyToDataTable();
                        //DataTable dtResult = Dm_Duoc.Select("FieldName LIKE '%" + text + "%' or MaDuoc LIKE '%" + text + "%'").CopyToDataTable();
                        cbbXetNghiem.DataSource = dtResult;
                        cbbXetNghiem.DroppedDown = true;
                    }
                    else
                    {
                        cbbXetNghiem.DataSource = null;
                        cbbXetNghiem.DroppedDown = true;
                    }
                }
            }
        }

        private void cbbPhongTuVan_Click(object sender, EventArgs e)
        {
            cbbPhongTuVan.DataSource = PhongTuVan;
            cbbPhongTuVan.DroppedDown = true;
        }

        private void cbbXetNghiem_Click(object sender, EventArgs e)
        {
            cbbXetNghiem.DataSource = TenXetNghiem;
            cbbXetNghiem.DroppedDown = true;
        }

        private void Xem_Click(object sender, EventArgs e)
        {
            getDuLieu();
            gridView1.Columns.Clear();
            gridControl1.DataSource = DuLieu;
        }
    }
}