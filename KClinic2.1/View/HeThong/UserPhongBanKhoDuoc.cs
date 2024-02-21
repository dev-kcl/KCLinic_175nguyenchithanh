using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.View.HeThong
{
    public partial class UserPhongBanKhoDuoc : DevExpress.XtraEditors.XtraForm
    {
        public string User_Id = "null";
        public UserPhongBanKhoDuoc()
        {
            InitializeComponent();
        }
        DataTable CBBUser_PhongKham;
        private void UserPhongBanKhoDuoc_Load(object sender, EventArgs e)
        {
            CBBUser_PhongKham = Model.dbDanhMuc.CBBUser_PhongKham();
            cbbUser.DataSource = CBBUser_PhongKham;
            cbbUser.ValueMember = "FieldCode";
            cbbUser.DisplayMember = "FieldName";
            btnLuu.Enabled = false;

            // Allow editing of the Grade column
            //gridView2.OptionsBehavior.Editable = true;
        }

        private void cbbUser_ValueChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            //string User = "null";
            if (cbbUser.SelectedItem != null) { User_Id = cbbUser.Value.ToString().Replace("'", "''"); }
            DataTable SelectPhongBanTheoIdUser = Model.db.SelectPhongBanTheoIdUser(User_Id);
            gridViewPhongBan.OptionsSelection.MultiSelect = true;
            gridViewPhongBan.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            SelectPhongBanTheoIdUser.Columns.Add(new DataColumn("checkPhongbanBoolean", typeof(bool)) { DefaultValue = false });
            foreach (DataRow row in SelectPhongBanTheoIdUser.Rows)
            {
                row["checkPhongbanBoolean"] = int.Parse(row["checkPhongban"].ToString()) == 1 ? true : false;
            }
            gridControlPhongBan.DataSource = SelectPhongBanTheoIdUser;
            gridViewPhongBan.OptionsSelection.CheckBoxSelectorField = "checkPhongbanBoolean";

            




        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Model.db.DelelePhanQuyenPhongBanTheoIdUser(User_Id);
           
            Int32[] selectedRowHandlesPhongBan = gridViewPhongBan.GetSelectedRows();
            




            for (int i = 0; i < selectedRowHandlesPhongBan.Length; i++)
            {

                int selectedRowHandle = selectedRowHandlesPhongBan[i];
                string k = gridViewPhongBan.GetRowCellValue(selectedRowHandle, "PhongBan_Id").ToString();
                if (selectedRowHandle >= 0)
                {
                    Model.db.InsertPhanQuyenIdUserPhongBan(User_Id, gridViewPhongBan.GetRowCellValue(selectedRowHandle, "PhongBan_Id").ToString());
                }
            }

           
            alertControl1.Show(this, "Thông báo", "Cập nhật phân quyền thành công ", "");


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}