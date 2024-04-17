using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KClinic2._1
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (RibbonPage page in ribbonControl1.Pages)
            {
                
                foreach (RibbonPageGroup group in page.Groups)
                {
                    group.Visible = false;
                }
                page.Visible = false;
            }
            
            foreach (BarItem item in ribbonControl1.Items)
            {
                item.Visibility = BarItemVisibility.Never;
            }
            DataTable CheckUserPermission = Model.db.CheckUserPermission(Login.User_Id);
            if (CheckUserPermission != null)
            {
                if (CheckUserPermission.Rows.Count > 0)
                {
                    foreach (DataRow subItem in CheckUserPermission.Rows)
                    {
                        foreach (RibbonPage page in ribbonControl1.Pages)
                        {
                            if (page.Name == subItem["MenuCode"].ToString())
                            {
                                page.Visible = true;
                            }
                            else
                            {
                                foreach (RibbonPageGroup group in page.Groups)
                                {
                                    if (group.Name == subItem["MenuCode"].ToString())
                                    {
                                        group.Visible = true;
                                    }
                                    else
                                    {
                                        foreach (BarItem item in ribbonControl1.Items)
                                        {
                                            if (item.Name == subItem["MenuCode"].ToString())
                                            {
                                                item.Visibility = BarItemVisibility.Always;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            
            ribbonControl1.Minimized = true;
            lbTenNhanVien.Caption = "Nhân viên làm việc: " + Login.UserCode + " - " + Login.UserName
                + " | Nơi làm việc: " + Login.TenPhongBan

                ;
            View.Home frm = new View.Home();
            frm.MdiParent = this;
            frm.Show();
        }
        public void ChangeStatus()
        {
            lbTenNhanVien.Caption = "Nhân viên làm việc: " + Login.UserCode + " - " + Login.UserName
                + " | Nơi làm việc: " + Login.TenPhongBan

                ;
        }
        public Boolean ActivateThisChild(String formName)
        {
            int i;
            Boolean formSetToMdi = false;
            for (i = 0; i < this.MdiChildren.Length; i++)
            // loop for all the mdi children
            {
                if (this.MdiChildren[i].Name == formName)
                // find the Mdi child with the same name as your form
                {
                    // if found just activate it
                    this.MdiChildren[i].Activate();
                    formSetToMdi = true;
                }
            }

            if (i == 0 || formSetToMdi == false)
                // if the given form not found as mdi child return false.
                return false;

            else
                return true;


        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            View.XetNghiem.XetNghiem frm = new View.XetNghiem.XetNghiem();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            View.DanhMuc.DM_NhomDichVu frm = new View.DanhMuc.DM_NhomDichVu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("TiepNhan") == false)
            {
                View.TiepNhan.TiepNhan frm = new View.TiepNhan.TiepNhan();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_DichVu") == false)
            {
                View.DanhMuc.DM_DichVu frm = new View.DanhMuc.DM_DichVu();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_DichVuCon") == false)
            {
                View.DanhMuc.DM_DichVuCon frm = new View.DanhMuc.DM_DichVuCon();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("GiaTriChuan") == false)
            {
                View.DanhMuc.GiaTriChuan frm = new View.DanhMuc.GiaTriChuan();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("NhomBenh") == false)
            {
                View.DanhMuc.NhomBenh frm = new View.DanhMuc.NhomBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("NoiDungNhomBenh") == false)
            {
                View.DanhMuc.NoiDungNhomBenh frm = new View.DanhMuc.NoiDungNhomBenh();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("BacSi") == false)
            {
                View.DanhMuc.BacSi frm = new View.DanhMuc.BacSi();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("KTV") == false)
            {
                View.DanhMuc.KTV frm = new View.DanhMuc.KTV();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_LoaiPhongBan") == false)
            {
                View.DanhMuc.DM_LoaiPhongBan frm = new View.DanhMuc.DM_LoaiPhongBan();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("PhongBan") == false)
            {
                View.DanhMuc.PhongBan frm = new View.DanhMuc.PhongBan();
                frm.MdiParent = this;
                frm.Show();
            }
               
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_QuocGia") == false)
            {
                View.DanhMuc.DM_QuocGia frm = new View.DanhMuc.DM_QuocGia();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_DonViTinh") == false)
            {
                View.DanhMuc.DM_DonViTinh frm = new View.DanhMuc.DM_DonViTinh();
                frm.MdiParent = this;
                frm.Show();
            }
               
        }

        private void barButtonItem19_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_LoaiDuoc") == false)
            {
                View.DanhMuc.DM_LoaiDuoc frm = new View.DanhMuc.DM_LoaiDuoc();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_Duoc") == false)
            {
                View.DanhMuc.DM_Duoc frm = new View.DanhMuc.DM_Duoc();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DuocTonKho") == false)
            {
                View.DanhMuc.DuocTonKho frm = new View.DanhMuc.DuocTonKho();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_BacSiPhongKham") == false)
            {
                View.DanhMuc.DM_BacSiPhongKham frm = new View.DanhMuc.DM_BacSiPhongKham();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("KhamBenh") == false)
            {
                View.KhamBenh.KhamBenh frm = new View.KhamBenh.KhamBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("ToaThuocMau") == false)
            {
                View.DanhMuc.ToaThuocMau frm = new View.DanhMuc.ToaThuocMau();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("ToaThuocMau_NoiDung") == false)
            {
                View.DanhMuc.ToaThuocMau_NoiDung frm = new View.DanhMuc.ToaThuocMau_NoiDung();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_LoaiMauXetNghiem") == false)
            {
                View.DanhMuc.DM_LoaiMauXetNghiem frm = new View.DanhMuc.DM_LoaiMauXetNghiem();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("ChanDoanHinhAnh") == false)
            {
                View.ChanDoanHinhAnh.ChanDoanHinhAnh frm = new View.ChanDoanHinhAnh.ChanDoanHinhAnh();
                frm.MdiParent = this;
                frm.Show();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
                
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("TuDienKetLuan") == false)
            {
                View.DanhMuc.TuDienKetLuan frm = new View.DanhMuc.TuDienKetLuan();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("BaoCaoThuTien") == false)
            {
                View.HeThongBaoCao.BaoCaoThuTien frm = new View.HeThongBaoCao.BaoCaoThuTien();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("BaoCaoSoLuongChiDinh") == false)
            {
                View.HeThongBaoCao.BaoCaoSoLuongChiDinh frm = new View.HeThongBaoCao.BaoCaoSoLuongChiDinh();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("BaoCaoBNChiDinhDichVu") == false)
            {
                View.HeThongBaoCao.BaoCaoBNChiDinhDichVu frm = new View.HeThongBaoCao.BaoCaoBNChiDinhDichVu();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("BanThuocTaiQuay") == false)
            {
                View.TongHop.BanThuocTaiQuay frm = new View.TongHop.BanThuocTaiQuay();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("BanThuocTaiQuay") == false)
            {
                View.TongHop.BanThuocTaiQuay frm = new View.TongHop.BanThuocTaiQuay();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đăng xuất không? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login.MaBenhVien = "";
                Login.User_Id = "";
                Login.UserCode = "";
                Login.UserName = "";
                Login frm = new Login();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("Users") == false)
            {
                View.HeThong.Users frm = new View.HeThong.Users();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("BenhVien") == false)
            {
                View.HeThong.BenhVien frm = new View.HeThong.BenhVien();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("Menu") == false)
            {
                View.HeThong.Menu frm = new View.HeThong.Menu();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActivateThisChild("Permission") == false)
            {
                View.HeThong.Permission frm = new View.HeThong.Permission();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("Setting") == false)
            {
                View.HeThong.Setting frm = new View.HeThong.Setting();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("DoiMatKhau") == false)
            {
                View.HeThong.DoiMatKhau frm = new View.HeThong.DoiMatKhau();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("ReportError") == false)
            {
                View.HeThong.ReportError frm = new View.HeThong.ReportError();
                frm.MdiParent = this;
                frm.Show();
            }
                
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("BaoCaoThongKeDonThuoc") == false)
            {
                View.HeThongBaoCao.BaoCaoThongKeDonThuoc frm = new View.HeThongBaoCao.BaoCaoThongKeDonThuoc();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("TuDienChanDoanKhamBenh") == false)
            {
                View.DanhMuc.TuDienChanDoanKhamBenh frm = new View.DanhMuc.TuDienChanDoanKhamBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("Dictionary") == false)
            {
                View.DanhMuc.Dictionary frm = new View.DanhMuc.Dictionary();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("BaoCaoBSThucHienDichVu") == false)
            {
                View.HeThongBaoCao.BaoCaoBSThucHienDichVu frm = new View.HeThongBaoCao.BaoCaoBSThucHienDichVu();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("BenhSu") == false)
            {
                View.BenhNhan.BenhSu frm = new View.BenhNhan.BenhSu();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("ImportXetNghiem") == false)
            {
                View.XetNghiem.ImportXetNghiem frm = new View.XetNghiem.ImportXetNghiem();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem48_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("LichHenBenhNhan") == false)
            {
                View.KhamBenh.LichHenBenhNhan frm = new View.KhamBenh.LichHenBenhNhan();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("GiaiPhauBenh") == false)
            {
                View.GiaiPhauBenh.GiaiPhauBenh frm = new View.GiaiPhauBenh.GiaiPhauBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("HeThongBaoCao") == false)
            {
                View.HeThongBaoCao.HeThongBaoCao frm = new View.HeThongBaoCao.HeThongBaoCao();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem54_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("DM_Duoc_DonGia") == false)
            {
                View.DanhMuc.DM_Duoc_DonGia frm = new View.DanhMuc.DM_Duoc_DonGia();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.DanhMuc.DM_DoiTuong frm = new View.DanhMuc.DM_DoiTuong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.DanhMuc.DM_HopDongKSK frm = new View.DanhMuc.DM_HopDongKSK();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem52_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("UserPhongBanKhoDuoc") == false)
            {
                View.HeThong.UserPhongBanKhoDuoc frm = new View.HeThong.UserPhongBanKhoDuoc();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.HeThong.DoiNoiLamViec frm = new View.HeThong.DoiNoiLamViec(this);
            frm.ShowDialog();
        }
        private void barButtonItem57_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.HeThong.PhongBanDichVu frm = new View.HeThong.PhongBanDichVu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.TiepNhan.ManHinhHangDoi frm = new View.TiepNhan.ManHinhHangDoi();
            frm.MdiParent = this;
            frm.Show();

        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.HeThongBaoCao.BaoCaoDoanhThuPhongKham frm = new View.HeThongBaoCao.BaoCaoDoanhThuPhongKham();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem60_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.HeThongBaoCao.BaoCaoBNPTuVan frm = new View.HeThongBaoCao.BaoCaoBNPTuVan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem61_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("TiepNhanTheThanhVien") == false)
            {
                View.TiepNhan.TiepNhanTheThanhVien frm = new View.TiepNhan.TiepNhanTheThanhVien();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("ThongTinThe") == false)
            {
                View.TheThanhVien.ThongTinThe frm = new View.TheThanhVien.ThongTinThe();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActivateThisChild("DanhMucLoaiThe") == false)
            {
                View.TheThanhVien.DanhMucLoaiThe frm = new View.TheThanhVien.DanhMucLoaiThe();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
