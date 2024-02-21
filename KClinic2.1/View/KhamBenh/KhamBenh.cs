using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using KClinic2._1.Utils;
using KClinic2._1.View.TiepNhan;

namespace KClinic2._1.View.KhamBenh
{
    public partial class KhamBenh : DevExpress.XtraEditors.XtraForm
    {

        public string BenhNhan_Id;
        public string TenBenhNhan;
        public static string TiepNhan_Id = "";
        public string KhamBenh_Id;
        public string ThaoTac;
        public string CLSYeuCau_Id;
        public string CLSYeuCauCha_Id;
        public string CLSYeuCauChiTiet_Id;
        public string ToaThuoc_Id;

        Model.UDPSocket s;
        public string PhongKham_Id;
        public string HangDoiPhongKham_Id = "0";
        public string HangDoiPhongKham_IdDaGoi = "0";
        public static string BienSetGoi = "0";

        public KhamBenh()
        {
            InitializeComponent();
        }

        private void KhamBenh_Load(object sender, EventArgs e)
        {
            ReloadFormKhamBenh();
            this.KeyPreview = true;
        }
        DataTable Dm_DichVu;
        DataTable Dm_NhomBenh;
        DataTable CheckUserPhongKham;
        DataTable CheckUserBacSiPhongKham;
        DataTable CheckBenhNhanKhamBenh;

        DataTable Dm_Duoc;
        DataTable Dm_ToaThuocMau;
        DataTable TuDienChanDoan;
        DataTable PhongBan;

        void getCheckBenhNhanKhamBenh()
        {
            CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
            gridDSKham.DataSource = CheckBenhNhanKhamBenh;
        }

        void getdata()
        {

            Dm_DichVu = Model.DbTiepNhan.Dm_DichVu();
            cbbDV.DataSource = Dm_DichVu;
            cbbDV.ValueMember = "Dich_Id";
            cbbDV.DisplayMember = "TenDichVu";

            Dm_NhomBenh = Model.DbTiepNhan.Dm_NhomBenh();
            cbbNhomBenh.DataSource = Dm_NhomBenh;
            cbbNhomBenh.ValueMember = "NhomBenh_Id";
            cbbNhomBenh.DisplayMember = "TenNhomBenh";


            CheckUserPhongKham = Model.dbKhamBenh.CheckUserPhongKham(Login.User_Id);
            cbbPhongKham.DataSource = CheckUserPhongKham;
            cbbPhongKham.ValueMember = "PhongBan_Id";
            cbbPhongKham.DisplayMember = "TenPhongBan";
            if (CheckUserPhongKham != null)
            {
                if (CheckUserPhongKham.Rows.Count > 0)
                {
                    cbbPhongKham.SelectedIndex = 0;

                    CheckUserBacSiPhongKham = Model.dbKhamBenh.CheckUserBacSiPhongKham(Login.User_Id, cbbPhongKham.Value.ToString());
                    cbbBacSiKham.DataSource = CheckUserBacSiPhongKham;
                    cbbBacSiKham.ValueMember = "BacSi_Id";
                    cbbBacSiKham.DisplayMember = "TenBacSi";
                    if (CheckUserBacSiPhongKham != null)
                    {
                        if (CheckUserBacSiPhongKham.Rows.Count > 0)
                        {
                            cbbBacSiKham.SelectedIndex = 0;
                        }
                    }
                }
            }
            

            

            Dm_ToaThuocMau = Model.dbKhamBenh.CBBToaThuocMau();
            cbbToaThuocMau.DataSource = Dm_ToaThuocMau;
            cbbToaThuocMau.ValueMember = "ToaThuocMau_Id";
            cbbToaThuocMau.DisplayMember = "TenToaThuocMau";

            Dm_Duoc = Model.dbKhamBenh.CBBDuoc();
            cbbThuoc.DataSource = Dm_Duoc;
            cbbThuoc.ValueMember = "Duoc_Id";
            cbbThuoc.DisplayMember = "TenDuocDayDu";

            //cbbTest.Properties.DataSource = Dm_Duoc;
            //cbbTest.Properties.ValueMember = "Duoc_Id";
            //cbbTest.Properties.DisplayMember = "TenDuocDayDu";

            TuDienChanDoan = Model.dbDanhMuc.CBBTuDienChanDoanKhamBenh();
            cbbTuDien.DataSource = TuDienChanDoan;
            cbbTuDien.ValueMember = "FieldCode";
            cbbTuDien.DisplayMember = "FieldName";
        }

