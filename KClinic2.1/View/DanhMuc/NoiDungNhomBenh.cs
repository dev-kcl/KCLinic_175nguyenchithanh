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
    public partial class NoiDungNhomBenh : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public NoiDungNhomBenh()
        {
            InitializeComponent();
        }

        private void NoiDungNhomBenh_Load(object sender, EventArgs e)
        {
            DataTable CBBNhomBenh = Model.dbDanhMuc.CBBNhomBenh();
            cbbNhomBenh.DataSource = CBBNhomBenh;
            cbbNhomBenh.ValueMember = "FieldCode";
            cbbNhomBenh.DisplayMember = "FieldName";
            cbbNhomBenh.SelectedIndex = 0;
            DataTable SelectNoiDungNhomBenh = Model.dbDanhMuc.SelectNoiDungNhomBenh();
            gridDichVu.DataSource = SelectNoiDungNhomBenh;
            DataTable CBBDichVuNoiDungNhomBenh = Model.dbDanhMuc.CBBDichVuNoiDungNhomBenh();
            cbbDichVu.DataSource = CBBDichVuNoiDungNhomBenh;
            cbbDichVu.ValueMember = "FieldCode";
            cbbDichVu.DisplayMember = "FieldName";
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            An();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            Hien();
            ThaoTac = "Them";
            DM_Id = "";
            Reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            Hien();
            ThaoTac = "Sua";
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string NhomBenh_Id = "null";
            if (cbbNhomBenh.SelectedItem != null) { NhomBenh_Id = cbbNhomBenh.SelectedValue.ToString(); }
            string DichVu_Id = "null";
            if (cbbDichVu.SelectedItem != null) { DichVu_Id = cbbDichVu.SelectedValue.ToString(); }

            if (NhomBenh_Id == "null")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Nhóm Bệnh!", "");
            }
            else if (DichVu_Id == "null")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Dịch vụ!", "");
            }
            else
            {
                if (ThaoTac == "Them")
                {
                    DataTable CheckDichVuNoiDungNhomBenh = Model.dbDanhMuc.CheckDichVuNoiDungNhomBenh(DichVu_Id, NhomBenh_Id);
                    if (CheckDichVuNoiDungNhomBenh.Rows.Count > 0)
                    {
                        if (CheckDichVuNoiDungNhomBenh.Rows[0]["SoLuong"].ToString() == "0")
                        {
                            DataTable Insert = Model.dbDanhMuc.InsertNoiDungNhomBenh(
                                NhomBenh_Id
                                , DichVu_Id
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                );
                            if (Insert.Rows.Count > 0)
                            {
                                DM_Id = Insert.Rows[0][0].ToString();
                                alertControl1.Show(this, "Thông báo", "Đã thêm thành công!", "");
                            }
                            //
                            btnThem.Enabled = true;
                            btnSua.Enabled = true;
                            btnLuu.Enabled = false;
                            btnHuy.Enabled = false;
                            btnXoa.Enabled = true;
                            An();
                            DataTable SelectNoiDungNhomBenh = Model.dbDanhMuc.SelectNoiDungNhomBenh();
                            gridDichVu.DataSource = SelectNoiDungNhomBenh;
                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Dịch vụ này đã gán vào nhóm bệnh được chọn. Vui lòng kiểm tra lại!", "");
                        }
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateNoiDungNhomBenh(
                         NhomBenh_Id
                        , DichVu_Id
                        , "null"
                        , "null"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , "0"
                        , DM_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0][0].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công!", "");
                    }
                    //
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    btnXoa.Enabled = true;
                    An();
                    DataTable SelectNoiDungNhomBenh = Model.dbDanhMuc.SelectNoiDungNhomBenh();
                    gridDichVu.DataSource = SelectNoiDungNhomBenh;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            An();
            if (ThaoTac == "Them")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                DM_Id = "";
            }
            else if (ThaoTac == "Sua")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string nguoicapnhat = Login.User_Id;
            DialogResult dr = MessageBox.Show("Bạn có đồng ý xóa?",
            "Thong Bao!", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    btnXoa.Enabled = false;
                    An();
                    //
                    DataTable Delete = Model.dbDanhMuc.DeleteNoiDungNhomBenh(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectNoiDungNhomBenh = Model.dbDanhMuc.SelectNoiDungNhomBenh();
                    gridDichVu.DataSource = SelectNoiDungNhomBenh;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công!", "");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadThongTinForm()
        {
            DataTable SelectNoiDungNhomBenhTheoID = Model.dbDanhMuc.SelectNoiDungNhomBenhTheoID(DM_Id);
            {
                if (SelectNoiDungNhomBenhTheoID != null)
                {
                    if (SelectNoiDungNhomBenhTheoID.Rows.Count > 0)
                    {
                        string NhomBenh_Id = SelectNoiDungNhomBenhTheoID.Rows[0]["NhomBenh_Id"].ToString();
                        if (!String.IsNullOrEmpty(NhomBenh_Id))
                        {
                            cbbNhomBenh.SelectedValue = Int32.Parse(NhomBenh_Id);
                        }
                        string DichVu_Id = SelectNoiDungNhomBenhTheoID.Rows[0]["DichVu_Id"].ToString();
                        if (!String.IsNullOrEmpty(DichVu_Id))
                        {
                            cbbDichVu.SelectedValue = Int32.Parse(DichVu_Id);
                        }
                    }
                }
            }
        }
        public void Hien()
        {
            cbbNhomBenh.Enabled = true;
            cbbDichVu.Enabled = true;
        }
        public void An()
        {
            cbbNhomBenh.Enabled = false;
            cbbDichVu.Enabled = false;
        }
        public void Reset()
        {
            cbbNhomBenh.SelectedIndex = 0;
            cbbDichVu.Text = "";
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                DM_Id = gridView1.GetRowCellValue(n, "MapNhomBenhDichVu_Id").ToString();
                DataTable SelectNoiDungNhomBenhTheoID = Model.dbDanhMuc.SelectNoiDungNhomBenhTheoID(DM_Id);
                {
                    if (SelectNoiDungNhomBenhTheoID != null)
                    {
                        if (SelectNoiDungNhomBenhTheoID.Rows.Count > 0)
                        {
                            string NhomBenh_Id = SelectNoiDungNhomBenhTheoID.Rows[0]["NhomBenh_Id"].ToString();
                            if (!String.IsNullOrEmpty(NhomBenh_Id))
                            {
                                cbbNhomBenh.SelectedValue = Int32.Parse(NhomBenh_Id);
                            }
                            string DichVu_Id = SelectNoiDungNhomBenhTheoID.Rows[0]["DichVu_Id"].ToString();
                            if (!String.IsNullOrEmpty(DichVu_Id))
                            {
                                cbbDichVu.SelectedValue = Int32.Parse(DichVu_Id);
                            }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                        }
                    }
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
    }
}