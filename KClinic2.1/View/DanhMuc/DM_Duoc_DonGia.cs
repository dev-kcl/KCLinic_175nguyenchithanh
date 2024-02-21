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

namespace KClinic2._1.View.DanhMuc
{
    public partial class DM_Duoc_DonGia : DevExpress.XtraEditors.XtraForm
    {
        public DM_Duoc_DonGia()
        {
            InitializeComponent();
        }

        private void DM_Duoc_DonGia_Load_1(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnPhatHanhGia.Enabled = true;
            CapNhat_DM_Duoc_DonGia();
            SelectDM_Duoc_DonGia();
        }
        public void CapNhat_DM_Duoc_DonGia()
        {
            DataTable CapNhat_DM_Duoc_DonGia = Model.dbDuoc.CapNhat_DM_Duoc_DonGia();
        }
        public void SelectDM_Duoc_DonGia()
        {
            DataTable SelectDM_Duoc_DonGia = Model.dbDuoc.SelectDM_Duoc_DonGia();
            gridDichVu.DataSource = SelectDM_Duoc_DonGia;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnPhatHanhGia.Enabled = false;
            CapNhat_DM_Duoc_DonGia();
            SelectDM_Duoc_DonGia();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
            for (int i = 0; i < gridDichVuDaTa.Rows.Count; i++)
            {
                string DonGiaThayDoi = "null";
                if (gridDichVuDaTa.Rows[i]["DonGiaThayDoi"].ToString() != "")
                { DonGiaThayDoi = "N'" + gridDichVuDaTa.Rows[i]["DonGiaThayDoi"].ToString().Replace("'", "''") + "'"; }
                string CongTiem = "null";
                if (gridDichVuDaTa.Rows[i]["CongTiem"].ToString() != "")
                { CongTiem = "N'" + gridDichVuDaTa.Rows[i]["CongTiem"].ToString().Replace("'", "''") + "'"; }

                DataTable UpdateDuoc_DonGia = Model.dbDuoc.UpdateDuoc_DonGia(
                     gridDichVuDaTa.Rows[i]["Duoc_DonGia_Id"].ToString()
                    , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                    , Login.User_Id
                    , DonGiaThayDoi
                    , CongTiem
                    );
            }
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnPhatHanhGia.Enabled = true;
            SelectDM_Duoc_DonGia();
            alertControl1.Show(this, "Thông báo", "Đã cập nhật thành công! ", "");
        }

        private void btnLamTuoi_Click_1(object sender, EventArgs e)
        {
            CapNhat_DM_Duoc_DonGia();
            SelectDM_Duoc_DonGia();
        }

        private void btnPhatHanhGia_Click_1(object sender, EventArgs e)
        {
            DataTable PhatHanhGia = Model.dbDuoc.PhatHanhGia("'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", Login.User_Id);
            alertControl1.Show(this, "Thông báo", "Đã Phát hành giá thành công! ", "");
            SelectDM_Duoc_DonGia();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnPhatHanhGia.Enabled = true;
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}