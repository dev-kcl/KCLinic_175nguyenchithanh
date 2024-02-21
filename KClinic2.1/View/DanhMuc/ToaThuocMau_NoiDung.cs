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
    public partial class ToaThuocMau_NoiDung : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public ToaThuocMau_NoiDung()
        {
            InitializeComponent();
        }
        DataTable CBBDuocNoiDungToaThuocMau;
        private void ToaThuocMau_NoiDung_Load(object sender, EventArgs e)
        {
            DataTable CBBToaThuocMau = Model.dbDanhMuc.CBBToaThuocMau();
            cbbToaThuocMau.DataSource = CBBToaThuocMau;
            cbbToaThuocMau.ValueMember = "FieldCode";
            cbbToaThuocMau.DisplayMember = "FieldName";
            cbbToaThuocMau.SelectedIndex = 0;
            DataTable SelectNoiDungToaThuocMau = Model.dbDanhMuc.SelectNoiDungToaThuocMau();
            gridDichVu.DataSource = SelectNoiDungToaThuocMau;
            getform();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            An();
        }
        void getform()
        {
            CBBDuocNoiDungToaThuocMau = Model.dbDanhMuc.CBBDuocNoiDungToaThuocMau();
            cbbDuoc.DataSource = CBBDuocNoiDungToaThuocMau;
            cbbDuoc.ValueMember = "FieldCode";
            cbbDuoc.DisplayMember = "FieldName";
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
            string ToaThuocMau_Id = "null";
            if (cbbToaThuocMau.SelectedItem != null) { ToaThuocMau_Id = cbbToaThuocMau.SelectedValue.ToString(); }
            string Duoc_Id = "null";
            if (cbbDuoc.SelectedItem != null) { Duoc_Id = cbbDuoc.SelectedValue.ToString(); }
            string Sang = "null";
            if (txtSang.Text != "") { Sang = "N'" + txtSang.Text + "'"; }
            string Trua = "null";
            if (txtTrua.Text != "") { Trua = "N'" + txtTrua.Text + "'"; ; }
            string Chieu = "null";
            if (txtChieu.Text != "") { Chieu = "N'" + txtChieu.Text + "'"; ; }
            string Toi = "null";
            if (txtToi.Text != "") { Toi = "N'" + txtToi.Text + "'"; ; }
            string SoNgay = "null";
            if (txtSoNgay.Text != "") { SoNgay = "N'" + txtSoNgay.Text + "'"; ; }
            string SoLuong = "null";
            if (txtSoLuong.Text != "") { SoLuong = "N'" + txtSoLuong.Text + "'"; ; }

            if (ToaThuocMau_Id == "null")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn toa thuốc mẫu!", "");
            }
            else if (Duoc_Id == "null")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn dược!", "");
            }
            else if (SoLuong == "null")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa nhập số lượng!", "");
            }
            else
            {
                if (ThaoTac == "Them")
                {
                    DataTable CheckDuocNoiDungToaThuocMau = Model.dbDanhMuc.CheckDuocNoiDungToaThuocMau(Duoc_Id, ToaThuocMau_Id);
                    if (CheckDuocNoiDungToaThuocMau.Rows.Count > 0)
                    {
                        if (CheckDuocNoiDungToaThuocMau.Rows[0]["SoLuong"].ToString() == "0")
                        {
                            DataTable Insert = Model.dbDanhMuc.InsertNoiDungToaThuocMau(
                                ToaThuocMau_Id
                                , Duoc_Id
                                , SoLuong
                                , SoNgay
                                , Sang
                                , Trua
                                , Chieu
                                , Toi
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
                            DataTable SelectNoiDungToaThuocMau = Model.dbDanhMuc.SelectNoiDungToaThuocMau();
                            gridDichVu.DataSource = SelectNoiDungToaThuocMau;
                            getform();
                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Dược này đã gán vào toa thuốc mẫu được chọn. Vui lòng kiểm tra lại!", "");
                        }
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateNoiDungToaThuocMau(
                        ToaThuocMau_Id
                        , Duoc_Id
                        , SoLuong
                        , SoNgay
                        , Sang
                        , Trua
                        , Chieu
                        , Toi
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
                    DataTable SelectNoiDungToaThuocMau = Model.dbDanhMuc.SelectNoiDungToaThuocMau();
                    gridDichVu.DataSource = SelectNoiDungToaThuocMau;
                    getform();
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
            getform();
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
                    DataTable Delete = Model.dbDanhMuc.DeleteNoiDungToaThuocMau(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectNoiDungToaThuocMau = Model.dbDanhMuc.SelectNoiDungToaThuocMau();
                    gridDichVu.DataSource = SelectNoiDungToaThuocMau;
                    getform();
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            getform();
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                DM_Id = gridView1.GetRowCellValue(n, "MapToaThuocMauVoiDuoc_Id").ToString();
                DataTable SelectNoiDungToaThuocMauTheoID = Model.dbDanhMuc.SelectNoiDungToaThuocMauTheoID(DM_Id);
                {
                    if (SelectNoiDungToaThuocMauTheoID != null)
                    {
                        if (SelectNoiDungToaThuocMauTheoID.Rows.Count > 0)
                        {
                            string ToaThuocMau_Id = SelectNoiDungToaThuocMauTheoID.Rows[0]["ToaThuocMau_Id"].ToString();
                            if (!String.IsNullOrEmpty(ToaThuocMau_Id))
                            {
                                cbbToaThuocMau.SelectedValue = Int32.Parse(ToaThuocMau_Id);
                            }
                            string Duoc_Id = SelectNoiDungToaThuocMauTheoID.Rows[0]["Duoc_Id"].ToString();
                            if (!String.IsNullOrEmpty(Duoc_Id))
                            {
                                cbbDuoc.SelectedValue = Int32.Parse(Duoc_Id);
                            }
                            txtSang.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Sang"].ToString();
                            txtTrua.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Trua"].ToString();
                            txtChieu.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Chieu"].ToString();
                            txtToi.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Toi"].ToString();
                            txtSoNgay.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["SoNgay"].ToString();
                            txtSoLuong.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["SoLuong"].ToString();
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
        public void LoadThongTinForm()
        {
            DataTable SelectNoiDungToaThuocMauTheoID = Model.dbDanhMuc.SelectNoiDungToaThuocMauTheoID(DM_Id);
            {
                if (SelectNoiDungToaThuocMauTheoID != null)
                {
                    if (SelectNoiDungToaThuocMauTheoID.Rows.Count > 0)
                    {
                        string ToaThuocMau_Id = SelectNoiDungToaThuocMauTheoID.Rows[0]["ToaThuocMau_Id"].ToString();
                        if (!String.IsNullOrEmpty(ToaThuocMau_Id))
                        {
                            cbbToaThuocMau.SelectedValue = Int32.Parse(ToaThuocMau_Id);
                        }
                        string Duoc_Id = SelectNoiDungToaThuocMauTheoID.Rows[0]["Duoc_Id"].ToString();
                        if (!String.IsNullOrEmpty(Duoc_Id))
                        {
                            cbbDuoc.SelectedValue = Int32.Parse(Duoc_Id);
                        }
                        txtSang.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Sang"].ToString();
                        txtTrua.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Trua"].ToString();
                        txtChieu.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Chieu"].ToString();
                        txtToi.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["Toi"].ToString();
                        txtSoNgay.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["SoNgay"].ToString();
                        txtSoLuong.Text = SelectNoiDungToaThuocMauTheoID.Rows[0]["SoLuong"].ToString();
                    }
                }
            }
        }
        public void Hien()
        {
            cbbToaThuocMau.Enabled = true;
            cbbDuoc.Enabled = true;
            txtSang.Enabled = true;
            txtTrua.Enabled = true;
            txtChieu.Enabled = true;
            txtToi.Enabled = true;
            txtSoNgay.Enabled = true;
            txtSoLuong.Enabled = true;
        }
        public void An()
        {
            cbbToaThuocMau.Enabled = false;
            cbbDuoc.Enabled = false;
            txtSang.Enabled = false;
            txtTrua.Enabled = false;
            txtChieu.Enabled = false;
            txtToi.Enabled = false;
            txtSoNgay.Enabled = false;
            txtSoLuong.Enabled = false;
        }
        public void Reset()
        {
            cbbToaThuocMau.SelectedIndex = 0;
            cbbDuoc.Text = "";
            txtSang.Text = "";
            txtTrua.Text = "";
            txtChieu.Text = "";
            txtToi.Text = "";
            txtSoNgay.Text = "";
            txtSoLuong.Text = "";
        }

        private void cbbDuoc_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbDuoc.Text;
            DataRow[] resultRow = CBBDuocNoiDungToaThuocMau.Select("FieldName LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = CBBDuocNoiDungToaThuocMau.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                cbbDuoc.DataSource = dtResult;
                cbbDuoc.DroppedDown = true;
            }
            else
            {
                cbbDuoc.DataSource = null;
                cbbDuoc.DroppedDown = true;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
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