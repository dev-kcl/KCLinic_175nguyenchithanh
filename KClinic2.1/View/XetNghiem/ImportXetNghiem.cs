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

namespace KClinic2._1.View.XetNghiem
{
    public partial class ImportXetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public string TiepNhan_Id;
        public string BenhNhan_Id;
        public ImportXetNghiem()
        {
            InitializeComponent();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            //this.openFileDialog1.Filter = "File (*.pdf)|*.pdf|" + "All files (*.*)|*.*";
            //                   ^  ^  ^  ^  ^  ^ 
            this.openFileDialog1.Filter = "File (*.pdf)|*.pdf";
            this.openFileDialog1.Title = "My File Browser";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    pdfViewer1.LoadDocument(file);
                    //string filename = System.IO.Path.GetFileName(file);
                    lbTenFile.Text = file;
                }
            }
            btnUpload.Enabled = true;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DataTable DuongDanFile = Model.db.DuongDanFile();
            //pdfViewer1.SaveDocument(DuongDanFile.Rows[0][0].ToString() + "");
            string File = "XN_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
            pdfViewer1.SaveDocument(DuongDanFile.Rows[0][0].ToString() + File);
            DataTable InsertXetnghiemFile = Model.db.InsertXetnghiemFile(
                TiepNhan_Id
                ,BenhNhan_Id
                , "N'" + File + "'"
                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                , Login.User_Id
                );
            alertControl1.Show(this, "Thông báo", "Đã tải file thành công cho bệnh nhân " + txtTenBenhNhan.Text + "!", "");
            TiepNhan_Id = "";
            BenhNhan_Id = "";
            lbTenFile.Text = "";
            txtMaYTe.Text = "";
            txtTenBenhNhan.Text = "";
            btnUpload.Enabled = false;
            
        }

        private void ImportXetNghiem_Load(object sender, EventArgs e)
        {
            TiepNhan_Id = "";
            BenhNhan_Id = "";
            lbTenFile.Text = "";
            btnUpload.Enabled = false;
        }
        public void LoadThongTinBenhNhanDaTiepNhan()
        {
            DataTable LoadThongTinBenhNhanDaTiepNhan = Model.DbTiepNhan.LoadThongTinBenhNhanDaTiepNhan(TiepNhan_Id);
            if (LoadThongTinBenhNhanDaTiepNhan.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhanDaTiepNhan.Rows[0]["MaYTe"].ToString();
                txtTenBenhNhan.Text = LoadThongTinBenhNhanDaTiepNhan.Rows[0]["TenBenhNhan"].ToString();
                BenhNhan_Id = LoadThongTinBenhNhanDaTiepNhan.Rows[0]["BenhNhan_Id"].ToString();
                TiepNhan_Id = LoadThongTinBenhNhanDaTiepNhan.Rows[0]["TiepNhan_Id"].ToString();
            }
        }
        private void btn_S_Click(object sender, EventArgs e)
        {
            View.XetNghiem.TimKiemBenhNhanImport tc = new View.XetNghiem.TimKiemBenhNhanImport(this);
            tc.ShowDialog();
        }

        private void txtSoTiepNhan_TextChanged(object sender, EventArgs e)
        {

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