        public void ReloadFormKhamBenh()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnXem.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = true;
            BenhNhan_Id = "";
            TenBenhNhan = "";
            CLSYeuCau_Id = "";
            CLSYeuCauChiTiet_Id = "";
            ToaThuoc_Id = "";
            KhamBenh_Id = "";
            An();
            Reset();
            btnXetNghiem.Enabled = false;
            btnChanDoanHinhAnh.Enabled = false;
            getdata();
            getCheckBenhNhanKhamBenh();
            if (TiepNhan_Id != "")
            {
                DataTable CheckBenhNhanKhamBenhTheoTiepNhan_Id = Model.dbKhamBenh.CheckBenhNhanKhamBenhTheoTiepNhan_Id(TiepNhan_Id);
                if (CheckBenhNhanKhamBenhTheoTiepNhan_Id != null)
                {
                    if (CheckBenhNhanKhamBenhTheoTiepNhan_Id.Rows.Count > 0)
                    {
                        CLSYeuCau_Id = CheckBenhNhanKhamBenhTheoTiepNhan_Id.Rows[0]["CLSYeuCau_Id"].ToString();
                        if (CheckBenhNhanKhamBenhTheoTiepNhan_Id.Rows[0]["KhamBenh_Id"].ToString() == "0")
                        {
                            LoadThongTinBenhNhanDaTiepNhanKhamBenh(TiepNhan_Id);
                        }
                        else
                        {
                            KhamBenh_Id = CheckBenhNhanKhamBenhTheoTiepNhan_Id.Rows[0]["KhamBenh_Id"].ToString();
                            ThaoTac = "Sua";
                            LoadThongTinBenhNhanDaKhamButton();
                            LoadThongTinBenhNhanDaKham();
                        }
                    }

                }

            }
            else { TiepNhan_Id = ""; }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (TiepNhan_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân khám ", "");
            }
            else if (ThaoTac == "Sua")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân khám ", "");
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
                btnXoa.Enabled = false;
                btnXem.Enabled = false;
                btnIn.Enabled = false;
                btnTimKiem.Enabled = false;
                Hien();
                btnXetNghiem.Enabled = false;
                btnChanDoanHinhAnh.Enabled = false;
                ThaoTac = "Them";
                //BenhNhan_Id = ""; 
                //TenBenhNhan = "";
                //TiepNhan_Id = "";
                //CLSYeuCau_Id = "";
                KhamBenh_Id = "";
                CLSYeuCauChiTiet_Id = "";
                ToaThuoc_Id = "";
                Reset();
                Resettab();
                getdata();
                //DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                //DataTable HoanTatBookingPhienDangNhap = Model.dbKhamBenh.HoanTatBookingPhienDangNhap(Login.PhienDangNhap_Id);
                txtMach.Focus();
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable SelectXacNhanHoanTatKham = Model.dbKhamBenh.SelectXacNhanHoanTatKham(KhamBenh_Id);
            if (SelectXacNhanHoanTatKham != null)
            {
                if (SelectXacNhanHoanTatKham.Rows.Count > 0)
                {
                    alertControl1.Show(this, "Thông báo", "Bệnh nhân đã được xác nhận khám! Không thể sửa.", "");
                }
                else
                {
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                    btnXoa.Enabled = false;
                    btnXem.Enabled = false;
                    btnIn.Enabled = false;
                    btnTimKiem.Enabled = false;
                    Hien();
                    ThaoTac = "Sua";
                    DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                    DataTable HoanTatBookingPhienDangNhap = Model.dbKhamBenh.HoanTatBookingPhienDangNhap(Login.PhienDangNhap_Id);
                    CLSYeuCauChiTiet_Id = "";
                    ToaThuoc_Id = "";
                    getdata();
                    Resettab();
                    txtMach.Focus();
                    //
                    btnXetNghiem.Enabled = false;
                    btnChanDoanHinhAnh.Enabled = false;
                    LoadThongTinBenhNhanDaKham();
                }
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
                btnXoa.Enabled = false;
                btnXem.Enabled = false;
                btnIn.Enabled = false;
                btnTimKiem.Enabled = false;
                Hien();
                ThaoTac = "Sua";
                DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                DataTable HoanTatBookingPhienDangNhap = Model.dbKhamBenh.HoanTatBookingPhienDangNhap(Login.PhienDangNhap_Id);
                CLSYeuCauChiTiet_Id = "";
                ToaThuoc_Id = "";
                getdata();
                Resettab();
                txtMach.Focus();
                //
                btnXetNghiem.Enabled = false;
                btnChanDoanHinhAnh.Enabled = false;
                LoadThongTinBenhNhanDaKham();
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtChanDoan.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Chẩn đoán không được để trống!", "");
            }
            else
            {
                string Mach = "null"; if (txtMach.Text != "") { Mach = "N'" + txtMach.Text.Replace("'", "''") + "'"; }
                string NhietDo = "null"; if (txtNhietDo.Text != "") { NhietDo = "N'" + txtNhietDo.Text.Replace("'", "''") + "'"; }
                string CanNang = "null"; if (txtCanNang.Text != "") { CanNang = "N'" + txtCanNang.Text.Replace("'", "''") + "'"; }
                string ChieuCao = "null"; if (txtChieuCao.Text != "") { ChieuCao = "N'" + txtChieuCao.Text.Replace("'", "''") + "'"; }
                string HuyetApCao = "null"; if (txtHuyetApCao.Text != "") { HuyetApCao = "N'" + txtHuyetApCao.Text.Replace("'", "''") + "'"; }
                string HuyetApThap = "null"; if (txtHuyetApThap.Text != "") { HuyetApThap = "N'" + txtHuyetApThap.Text.Replace("'", "''") + "'"; }
                string NhipTho = "null"; if (txtNhipTho.Text != "") { NhipTho = "N'" + txtNhipTho.Text.Replace("'", "''") + "'"; }
                string BMI = "null"; if (txtBMI.Text != "") { BMI = "N'" + txtBMI.Text.Replace("'", "''") + "'"; }
                string TrieuChung = "null"; if (txtTrieuChung.Text != "") { TrieuChung = "N'" + txtTrieuChung.Text.Replace("'", "''") + "'"; }
                string ChanDoan = "null"; if (txtChanDoan.Text != "") { ChanDoan = "N'" + txtChanDoan.Text.Replace("'", "''") + "'"; }

                string TienSu = "null"; if (txtTienSu.Text != "") { TienSu = "N'" + txtTienSu.Text.Replace("'", "''") + "'"; }
                string Kham = "null"; if (txtKham.Text != "") { Kham = "N'" + txtKham.Text.Replace("'", "''") + "'"; }

                string PhongKham_Id = "null";
                if (cbbPhongKham.SelectedItem != null) { PhongKham_Id = cbbPhongKham.Value.ToString(); }
                string BacSi_Id = "null";
                if (cbbBacSiKham.SelectedItem != null) { BacSi_Id = cbbBacSiKham.Value.ToString(); }
                string ThoiGianKham = "'" + txtThoiGianKham.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                string NgayKham = "'" + txtThoiGianKham.Value.ToString("yyyyMMdd") + "'";

                string KetLuan = "null"; //if (txtKetLuan.Text != "") { KetLuan = "N'" + txtKetLuan.Text.Replace("'", "''") + "'"; }
                string LoiDan = "null"; if (txtLoiDan.Text != "") { LoiDan = "N'" + txtLoiDan.Text.Replace("'", "''") + "'"; }
                string HenTaiKham = "null";
                if (txtHenTaiKham.Text != "") { HenTaiKham = "'" + txtHenTaiKham.Value.ToString("yyyyMMdd HH:mm:ss") + "'"; }

                string LyDoKham = "null"; if (txtLyDoKham.Text != "") { LyDoKham = "N'" + txtLyDoKham.Text.Replace("'", "''") + "'"; }
                string TomTatCLS = "null"; if (txtTomTatKetQuaCLS.Text != "") { TomTatCLS = "N'" + txtTomTatKetQuaCLS.Text.Replace("'", "''") + "'"; }
                string DieuTri = "null"; if (txtDieuTri.Text != "") { DieuTri = "N'" + txtDieuTri.Text.Replace("'", "''") + "'"; }
                string GhiChu = "null"; if (txtGhiChu.Text != "") { GhiChu = "N'" + txtGhiChu.Text.Replace("'", "''") + "'"; }

                string NoiDung = "null"; if (txtNoiDungHenTaiKhai.Text != "") { NoiDung = "N'" + txtNoiDungHenTaiKhai.Text.Replace("'", "''") + "'"; }

                if (ThaoTac == "Them")
                {
                    DataTable InsertKhamBenh = Model.dbKhamBenh.InsertKhamBenh(
                              TiepNhan_Id
                            , BenhNhan_Id
                            , NgayKham
                            , ThoiGianKham
                            , PhongKham_Id
                            , BacSi_Id
                            , Mach
                            , NhietDo
                            , CanNang
                            , ChieuCao
                            , HuyetApCao
                            , HuyetApThap
                            , NhipTho
                            , BMI
                            , TrieuChung
                            , "null"
                            , ChanDoan
                            , KetLuan
                            , LoiDan
                            , CLSYeuCau_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , Login.User_Id
                            , "null"
                            , "null"
                            , "0"
                            , HenTaiKham
                            , TienSu
                            , Kham
                            , LyDoKham
                            , TomTatCLS
                            , DieuTri
                            , GhiChu
                            , NoiDung
                            );
                    if (InsertKhamBenh.Rows.Count > 0)
                    {
                        KhamBenh_Id = InsertKhamBenh.Rows[0]["KhamBenh_Id"].ToString();
                        TenBenhNhan = InsertKhamBenh.Rows[0]["TenBenhNhan"].ToString();

                        DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                     CLSYeuCau_Id
                                    , "N'CoKetQua'"
                                    );
                        //CLSYeuCau
                        DataTable BangCLS = gridDichVu.DataSource as DataTable;
                        DataTable CheckClsYeuCauPhienDangNhap = Model.DbTiepNhan.CheckClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                        if (CheckClsYeuCauPhienDangNhap != null)
                        {
                            if (CheckClsYeuCauPhienDangNhap.Rows.Count > 0)
                            {
                                int i1;
                                for (i1 = 0; i1 < CheckClsYeuCauPhienDangNhap.Rows.Count; i1++)
                                {
                                    if (CheckClsYeuCauPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Them")
                                    {
                                        DataTable UpdateCLSYeuCau = Model.DbTiepNhan.UpdateCLSYeuCau(
                                            CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                            , TiepNhan_Id
                                            , BenhNhan_Id
                                            );
                                    }
                                    else
                                    {
                                        DataTable DeleteCLSYeuCau = Model.DbTiepNhan.DeleteCLSYeuCau(
                                            CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                            , Login.User_Id
                                            );
                                    }
                                }
                            }
                        }
                        DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                        //
                        //Thuốc
                        DataTable CheckToaThuocPhienDangNhap = Model.dbKhamBenh.CheckToaThuocPhienDangNhap(Login.PhienDangNhap_Id);
                        if (CheckToaThuocPhienDangNhap != null)
                        {
                            if (CheckToaThuocPhienDangNhap.Rows.Count > 0)
                            {
                                int i1;
                                for (i1 = 0; i1 < CheckToaThuocPhienDangNhap.Rows.Count; i1++)
                                {
                                    if (CheckToaThuocPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Them")
                                    {
                                        DataTable UpdateToaThuocThem = Model.dbKhamBenh.UpdateToaThuocThem(
                                              KhamBenh_Id
                                            , CheckToaThuocPhienDangNhap.Rows[i1]["ToaThuoc_Id"].ToString()
                                            );
                                    }
                                    else if (CheckToaThuocPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Sua")
                                    {
                                        string Sang = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Sang"].ToString() != "")
                                        { Sang = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Sang"].ToString() + "'"; }
                                        string Trua = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Trua"].ToString() != "")
                                        { Trua = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Trua"].ToString() + "'"; }
                                        string Chieu = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Chieu"].ToString() != "")
                                        { Chieu = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Chieu"].ToString() + "'"; }
                                        string Toi = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Toi"].ToString() != "")
                                        { Toi = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Toi"].ToString() + "'"; }
                                        string SoNgay = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["SoNgay"].ToString() != "")
                                        { SoNgay = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["SoNgay"].ToString() + "'"; }
                                        string SoLuong = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["SoLuong"].ToString() != "")
                                        { SoLuong = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["SoLuong"].ToString() + "'"; }

                                        string CachDung = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["GhiChu"].ToString() != "")
                                        { CachDung = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["GhiChu"].ToString() + "'"; }

                                        DataTable UpdateToaThuocSua = Model.dbKhamBenh.UpdateToaThuocSua(
                                              KhamBenh_Id
                                            , CheckToaThuocPhienDangNhap.Rows[i1]["ToaThuoc_Id"].ToString()
                                            , CheckToaThuocPhienDangNhap.Rows[i1]["Duoc_Id"].ToString()
                                            , Sang
                                            , Trua
                                            , Chieu
                                            , Toi
                                            , SoNgay
                                            , SoLuong
                                            , "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["DonGia"].ToString() + "'"
                                            , Login.User_Id
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            , CachDung
                                            );
                                    }
                                    else
                                    {
                                        DataTable DeleteToaThuoc = Model.dbKhamBenh.DeleteToaThuoc(
                                            CheckToaThuocPhienDangNhap.Rows[i1]["ToaThuoc_Id"].ToString()
                                            , Login.User_Id
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            );
                                    }
                                }
                            }
                        }
                        DataTable HoanTatBookingPhienDangNhap = Model.dbKhamBenh.HoanTatBookingPhienDangNhap(Login.PhienDangNhap_Id);

                        //
                        LoadThongTinBenhNhanDaKham();
                    }

                    //
                    alertControl1.Show(this, "Thông báo", "Đã thêm thành công khám bệnh bệnh nhân " + TenBenhNhan, "");
                    //MessageBox.Show("Đã thêm thành công!");
                }
                if (ThaoTac == "Sua")
                {
                    DataTable UpdateKhamBenh = Model.dbKhamBenh.UpdateKhamBenh(
                             KhamBenh_Id
                            , TiepNhan_Id
                            , BenhNhan_Id
                            , NgayKham
                            , ThoiGianKham
                            , PhongKham_Id
                            , BacSi_Id
                            , Mach
                            , NhietDo
                            , CanNang
                            , ChieuCao
                            , HuyetApCao
                            , HuyetApThap
                            , NhipTho
                            , BMI
                            , TrieuChung
                            , "null"
                            , ChanDoan
                            , KetLuan
                            , LoiDan
                            , CLSYeuCau_Id
                            , "null"
                            , "null"
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , Login.User_Id
                            , "0"
                            , HenTaiKham
                            , TienSu
                            , Kham
                            , LyDoKham
                            , TomTatCLS
                            , DieuTri
                            , GhiChu
                            , NoiDung
                            );
                    if (UpdateKhamBenh.Rows.Count > 0)
                    {
                        KhamBenh_Id = UpdateKhamBenh.Rows[0]["KhamBenh_Id"].ToString();
                        TenBenhNhan = UpdateKhamBenh.Rows[0]["TenBenhNhan"].ToString();

                        DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                     CLSYeuCau_Id
                                    , "N'CoKetQua'"
                                    );
                        //
                        //update clsyeucau
                        DataTable CheckClsYeuCauPhienDangNhap = Model.DbTiepNhan.CheckClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                        if (CheckClsYeuCauPhienDangNhap != null)
                        {
                            if (CheckClsYeuCauPhienDangNhap.Rows.Count > 0)
                            {
                                int i1;
                                for (i1 = 0; i1 < CheckClsYeuCauPhienDangNhap.Rows.Count; i1++)
                                {
                                    if (CheckClsYeuCauPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Them")
                                    {
                                        DataTable UpdateCLSYeuCau = Model.DbTiepNhan.UpdateCLSYeuCau(
                                            CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                            , TiepNhan_Id
                                            , BenhNhan_Id
                                            );
                                    }
                                    else
                                    {
                                        DataTable DeleteCLSYeuCau = Model.DbTiepNhan.DeleteCLSYeuCau(
                                            CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                            , Login.User_Id
                                            );
                                    }
                                }
                            }
                        }
                        DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);

                        //Thuốc
                        DataTable CheckToaThuocPhienDangNhap = Model.dbKhamBenh.CheckToaThuocPhienDangNhap(Login.PhienDangNhap_Id);
                        if (CheckToaThuocPhienDangNhap != null)
                        {
                            if (CheckToaThuocPhienDangNhap.Rows.Count > 0)
                            {
                                int i1;
                                for (i1 = 0; i1 < CheckToaThuocPhienDangNhap.Rows.Count; i1++)
                                {
                                    if (CheckToaThuocPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Them")
                                    {
                                        DataTable UpdateToaThuocThem = Model.dbKhamBenh.UpdateToaThuocThem(
                                              KhamBenh_Id
                                            , CheckToaThuocPhienDangNhap.Rows[i1]["ToaThuoc_Id"].ToString()
                                            );
                                    }
                                    else if (CheckToaThuocPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Sua")
                                    {
                                        string Sang = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Sang"].ToString() != "")
                                        { Sang = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Sang"].ToString() + "'"; }
                                        string Trua = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Trua"].ToString() != "")
                                        { Trua = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Trua"].ToString() + "'" ; }
                                        string Chieu = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Chieu"].ToString() != "")
                                        { Chieu = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Chieu"].ToString() + "'" ; }
                                        string Toi = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["Toi"].ToString() != "")
                                        { Toi = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["Toi"].ToString() + "'" ; }
                                        string SoNgay = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["SoNgay"].ToString() != "")
                                        { SoNgay = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["SoNgay"].ToString() + "'" ; }
                                        string SoLuong = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["SoLuong"].ToString() != "")
                                        { SoLuong = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["SoLuong"].ToString() + "'"; }
                                        string CachDung = "null";
                                        if (CheckToaThuocPhienDangNhap.Rows[i1]["GhiChu"].ToString() != "")
                                        { CachDung = "N'" + CheckToaThuocPhienDangNhap.Rows[i1]["GhiChu"].ToString() + "'"; }

                                        DataTable UpdateToaThuocSua = Model.dbKhamBenh.UpdateToaThuocSua(
                                              KhamBenh_Id
                                            , CheckToaThuocPhienDangNhap.Rows[i1]["ToaThuoc_Id"].ToString()
                                            , CheckToaThuocPhienDangNhap.Rows[i1]["Duoc_Id"].ToString()
                                            , Sang
                                            , Trua
                                            , Chieu
                                            , Toi
                                            , SoNgay
                                            , SoLuong
                                            , "N'" +  CheckToaThuocPhienDangNhap.Rows[i1]["DonGia"].ToString() + "'"
                                            , Login.User_Id
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            , CachDung
                                            );
                                    }
                                    else
                                    {
                                        DataTable DeleteToaThuoc = Model.dbKhamBenh.DeleteToaThuoc(
                                            CheckToaThuocPhienDangNhap.Rows[i1]["ToaThuoc_Id"].ToString()
                                            , Login.User_Id
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            );
                                    }
                                }
                            }
                        }
                        DataTable HoanTatBookingPhienDangNhap = Model.dbKhamBenh.HoanTatBookingPhienDangNhap(Login.PhienDangNhap_Id);
                        //
                        LoadThongTinBenhNhanDaKham();
                    }
                    //
                    alertControl1.Show(this, "Thông báo", "Đã sửa thành công khám bệnh nhân " + TenBenhNhan, "");
                    //MessageBox.Show("Đã sửa thành công!");
                }
                //
                CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
                gridDSKham.DataSource = CheckBenhNhanKhamBenh;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                btnXem.Enabled = true;
                btnIn.Enabled = true;
                btnTimKiem.Enabled = true;
                An();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXem.Enabled = true;
            btnIn.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXetNghiem.Enabled = false;
            btnChanDoanHinhAnh.Enabled = false;
            DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
            An();
            if (ThaoTac == "Them")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                BenhNhan_Id = "";
                TenBenhNhan = "";
                TiepNhan_Id = "";
                CLSYeuCau_Id = "";
                KhamBenh_Id = "";
                ToaThuoc_Id = "";
                CLSYeuCauChiTiet_Id = "";
                CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
                gridDSKham.DataSource = CheckBenhNhanKhamBenh;
                Resettab();
                txtMaYTe.Text = "";
                txtSoTiepNhan.Text = "";
                txtHoTen.Text = "";
                txtGioiTinh.Text = "";
                txtNamSinh.Text = "";
                txtTuoi.Text = "";
                txtNoiDungKham.Text = "";
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
            DataTable SelectXacNhanHoanTatKham = Model.dbKhamBenh.SelectXacNhanHoanTatKham(KhamBenh_Id);
            if (SelectXacNhanHoanTatKham != null)
            {
                if (SelectXacNhanHoanTatKham.Rows.Count > 0)
                {
                    alertControl1.Show(this, "Thông báo", "Bệnh nhân đã được xác nhận khám! Không thể Xoá.", "");
                }
                else
                {
                    string nguoicapnhat = Login.User_Id;
                    DialogResult dr = MessageBox.Show("Bạn có đồng ý xóa?",
                    "Thong Bao!", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            DataTable CheckDaChiDinhDichVuTruKhamBenh = Model.dbKhamBenh.CheckDaChiDinhDichVuTruKhamBenh(TiepNhan_Id);
                            if (CheckDaChiDinhDichVuTruKhamBenh != null)
                            {
                                if (Login.User_Id == "2")
                                {
                                    btnThem.Enabled = true;
                                    btnSua.Enabled = false;
                                    btnLuu.Enabled = false;
                                    btnHuy.Enabled = false;
                                    btnXoa.Enabled = false;
                                    btnXem.Enabled = true;
                                    btnIn.Enabled = true;
                                    btnTimKiem.Enabled = true;
                                    An();
                                    btnXetNghiem.Enabled = false;
                                    btnChanDoanHinhAnh.Enabled = false;
                                    //
                                    DataTable Delete = Model.dbKhamBenh.DeleteKhamBenh(KhamBenh_Id, nguoicapnhat);
                                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công khám bệnh của bệnh nhân " + Delete.Rows[0]["TenBenhNhan"].ToString(), "");
                                    if (Delete != null)
                                    {
                                        DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                             CLSYeuCau_Id
                                            , "N'ChuaThucHien'"
                                            );
                                    }

                                    Reset();
                                    Resettab();
                                    //
                                    BenhNhan_Id = "";
                                    TenBenhNhan = "";
                                    TiepNhan_Id = "";
                                    CLSYeuCau_Id = "";
                                    KhamBenh_Id = "";
                                    ToaThuoc_Id = "";
                                    CLSYeuCauChiTiet_Id = "";
                                    CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
                                    gridDSKham.DataSource = CheckBenhNhanKhamBenh;
                                    txtMaYTe.Text = "";
                                    txtSoTiepNhan.Text = "";
                                    txtHoTen.Text = "";
                                    txtGioiTinh.Text = "";
                                    txtNamSinh.Text = "";
                                    txtTuoi.Text = "";
                                    txtNoiDungKham.Text = "";
                                }
                                else
                                {
                                    if (Int32.Parse(CheckDaChiDinhDichVuTruKhamBenh.Rows[0]["SoLuong"].ToString()) == 0)
                                    {
                                        btnThem.Enabled = true;
                                        btnSua.Enabled = false;
                                        btnLuu.Enabled = false;
                                        btnHuy.Enabled = false;
                                        btnXoa.Enabled = false;
                                        btnXem.Enabled = true;
                                        btnIn.Enabled = true;
                                        btnTimKiem.Enabled = true;
                                        An();
                                        btnXetNghiem.Enabled = false;
                                        btnChanDoanHinhAnh.Enabled = false;
                                        //
                                        DataTable Delete = Model.dbKhamBenh.DeleteKhamBenh(KhamBenh_Id, nguoicapnhat);
                                        alertControl1.Show(this, "Thông báo", "Đã xóa thành công khám bệnh của bệnh nhân " + Delete.Rows[0]["TenBenhNhan"].ToString(), "");
                                        if (Delete != null)
                                        {
                                            DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                                 CLSYeuCau_Id
                                                , "N'ChuaThucHien'"
                                                );
                                        }

                                        Reset();
                                        Resettab();
                                        //
                                        BenhNhan_Id = "";
                                        TenBenhNhan = "";
                                        TiepNhan_Id = "";
                                        CLSYeuCau_Id = "";
                                        KhamBenh_Id = "";
                                        ToaThuoc_Id = "";
                                        CLSYeuCauChiTiet_Id = "";
                                        CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
                                        gridDSKham.DataSource = CheckBenhNhanKhamBenh;
                                        txtMaYTe.Text = "";
                                        txtSoTiepNhan.Text = "";
                                        txtHoTen.Text = "";
                                        txtGioiTinh.Text = "";
                                        txtNamSinh.Text = "";
                                        txtTuoi.Text = "";
                                        txtNoiDungKham.Text = "";
                                    }
                                    else
                                    {
                                        alertControl1.Show(this, "Thông báo", "Bệnh nhân này đã chỉ định dịch vu, không thể xóa! Vui lòng kiểm tra lại", "");
                                    }
                                }
                                
                            }
                            else
                            {
                                alertControl1.Show(this, "Thông báo", "Bệnh nhân này đã chỉ định dịch vu, không thể xóa! Vui lòng kiểm tra lại", "");
                            }
                            //
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
            }
            else
            {
                string nguoicapnhat = Login.User_Id;
                DialogResult dr = MessageBox.Show("Bạn có đồng ý xóa?",
                "Thong Bao!", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        DataTable CheckDaChiDinhDichVuTruKhamBenh = Model.dbKhamBenh.CheckDaChiDinhDichVuTruKhamBenh(TiepNhan_Id);
                        if (CheckDaChiDinhDichVuTruKhamBenh != null)
                        {
                            if (Int32.Parse(CheckDaChiDinhDichVuTruKhamBenh.Rows[0]["SoLuong"].ToString()) == 0)
                            {
                                btnThem.Enabled = true;
                                btnSua.Enabled = false;
                                btnLuu.Enabled = false;
                                btnHuy.Enabled = false;
                                btnXoa.Enabled = false;
                                btnXem.Enabled = true;
                                btnIn.Enabled = true;
                                btnTimKiem.Enabled = true;
                                An();
                                btnXetNghiem.Enabled = false;
                                btnChanDoanHinhAnh.Enabled = false;
                                //
                                DataTable Delete = Model.dbKhamBenh.DeleteKhamBenh(KhamBenh_Id, nguoicapnhat);
                                alertControl1.Show(this, "Thông báo", "Đã xóa thành công khám bệnh của bệnh nhân " + Delete.Rows[0]["TenBenhNhan"].ToString(), "");
                                if (Delete != null)
                                {
                                    DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                         CLSYeuCau_Id
                                        , "N'ChuaThucHien'"
                                        );
                                }

                                Reset();
                                Resettab();
                                //
                                BenhNhan_Id = "";
                                TenBenhNhan = "";
                                TiepNhan_Id = "";
                                CLSYeuCau_Id = "";
                                KhamBenh_Id = "";
                                ToaThuoc_Id = "";
                                CLSYeuCauChiTiet_Id = "";
                                CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
                                gridDSKham.DataSource = CheckBenhNhanKhamBenh;
                                txtMaYTe.Text = "";
                                txtSoTiepNhan.Text = "";
                                txtHoTen.Text = "";
                                txtGioiTinh.Text = "";
                                txtNamSinh.Text = "";
                                txtTuoi.Text = "";
                                txtNoiDungKham.Text = "";
                            }
                            else
                            {
                                alertControl1.Show(this, "Thông báo", "Bệnh nhân này đã chỉ định dịch vu, không thể xóa! Vui lòng kiểm tra lại", "");
                            }
                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Bệnh nhân này đã chỉ định dịch vu, không thể xóa! Vui lòng kiểm tra lại", "");
                        }
                        //
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            //
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            popupMenu2.ShowPopup(Cursor.Position);
            //if (KhamBenh_Id == "")
            //{
            //    alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            //}
            //else
            //{
            //    DataTable table1 = Model.dbKhamBenh.SP_BaoCao_001_ToaThuoc(KhamBenh_Id);
            //    if (table1 != null)
            //    {
            //        if (table1.Rows.Count > 0)
            //        {
            //            table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
            //            table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
            //            table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
            //            table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
            //            table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
            //            byte[] Image = null;
            //            byte[] ImageLogo = null;
            //            string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
            //            if (table1.Rows[0]["MaYTe"].ToString() != "")
            //            {
            //                DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
            //                string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
            //                FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //                Image = new byte[fs.Length];
            //                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
            //                fs.Close();

            //                DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
            //                if (SelectSettingTheoSettingCode2 != null)
            //                {
            //                    if (SelectSettingTheoSettingCode2.Rows.Count > 0)
            //                    {
            //                        string Logo = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();
            //                        FileStream fsLogo = new FileStream(Logo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //                        ImageLogo = new byte[fsLogo.Length];
            //                        fsLogo.Read(ImageLogo, 0, Convert.ToInt32(fsLogo.Length));
            //                        fsLogo.Close();
            //                    }
            //                }

            //                DataTable BenhVien = Model.db.BenhVien(Login.MaBenhVien);
            //                if (BenhVien != null)
            //                {
            //                    if (BenhVien.Rows.Count > 0)
            //                    {
            //                        TenBenhVien = BenhVien.Rows[0]["TenBenhVien"].ToString();
            //                        DiaChiBenhVien = BenhVien.Rows[0]["DiaChiBenhVien"].ToString();
            //                        DienThoai = BenhVien.Rows[0]["DienThoai"].ToString();
            //                    }
            //                }

            //                for (int i = 0; i < table1.Rows.Count; i++)
            //                {
            //                    table1.Rows[i]["BarcodeMaYTe"] = Image;
            //                    table1.Rows[i]["Logo"] = ImageLogo;
            //                    table1.Rows[i]["TenBenhVien"] = TenBenhVien;
            //                    table1.Rows[i]["DiaChiBenhVien"] = DiaChiBenhVien;
            //                    table1.Rows[i]["DienThoai"] = DienThoai;
            //                }
            //            }
            //        }
            //    }
            //    ReportDocument rptDoca = new ReportDocument();
            //    DataTable ShowDuongDan = Model.db.ShowDuongDan();
            //    string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC008_ToaThuoc.rpt";
            //    rptDoca.Load(DuongDan);
            //    rptDoca.Subreports["ThongTinBenhVien"].SetDataSource(table1);
            //    rptDoca.Subreports["ThongTinToaThuoc"].SetDataSource(table1);
            //    rptDoca.SetDataSource(table1);
            //    rptDoca.PrintToPrinter(1, false, 0, 0);
            //}
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            popupMenu3.ShowPopup(Cursor.Position);
            //if (KhamBenh_Id == "")
            //{
            //    alertcontrol1.show(this, "thông báo", "chưa chọn bệnh nhân!", "");
            //}
            //else
            //{
            //    view.hethongbaocao.toathuoc bc = new view.hethongbaocao.toathuoc(this);
            //    bc.show();
            //}

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            View.KhamBenh.TimKiemKhamBenh tc = new View.KhamBenh.TimKiemKhamBenh(this);
            tc.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Reset();
            this.Close();
        }

        private void btnLamTuoi_Click(object sender, EventArgs e)
        {
            CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
            gridDSKham.DataSource = CheckBenhNhanKhamBenh;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            Reset();
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
                CLSYeuCau_Id = gridView1.GetRowCellValue(n, "CLSYeuCau_Id").ToString();
                LoadThongTinBenhNhanDaTiepNhanKhamBenh(TiepNhan_Id);
                ThaoTac = "Them";

            }
        }
        void LoadBenhNhanTrenHangDoi(string tenBenhNhan)
        {
            var manHinhHangDoi = ApplicationUtil.FindOpenForm<ManHinhHangDoi>("ManHinhHangDoi");
            if (manHinhHangDoi == null)
            {
                alertControl1.Show(this, "Thông báo", "Chưa mở màn hình hàng đợi", "");
            }
            else {
                manHinhHangDoi.SetBenhNhanDangKham(tenBenhNhan);
            }
        }
        void LoadThongTinBenhNhanDaTiepNhanKhamBenh(string _TiepNhan_Id)
        {
            DataTable LoadThongTinBenhNhanDaTiepNhanKhamBenh = Model.dbKhamBenh.LoadThongTinBenhNhanDaTiepNhanKhamBenh(TiepNhan_Id);
            if (LoadThongTinBenhNhanDaTiepNhanKhamBenh != null)
            {
                if (LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows.Count > 0)
                {
                    txtMaYTe.Text = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["MaYTe"].ToString();
                    txtHoTen.Text = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    txtSoTiepNhan.Text = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["SoTiepNhan"].ToString();
                    txtGioiTinh.Text = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["GioiTinh"].ToString();
                    txtNamSinh.Text = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["NamSinh"].ToString();
                    txtTuoi.Text = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["Tuoi"].ToString();

                    TiepNhan_Id = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["TiepNhan_Id"].ToString();
                    BenhNhan_Id = LoadThongTinBenhNhanDaTiepNhanKhamBenh.Rows[0]["BenhNhan_Id"].ToString();
                }
            }
            DataTable LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau = Model.dbKhamBenh.LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau(CLSYeuCau_Id);
            if (LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau != null)
            {
                if (LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau.Rows.Count > 0)
                {
                    txtNoiDungKham.Text = LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau.Rows[0]["TenDichVu"].ToString();
                    CLSYeuCau_Id = LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau.Rows[0]["CLSYeuCau_Id"].ToString();
                }
            }
        }
        public void LoadThongTinBenhNhanDaKhamButton()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = true;
            btnXem.Enabled = true;
            btnIn.Enabled = true;
            btnTimKiem.Enabled = true;
        }

        public void LoadThongTinBenhNhanDaKham()
        {
            DataTable LoadThongTinBenhNhanDaKhamBenh = Model.dbKhamBenh.LoadThongTinBenhNhanDaKhamBenh(KhamBenh_Id);
            if (LoadThongTinBenhNhanDaKhamBenh.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["MaYTe"].ToString();
                txtHoTen.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                txtSoTiepNhan.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["SoTiepNhan"].ToString();
                txtGioiTinh.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["GioiTinh"].ToString();
                txtNamSinh.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["NamSinh"].ToString();
                txtTuoi.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["Tuoi"].ToString();

                TiepNhan_Id = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["TiepNhan_Id"].ToString();
                BenhNhan_Id = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["BenhNhan_Id"].ToString();
                txtNoiDungKham.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["TenDichVu"].ToString();
                CLSYeuCau_Id = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["CLSYeuCau_Id"].ToString();

                txtMach.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["Mach"].ToString();
                txtNhietDo.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["NhietDo"].ToString();
                txtCanNang.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["CanNang"].ToString();
                txtChieuCao.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["ChieuCao"].ToString();
                txtHuyetApCao.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["HuyetApCao"].ToString();
                txtHuyetApThap.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["HuyetApThap"].ToString();
                txtNhipTho.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["NhipTho"].ToString();
                txtBMI.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["BMI"].ToString();
                txtTrieuChung.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["TrieuChung"].ToString();
                txtChanDoan.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["ChanDoan"].ToString();
                //txtKetLuan.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["KetLuan"].ToString();
                txtLoiDan.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["LoiDan"].ToString();

                txtTienSu.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["TienSu"].ToString();
                txtKham.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["Kham"].ToString();

                txtLyDoKham.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["LyDoKham"].ToString();
                txtTomTatKetQuaCLS.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["TomTatCLS"].ToString();
                txtDieuTri.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["DieuTri"].ToString();
                txtGhiChu.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["GhiChu"].ToString();

                txtNoiDungHenTaiKhai.Text = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["NoiDungHenTaiKham"].ToString();

                string PhongKham_Id = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["PhongKham_Id"].ToString();
                if (!String.IsNullOrEmpty(PhongKham_Id))
                {
                    cbbPhongKham.Value = Int32.Parse(PhongKham_Id);
                }

                string BacSiKham = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["BacSiKham"].ToString();
                if (!String.IsNullOrEmpty(BacSiKham))
                {
                    cbbBacSiKham.Value = Int32.Parse(BacSiKham);
                }

                string ThoiGianKham = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["ThoiGianKham"].ToString();
                if (!String.IsNullOrEmpty(ThoiGianKham))
                {
                    DateTime enteredDate = DateTime.Parse(ThoiGianKham);
                    txtThoiGianKham.Value = enteredDate;
                }

                string HenTaiKham = LoadThongTinBenhNhanDaKhamBenh.Rows[0]["HenTaiKham"].ToString();
                if (!String.IsNullOrEmpty(HenTaiKham))
                {
                    DateTime enteredDate = DateTime.Parse(HenTaiKham);
                    txtHenTaiKham.Value = enteredDate;
                }
            }
            DataTable ThemClsYeuCauVaoPhieuDangNhap = Model.DbTiepNhan.ThemClsYeuCauVaoPhieuDangNhap(Login.PhienDangNhap_Id, TiepNhan_Id);
            DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
            gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;

            DataTable ThemBookingVaoPhieuDangNhap = Model.dbKhamBenh.ThemBookingVaoPhieuDangNhap(Login.PhienDangNhap_Id, KhamBenh_Id);
            DataTable SelectDuocBooking = Model.dbKhamBenh.SelectDuocBooking(Login.PhienDangNhap_Id);
            gridThuoc.DataSource = SelectDuocBooking;

            DataTable CheckNhomDichVuDaChiDinhTheoTiepNhan = Model.dbKhamBenh.CheckNhomDichVuDaChiDinhTheoTiepNhan(TiepNhan_Id);
            if (CheckNhomDichVuDaChiDinhTheoTiepNhan != null)
            {
                string MaNhomKham = CheckNhomDichVuDaChiDinhTheoTiepNhan.Rows[0]["MaNhomDichVu"].ToString();
                if (MaNhomKham.Contains("XN")) { btnXetNghiem.Enabled = true; } else { btnXetNghiem.Enabled = false; }
                if (MaNhomKham.Contains("SA") || MaNhomKham.Contains("XQ") || MaNhomKham.Contains("GPB") || MaNhomKham.Contains("SCTC") || MaNhomKham.Contains("K-")) { btnChanDoanHinhAnh.Enabled = true; } else { btnChanDoanHinhAnh.Enabled = false; }
            }

            Resettab();
        }

        public void Hien()
        {
            txtMaYTe.Enabled = false;
            txtSoTiepNhan.Enabled = false;
            txtHoTen.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtNamSinh.Enabled = false;
            txtTuoi.Enabled = false;
            txtNoiDungKham.Enabled = false;
            btnLamTuoi.Enabled = false;

            txtMach.Enabled = true;
            txtNhietDo.Enabled = true;
            txtCanNang.Enabled = true;
            txtChieuCao.Enabled = true;
            txtHuyetApCao.Enabled = true;
            txtHuyetApThap.Enabled = true;
            txtNhipTho.Enabled = true;
            txtBMI.Enabled = true;
            txtTrieuChung.Enabled = true;
            txtChanDoan.Enabled = true;

            pnDichVu.Enabled = true;
            pnNhomBenh.Enabled = true;
            pnThuoc.Enabled = true;
            pnToaThuocMau.Enabled = true;
            txtSang.Enabled = true;
            pnPhongKham.Enabled = false;
            pnBacSi.Enabled = false;
            gridDSKham.Enabled = false;
            pnThoiGianKham.Enabled = true;
            pnHenTaiKham.Enabled = true;
            //txtKetLuan.Enabled = true;
            txtLoiDan.Enabled = true;

            txtSang.Enabled = true;
            txtTrua.Enabled = true;
            txtChieu.Enabled = true;
            txtToi.Enabled = true;
            txtSoNgay.Enabled = true;
            txtSoLuong.Enabled = true;
            txtCachDung.Enabled = true;

            btnThemNhomBenh.Enabled = true;
            btnChonDichVu.Enabled = true;
            btnXoaDichVu.Enabled = true;

            btnThemThuoc.Enabled = true;
            btnThemToaMau.Enabled = true;
            btnXoaThuoc.Enabled = true;
            btnNew.Enabled = true;

            txtTienSu.Enabled = true;
            txtKham.Enabled = true;
            txtLyDoKham.Enabled = true;
            txtTomTatKetQuaCLS.Enabled = true;
            txtDieuTri.Enabled = true;
            txtGhiChu.Enabled = true;
            txtNoiDungHenTaiKhai.Enabled = true;
        }
        public void An()
        {
            txtMaYTe.Enabled = true;
            txtSoTiepNhan.Enabled = true;
            txtHoTen.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtNamSinh.Enabled = true;
            txtTuoi.Enabled = true;
            txtNoiDungKham.Enabled = true;
            btnLamTuoi.Enabled = true;

            txtMach.Enabled = false;
            txtNhietDo.Enabled = false;
            txtCanNang.Enabled = false;
            txtChieuCao.Enabled = false;
            txtHuyetApCao.Enabled = false;
            txtHuyetApThap.Enabled = false;
            txtNhipTho.Enabled = false;
            txtBMI.Enabled = false;
            txtTrieuChung.Enabled = false;
            txtChanDoan.Enabled = false;

            pnDichVu.Enabled = false;
            pnNhomBenh.Enabled = false;
            pnThuoc.Enabled = false;
            pnToaThuocMau.Enabled = false;
            txtSang.Enabled = false;
            pnPhongKham.Enabled = true;
            pnBacSi.Enabled = true;
            gridDSKham.Enabled = true;
            pnThoiGianKham.Enabled = false;
            //txtKetLuan.Enabled = false;
            txtLoiDan.Enabled = false;
            pnHenTaiKham.Enabled = false;

            txtSang.Enabled = false;
            txtTrua.Enabled = false;
            txtChieu.Enabled = false;
            txtToi.Enabled = false;
            txtSoNgay.Enabled = false;
            txtSoLuong.Enabled = false;
            txtCachDung.Enabled = false;

            btnThemNhomBenh.Enabled = false;
            btnChonDichVu.Enabled = false;
            btnXoaDichVu.Enabled = false;

            btnThemThuoc.Enabled = false;
            btnThemToaMau.Enabled = false;
            btnXoaThuoc.Enabled = false;
            btnNew.Enabled = false;

            txtTienSu.Enabled = false;
            txtKham.Enabled = false;
            txtLyDoKham.Enabled = false;
            txtTomTatKetQuaCLS.Enabled = false;
            txtDieuTri.Enabled = false;
            txtGhiChu.Enabled = false;
            txtNoiDungHenTaiKhai.Enabled = false;
        }
        public void Reset()
        {
            //txtMaYTe.Text = "";
            //txtSoTiepNhan.Text = "";
            //txtHoTen.Text = "";
            //txtGioiTinh.Text = "";
            //txtNamSinh.Text = "";
            //txtTuoi.Text = "";
            //txtNoiDungKham.Text = "";

            txtMach.Text = "";
            txtNhietDo.Text = "";
            txtCanNang.Text = "";
            txtChieuCao.Text = "";
            txtHuyetApCao.Text = "";
            txtHuyetApThap.Text = "";
            txtNhipTho.Text = "";
            txtBMI.Text = "";
            txtTrieuChung.Text = "";
            txtChanDoan.Text = "";

            //txtKetLuan.Text = "";
            txtLoiDan.Text = "";
            txtSang.Text = "";

            cbbNhomBenh.Text = "";
            cbbDV.Text = "";
            cbbThuoc.Text = "";
            cbbToaThuocMau.Text = "";

            txtSang.Text = "";
            txtTrua.Text = "";
            txtChieu.Text = "";
            txtToi.Text = "";
            txtSoNgay.Text = "";
            txtSoLuong.Text = "";
            txtCachDung.Text = "";

            txtThoiGianKham.Value = DateTime.Now;
            txtHenTaiKham.Text = "";

            //DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
            DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
            DataTable HoanTatBookingPhienDangNhap = Model.dbKhamBenh.HoanTatBookingPhienDangNhap(Login.PhienDangNhap_Id);
            gridDichVu.DataSource = null;
            gridThuoc.DataSource = null;

            txtTienSu.Text = "";
            txtKham.Text = "";
            txtLyDoKham.Text = "";
            txtTomTatKetQuaCLS.Text = "";
            txtDieuTri.Text = "";
            txtGhiChu.Text = "";
            txtNoiDungHenTaiKhai.Text = "";

        }
        void Resettab()
        {
            cbbNhomBenh.Text = "";
            cbbDV.Text = "";
            cbbThuoc.Text = "";
            cbbToaThuocMau.Text = "";
            txtSang.Text = ""; txtTrua.Text = ""; txtChieu.Text = ""; txtToi.Text = "";
            txtSoNgay.Text = ""; txtSoLuong.Text = ""; txtCachDung.Text = "";
        }

        private void btnChonDichVu_Click(object sender, EventArgs e)
        {
            if (cbbDV.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbDV.SelectedItem;
                string DichVuId = typeItem.Row[0].ToString();
                DataRowView typeItem1 = (DataRowView)cbbphongban.SelectedItem;
                string Phongban_id = typeItem1.Row[0].ToString();
                DataTable Dm_DichVu_DonGia = Model.DbTiepNhan.Dm_DichVu_DonGia(DichVuId);
                string GiaDichVu = Dm_DichVu_DonGia.Rows[0]["GiaDichVu"].ToString();
                //
                DataTable InsertCLSYeuCau = Model.DbTiepNhan.InsertCLSYeuCau(
                                  "null"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , DichVuId
                                , "1"
                                , GiaDichVu
                                , "null"
                                , "1"
                                , "ChuaThucHien"
                                , Login.User_Id
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , "null"
                                ,Phongban_id
                                );
                if (InsertCLSYeuCau.Rows.Count > 0)
                {
                    CLSYeuCauChiTiet_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                    CLSYeuCauCha_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                }
                DataTable InsertCLSYeuCau_PhieuDangNhap = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                    Login.PhienDangNhap_Id
                    , CLSYeuCauChiTiet_Id
                    , DichVuId
                    , "N'" + "Them" + "'"
                    );
                //thêm phiếu yêu cầu cho dịch vụ cấp dưới
                DataTable CheckDichVuCapDuoi = Model.DbTiepNhan.CheckDichVuCapDuoi(DichVuId);
                if (CheckDichVuCapDuoi != null)
                {
                    if (CheckDichVuCapDuoi.Rows.Count > 0)
                    {
                        for (int j = 0; j < CheckDichVuCapDuoi.Rows.Count; j++)
                        {
                            DataTable InsertCLSYeuCauCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau(
                                  "null"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                , "1"
                                , "0" //set giá dịch vụ = 0
                                , "null"
                                , "1"
                                , "ChuaThucHien"
                                , Login.User_Id
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , CLSYeuCauCha_Id
                                ,Phongban_id
                                );
                            if (InsertCLSYeuCauCapDuoi.Rows.Count > 0)
                            {
                                CLSYeuCauChiTiet_Id = InsertCLSYeuCauCapDuoi.Rows[0][0].ToString();
                            }
                            DataTable InsertCLSYeuCau_PhieuDangNhapCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                                Login.PhienDangNhap_Id
                                , CLSYeuCauChiTiet_Id
                                , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                , "N'" + "Them" + "'"
                                );
                        }
                    }
                }
                //
                DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
                gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                Resettab();
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn Dịch vụ!", "");
            }
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            DataTable CheckDichVuDaThucHien = Model.DbTiepNhan.CheckDichVuDaThucHien(CLSYeuCauChiTiet_Id);
            if (CheckDichVuDaThucHien != null)
            {
                if (CheckDichVuDaThucHien.Rows[0]["TrangThai"].ToString() == "ChuaThucHien")
                {
                    DataTable Delete = Model.DbTiepNhan.Delete_ClsYeuCau_PhienDangNhap(CLSYeuCauChiTiet_Id, Login.User_Id);

                    DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
                    gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                    CLSYeuCauChiTiet_Id = "";
                    Resettab();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Phiếu yêu cầu đã có kết quả!", "");
                }
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn phiếu cần xóa!", "");
            }
        }

        private void btnThemNhomBenh_Click(object sender, EventArgs e)
        {
            if (cbbNhomBenh.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbNhomBenh.SelectedItem;
                string NhomBenhId = typeItem.Row[0].ToString();

                DataTable CheckNhomBenh_DichVu = Model.DbTiepNhan.CheckNhomBenh_DichVu(NhomBenhId);
                if (CheckNhomBenh_DichVu != null)
                {
                    if (CheckNhomBenh_DichVu.Rows.Count > 0)
                    {
                        for (int i = 0; i < CheckNhomBenh_DichVu.Rows.Count; i++)
                        {
                            DataTable InsertCLSYeuCau = Model.DbTiepNhan.InsertCLSYeuCau(
                                  "null"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString()
                                , "1"
                                , CheckNhomBenh_DichVu.Rows[i]["GiaDichVu"].ToString()
                                , "null"
                                , "1"
                                , "ChuaThucHien"
                                , Login.User_Id
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , "null"
                                , CheckNhomBenh_DichVu.Rows[i]["PhongBan_Id"].ToString()
                                );
                            if (InsertCLSYeuCau.Rows.Count > 0)
                            {
                                CLSYeuCauChiTiet_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                                CLSYeuCauCha_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                            }
                            DataTable InsertCLSYeuCau_PhieuDangNhap = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                                Login.PhienDangNhap_Id
                                , CLSYeuCauChiTiet_Id
                                , CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString()
                                , "N'" + "Them" + "'"
                                );
                            //thêm phiếu yêu cầu cho dịch vụ cấp dưới
                            DataTable CheckDichVuCapDuoi = Model.DbTiepNhan.CheckDichVuCapDuoi(CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString());
                            if (CheckDichVuCapDuoi != null)
                            {
                                if (CheckDichVuCapDuoi.Rows.Count > 0)
                                {
                                    for (int j = 0; j < CheckDichVuCapDuoi.Rows.Count; j++)
                                    {
                                        DataTable InsertCLSYeuCauCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau(
                                              "null"
                                            , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            , "null"
                                            , "null"
                                            , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                            , "1"
                                            , "0" //set gia dịch vụ = 0
                                            , "null"
                                            , "1"
                                            , "ChuaThucHien"
                                            , Login.User_Id
                                            , Login.User_Id
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            , "null"
                                            , "null"
                                            , "0"
                                            , CLSYeuCauCha_Id
                                            , CheckNhomBenh_DichVu.Rows[i]["PhongBan_Id"].ToString()
                                            );
                                        if (InsertCLSYeuCauCapDuoi.Rows.Count > 0)
                                        {
                                            CLSYeuCauChiTiet_Id = InsertCLSYeuCauCapDuoi.Rows[0][0].ToString();
                                        }
                                        DataTable InsertCLSYeuCau_PhieuDangNhapCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                                            Login.PhienDangNhap_Id
                                            , CLSYeuCauChiTiet_Id
                                            , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                            , "N'" + "Them" + "'"
                                            );
                                    }
                                }
                            }
                        }
                        DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
                        gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                        Resettab();
                    }
                }
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn Nhóm bệnh!", "");
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView2.RowCount > 0)
            {
                CLSYeuCauChiTiet_Id = gridView2.GetRowCellValue(n, "CLSYeuCau_Id").ToString();
            }
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.Column.FieldName == "TrangThai")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TrangThai"]);
                if (status != "Chưa thực hiện")
                {
                    e.Appearance.BackColor = Color.FromArgb(52, 152, 219);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                    e.Appearance.ForeColor = Color.FromArgb(236, 240, 241);
                }
            }
            
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (cbbThuoc.SelectedItem == null)
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn loại dược!", "");
                cbbThuoc.Focus();
            }
            else if (txtSoLuong.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa nhập số lượng!", "");
                txtSoLuong.Focus();
            }
            else
            {
                DataRowView typeItem = (DataRowView)cbbThuoc.SelectedItem;
                string Duoc_Id = typeItem.Row[0].ToString();

                DataTable Dm_Duoc_DonGia = Model.dbKhamBenh.Dm_Duoc_DonGia(Duoc_Id);
                string GiaDuoc = Dm_Duoc_DonGia.Rows[0]["DonGia"].ToString();
                //

                string Sang = "null";
                if (txtSang.Text != "") { Sang = "N'" + txtSang.Text + "'"; }
                string Trua = "null";
                if (txtTrua.Text != "") { Trua = "N'" + txtTrua.Text + "'";  }
                string Chieu = "null";
                if (txtChieu.Text != "") { Chieu = "N'" + txtChieu.Text + "'";  }
                string Toi = "null";
                if (txtToi.Text != "") { Toi = "N'" + txtToi.Text + "'";  }
                string SoNgay = "null";
                if (txtSoNgay.Text != "") { SoNgay = "N'" + txtSoNgay.Text + "'";  }
                string SoLuong = "null";
                if (txtSoLuong.Text != "") { SoLuong = "N'" + txtSoLuong.Text + "'";  }

                string CachDung = "null";
                if (txtCachDung.Text != "") { CachDung = "N'" + txtCachDung.Text + "'"; }

                if (ToaThuoc_Id == "") // Thêm toa thuốc mới
                {
                    DataTable InsertToaThuoc = Model.dbKhamBenh.InsertToaThuoc(
                                 "null"
                                , "null"
                                , Duoc_Id
                                , Sang
                                , Trua
                                , Chieu
                                , Toi
                                , SoNgay
                                , SoLuong
                                , GiaDuoc
                                , "null" //ThanhTien
                                , "0" //DaCho
                                , "0" //SoLuongDaCho
                                , "0" //DaThanhToan
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , CachDung
                                );
                    if (InsertToaThuoc.Rows.Count > 0)
                    {
                        ToaThuoc_Id = InsertToaThuoc.Rows[0]["ToaThuoc_Id"].ToString();
                    }
                    DataTable InsertToaThuoc_PhieuDangNhap = Model.dbKhamBenh.InsertToaThuoc_PhieuDangNhap(
                        Login.PhienDangNhap_Id
                        , "null"
                        , ToaThuoc_Id
                        , Duoc_Id
                        , Sang
                        , Trua
                        , Chieu
                        , Toi
                        , SoNgay
                        , SoLuong
                        , GiaDuoc
                        , "N'" + "Them" + "'"
                        , CachDung
                        );

                    //
                    DataTable SelectDuocBooking = Model.dbKhamBenh.SelectDuocBooking(Login.PhienDangNhap_Id);
                    gridThuoc.DataSource = SelectDuocBooking;
                    ToaThuoc_Id = "";
                    cbbThuoc.Focus();
                }
                else //Sửa toa thuốc đang chọn
                {
                    DataTable UpdateToaThuoc_PhieuDangNhap = Model.dbKhamBenh.UpdateToaThuoc_PhieuDangNhap(
                        Login.PhienDangNhap_Id
                        , "null"
                        , ToaThuoc_Id
                        , Duoc_Id
                        , Sang
                        , Trua
                        , Chieu
                        , Toi
                        , SoNgay
                        , SoLuong
                        , GiaDuoc
                        , "N'" + "Sua" + "'"
                        , CachDung
                        );

                    //
                    DataTable SelectDuocBooking = Model.dbKhamBenh.SelectDuocBooking(Login.PhienDangNhap_Id);
                    gridThuoc.DataSource = SelectDuocBooking;
                    ToaThuoc_Id = "";
                    cbbThuoc.Focus();
                }
                Resettab();
                // 
            }
            cbbThuoc.DataSource = Dm_Duoc;
            cbbThuoc.DroppedDown = true;
        }

        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            DataTable CheckThuocDaBan = Model.dbKhamBenh.CheckThuocDaBan(ToaThuoc_Id);
            if (CheckThuocDaBan != null)
            {
                if (CheckThuocDaBan.Rows[0]["DaCho"].ToString() == "0")
                {
                    DataTable Delete = Model.dbKhamBenh.Delete_BookingDuoc_PhienDangNhap(ToaThuoc_Id);

                    DataTable SelectDuocBooking = Model.dbKhamBenh.SelectDuocBooking(Login.PhienDangNhap_Id);
                    gridThuoc.DataSource = SelectDuocBooking;
                    ToaThuoc_Id = "";
                    Resettab();
                    cbbThuoc.Focus();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Thuốc này đã bán từ nhà thuốc!", "");
                }
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn toa thuốc cần xóa!", "");
            }
        }

        private void gridView3_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView3.RowCount > 0)
            {
                ToaThuoc_Id = gridView3.GetRowCellValue(n, "ToaThuoc_Id").ToString();
                SelectDuocBookingTheoToaThuocID();
            }
        }
        public void SelectDuocBookingTheoToaThuocID()
        {
            DataTable SelectDuocBookingTheoID = Model.dbKhamBenh.SelectDuocBookingTheoID(Login.PhienDangNhap_Id,ToaThuoc_Id);
            if (SelectDuocBookingTheoID.Rows.Count > 0)
            {
                txtSang.Text = SelectDuocBookingTheoID.Rows[0]["Sang"].ToString();
                txtTrua.Text = SelectDuocBookingTheoID.Rows[0]["Trua"].ToString();
                txtChieu.Text = SelectDuocBookingTheoID.Rows[0]["Chieu"].ToString();
                txtToi.Text = SelectDuocBookingTheoID.Rows[0]["Toi"].ToString();
                txtSoNgay.Text = SelectDuocBookingTheoID.Rows[0]["SoNgay"].ToString();
                txtSoLuong.Text = SelectDuocBookingTheoID.Rows[0]["SoLuong"].ToString();

                string Duoc_Id = SelectDuocBookingTheoID.Rows[0]["Duoc_Id"].ToString();
                if (!String.IsNullOrEmpty(Duoc_Id))
                {
                    cbbThuoc.Value = Int32.Parse(Duoc_Id);
                }

                txtCachDung.Text = SelectDuocBookingTheoID.Rows[0]["GhiChu"].ToString();

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ToaThuoc_Id = "";
            Dm_Duoc = Model.dbKhamBenh.CBBDuoc();
            cbbThuoc.DataSource = Dm_Duoc;
            cbbThuoc.ValueMember = "Duoc_Id";
            cbbThuoc.DisplayMember = "TenDuocDayDu";
            Resettab();
            cbbThuoc.Focus();
            cbbThuoc.DataSource = Dm_Duoc;
            cbbThuoc.DroppedDown = true;
        }

        private void cbbThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            //string text = cbbThuoc.Text;
            //if (text == "")
            //{
            //    DataTable dtResult = Dm_Duoc.Select("TenDuocDayDu LIKE '%" + text + "%' or MaDuoc LIKE '%" + text + "%'").CopyToDataTable();
            //    cbbThuoc.DataSource = dtResult;
            //    cbbThuoc.DroppedDown = true;
            //}
            //else
            //{
            //    DataRow[] resultRow = Dm_Duoc.Select("TenDuocDayDu LIKE '%" + text + "%' or MaDuoc LIKE '%" + text + "%'");
            //    if (resultRow.Count() > 0)
            //    {
            //        DataTable dtResult = Dm_Duoc.Select("TenDuocDayDu LIKE '%" + text + "%' or MaDuoc LIKE '%" + text + "%'").CopyToDataTable();
            //        cbbThuoc.DataSource = dtResult;
            //        cbbThuoc.DroppedDown = true;
            //    }
            //    else
            //    {
            //        cbbThuoc.DataSource = null;
            //        cbbThuoc.DroppedDown = true;
            //    }
            //}
        }

        private void cbbDV_KeyDown(object sender, KeyEventArgs e)
        {
            //string text = cbbdv.text;
            //datarow[] resultrow = dm_dichvu.select("tendichvu like '%" + text + "%' or madichvu like '%" + text + "%'");
            //if (resultrow.count() > 0)
            //{
            //    datatable dtresult = dm_dichvu.select("tendichvu like '%" + text + "%' or madichvu like '%" + text + "%'").copytodatatable();
            //    cbbdv.datasource = dtresult;
            //    cbbdv.droppeddown = true;
            //}
            //else
            //{
            //    cbbdv.datasource = null;
            //    cbbdv.droppeddown = true;
            //}
        }

        private void cbbNhomBenh_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbNhomBenh.Text;
            DataRow[] resultRow = Dm_NhomBenh.Select("TenNhomBenh LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = Dm_NhomBenh.Select("TenNhomBenh LIKE '%" + text + "%'").CopyToDataTable();
                cbbNhomBenh.DataSource = dtResult;
                cbbNhomBenh.DroppedDown = true;
            }
            else
            {
                cbbNhomBenh.DataSource = null;
                cbbNhomBenh.DroppedDown = true;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void cbbBacSiKham_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btnThemToaMau_Click(object sender, EventArgs e)
        {
            if (cbbToaThuocMau.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbToaThuocMau.SelectedItem;
                string ToaThuocMau_Id = typeItem.Row[0].ToString();

                DataTable CheckToaThuocMau_Duoc = Model.dbKhamBenh.CheckToaThuocMau_Duoc(ToaThuocMau_Id);
                if (CheckToaThuocMau_Duoc != null)
                {
                    if (CheckToaThuocMau_Duoc.Rows.Count > 0)
                    {
                        for (int i1 = 0; i1 < CheckToaThuocMau_Duoc.Rows.Count; i1++)
                        {
                            string Sang = "null";
                            if (CheckToaThuocMau_Duoc.Rows[i1]["Sang"].ToString() != "")
                            { Sang = "N'" + CheckToaThuocMau_Duoc.Rows[i1]["Sang"].ToString() + "'"; }
                            string Trua = "null";
                            if (CheckToaThuocMau_Duoc.Rows[i1]["Trua"].ToString() != "")
                            { Trua = "N'" + CheckToaThuocMau_Duoc.Rows[i1]["Trua"].ToString() + "'"; }
                            string Chieu = "null";
                            if (CheckToaThuocMau_Duoc.Rows[i1]["Chieu"].ToString() != "")
                            { Chieu = "N'" + CheckToaThuocMau_Duoc.Rows[i1]["Chieu"].ToString() + "'"; }
                            string Toi = "null";
                            if (CheckToaThuocMau_Duoc.Rows[i1]["Toi"].ToString() != "")
                            { Toi = "N'" + CheckToaThuocMau_Duoc.Rows[i1]["Toi"].ToString() + "'"; }
                            string SoNgay = "null";
                            if (CheckToaThuocMau_Duoc.Rows[i1]["SoNgay"].ToString() != "")
                            { SoNgay = "N'" + CheckToaThuocMau_Duoc.Rows[i1]["SoNgay"].ToString() + "'"; }
                            string SoLuong = "null";
                            if (CheckToaThuocMau_Duoc.Rows[i1]["SoLuong"].ToString() != "")
                            { SoLuong = "N'" + CheckToaThuocMau_Duoc.Rows[i1]["SoLuong"].ToString() + "'"; }

                            string CachDung = "null";
                            if (CheckToaThuocMau_Duoc.Rows[i1]["CachSuDung"].ToString() != "")
                            { CachDung = "N'" + CheckToaThuocMau_Duoc.Rows[i1]["CachSuDung"].ToString() + "'"; }

                            DataTable InsertToaThuoc = Model.dbKhamBenh.InsertToaThuoc(
                                 "null"
                                , "null"
                                , CheckToaThuocMau_Duoc.Rows[i1]["Duoc_Id"].ToString()
                                , Sang
                                , Trua
                                , Chieu
                                , Toi
                                , SoNgay
                                , SoLuong
                                , "N'" + CheckToaThuocMau_Duoc.Rows[i1]["DonGia"].ToString() + "'"
                                , "null" //ThanhTien
                                , "0" //DaCho
                                , "0" //SoLuongDaCho
                                , "0" //DaThanhToan
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , CachDung
                                );
                            if (InsertToaThuoc.Rows.Count > 0)
                            {
                                ToaThuoc_Id = InsertToaThuoc.Rows[0]["ToaThuoc_Id"].ToString();
                            }

                            DataTable InsertToaThuoc_PhieuDangNhap = Model.dbKhamBenh.InsertToaThuoc_PhieuDangNhap(
                                Login.PhienDangNhap_Id
                                , "null"
                                , ToaThuoc_Id
                                , CheckToaThuocMau_Duoc.Rows[i1]["Duoc_Id"].ToString()
                                , Sang
                                , Trua
                                , Chieu
                                , Toi
                                , SoNgay
                                , SoLuong
                                , "N'" + CheckToaThuocMau_Duoc.Rows[i1]["DonGia"].ToString() + "'"
                                , "N'" + "Them" + "'"
                                , CachDung
                                );

                            //
                        }
                        DataTable SelectDuocBooking = Model.dbKhamBenh.SelectDuocBooking(Login.PhienDangNhap_Id);
                        gridThuoc.DataSource = SelectDuocBooking;
                        ToaThuoc_Id = "";
                        Resettab();
                        cbbThuoc.Focus();
                    }
                }
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn toa thuóc mẫu!", "");
            }
        }

        private void cbbToaThuocMau_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbToaThuocMau.Text;
            DataRow[] resultRow = Dm_ToaThuocMau.Select("TenToaThuocMau LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = Dm_ToaThuocMau.Select("TenToaThuocMau LIKE '%" + text + "%'").CopyToDataTable();
                cbbToaThuocMau.DataSource = dtResult;
                cbbToaThuocMau.DroppedDown = true;
            }
            else
            {
                cbbToaThuocMau.DataSource = null;
                cbbToaThuocMau.DroppedDown = true;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }
        private void btnChanDoanHinhAnh_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiParent.MdiChildren)
            {
                if (child.Name == "ChanDoanHinhAnh")
                {
                    child.Close();
                }
            }
            View.ChanDoanHinhAnh.ChanDoanHinhAnh frm = new View.ChanDoanHinhAnh.ChanDoanHinhAnh();
            View.ChanDoanHinhAnh.ChanDoanHinhAnh.TiepNhan_Id = TiepNhan_Id;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnXetNghiem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiParent.MdiChildren)
            {
                if (child.Name == "XetNghiem")
                {
                    child.Close();
                }
            }
            View.XetNghiem.XetNghiem frm = new View.XetNghiem.XetNghiem();
            View.XetNghiem.XetNghiem.TiepNhan_Id = TiepNhan_Id;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }


        private void txtSang_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtTrua_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtChieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtToi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSoNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtMach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNhietDo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtHuyetApCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtHuyetApThap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCanNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtChieuCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtBMI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNhipTho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtChieuCao_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (txtChieuCao.Text != "" && txtCanNang.Text != "")
                {
                    string cc = txtChieuCao.Text;
                    string cn = txtCanNang.Text;
                    decimal decimalCc = Decimal.Parse(cc, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalCn = Decimal.Parse(cn, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalBMI;
                    if (decimalCc != 0)
                    {
                        decimalBMI = decimalCn / (decimalCc * decimalCc);
                        txtBMI.Text = decimalBMI.ToString("0.00");
                    }
                }
            }
            if (e.KeyData == Keys.Enter)
            {
                if (txtChieuCao.Text != "" && txtCanNang.Text != "")
                {
                    string cc = txtChieuCao.Text;
                    string cn = txtCanNang.Text;
                    decimal decimalCc = Decimal.Parse(cc, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalCn = Decimal.Parse(cn, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalBMI;
                    if (decimalCc != 0)
                    {
                        decimalBMI = decimalCn / (decimalCc * decimalCc);
                        txtBMI.Text = decimalBMI.ToString("0.00");
                    }
                }
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                if (txtChieuCao.Text != "" && txtCanNang.Text != "")
                {
                    string cc = txtChieuCao.Text;
                    string cn = txtCanNang.Text;
                    decimal decimalCc = Decimal.Parse(cc, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalCn = Decimal.Parse(cn, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalBMI;
                    if (decimalCc != 0)
                    {
                        decimalBMI = decimalCn / (decimalCc * decimalCc);
                        txtBMI.Text = decimalBMI.ToString("0.00");
                    }
                }
            }
        }

        private void txtCanNang_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (txtChieuCao.Text != "" && txtCanNang.Text != "")
                {
                    string cc = txtChieuCao.Text;
                    string cn = txtCanNang.Text;
                    decimal decimalCc = Decimal.Parse(cc, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalCn = Decimal.Parse(cn, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalBMI;
                    if (decimalCc != 0)
                    {
                        decimalBMI = decimalCn / (decimalCc * decimalCc);
                        txtBMI.Text = decimalBMI.ToString("0.00");
                    }
                }
            }
            if (e.KeyData == Keys.Enter)
            {
                if (txtChieuCao.Text != "" && txtCanNang.Text != "")
                {
                    string cc = txtChieuCao.Text;
                    string cn = txtCanNang.Text;
                    decimal decimalCc = Decimal.Parse(cc, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalCn = Decimal.Parse(cn, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalBMI;
                    if (decimalCc != 0)
                    {
                        decimalBMI = decimalCn / (decimalCc * decimalCc);
                        txtBMI.Text = decimalBMI.ToString("0.00");
                    }
                }
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                if (txtChieuCao.Text != "" && txtCanNang.Text != "")
                {
                    string cc = txtChieuCao.Text;
                    string cn = txtCanNang.Text;
                    decimal decimalCc = Decimal.Parse(cc, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalCn = Decimal.Parse(cn, System.Globalization.CultureInfo.InvariantCulture);
                    decimal decimalBMI;
                    if (decimalCc != 0)
                    {
                        decimalBMI = decimalCn / (decimalCc * decimalCc);
                        txtBMI.Text = decimalBMI.ToString("0.00");
                    }
                }
            }
        }

        private void txtSang_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (txtSang.Text != "" )
                {
                    string s = txtSang.Text;
                    string tr = txtTrua.Text;
                    string c = txtChieu.Text;
                    string t = txtToi.Text;
                    string sn = txtSoNgay.Text;
                    decimal decimal_s = 0, decimal_tr = 0, decimal_c = 0, decimal_t = 0, decimal_sn = 0;
                    if (s != "") { decimal_s = Decimal.Parse(s, System.Globalization.CultureInfo.InvariantCulture);}
                    if (tr != "") {decimal_tr = Decimal.Parse(tr, System.Globalization.CultureInfo.InvariantCulture);}
                    if (c != ""){decimal_c = Decimal.Parse(c, System.Globalization.CultureInfo.InvariantCulture);}
                    if (t != ""){decimal_t = Decimal.Parse(t, System.Globalization.CultureInfo.InvariantCulture);}
                    if (sn != ""){decimal_sn = Decimal.Parse(sn, System.Globalization.CultureInfo.InvariantCulture);}
                    decimal decimalSL = (decimal_s + decimal_tr + decimal_c + decimal_t) * decimal_sn;
                    txtSoLuong.Text = decimalSL.ToString("0.00");
                }
            }
        }

        private void txtSoNgay_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (txtSoNgay.Text != "")
                {
                    string s = txtSang.Text;
                    string tr = txtTrua.Text;
                    string c = txtChieu.Text;
                    string t = txtToi.Text;
                    string sn = txtSoNgay.Text;
                    decimal decimal_s = 0, decimal_tr = 0, decimal_c = 0, decimal_t = 0, decimal_sn = 0;
                    if (s != "") { decimal_s = Decimal.Parse(s, System.Globalization.CultureInfo.InvariantCulture); }
                    if (tr != "") { decimal_tr = Decimal.Parse(tr, System.Globalization.CultureInfo.InvariantCulture); }
                    if (c != "") { decimal_c = Decimal.Parse(c, System.Globalization.CultureInfo.InvariantCulture); }
                    if (t != "") { decimal_t = Decimal.Parse(t, System.Globalization.CultureInfo.InvariantCulture); }
                    if (sn != "") { decimal_sn = Decimal.Parse(sn, System.Globalization.CultureInfo.InvariantCulture); }
                    decimal decimalSL = (decimal_s + decimal_tr + decimal_c + decimal_t) * decimal_sn;
                    txtSoLuong.Text = decimalSL.ToString("0.00");
                }
            }
        }

        private void txtTrua_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (txtTrua.Text != "")
                {
                    string s = txtSang.Text;
                    string tr = txtTrua.Text;
                    string c = txtChieu.Text;
                    string t = txtToi.Text;
                    string sn = txtSoNgay.Text;
                    decimal decimal_s = 0, decimal_tr = 0, decimal_c = 0, decimal_t = 0, decimal_sn = 0;
                    if (s != "") { decimal_s = Decimal.Parse(s, System.Globalization.CultureInfo.InvariantCulture); }
                    if (tr != "") { decimal_tr = Decimal.Parse(tr, System.Globalization.CultureInfo.InvariantCulture); }
                    if (c != "") { decimal_c = Decimal.Parse(c, System.Globalization.CultureInfo.InvariantCulture); }
                    if (t != "") { decimal_t = Decimal.Parse(t, System.Globalization.CultureInfo.InvariantCulture); }
                    if (sn != "") { decimal_sn = Decimal.Parse(sn, System.Globalization.CultureInfo.InvariantCulture); }
                    decimal decimalSL = (decimal_s + decimal_tr + decimal_c + decimal_t) * decimal_sn;
                    txtSoLuong.Text = decimalSL.ToString("0.00");
                }
            }
        }

        private void txtChieu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (txtChieu.Text != "")
                {
                    string s = txtSang.Text;
                    string tr = txtTrua.Text;
                    string c = txtChieu.Text;
                    string t = txtToi.Text;
                    string sn = txtSoNgay.Text;
                    decimal decimal_s = 0, decimal_tr = 0, decimal_c = 0, decimal_t = 0, decimal_sn = 0;
                    if (s != "") { decimal_s = Decimal.Parse(s, System.Globalization.CultureInfo.InvariantCulture); }
                    if (tr != "") { decimal_tr = Decimal.Parse(tr, System.Globalization.CultureInfo.InvariantCulture); }
                    if (c != "") { decimal_c = Decimal.Parse(c, System.Globalization.CultureInfo.InvariantCulture); }
                    if (t != "") { decimal_t = Decimal.Parse(t, System.Globalization.CultureInfo.InvariantCulture); }
                    if (sn != "") { decimal_sn = Decimal.Parse(sn, System.Globalization.CultureInfo.InvariantCulture); }
                    decimal decimalSL = (decimal_s + decimal_tr + decimal_c + decimal_t) * decimal_sn;
                    txtSoLuong.Text = decimalSL.ToString("0.00");
                }
            }
        }

        private void txtToi_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (txtToi.Text != "")
                {
                    string s = txtSang.Text;
                    string tr = txtTrua.Text;
                    string c = txtChieu.Text;
                    string t = txtToi.Text;
                    string sn = txtSoNgay.Text;
                    decimal decimal_s = 0, decimal_tr = 0, decimal_c = 0, decimal_t = 0, decimal_sn = 0;
                    if (s != "") { decimal_s = Decimal.Parse(s, System.Globalization.CultureInfo.InvariantCulture); }
                    if (tr != "") { decimal_tr = Decimal.Parse(tr, System.Globalization.CultureInfo.InvariantCulture); }
                    if (c != "") { decimal_c = Decimal.Parse(c, System.Globalization.CultureInfo.InvariantCulture); }
                    if (t != "") { decimal_t = Decimal.Parse(t, System.Globalization.CultureInfo.InvariantCulture); }
                    if (sn != "") { decimal_sn = Decimal.Parse(sn, System.Globalization.CultureInfo.InvariantCulture); }
                    decimal decimalSL = (decimal_s + decimal_tr + decimal_c + decimal_t) * decimal_sn;
                    txtSoLuong.Text = decimalSL.ToString("0.00");
                }
            }
        }

        private void KhamBenh_FormClosing(object sender, FormClosingEventArgs e)
        {
            TiepNhan_Id = "";
        }


        private void cbbThuoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbThuoc.Text;
                if (text == "")
                {
                    DataTable dtResult = Dm_Duoc.Select("TenDuocDayDu LIKE '%" + text + "%' or MaDuoc LIKE '%" + text + "%'").CopyToDataTable();
                    cbbThuoc.DataSource = dtResult;
                    cbbThuoc.DroppedDown = true;
                }
                else
                {
                    DataRow[] resultRow = Dm_Duoc.Select("TenDuocDayDu LIKE '%" + text + "%' or MaDuoc LIKE '%" + text + "%'");
                    if (resultRow.Count() > 0)
                    {
                        DataTable dtResult = Dm_Duoc.Select("TenDuocDayDu LIKE '%" + text + "%' or MaDuoc LIKE '%" + text + "%'").CopyToDataTable();
                        cbbThuoc.DataSource = dtResult;
                        cbbThuoc.DroppedDown = true;
                    }
                    else
                    {
                        cbbThuoc.DataSource = null;
                        cbbThuoc.DroppedDown = true;
                    }
                }
            }
        }

        private void cbbThuoc_Click(object sender, EventArgs e)
        {
            cbbThuoc.DataSource = Dm_Duoc;
            cbbThuoc.DroppedDown = true;
        }


        private void cbbLoaiKetQua_ValueChanged(object sender, EventArgs e)
        {
            string text = cbbTuDien.Value.ToString();
            DataRow[] resultRow = TuDienChanDoan.Select("FieldCode = " + text);
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = TuDienChanDoan.Select("FieldCode = " + text).CopyToDataTable();
                if (txtChanDoan.Text == "")
                {
                    txtChanDoan.Text = dtResult.Rows[0]["ChanDoan"].ToString();

                }
                else
                {
                    DialogResult dr = MessageBox.Show("Trường Chẩn đoán đã có dữ liệu nhập, bạn có muốn thay đổi?", "Thong Bao!", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            txtChanDoan.Text = dtResult.Rows[0]["ChanDoan"].ToString();
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                //
                if (txtLoiDan.Text == "")
                {
                    txtLoiDan.Text = dtResult.Rows[0]["LoiDan"].ToString();

                }
                else
                {
                    DialogResult dr = MessageBox.Show("Trường Lời dặn đã có dữ liệu nhập, bạn có muốn thay đổi?", "Thong Bao!", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            txtLoiDan.Text = dtResult.Rows[0]["LoiDan"].ToString();
                            break;
                        case DialogResult.No:
                            break;
                    }
                }

            }
        }

        private void btnHangDoi_Click(object sender, EventArgs e)
        {
            View.KhamBenh.HangDoiKhamBenh bc = new View.KhamBenh.HangDoiKhamBenh();
            bc.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                LoadThongTinBenhNhanDaKhamButton();
                LoadThongTinBenhNhanDaKham();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                string nguoicapnhat = Login.User_Id;
                DialogResult dr = MessageBox.Show("Bạn có đồng ý xác nhận hoàn tất khám không? Nếu xác nhận, dữ liệu sẽ không thể sửa hoặc xoá!",
                "Thong Bao!", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        DataTable InsertXacNhanHoanTatKham = Model.dbKhamBenh.InsertXacNhanHoanTatKham(TiepNhan_Id, KhamBenh_Id, "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", nguoicapnhat);
                        if (InsertXacNhanHoanTatKham != null)
                        {
                            alertControl1.Show(this, "Thông báo", "Đã xác nhận thành công!", "");

                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Có lỗi trong quá trình xử lý! vui lòng kiểm tra lại.", "");
                        }
                        //
                        break;
                    case DialogResult.No:
                        break;
                }
            }
             
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                DataTable SelectXacNhanHoanTatKham = Model.dbKhamBenh.SelectXacNhanHoanTatKham(KhamBenh_Id);
                if (SelectXacNhanHoanTatKham != null)
                {
                    if (SelectXacNhanHoanTatKham.Rows.Count > 0)
                    {
                        string nguoicapnhat = Login.User_Id;
                        DialogResult dr = MessageBox.Show("Bạn có đồng ý huỷ xác nhận hoàn tất khám không?",
                        "Thong Bao!", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                DataTable UpdateXacNhanHoanTatKham = Model.dbKhamBenh.UpdateXacNhanHoanTatKham(KhamBenh_Id, "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", nguoicapnhat);
                                if (UpdateXacNhanHoanTatKham != null)
                                {
                                    alertControl1.Show(this, "Thông báo", "Đã huỷ xác nhận thành công!", "");

                                }
                                else
                                {
                                    alertControl1.Show(this, "Thông báo", "Có lỗi trong quá trình xử lý! vui lòng kiểm tra lại.", "");
                                }
                                //
                                break;
                            case DialogResult.No:
                                break;
                        }
                    }
                    else
                    {
                        alertControl1.Show(this, "Thông báo", "Bệnh nhân này chưa xác nhận công khám!", "");
                    }
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Bệnh nhân này chưa xác nhận công khám!", "");
                }
            }
        }

        private void cbbThuoc_ValueChanged(object sender, EventArgs e)
        {
            if (cbbThuoc.SelectedItem != null)
            {
                DataTable dtResult = Dm_Duoc.Select("Duoc_Id = '" + cbbThuoc.Value.ToString() + "'").CopyToDataTable();
                if (dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        txtCachDung.Text = dtResult.Rows[0]["CachSuDung"].ToString();
                    }
                }
                    
            }
            
        }

        private void btnXemBenhSu_Click(object sender, EventArgs e)
        {
            View.BenhNhan.BenhSu.BNKham_Id = "";
            foreach (Form child in this.MdiParent.MdiChildren)
            {
                if (child.Name == "BenhSu")
                {
                    child.Close();
                }
            }
            View.BenhNhan.BenhSu frm = new View.BenhNhan.BenhSu();
            View.BenhNhan.BenhSu.BNKham_Id = BenhNhan_Id;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void KhamBenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {
                if (btnLuu.Enabled == true)
                {
                    btnLuu.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Lưu!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                if (btnThem.Enabled == true)
                {
                    btnThem.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Thêm!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                if (btnSua.Enabled == true)
                {
                    btnSua.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Sửa!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.W)
            {
                if (btnHuy.Enabled == true)
                {
                    btnHuy.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Huỷ!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D)
            {
                if (btnXoa.Enabled == true)
                {
                    btnXoa.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Xoá!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
            {
                if (btnTimKiem.Enabled == true)
                {
                    btnTimKiem.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Tìm kiếm!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
            {
                if (btnIn.Enabled == true)
                {
                    btnIn.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím In!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {
                if (btnXem.Enabled == true)
                {
                    btnXem.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Xem!", "");
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form child in this.MdiParent.MdiChildren)
            {
                if (child.Name == "GiaiPhauBenh")
                {
                    child.Close();
                }
            }
            View.GiaiPhauBenh.GiaiPhauBenh frm = new View.GiaiPhauBenh.GiaiPhauBenh();
            View.GiaiPhauBenh.GiaiPhauBenh.TiepNhan_Id = TiepNhan_Id;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void cbbDV_ValueChanged(object sender, EventArgs e)
        {
            string t = "";
            if (cbbDV.Value != null)
            {
                t = cbbDV.Value.ToString();
                PhongBan = Model.DbTiepNhan.CBBPhongBan(t);
                if (PhongBan != null)
                {
                    if (PhongBan.Rows.Count > 0)
                    {
                        cbbphongban.DataSource = PhongBan;

                        cbbphongban.ValueMember = "PhongBan_Id";
                        cbbphongban.DisplayMember = "TenPhongBan";
                        //cbbphongban.Value = "48";
                        //cbbphongban.Value = cbbphongban.ValueMember.ToString().Min();
                        int firstRowValue = (int)PhongBan.Rows[0]["PhongBan_Id"];
                        cbbphongban.Value = firstRowValue.ToString();


                    }

                }
            }
            else
            {
                cbbphongban.DataSource = null; cbbphongban.DataSource = null;
            }
        }

        private void cbbDV_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbDV.Text;
                DataRow[] resultRow = Dm_DichVu.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = Dm_DichVu.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'").CopyToDataTable();
                    cbbDV.DataSource = dtResult;
                    cbbDV.DroppedDown = true;
                }
                else
                {
                    cbbDV.DataSource = null;
                    cbbDV.DroppedDown = true;
                }
            }
        }
        private void rSetGoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rSetGoi.SelectedIndex == 0)
            {
                BienSetGoi = "0";
            }
            else if (rSetGoi.SelectedIndex == 1) { BienSetGoi = "1"; }
            else { BienSetGoi = "2"; }
        }

        private void btnGoiBenhNhan_Click(object sender, EventArgs e)
        {
                if (TiepNhan_Id != null)
                {
                    string nguoicapnhat = Login.User_Id;
                    DialogResult dr = MessageBox.Show("Bạn muốn gọi bệnh nhân vào?",
                    "Thong Bao!", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        DataTable GoiBenhNhanKham = Model.dbManHinhHangDoi.GoiBenhNhan(TiepNhan_Id);
                        //

                        var tenBenhNhan = "";
                        if (GoiBenhNhanKham == null)
                        {
                            alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân để gọi");
                        }
                        else
                        {
                            tenBenhNhan = GoiBenhNhanKham.Rows[0]["TenBenhNhan"].ToString();
                            LoadBenhNhanTrenHangDoi(tenBenhNhan);
                        }
                        //
                        break;
                        case DialogResult.No:
                            break;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Đã hết bệnh nhân trong hàng chờ!");
                }
                //
        }

        private void cbbDV_Click(object sender, EventArgs e)
        {
            cbbDV.DataSource = null;
            cbbDV.DroppedDown = true;
        }

        private void InToaThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                DataTable table1 = Model.dbKhamBenh.SP_BaoCao_001_ToaThuoc(KhamBenh_Id);
                if (table1 != null)
                {
                    if (table1.Rows.Count > 0)
                    {
                        table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                        byte[] Image = null;
                        byte[] ImageLogo = null;
                        string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                        if (table1.Rows[0]["MaYTe"].ToString() != "")
                        {
                            DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                            string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                            FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            Image = new byte[fs.Length];
                            fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                            fs.Close();

                            DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
                            if (SelectSettingTheoSettingCode2 != null)
                            {
                                if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                                {
                                    string Logo = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();
                                    FileStream fsLogo = new FileStream(Logo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                    ImageLogo = new byte[fsLogo.Length];
                                    fsLogo.Read(ImageLogo, 0, Convert.ToInt32(fsLogo.Length));
                                    fsLogo.Close();
                                }
                            }

                            DataTable BenhVien = Model.db.BenhVien(Login.MaBenhVien);
                            if (BenhVien != null)
                            {
                                if (BenhVien.Rows.Count > 0)
                                {
                                    TenBenhVien = BenhVien.Rows[0]["TenBenhVien"].ToString();
                                    DiaChiBenhVien = BenhVien.Rows[0]["DiaChiBenhVien"].ToString();
                                    DienThoai = BenhVien.Rows[0]["DienThoai"].ToString();
                                }
                            }

                            for (int i = 0; i < table1.Rows.Count; i++)
                            {
                                table1.Rows[i]["BarcodeMaYTe"] = Image;
                                table1.Rows[i]["Logo"] = ImageLogo;
                                table1.Rows[i]["TenBenhVien"] = TenBenhVien;
                                table1.Rows[i]["DiaChiBenhVien"] = DiaChiBenhVien;
                                table1.Rows[i]["DienThoai"] = DienThoai;
                            }
                        }
                    }
                }
                ReportDocument rptDoca = new ReportDocument();
                DataTable ShowDuongDan = Model.db.ShowDuongDan();
                string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC008_ToaThuoc.rpt";
                rptDoca.Load(DuongDan);
                rptDoca.Subreports["ThongTinBenhVien"].SetDataSource(table1);
                rptDoca.Subreports["ThongTinToaThuoc"].SetDataSource(table1);
                rptDoca.SetDataSource(table1);
                rptDoca.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void InChiDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                DataTable table1 = Model.dbKhamBenh.SP_BaoCao_003_PhieuChiDinhDichVuTruKham(KhamBenh_Id);
                if (table1 != null)
                {
                    if (table1.Rows.Count > 0)
                    {
                        table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                        byte[] Image = null;
                        byte[] ImageLogo = null;
                        string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                        if (table1.Rows[0]["MaYTe"].ToString() != "")
                        {
                            DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                            string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                            FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            Image = new byte[fs.Length];
                            fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                            fs.Close();

                            DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
                            if (SelectSettingTheoSettingCode2 != null)
                            {
                                if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                                {
                                    string Logo = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();
                                    FileStream fsLogo = new FileStream(Logo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                    ImageLogo = new byte[fsLogo.Length];
                                    fsLogo.Read(ImageLogo, 0, Convert.ToInt32(fsLogo.Length));
                                    fsLogo.Close();
                                }
                            }

                            DataTable BenhVien = Model.db.BenhVien(Login.MaBenhVien);
                            if (BenhVien != null)
                            {
                                if (BenhVien.Rows.Count > 0)
                                {
                                    TenBenhVien = BenhVien.Rows[0]["TenBenhVien"].ToString();
                                    DiaChiBenhVien = BenhVien.Rows[0]["DiaChiBenhVien"].ToString();
                                    DienThoai = BenhVien.Rows[0]["DienThoai"].ToString();
                                }
                            }

                            for (int i = 0; i < table1.Rows.Count; i++)
                            {
                                table1.Rows[i]["BarcodeMaYTe"] = Image;
                                table1.Rows[i]["Logo"] = ImageLogo;
                                table1.Rows[i]["TenBenhVien"] = TenBenhVien;
                                table1.Rows[i]["DiaChiBenhVien"] = DiaChiBenhVien;
                                table1.Rows[i]["DienThoai"] = DienThoai;
                            }
                        }
                    }
                }
                ReportDocument rptDoca = new ReportDocument();
                DataTable ShowDuongDan = Model.db.ShowDuongDan();
                string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC001_PhieuChiDinhDichVu.rpt";
                rptDoca.Load(DuongDan);
                rptDoca.SetDataSource(table1);
                rptDoca.PrintToPrinter(1, false, 0, 0);
            }
            }

        private void InPhieuKham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                DataTable table1 = Model.dbKhamBenh.SP_BaoCao_002_Phieukham(KhamBenh_Id);
                if (table1 != null)
                {
                    if (table1.Rows.Count > 0)
                    {
                        table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                        byte[] Image = null;
                        byte[] ImageLogo = null;
                        string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                        if (table1.Rows[0]["MaYTe"].ToString() != "")
                        {
                            DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                            string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                            FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            Image = new byte[fs.Length];
                            fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                            fs.Close();

                            DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
                            if (SelectSettingTheoSettingCode2 != null)
                            {
                                if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                                {
                                    string Logo = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();
                                    FileStream fsLogo = new FileStream(Logo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                    ImageLogo = new byte[fsLogo.Length];
                                    fsLogo.Read(ImageLogo, 0, Convert.ToInt32(fsLogo.Length));
                                    fsLogo.Close();
                                }
                            }

                            DataTable BenhVien = Model.db.BenhVien(Login.MaBenhVien);
                            if (BenhVien != null)
                            {
                                if (BenhVien.Rows.Count > 0)
                                {
                                    TenBenhVien = BenhVien.Rows[0]["TenBenhVien"].ToString();
                                    DiaChiBenhVien = BenhVien.Rows[0]["DiaChiBenhVien"].ToString();
                                    DienThoai = BenhVien.Rows[0]["DienThoai"].ToString();
                                }
                            }

                            for (int i = 0; i < table1.Rows.Count; i++)
                            {
                                table1.Rows[i]["BarcodeMaYTe"] = Image;
                                table1.Rows[i]["Logo"] = ImageLogo;
                                table1.Rows[i]["TenBenhVien"] = TenBenhVien;
                                table1.Rows[i]["DiaChiBenhVien"] = DiaChiBenhVien;
                                table1.Rows[i]["DienThoai"] = DienThoai;
                            }
                        }
                    }
                }
                ReportDocument rptDoca = new ReportDocument();
                DataTable ShowDuongDan = Model.db.ShowDuongDan();
                string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC009_PhieuKham.rpt";
                rptDoca.Load(DuongDan);
                rptDoca.SetDataSource(table1);
                rptDoca.PrintToPrinter(1, false, 0, 0);
            }
            }

        private void XemToaThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                View.HeThongBaoCao.ToaThuoc bc = new View.HeThongBaoCao.ToaThuoc(this);
                bc.Show();
            }
        }

        private void XemPhieuKham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                View.HeThongBaoCao.PhieuKham bc = new View.HeThongBaoCao.PhieuKham(this);
                bc.Show();
            }
        }

        private void XemChiDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KhamBenh_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                View.HeThongBaoCao.PhieuChiDinh_Kham bc = new View.HeThongBaoCao.PhieuChiDinh_Kham(this);
                bc.Show();
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
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.Name == "Add" && e.IsGetData)
            {
                e.Value = "Thêm Phiếu Khám";
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            int n = gridView1.FocusedRowHandle;
            if (gridView1.RowCount > 0)
            {
                TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
                LoadThongTinBenhNhanDaTiepNhanKhamBenh(TiepNhan_Id);
            }
            if (TiepNhan_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân khám ", "");
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
                btnXoa.Enabled = false;
                btnXem.Enabled = false;
                btnIn.Enabled = false;
                btnTimKiem.Enabled = false;
                Hien();
                btnXetNghiem.Enabled = false;
                btnChanDoanHinhAnh.Enabled = false;
                ThaoTac = "Them";
                KhamBenh_Id = "";
                CLSYeuCauChiTiet_Id = "";
                ToaThuoc_Id = "";
                Reset();
                Resettab();
                getdata();
                txtMach.Focus();
            }
        }

    }
}
