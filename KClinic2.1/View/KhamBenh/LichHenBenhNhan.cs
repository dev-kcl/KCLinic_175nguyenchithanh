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
using ZaloDotNetSDK;
using Newtonsoft.Json.Linq;

namespace KClinic2._1.View.KhamBenh
{
    public partial class LichHenBenhNhan : DevExpress.XtraEditors.XtraForm
    {
        public string AccessToken;
        public LichHenBenhNhan()
        {
            InitializeComponent();
        }

        private void LichHenBenhNhan_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemKhamBenh = Model.db.LoaiTimKiemKhamBenh();
            cbbLoai.DataSource = LoaiTimKiemKhamBenh;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "1";
            txtTimKiem.Focus();
            txtTimKiem.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable SelectLichHen = Model.dbKhamBenh.SelectLichHen(cbbLoai.SelectedValue.ToString(), DateTime.Now.ToString("dd/MM/yyyy"));
            gridDichVu.DataSource = SelectLichHen;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable SelectLichHen = Model.dbKhamBenh.SelectLichHen(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
            gridDichVu.DataSource = SelectLichHen;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable SelectLichHen = Model.dbKhamBenh.SelectLichHen(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
                gridDichVu.DataSource = SelectLichHen;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void btnSendZalo_Click(object sender, EventArgs e)
        {
            AccessToken = Model.ZaloOa.GetAccessToken();
            ZaloClient client = new ZaloClient(AccessToken);
            DataTable SelectAccessTokenZalo = Model.db.SelectAccessTokenZalo();
            AccessToken = SelectAccessTokenZalo.Rows[0][0].ToString();

            Int32[] selectedRowHandles = gridView1.GetSelectedRows();
            if (selectedRowHandles.Length == 0)
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    int selectedRowHandle = selectedRowHandles[i];
                    if (selectedRowHandle >= 0)
                    {
                        if (gridView1.GetRowCellValue(selectedRowHandle, "Zalo_Id").ToString() != "")
                        {
                            JObject sentmess = client.sendTextMessageToUserIdV3(gridView1.GetRowCellValue(selectedRowHandle, "Zalo_Id").ToString(), "Chào anh chị! Anh chị có lịch hẹn tái khám vào lúc: " + gridView1.GetRowCellValue(selectedRowHandle, "HenTaiKham").ToString() + ".Nội dung nhắc hẹn:" + gridView1.GetRowCellValue(selectedRowHandle, "NoiDungHenTaiKham").ToString() + ". Vui lòng đến đúng hẹn. Xin cảm ơn!");
                            DataTable InsertLichHen = Model.dbKhamBenh.InsertLichHen(
                            gridView1.GetRowCellValue(selectedRowHandle, "KhamBenh_Id").ToString()
                            , gridView1.GetRowCellValue(selectedRowHandle, "TiepNhan_Id").ToString()
                            , gridView1.GetRowCellValue(selectedRowHandle, "BenhNhan_Id").ToString()
                            , "null"
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            );
                            alertControl1.Show(this, "Thông báo", "Bệnh nhân " + gridView1.GetRowCellValue(selectedRowHandle, "TenBenhNhan").ToString() + " đã nhận đươc tin nhắn hẹn tái khám!", "");
                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Bệnh nhân "  + gridView1.GetRowCellValue(selectedRowHandle, "TenBenhNhan").ToString() + " chưa nhập thông tin zalo!", "");
                        }
                    }

                }
            }
            DataTable SelectLichHen = Model.dbKhamBenh.SelectLichHen(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
            gridDichVu.DataSource = SelectLichHen;
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