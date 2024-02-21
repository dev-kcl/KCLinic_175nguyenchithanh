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
using System.IO;
using System.Drawing.Imaging;
using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Camera;
using DevExpress.XtraEditors.Camera;
using System.Drawing.Drawing2D;

namespace KClinic2._1.View.GiaiPhauBenh
{
    public partial class GiaiPhauBenh : DevExpress.XtraEditors.XtraForm
    {
        public string pathImage = System.Configuration.ConfigurationManager.AppSettings["pathImage"];

        public static string TiepNhan_Id = "";
        public string ThaoTac;
        public string CLSYeuCau_Id;
        public string CLSKetQua_Id;
        DataTable BacSiKetLuan;

        public GiaiPhauBenh()
        {
            InitializeComponent();
        }

        private void GiaiPhauBenh_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnXem.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = true;

            An();
            getdata();
            getcamera();
            if (TiepNhan_Id != "")
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
                ThaoTac = "Them";
                Reset();
                txtSoTiepNhan.Focus();
                View.GiaiPhauBenh.TimThongTinTiepNhan_Id.TiepNhan_Id = TiepNhan_Id;
                View.GiaiPhauBenh.TimThongTinTiepNhan_Id tc = new View.GiaiPhauBenh.TimThongTinTiepNhan_Id(this);
                tc.ShowDialog();
            }
            else { TiepNhan_Id = ""; }
            this.KeyPreview = true;
        }
        void getdata()
        {
            BacSiKetLuan = Model.dbCDHA.BacSiKetLuan();
            cbbBacSiKetLuan.DataSource = BacSiKetLuan;
            cbbBacSiKetLuan.ValueMember = "FieldCode";
            cbbBacSiKetLuan.DisplayMember = "FieldName";
        }
        void getcamera()
        {
            DataTable SelectSettingTheoSettingCode = Model.db.SelectSettingTheoSettingCode("DoSang");
            if (SelectSettingTheoSettingCode != null)
            {
                if (SelectSettingTheoSettingCode.Rows.Count > 0)
                {
                    txtDoSang.Text = SelectSettingTheoSettingCode.Rows[0]["NoiDung"].ToString();
                }
            }
            DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("DoNet");
            if (SelectSettingTheoSettingCode2 != null)
            {
                if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                {
                    txtDoNet.Text = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();
                }
            }
            //CameraDeviceInfo a4camInfo = CameraControl.GetDevices().Find(x => x.Name.Contains(CameraDeviceSA));
            //cameraControl1.Start(CameraControl.GetDevice(a4camInfo));
        }

        private void btnThem_Click(object sender, EventArgs e)
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
            ThaoTac = "Them";
            TiepNhan_Id = "";
            Reset();
            txtSoTiepNhan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
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
            txtSoTiepNhan.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoTiepNhan.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Họ Tên không được để trống!", "");
            }
            else if (txtThoiGianThucHien.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Thời gian thực hiện không được để trống!", "");
            }
            else
            {
                string NgayThucHien = "'" + txtThoiGianThucHien.Value.ToString("yyyyMMdd") + "'";
                string ThoiGianThucHien = "'" + txtThoiGianThucHien.Value.ToString("yyyyMMdd HH:mm:ss") + "'";

                string ChanDoan = "null"; if (txtChanDoan.Text != "") { ChanDoan = "N'" + txtChanDoan.Text.Replace("'", "''") + "'"; }
                string KetLuan = "null"; if (txtKetLuan.Text != "") { KetLuan = "N'" + txtKetLuan.Text.Replace("'", "''") + "'"; }
                string LoiDan = "null"; if (txtLoiDan.Text != "") { LoiDan = "N'" + txtLoiDan.Text.Replace("'", "''") + "'"; }

                string BacSiKetLuan = "null";
                if (cbbBacSiKetLuan.SelectedItem != null) { BacSiKetLuan = cbbBacSiKetLuan.Value.ToString(); }

                string KhongCoTonThuong = "null";
                if (cbKhongCoTonThuong.Checked == true) { KhongCoTonThuong = "1"; } else { KhongCoTonThuong = "0"; }
                string Trichomononas = "null";
                if (cbTrichomononas.Checked == true) { Trichomononas = "1"; } else { Trichomononas = "0"; }
                string Candida = "null";
                if (cbCandida.Checked == true) { Candida = "1"; } else { Candida = "0"; }
                string TapKhan = "null";
                if (cbTapKhan.Checked == true) { TapKhan = "1"; } else { TapKhan = "0"; }
                string Actinomyces = "null";
                if (cbActinomyces.Checked == true) { Actinomyces = "1"; } else { Actinomyces = "0"; }
                string Herpes = "null";
                if (cbHerpes.Checked == true) { Herpes = "1"; } else { Herpes = "0"; }
                string Cytomegalo = "null";
                if (cbCytomegalo.Checked == true) { Cytomegalo = "1"; } else { Cytomegalo = "0"; }
                string ChuyenSanGai = "null";
                if (cbChuyenSanGai.Checked == true) { ChuyenSanGai = "1"; } else { ChuyenSanGai = "0"; }
                string ThayDoiSung = "null";
                if (cbThayDoiSung.Checked == true) { ThayDoiSung = "1"; } else { ThayDoiSung = "0"; }
                string ChuyenSanTuyen = "null";
                if (cbChuyenSanTuyen.Checked == true) { ChuyenSanTuyen = "1"; } else { ChuyenSanTuyen = "0"; }
                string Teo = "null";
                if (cbTeo.Checked == true) { Teo = "1"; } else { Teo = "0"; }
                string ThayDoiLienQuanThaiky = "null";
                if (cbThayDoiLienQuanThaiky.Checked == true) { ThayDoiLienQuanThaiky = "1"; } else { ThayDoiLienQuanThaiky = "0"; }
                string DoViem = "null";
                if (cbDoViem.Checked == true) { DoViem = "1"; } else { DoViem = "0"; }
                string DoXaTri = "null";
                if (cbDoXaTri.Checked == true) { DoXaTri = "1"; } else { DoXaTri = "0"; }
                string DoVongTranhThai = "null";
                if (cbDoVongTranhThai.Checked == true) { DoVongTranhThai = "1"; } else { DoVongTranhThai = "0"; }

                string TinhTrangTeBaoKhac = "null"; if (txtTinhTrangTeBaoKhac.Text != "") { TinhTrangTeBaoKhac = "N'" + txtTinhTrangTeBaoKhac.Text.Replace("'", "''") + "'"; }

                string BatThuongTeBao = "null";
                if (cbBatThuongTeBao.Checked == true) { BatThuongTeBao = "1"; } else { BatThuongTeBao = "0"; }
                string TeBaoGaiKhongDienHinh = "null";
                if (cbTeBaoGaiKhongDienHinh.Checked == true) { TeBaoGaiKhongDienHinh = "1"; } else { TeBaoGaiKhongDienHinh = "0"; }
                string YNghia = "null";
                if (cbYNghia.Checked == true) { YNghia = "1"; } else { YNghia = "0"; }
                string ChuaLoaiTru = "null";
                if (cbChuaLoaiTru.Checked == true) { ChuaLoaiTru = "1"; } else { ChuaLoaiTru = "0"; }
                string TonThuongThap = "null";
                if (cbTonThuongThap.Checked == true) { TonThuongThap = "1"; } else { TonThuongThap = "0"; }
                string TonThuongCao = "null";
                if (cbTonThuongCao.Checked == true) { TonThuongCao = "1"; } else { TonThuongCao = "0"; }
                string CarcinomaTeBaoGai = "null";
                if (cbCarcinomaTeBaoGai.Checked == true) { CarcinomaTeBaoGai = "1"; } else { CarcinomaTeBaoGai = "0"; }
                string TeBaoTuyenKhongDienHinh = "null";
                if (cbTeBaoTuyenKhongDienHinh.Checked == true) { TeBaoTuyenKhongDienHinh = "1"; } else { TeBaoTuyenKhongDienHinh = "0"; }
                string TeBaoTuyenCoTrong = "null";
                if (cbTeBaoTuyenCoTrong.Checked == true) { TeBaoTuyenCoTrong = "1"; } else { TeBaoTuyenCoTrong = "0"; }
                string TeBaoNoiMo = "null";
                if (cbTeBaoNoiMo.Checked == true) { TeBaoNoiMo = "1"; } else { TeBaoNoiMo = "0"; }
                string TeBaoTuyen = "null";
                if (cbTeBaoTuyen.Checked == true) { TeBaoTuyen = "1"; } else { TeBaoTuyen = "0"; }
                string TeBaoTuyenCoTrongHuongDenU = "null";
                if (cbTeBaoTuyenCoTrongHuongDenU.Checked == true) { TeBaoTuyenCoTrongHuongDenU = "1"; } else { TeBaoTuyenCoTrongHuongDenU = "0"; }
                string TeBaoTuyenHuongDenU = "null";
                if (cbTeBaoTuyenHuongDenU.Checked == true) { TeBaoTuyenHuongDenU = "1"; } else { TeBaoTuyenHuongDenU = "0"; }
                string CarcinomaTeBaoTuyenCoTron = "null";
                if (cbCarcinomaTeBaoTuyenCoTron.Checked == true) { CarcinomaTeBaoTuyenCoTron = "1"; } else { CarcinomaTeBaoTuyenCoTron = "0"; }
                string CarcinomaTeBaoTuyen = "null";
                if (cbCarcinomaTeBaoTuyen.Checked == true) { CarcinomaTeBaoTuyen = "1"; } else { CarcinomaTeBaoTuyen = "0"; }
                string TuyenCoTrong = "null";
                if (cbTuyenCoTrong.Checked == true) { TuyenCoTrong = "1"; } else { TuyenCoTrong = "0"; }
                string TuyenNoiMac = "null";
                if (cbTuyenNoiMac.Checked == true) { TuyenNoiMac = "1"; } else { TuyenNoiMac = "0"; }
                string TuyenNgoaiTuCung = "null";
                if (cbTuyenNgoaiTuCung.Checked == true) { TuyenNgoaiTuCung = "1"; } else { TuyenNgoaiTuCung = "0"; }
                string TuyenKhongDacHieu = "null";
                if (cbTuyenKhongDacHieu.Checked == true) { TuyenKhongDacHieu = "1"; } else { TuyenKhongDacHieu = "0"; }

                string UAcTinhKhac = "null"; if (txtUAcTinhKhac.Text != "") { UAcTinhKhac = "N'" + txtUAcTinhKhac.Text.Replace("'", "''") + "'"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbGPB.Insert(
                                KhongCoTonThuong
                                ,Trichomononas
                                ,Candida
                                ,TapKhan
                                ,Actinomyces
                                ,Herpes
                                ,Cytomegalo
                                ,ChuyenSanGai
                                ,ThayDoiSung
                                ,ChuyenSanTuyen
                                ,Teo
                                ,ThayDoiLienQuanThaiky
                                ,DoViem
                                ,DoXaTri
                                ,DoVongTranhThai
                                ,TinhTrangTeBaoKhac
                                ,BatThuongTeBao
                                ,TeBaoGaiKhongDienHinh
                                ,YNghia
                                ,ChuaLoaiTru
                                ,TonThuongThap
                                ,TonThuongCao
                                ,CarcinomaTeBaoGai
                                ,TeBaoTuyenKhongDienHinh
                                ,TeBaoTuyenCoTrong
                                ,TeBaoNoiMo
                                ,TeBaoTuyen
                                ,TeBaoTuyenCoTrongHuongDenU
                                ,TeBaoTuyenHuongDenU
                                ,CarcinomaTeBaoTuyenCoTron
                                ,CarcinomaTeBaoTuyen
                                ,TuyenCoTrong
                                ,TuyenNoiMac
                                ,TuyenNgoaiTuCung
                                ,TuyenKhongDacHieu
                                ,UAcTinhKhac
                                ,KetLuan
                                ,LoiDan
                                ,BacSiKetLuan
                                , "null" //KTVThucHien
                                , "0"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , Login.User_Id
                                , "null"
                                , "null"
                                , CLSYeuCau_Id
                                , NgayThucHien
                                , ThoiGianThucHien
                                , TiepNhan_Id
                                , "null" //BenhNhan_Id
                                , ChanDoan
                                );
                    if (Insert != null)
                    {
                        if (Insert.Rows.Count > 0)
                        {
                            CLSKetQua_Id = Insert.Rows[0]["CLSKetQuaGPB_Id"].ToString();
                            //update trạng thái
                            DataTable UpdateTrangThaiCLSYeuCau = Model.dbGPB.UpdateTrangThaiCLSYeuCau(
                                        CLSYeuCau_Id
                                        , "N'CoKetQua'"
                                        );
                            DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                            //insert hình ảnh
                            DataTable DeleteHinhAnh = Model.dbGPB.DeleteHinhAnh(CLSKetQua_Id);
                            int SLHinhAnh = 0;
                            if (DeleteHinhAnh != null)
                            {
                                if (DeleteHinhAnh.Rows.Count > 0)
                                {
                                    SLHinhAnh = Int32.Parse(DeleteHinhAnh.Rows[0]["SL"].ToString());
                                }
                            }

                            DataTable selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id = Model.dbGPB.selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id(CLSYeuCau_Id);
                            string dir = DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + CLSYeuCau_Id;

                            if (selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id != null)
                            {
                                if (selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows.Count > 0)
                                {
                                    dir = DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows[0]["MaYTe"].ToString() + @"\" + selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows[0]["SoPhieuYeuCau"].ToString();
                                }
                            }

                            string NameHinhAnh = selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows[0]["SoPhieuYeuCau"].ToString();
                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }

                            string dirMain = dir + @"\";

                            if (NameAnh1 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 1).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 1).ToString() + ".jpg";
                                if (NameAnh1.Replace("\\", @"\") != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox1.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh2 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 2).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 2).ToString() + ".jpg";
                                if (NameAnh2 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox2.Image.Save(HinhAnh);
                                    }
                                }

                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh3 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 3).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 3).ToString() + ".jpg";
                                if (NameAnh3 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox3.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh4 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 4).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 4).ToString() + ".jpg";
                                if (NameAnh4 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox4.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh5 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 5).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 5).ToString() + ".jpg";
                                if (NameAnh5 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox5.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh6 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 6).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 6).ToString() + ".jpg";
                                if (NameAnh6 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox6.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh7 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 7).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 7).ToString() + ".jpg";
                                if (NameAnh7 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox7.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh8 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 8).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 8).ToString() + ".jpg";
                                if (NameAnh8 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox9.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh9 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 9).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 9).ToString() + ".jpg";
                                if (NameAnh9 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox9.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }

                            alertControl1.Show(this, "Thông báo", "Đã thêm thành công!", "");
                        }
                    }

                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbGPB.Update(
                                 KhongCoTonThuong
                                , Trichomononas
                                , Candida
                                , TapKhan
                                , Actinomyces
                                , Herpes
                                , Cytomegalo
                                , ChuyenSanGai
                                , ThayDoiSung
                                , ChuyenSanTuyen
                                , Teo
                                , ThayDoiLienQuanThaiky
                                , DoViem
                                , DoXaTri
                                , DoVongTranhThai
                                , TinhTrangTeBaoKhac
                                , BatThuongTeBao
                                , TeBaoGaiKhongDienHinh
                                , YNghia
                                , ChuaLoaiTru
                                , TonThuongThap
                                , TonThuongCao
                                , CarcinomaTeBaoGai
                                , TeBaoTuyenKhongDienHinh
                                , TeBaoTuyenCoTrong
                                , TeBaoNoiMo
                                , TeBaoTuyen
                                , TeBaoTuyenCoTrongHuongDenU
                                , TeBaoTuyenHuongDenU
                                , CarcinomaTeBaoTuyenCoTron
                                , CarcinomaTeBaoTuyen
                                , TuyenCoTrong
                                , TuyenNoiMac
                                , TuyenNgoaiTuCung
                                , TuyenKhongDacHieu
                                , UAcTinhKhac
                                , KetLuan
                                , LoiDan
                                , BacSiKetLuan
                                , "null" //KTVThucHien
                                , "0"
                                , "null"
                                , "null"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , Login.User_Id
                                , CLSYeuCau_Id
                                , NgayThucHien
                                , ThoiGianThucHien
                                , TiepNhan_Id
                                , "null" //BenhNhan_Id
                                , CLSKetQua_Id
                                , ChanDoan
                                );
                    if (Update != null)
                    {
                        if (Update.Rows.Count > 0)
                        {
                            CLSKetQua_Id = Update.Rows[0]["CLSKetQuaGPB_Id"].ToString();
                            //update kết quả và trạng thái
                            DataTable UpdateTrangThaiCLSYeuCau = Model.dbGPB.UpdateTrangThaiCLSYeuCau(
                                         CLSYeuCau_Id
                                        , "N'CoKetQua'"
                                        );
                            DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                            //insert hình ảnh
                            DataTable DeleteHinhAnh = Model.dbGPB.DeleteHinhAnh(CLSKetQua_Id);
                            int SLHinhAnh = 0;
                            if (DeleteHinhAnh != null)
                            {
                                if (DeleteHinhAnh.Rows.Count > 0)
                                {
                                    SLHinhAnh = Int32.Parse(DeleteHinhAnh.Rows[0]["SL"].ToString());
                                }
                            }

                            DataTable selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id = Model.dbGPB.selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id(CLSYeuCau_Id);
                            string dir = DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + CLSYeuCau_Id;

                            if (selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id != null)
                            {
                                if (selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows.Count > 0)
                                {
                                    dir = DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows[0]["MaYTe"].ToString() + @"\" + selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows[0]["SoPhieuYeuCau"].ToString();
                                }
                            }

                            string NameHinhAnh = selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id.Rows[0]["SoPhieuYeuCau"].ToString();
                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }

                            string dirMain = dir + @"\";

                            if (NameAnh1 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 1).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 1).ToString() + ".jpg";
                                if (NameAnh1.Replace("\\", @"\") != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox1.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh2 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 2).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 2).ToString() + ".jpg";
                                if (NameAnh2 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox2.Image.Save(HinhAnh);
                                    }
                                }

                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh3 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 3).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 3).ToString() + ".jpg";
                                if (NameAnh3 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox3.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh4 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 4).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 4).ToString() + ".jpg";
                                if (NameAnh4 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox4.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh5 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 5).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 5).ToString() + ".jpg";
                                if (NameAnh5 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox5.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh6 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 6).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 6).ToString() + ".jpg";
                                if (NameAnh6 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox6.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh7 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 7).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 7).ToString() + ".jpg";
                                if (NameAnh7 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox7.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh8 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 8).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 8).ToString() + ".jpg";
                                if (NameAnh8 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox9.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }
                            if (NameAnh9 != "")
                            {
                                string HinhAnh = dirMain + NameHinhAnh + "_" + (SLHinhAnh + 9).ToString() + ".jpg";
                                string Name = NameHinhAnh + "_" + (SLHinhAnh + 9).ToString() + ".jpg";
                                if (NameAnh9 != HinhAnh)
                                {
                                    if (!System.IO.File.Exists(HinhAnh))
                                    {
                                        pictureBox9.Image.Save(HinhAnh);
                                    }
                                }
                                DataTable InsertHinhAnh = Model.dbGPB.InsertHinhAnh(CLSKetQua_Id, "N'" + HinhAnh + "'", "N'" + Name + "'");
                            }

                            alertControl1.Show(this, "Thông báo", "Đã sửa thành công!", "");
                        }
                    }

                    //
                }
                //
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
            An();
            if (ThaoTac == "Them")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                TiepNhan_Id = "";
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
                    btnXem.Enabled = true;
                    btnIn.Enabled = true;
                    btnTimKiem.Enabled = true;
                    An();
                    //
                    DataTable Delete = Model.dbGPB.Delete(CLSKetQua_Id, nguoicapnhat);
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công!", "");
                    Reset();
                    CLSKetQua_Id = "";
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (CLSKetQua_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Bệnh Nhân!", "");
            }
            else
            {
                DataTable table1 = Model.dbGPB.SP_BaoCao_013_PhieuKetQuaGPB(CLSKetQua_Id);

                if (table1 != null)
                {
                    if (table1.Rows.Count > 0)
                    {
                        table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                        string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                        if (table1.Rows[0]["MaYTe"].ToString() != "")
                        {
                            byte[] Image = null;
                            byte[] ImageLogo = null;
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
                        table1.Columns.Add("Hinh1a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh2a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh3a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh4a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh5a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh6a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh7a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh8a", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Hinh9a", System.Type.GetType("System.Byte[]"));

                        if (table1.Rows[0]["Hinh1"].ToString() != "")
                        {
                            FileStream fs = new FileStream(table1.Rows[0]["Hinh1"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image = new byte[fs.Length];
                            fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            table1.Rows[0]["Hinh1a"] = Image;
                        }


                        if (table1.Rows[0]["Hinh2"].ToString() != "")
                        {
                            FileStream fs2 = new FileStream(table1.Rows[0]["Hinh2"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image2 = new byte[fs2.Length];
                            fs2.Read(Image2, 0, Convert.ToInt32(fs2.Length));
                            fs2.Close();
                            table1.Rows[0]["Hinh2a"] = Image2;
                        }


                        if (table1.Rows[0]["Hinh3"].ToString() != "")
                        {
                            FileStream fs3 = new FileStream(table1.Rows[0]["Hinh3"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image3 = new byte[fs3.Length];
                            fs3.Read(Image3, 0, Convert.ToInt32(fs3.Length));
                            fs3.Close();
                            table1.Rows[0]["Hinh3a"] = Image3;
                        }

                        if (table1.Rows[0]["Hinh4"].ToString() != "")
                        {
                            FileStream fs4 = new FileStream(table1.Rows[0]["Hinh4"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image4 = new byte[fs4.Length];
                            fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                            fs4.Close();
                            table1.Rows[0]["Hinh4a"] = Image4;
                        }

                        if (table1.Rows[0]["Hinh5"].ToString() != "")
                        {
                            FileStream fs4 = new FileStream(table1.Rows[0]["Hinh5"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image4 = new byte[fs4.Length];
                            fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                            fs4.Close();
                            table1.Rows[0]["Hinh5a"] = Image4;
                        }

                        if (table1.Rows[0]["Hinh6"].ToString() != "")
                        {
                            FileStream fs4 = new FileStream(table1.Rows[0]["Hinh6"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image4 = new byte[fs4.Length];
                            fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                            fs4.Close();
                            table1.Rows[0]["Hinh6a"] = Image4;
                        }

                        if (table1.Rows[0]["Hinh7"].ToString() != "")
                        {
                            FileStream fs4 = new FileStream(table1.Rows[0]["Hinh7"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image4 = new byte[fs4.Length];
                            fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                            fs4.Close();
                            table1.Rows[0]["Hinh7a"] = Image4;
                        }

                        if (table1.Rows[0]["Hinh8"].ToString() != "")
                        {
                            FileStream fs4 = new FileStream(table1.Rows[0]["Hinh8"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image4 = new byte[fs4.Length];
                            fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                            fs4.Close();
                            table1.Rows[0]["Hinh8a"] = Image4;
                        }

                        if (table1.Rows[0]["Hinh9"].ToString() != "")
                        {
                            FileStream fs4 = new FileStream(table1.Rows[0]["Hinh9"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image4 = new byte[fs4.Length];
                            fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                            fs4.Close();
                            table1.Rows[0]["Hinh9a"] = Image4;
                        }
                    }
                }

                ReportDocument rptDoca = new ReportDocument();
                DataTable ShowDuongDan = Model.db.ShowDuongDan();
                string DuongDan;
                DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC013_PhieuTraLoiKetQuaSCTC.rpt";
                rptDoca.Load(DuongDan);
                //rptDoca.Subreports["BC010_PhieuTraLoiKetQuaCDHA_Sub"].SetDataSource(table1);
                rptDoca.SetDataSource(table1);
                rptDoca.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CLSKetQua_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Bệnh Nhân!", "");
            }
            else
            {
                View.HeThongBaoCao.PhieuTraLoiKetQuaGPB bc = new View.HeThongBaoCao.PhieuTraLoiKetQuaGPB(this);
                bc.Show();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            View.GiaiPhauBenh.TimKiemKetQua tc = new View.GiaiPhauBenh.TimKiemKetQua(this);
            tc.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_S_Click(object sender, EventArgs e)
        {
            View.GiaiPhauBenh.TimKiemBenhNhan tc = new View.GiaiPhauBenh.TimKiemBenhNhan(this);
            tc.ShowDialog();
        }

        private void txtSoTiepNhan_KeyDown(object sender, KeyEventArgs e)
        {
            CLSYeuCau_Id = "";
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                LayThongTinTheoSoPhieuYeuCau(txtSoTiepNhan.Text);
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }
        public void LayThongTinTheoSoPhieuYeuCau(string SoPhieuYeuCau)
        {
            DataTable CheckDaCoKetQuaTheoSoPhieuYeuCau = Model.dbGPB.CheckDaCoKetQuaTheoSoPhieuYeuCau(SoPhieuYeuCau);
            if (CheckDaCoKetQuaTheoSoPhieuYeuCau != null)
            {
                if (CheckDaCoKetQuaTheoSoPhieuYeuCau.Rows.Count > 0)
                {
                    if (CheckDaCoKetQuaTheoSoPhieuYeuCau.Rows[0]["KetQua"].ToString() == "0")
                    {
                        DataTable LoadThongTinBenhNhan = Model.dbGPB.LoadThongTinBenhNhanTheoSoPhieuYeuCau(SoPhieuYeuCau);
                        if (LoadThongTinBenhNhan.Rows.Count > 0)
                        {
                            txtSoTiepNhan.Text = LoadThongTinBenhNhan.Rows[0]["SoPhieuYeuCau"].ToString();
                            txtMaYTe.Text = LoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                            txtHoTen.Text = LoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                            txtTuoi.Text = LoadThongTinBenhNhan.Rows[0]["Tuoi"].ToString();
                            txtGioiTinh.Text = LoadThongTinBenhNhan.Rows[0]["GioiTinh"].ToString();
                            txtNamSinh.Text = LoadThongTinBenhNhan.Rows[0]["NamSinh"].ToString();
                            txtChanDoan.Text = LoadThongTinBenhNhan.Rows[0]["ChanDoan"].ToString();
                            txtTenDichVu.Text = LoadThongTinBenhNhan.Rows[0]["TenDichVu"].ToString();

                            txtThoiGianThucHien.Value = DateTime.Now;
                            TiepNhan_Id = LoadThongTinBenhNhan.Rows[0]["TiepNhan_Id"].ToString();
                            CLSYeuCau_Id = LoadThongTinBenhNhan.Rows[0]["CLSYeuCau_Id"].ToString();
                            //
                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Số phiếu yêu cầu không tồn tại! Vui lòng kiểm tra lại.", "");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số phiếu yêu cầu đã có kết quả!");
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
                        DataTable SuaLoadThongTinBenhNhan = Model.dbGPB.SuaLoadThongTinBenhNhanTheoSoPhieuYeuCau(SoPhieuYeuCau);
                        if (SuaLoadThongTinBenhNhan != null)
                        {
                            if (SuaLoadThongTinBenhNhan.Rows.Count > 0)
                            {
                                txtSoTiepNhan.Text = SuaLoadThongTinBenhNhan.Rows[0]["SoPhieuYeuCau"].ToString();
                                txtMaYTe.Text = SuaLoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                                txtHoTen.Text = SuaLoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                                txtTuoi.Text = SuaLoadThongTinBenhNhan.Rows[0]["Tuoi"].ToString();
                                txtGioiTinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["GioiTinh"].ToString();
                                txtNamSinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["NamSinh"].ToString();
                                txtChanDoan.Text = SuaLoadThongTinBenhNhan.Rows[0]["ChanDoan"].ToString();

                                string ThoiGianThucHien = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianThucHien"].ToString();
                                if (!String.IsNullOrEmpty(ThoiGianThucHien))
                                {
                                    DateTime enteredDate = DateTime.Parse(ThoiGianThucHien);
                                    txtThoiGianThucHien.Value = enteredDate;
                                }
                                txtLoiDan.Text = SuaLoadThongTinBenhNhan.Rows[0]["LoiDan"].ToString();
                                txtKetLuan.Text = SuaLoadThongTinBenhNhan.Rows[0]["KetLuan"].ToString();
                                string BacSiKetLuan_Id = SuaLoadThongTinBenhNhan.Rows[0]["BacSiKetLuan_Id"].ToString();
                                if (!String.IsNullOrEmpty(BacSiKetLuan_Id))
                                {
                                    cbbBacSiKetLuan.Value = Int32.Parse(BacSiKetLuan_Id);
                                }
                                txtTenDichVu.Text = SuaLoadThongTinBenhNhan.Rows[0]["TenDichVu"].ToString();

                                //cbbKTVThucHien.SelectedValue = Int32.Parse(SuaLoadThongTinBenhNhan.Rows[0]["KTVThucHien_Id"].ToString());
                                TiepNhan_Id = SuaLoadThongTinBenhNhan.Rows[0]["TiepNhan_Id"].ToString();
                                CLSYeuCau_Id = SuaLoadThongTinBenhNhan.Rows[0]["CLSYeuCau_Id"].ToString();
                                CLSKetQua_Id = SuaLoadThongTinBenhNhan.Rows[0]["CLSKetQuaGPB_Id"].ToString();

                                string KhongCoTonThuong = SuaLoadThongTinBenhNhan.Rows[0]["KhongCoTonThuong"].ToString();
                                string Trichomononas = SuaLoadThongTinBenhNhan.Rows[0]["Trichomononas"].ToString();
                                string Candida = SuaLoadThongTinBenhNhan.Rows[0]["Candida"].ToString();
                                string TapKhan = SuaLoadThongTinBenhNhan.Rows[0]["TapKhan"].ToString();
                                string Actinomyces = SuaLoadThongTinBenhNhan.Rows[0]["Actinomyces"].ToString();
                                string Herpes = SuaLoadThongTinBenhNhan.Rows[0]["Herpes"].ToString();
                                string Cytomegalo = SuaLoadThongTinBenhNhan.Rows[0]["Cytomegalo"].ToString();
                                string ChuyenSanGai = SuaLoadThongTinBenhNhan.Rows[0]["ChuyenSanGai"].ToString();
                                string ThayDoiSung = SuaLoadThongTinBenhNhan.Rows[0]["ThayDoiSung"].ToString();
                                string ChuyenSanTuyen = SuaLoadThongTinBenhNhan.Rows[0]["ChuyenSanTuyen"].ToString();
                                string Teo = SuaLoadThongTinBenhNhan.Rows[0]["Teo"].ToString();
                                string ThayDoiLienQuanThaiky = SuaLoadThongTinBenhNhan.Rows[0]["ThayDoiLienQuanThaiky"].ToString();
                                string DoViem = SuaLoadThongTinBenhNhan.Rows[0]["DoViem"].ToString();
                                string DoXaTri = SuaLoadThongTinBenhNhan.Rows[0]["DoXaTri"].ToString();
                                string DoVongTranhThai = SuaLoadThongTinBenhNhan.Rows[0]["DoVongTranhThai"].ToString();

                                txtTinhTrangTeBaoKhac.Text = SuaLoadThongTinBenhNhan.Rows[0]["TinhTrangTeBaoKhac"].ToString();

                                string BatThuongTeBao = SuaLoadThongTinBenhNhan.Rows[0]["BatThuongTeBao"].ToString();
                                string TeBaoGaiKhongDienHinh = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoGaiKhongDienHinh"].ToString();
                                string YNghia = SuaLoadThongTinBenhNhan.Rows[0]["YNghia"].ToString();
                                string ChuaLoaiTru = SuaLoadThongTinBenhNhan.Rows[0]["ChuaLoaiTru"].ToString();
                                string TonThuongThap = SuaLoadThongTinBenhNhan.Rows[0]["TonThuongThap"].ToString();
                                string TonThuongCao = SuaLoadThongTinBenhNhan.Rows[0]["TonThuongCao"].ToString();
                                string CarcinomaTeBaoGai = SuaLoadThongTinBenhNhan.Rows[0]["CarcinomaTeBaoGai"].ToString();
                                string TeBaoTuyenKhongDienHinh = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenKhongDienHinh"].ToString();
                                string TeBaoTuyenCoTrong = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenCoTrong"].ToString();
                                string TeBaoNoiMo = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoNoiMo"].ToString();
                                string TeBaoTuyen = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyen"].ToString();
                                string TeBaoTuyenCoTrongHuongDenU = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenCoTrongHuongDenU"].ToString();
                                string TeBaoTuyenHuongDenU = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenHuongDenU"].ToString();
                                string CarcinomaTeBaoTuyenCoTron = SuaLoadThongTinBenhNhan.Rows[0]["CarcinomaTeBaoTuyenCoTron"].ToString();
                                string CarcinomaTeBaoTuyen = SuaLoadThongTinBenhNhan.Rows[0]["CarcinomaTeBaoTuyen"].ToString();
                                string TuyenCoTrong = SuaLoadThongTinBenhNhan.Rows[0]["TuyenCoTrong"].ToString();
                                string TuyenNoiMac = SuaLoadThongTinBenhNhan.Rows[0]["TuyenNoiMac"].ToString();
                                string TuyenNgoaiTuCung = SuaLoadThongTinBenhNhan.Rows[0]["TuyenNgoaiTuCung"].ToString();
                                string TuyenKhongDacHieu = SuaLoadThongTinBenhNhan.Rows[0]["TuyenKhongDacHieu"].ToString();

                                txtUAcTinhKhac.Text = SuaLoadThongTinBenhNhan.Rows[0]["UAcTinhKhac"].ToString();

                                if (KhongCoTonThuong == "1") { cbKhongCoTonThuong.Checked = true; } else { cbKhongCoTonThuong.Checked = false; }
                                if (Trichomononas == "1") { cbTrichomononas.Checked = true; } else { cbTrichomononas.Checked = false; }
                                if (Candida == "1") { cbCandida.Checked = true; } else { cbCandida.Checked = false; }
                                if (TapKhan == "1") { cbTapKhan.Checked = true; } else { cbTapKhan.Checked = false; }
                                if (Actinomyces == "1") { cbActinomyces.Checked = true; } else { cbActinomyces.Checked = false; }
                                if (Herpes == "1") { cbHerpes.Checked = true; } else { cbHerpes.Checked = false; }
                                if (Cytomegalo == "1") { cbCytomegalo.Checked = true; } else { cbCytomegalo.Checked = false; }
                                if (ChuyenSanGai == "1") { cbChuyenSanGai.Checked = true; } else { cbChuyenSanGai.Checked = false; }
                                if (ThayDoiSung == "1") { cbThayDoiSung.Checked = true; } else { cbThayDoiSung.Checked = false; }
                                if (ChuyenSanTuyen == "1") { cbChuyenSanTuyen.Checked = true; } else { cbChuyenSanTuyen.Checked = false; }
                                if (Teo == "1") { cbTeo.Checked = true; } else { cbTeo.Checked = false; }
                                if (ThayDoiLienQuanThaiky == "1") { cbThayDoiLienQuanThaiky.Checked = true; } else { cbThayDoiLienQuanThaiky.Checked = false; }
                                if (DoViem == "1") { cbDoViem.Checked = true; } else { cbDoViem.Checked = false; }
                                if (DoXaTri == "1") { cbDoXaTri.Checked = true; } else { cbDoXaTri.Checked = false; }
                                if (DoVongTranhThai == "1") { cbDoVongTranhThai.Checked = true; } else { cbDoVongTranhThai.Checked = false; }

                                if (BatThuongTeBao == "1") { cbBatThuongTeBao.Checked = true; } else { cbBatThuongTeBao.Checked = false; }
                                if (TeBaoGaiKhongDienHinh == "1") { cbTeBaoGaiKhongDienHinh.Checked = true; } else { cbTeBaoGaiKhongDienHinh.Checked = false; }
                                if (YNghia == "1") { cbYNghia.Checked = true; } else { cbYNghia.Checked = false; }
                                if (ChuaLoaiTru == "1") { cbChuaLoaiTru.Checked = true; } else { cbChuaLoaiTru.Checked = false; }
                                if (TonThuongThap == "1") { cbTonThuongThap.Checked = true; } else { cbTonThuongThap.Checked = false; }
                                if (TonThuongCao == "1") { cbTonThuongCao.Checked = true; } else { cbTonThuongCao.Checked = false; }
                                if (CarcinomaTeBaoGai == "1") { cbCarcinomaTeBaoGai.Checked = true; } else { cbCarcinomaTeBaoGai.Checked = false; }
                                if (TeBaoTuyenKhongDienHinh == "1") { cbTeBaoTuyenKhongDienHinh.Checked = true; } else { cbTeBaoTuyenKhongDienHinh.Checked = false; }
                                if (TeBaoTuyenCoTrong == "1") { cbTeBaoTuyenCoTrong.Checked = true; } else { cbTeBaoTuyenCoTrong.Checked = false; }
                                if (TeBaoNoiMo == "1") { cbTeBaoNoiMo.Checked = true; } else { cbTeBaoNoiMo.Checked = false; }
                                if (TeBaoTuyen == "1") { cbTeBaoTuyen.Checked = true; } else { cbTeBaoTuyen.Checked = false; }
                                if (TeBaoTuyenCoTrongHuongDenU == "1") { cbTeBaoTuyenCoTrongHuongDenU.Checked = true; } else { cbTeBaoTuyenCoTrongHuongDenU.Checked = false; }
                                if (TeBaoTuyenHuongDenU == "1") { cbTeBaoTuyenHuongDenU.Checked = true; } else { cbTeBaoTuyenHuongDenU.Checked = false; }
                                if (CarcinomaTeBaoTuyenCoTron == "1") { cbCarcinomaTeBaoTuyenCoTron.Checked = true; } else { cbCarcinomaTeBaoTuyenCoTron.Checked = false; }
                                if (CarcinomaTeBaoTuyen == "1") { cbCarcinomaTeBaoTuyen.Checked = true; } else { cbCarcinomaTeBaoTuyen.Checked = false; }
                                if (TuyenCoTrong == "1") { cbTuyenCoTrong.Checked = true; } else { cbTuyenCoTrong.Checked = false; }
                                if (TuyenNoiMac == "1") { cbTuyenNoiMac.Checked = true; } else { cbTuyenNoiMac.Checked = false; }
                                if (TuyenNgoaiTuCung == "1") { cbTuyenNgoaiTuCung.Checked = true; } else { cbTuyenNgoaiTuCung.Checked = false; }
                                if (TuyenKhongDacHieu == "1") { cbTuyenKhongDacHieu.Checked = true; } else { cbTuyenKhongDacHieu.Checked = false; }

                                //
                                selectHinhAnh(CLSKetQua_Id);

                            }
                        }

                    }
                }
            }
        }
        public void LoadThongTinFormButton()
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
        public void LoadThongTinForm()
        {
            DataTable SuaLoadThongTinBenhNhan = Model.dbGPB.SuaLoadThongTinBenhNhan(CLSKetQua_Id);
            if (SuaLoadThongTinBenhNhan != null)
            {
                if (SuaLoadThongTinBenhNhan.Rows.Count > 0)
                {
                    txtSoTiepNhan.Text = SuaLoadThongTinBenhNhan.Rows[0]["SoPhieuYeuCau"].ToString();
                    txtMaYTe.Text = SuaLoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                    txtHoTen.Text = SuaLoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                    txtTuoi.Text = SuaLoadThongTinBenhNhan.Rows[0]["Tuoi"].ToString();
                    txtGioiTinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["GioiTinh"].ToString();
                    txtNamSinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["NamSinh"].ToString();
                    txtChanDoan.Text = SuaLoadThongTinBenhNhan.Rows[0]["ChanDoan"].ToString();

                    string ThoiGianThucHien = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianThucHien"].ToString();
                    if (!String.IsNullOrEmpty(ThoiGianThucHien))
                    {
                        DateTime enteredDate = DateTime.Parse(ThoiGianThucHien);
                        txtThoiGianThucHien.Value = enteredDate;
                    }
                    txtLoiDan.Text = SuaLoadThongTinBenhNhan.Rows[0]["LoiDan"].ToString();
                    txtKetLuan.Text = SuaLoadThongTinBenhNhan.Rows[0]["KetLuan"].ToString();
                    string BacSiKetLuan_Id = SuaLoadThongTinBenhNhan.Rows[0]["BacSiKetLuan_Id"].ToString();
                    if (!String.IsNullOrEmpty(BacSiKetLuan_Id))
                    {
                        cbbBacSiKetLuan.Value = Int32.Parse(BacSiKetLuan_Id);
                    }
                    txtTenDichVu.Text = SuaLoadThongTinBenhNhan.Rows[0]["TenDichVu"].ToString();
                    //cbbKTVThucHien.SelectedValue = Int32.Parse(SuaLoadThongTinBenhNhan.Rows[0]["KTVThucHien_Id"].ToString());
                    TiepNhan_Id = SuaLoadThongTinBenhNhan.Rows[0]["TiepNhan_Id"].ToString();
                    CLSYeuCau_Id = SuaLoadThongTinBenhNhan.Rows[0]["CLSYeuCau_Id"].ToString();
                    CLSKetQua_Id = SuaLoadThongTinBenhNhan.Rows[0]["CLSKetQua_Id"].ToString();

                    string KhongCoTonThuong = SuaLoadThongTinBenhNhan.Rows[0]["KhongCoTonThuong"].ToString();
                    string Trichomononas = SuaLoadThongTinBenhNhan.Rows[0]["Trichomononas"].ToString();
                    string Candida = SuaLoadThongTinBenhNhan.Rows[0]["Candida"].ToString();
                    string TapKhan = SuaLoadThongTinBenhNhan.Rows[0]["TapKhan"].ToString();
                    string Actinomyces = SuaLoadThongTinBenhNhan.Rows[0]["Actinomyces"].ToString();
                    string Herpes = SuaLoadThongTinBenhNhan.Rows[0]["Herpes"].ToString();
                    string Cytomegalo = SuaLoadThongTinBenhNhan.Rows[0]["Cytomegalo"].ToString();
                    string ChuyenSanGai = SuaLoadThongTinBenhNhan.Rows[0]["ChuyenSanGai"].ToString();
                    string ThayDoiSung = SuaLoadThongTinBenhNhan.Rows[0]["ThayDoiSung"].ToString();
                    string ChuyenSanTuyen = SuaLoadThongTinBenhNhan.Rows[0]["ChuyenSanTuyen"].ToString();
                    string Teo = SuaLoadThongTinBenhNhan.Rows[0]["Teo"].ToString();
                    string ThayDoiLienQuanThaiky = SuaLoadThongTinBenhNhan.Rows[0]["ThayDoiLienQuanThaiky"].ToString();
                    string DoViem = SuaLoadThongTinBenhNhan.Rows[0]["DoViem"].ToString();
                    string DoXaTri = SuaLoadThongTinBenhNhan.Rows[0]["DoXaTri"].ToString();
                    string DoVongTranhThai = SuaLoadThongTinBenhNhan.Rows[0]["DoVongTranhThai"].ToString();

                    txtTinhTrangTeBaoKhac.Text = SuaLoadThongTinBenhNhan.Rows[0]["TinhTrangTeBaoKhac"].ToString();

                    string BatThuongTeBao = SuaLoadThongTinBenhNhan.Rows[0]["BatThuongTeBao"].ToString();
                    string TeBaoGaiKhongDienHinh = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoGaiKhongDienHinh"].ToString();
                    string YNghia = SuaLoadThongTinBenhNhan.Rows[0]["YNghia"].ToString();
                    string ChuaLoaiTru = SuaLoadThongTinBenhNhan.Rows[0]["ChuaLoaiTru"].ToString();
                    string TonThuongThap = SuaLoadThongTinBenhNhan.Rows[0]["TonThuongThap"].ToString();
                    string TonThuongCao = SuaLoadThongTinBenhNhan.Rows[0]["TonThuongCao"].ToString();
                    string CarcinomaTeBaoGai = SuaLoadThongTinBenhNhan.Rows[0]["CarcinomaTeBaoGai"].ToString();
                    string TeBaoTuyenKhongDienHinh = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenKhongDienHinh"].ToString();
                    string TeBaoTuyenCoTrong = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenCoTrong"].ToString();
                    string TeBaoNoiMo = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoNoiMo"].ToString();
                    string TeBaoTuyen = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyen"].ToString();
                    string TeBaoTuyenCoTrongHuongDenU = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenCoTrongHuongDenU"].ToString();
                    string TeBaoTuyenHuongDenU = SuaLoadThongTinBenhNhan.Rows[0]["TeBaoTuyenHuongDenU"].ToString();
                    string CarcinomaTeBaoTuyenCoTron = SuaLoadThongTinBenhNhan.Rows[0]["CarcinomaTeBaoTuyenCoTron"].ToString();
                    string CarcinomaTeBaoTuyen = SuaLoadThongTinBenhNhan.Rows[0]["CarcinomaTeBaoTuyen"].ToString();
                    string TuyenCoTrong = SuaLoadThongTinBenhNhan.Rows[0]["TuyenCoTrong"].ToString();
                    string TuyenNoiMac = SuaLoadThongTinBenhNhan.Rows[0]["TuyenNoiMac"].ToString();
                    string TuyenNgoaiTuCung = SuaLoadThongTinBenhNhan.Rows[0]["TuyenNgoaiTuCung"].ToString();
                    string TuyenKhongDacHieu = SuaLoadThongTinBenhNhan.Rows[0]["TuyenKhongDacHieu"].ToString();

                    txtUAcTinhKhac.Text = SuaLoadThongTinBenhNhan.Rows[0]["UAcTinhKhac"].ToString();

                    if (KhongCoTonThuong == "1") { cbKhongCoTonThuong.Checked = true; } else { cbKhongCoTonThuong.Checked = false; }
                    if (Trichomononas == "1") { cbTrichomononas.Checked = true; } else { cbTrichomononas.Checked = false; }
                    if (Candida == "1") { cbCandida.Checked = true; } else { cbCandida.Checked = false; }
                    if (TapKhan == "1") { cbTapKhan.Checked = true; } else { cbTapKhan.Checked = false; }
                    if (Actinomyces == "1") { cbActinomyces.Checked = true; } else { cbActinomyces.Checked = false; }
                    if (Herpes == "1") { cbHerpes.Checked = true; } else { cbHerpes.Checked = false; }
                    if (Cytomegalo == "1") { cbCytomegalo.Checked = true; } else { cbCytomegalo.Checked = false; }
                    if (ChuyenSanGai == "1") { cbChuyenSanGai.Checked = true; } else { cbChuyenSanGai.Checked = false; }
                    if (ThayDoiSung == "1") { cbThayDoiSung.Checked = true; } else { cbThayDoiSung.Checked = false; }
                    if (ChuyenSanTuyen == "1") { cbChuyenSanTuyen.Checked = true; } else { cbChuyenSanTuyen.Checked = false; }
                    if (Teo == "1") { cbTeo.Checked = true; } else { cbTeo.Checked = false; }
                    if (ThayDoiLienQuanThaiky == "1") { cbThayDoiLienQuanThaiky.Checked = true; } else { cbThayDoiLienQuanThaiky.Checked = false; }
                    if (DoViem == "1") { cbDoViem.Checked = true; } else { cbDoViem.Checked = false; }
                    if (DoXaTri == "1") { cbDoXaTri.Checked = true; } else { cbDoXaTri.Checked = false; }
                    if (DoVongTranhThai == "1") { cbDoVongTranhThai.Checked = true; } else { cbDoVongTranhThai.Checked = false; }

                    if (BatThuongTeBao == "1") { cbBatThuongTeBao.Checked = true; } else { cbBatThuongTeBao.Checked = false; }
                    if (TeBaoGaiKhongDienHinh == "1") { cbTeBaoGaiKhongDienHinh.Checked = true; } else { cbTeBaoGaiKhongDienHinh.Checked = false; }
                    if (YNghia == "1") { cbYNghia.Checked = true; } else { cbYNghia.Checked = false; }
                    if (ChuaLoaiTru == "1") { cbChuaLoaiTru.Checked = true; } else { cbChuaLoaiTru.Checked = false; }
                    if (TonThuongThap == "1") { cbTonThuongThap.Checked = true; } else { cbTonThuongThap.Checked = false; }
                    if (TonThuongCao == "1") { cbTonThuongCao.Checked = true; } else { cbTonThuongCao.Checked = false; }
                    if (CarcinomaTeBaoGai == "1") { cbCarcinomaTeBaoGai.Checked = true; } else { cbCarcinomaTeBaoGai.Checked = false; }
                    if (TeBaoTuyenKhongDienHinh == "1") { cbTeBaoTuyenKhongDienHinh.Checked = true; } else { cbTeBaoTuyenKhongDienHinh.Checked = false; }
                    if (TeBaoTuyenCoTrong == "1") { cbTeBaoTuyenCoTrong.Checked = true; } else { cbTeBaoTuyenCoTrong.Checked = false; }
                    if (TeBaoNoiMo == "1") { cbTeBaoNoiMo.Checked = true; } else { cbTeBaoNoiMo.Checked = false; }
                    if (TeBaoTuyen == "1") { cbTeBaoTuyen.Checked = true; } else { cbTeBaoTuyen.Checked = false; }
                    if (TeBaoTuyenCoTrongHuongDenU == "1") { cbTeBaoTuyenCoTrongHuongDenU.Checked = true; } else { cbTeBaoTuyenCoTrongHuongDenU.Checked = false; }
                    if (TeBaoTuyenHuongDenU == "1") { cbTeBaoTuyenHuongDenU.Checked = true; } else { cbTeBaoTuyenHuongDenU.Checked = false; }
                    if (CarcinomaTeBaoTuyenCoTron == "1") { cbCarcinomaTeBaoTuyenCoTron.Checked = true; } else { cbCarcinomaTeBaoTuyenCoTron.Checked = false; }
                    if (CarcinomaTeBaoTuyen == "1") { cbCarcinomaTeBaoTuyen.Checked = true; } else { cbCarcinomaTeBaoTuyen.Checked = false; }
                    if (TuyenCoTrong == "1") { cbTuyenCoTrong.Checked = true; } else { cbTuyenCoTrong.Checked = false; }
                    if (TuyenNoiMac == "1") { cbTuyenNoiMac.Checked = true; } else { cbTuyenNoiMac.Checked = false; }
                    if (TuyenNgoaiTuCung == "1") { cbTuyenNgoaiTuCung.Checked = true; } else { cbTuyenNgoaiTuCung.Checked = false; }
                    if (TuyenKhongDacHieu == "1") { cbTuyenKhongDacHieu.Checked = true; } else { cbTuyenKhongDacHieu.Checked = false; }

                    selectHinhAnh(CLSKetQua_Id);
                }
            }

        }
        public void RefreshForm()
        {
            DataTable LayThongTinSoPhieuYeuCau = Model.dbGPB.LayThongTinSoPhieuYeuCau(CLSYeuCau_Id);
            if (LayThongTinSoPhieuYeuCau != null)
            {
                if (LayThongTinSoPhieuYeuCau.Rows.Count > 0)
                {
                    txtSoTiepNhan.Text = LayThongTinSoPhieuYeuCau.Rows[0]["SoPhieuYeuCau"].ToString();
                    txtMaYTe.Text = LayThongTinSoPhieuYeuCau.Rows[0]["MaYTe"].ToString();
                    txtHoTen.Text = LayThongTinSoPhieuYeuCau.Rows[0]["TenBenhNhan"].ToString();
                    txtTuoi.Text = LayThongTinSoPhieuYeuCau.Rows[0]["Tuoi"].ToString();
                    txtGioiTinh.Text = LayThongTinSoPhieuYeuCau.Rows[0]["GioiTinh"].ToString();
                    txtNamSinh.Text = LayThongTinSoPhieuYeuCau.Rows[0]["NamSinh"].ToString();
                    txtChanDoan.Text = LayThongTinSoPhieuYeuCau.Rows[0]["ChanDoan"].ToString();
                    txtTenDichVu.Text = LayThongTinSoPhieuYeuCau.Rows[0]["TenDichVu"].ToString();
                    txtThoiGianThucHien.Value = DateTime.Now;
                    TiepNhan_Id = LayThongTinSoPhieuYeuCau.Rows[0]["TiepNhan_Id"].ToString();
                    CLSYeuCau_Id = LayThongTinSoPhieuYeuCau.Rows[0]["CLSYeuCau_Id"].ToString();

                    //set camera
                    //if (LayThongTinSoPhieuYeuCau.Rows[0]["NhomDichVu_Id"].ToString() == "8")
                    //{
                    //    CameraDeviceInfo a4camInfo = CameraControl.GetDevices().Find(x => x.Name.Contains(CameraDeviceGPB));
                    //    cameraControl1.Start(CameraControl.GetDevice(a4camInfo));
                    //}
                    //else if (LayThongTinSoPhieuYeuCau.Rows[0]["NhomDichVu_Id"].ToString() == "9")
                    //{
                    //    CameraDeviceInfo a4camInfo = CameraControl.GetDevices().Find(x => x.Name.Contains(CameraDeviceNS));
                    //    cameraControl1.Start(CameraControl.GetDevice(a4camInfo));
                    //}
                    //else
                    //{
                    //    CameraDeviceInfo a4camInfo = CameraControl.GetDevices().Find(x => x.Name.Contains(CameraDeviceSA));
                    //    cameraControl1.Start(CameraControl.GetDevice(a4camInfo));
                    //}
                }
            }

            txtChanDoan.Focus();
        }
        public void Hien()
        {
            txtSoTiepNhan.Enabled = true;
            txtHoTen.Enabled = true;
            txtTuoi.Enabled = true;
            txtMaYTe.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtNamSinh.Enabled = true;
            txtChanDoan.Enabled = true;
            cbbBacSiKetLuan.Enabled = true;

            pnSCTC.Enabled = true;

            txtLoiDan.Enabled = true;
            txtKetLuan.Enabled = true;
            btn_S.Enabled = true;
            //gridDichVu.Enabled = true;
            txtThoiGianThucHien.Enabled = true;
            //cbbNhomDichVu.Enabled = true;
            txtTenDichVu.Enabled = true;
        }
        public void An()
        {
            txtSoTiepNhan.Enabled = false;
            txtHoTen.Enabled = false;
            txtTuoi.Enabled = false;
            txtMaYTe.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtNamSinh.Enabled = false;
            txtChanDoan.Enabled = false;
            cbbBacSiKetLuan.Enabled = false;

            pnSCTC.Enabled = false;

            txtLoiDan.Enabled = false;
            txtKetLuan.Enabled = false;
            btn_S.Enabled = false;
            //gridDichVu.Enabled = false;
            txtThoiGianThucHien.Enabled = false;
            //cbbNhomDichVu.Enabled = false;
            txtTenDichVu.Enabled = false;
        }
        public void Reset()
        {
            txtSoTiepNhan.Text = "";
            txtHoTen.Text = "";
            txtTuoi.Text = "";
            txtMaYTe.Text = "";
            txtGioiTinh.Text = "";
            txtNamSinh.Text = "";
            txtChanDoan.Text = "";
            cbbBacSiKetLuan.Text = "";
            //cbbLoaiKetQua.Text = "";
            //txtMoTa.Text = "";
            txtLoiDan.Text = "";
            txtKetLuan.Text = "";
            txtThoiGianThucHien.Text = "";
            txtTenDichVu.Text = "";
            ResetHinhAnh();

            cbKhongCoTonThuong.Checked = false;
            cbTrichomononas.Checked = false;
            cbCandida.Checked = false;
            cbTapKhan.Checked = false;
            cbActinomyces.Checked = false;
            cbHerpes.Checked = false;
            cbCytomegalo.Checked = false;
            cbChuyenSanGai.Checked = false;
            cbThayDoiSung.Checked = false;
            cbChuyenSanTuyen.Checked = false;
            cbTeo.Checked = false;
            cbThayDoiLienQuanThaiky.Checked = false;
            cbDoViem.Checked = false;
            cbDoXaTri.Checked = false;
            cbDoVongTranhThai.Checked = false;
            txtTinhTrangTeBaoKhac.Text = "";
            cbBatThuongTeBao.Checked = false;
            cbTeBaoGaiKhongDienHinh.Checked = false;
            cbYNghia.Checked = false;
            cbChuaLoaiTru.Checked = false;
            cbTonThuongThap.Checked = false;
            cbTonThuongCao.Checked = false;
            cbCarcinomaTeBaoGai.Checked = false;
            cbTeBaoTuyenKhongDienHinh.Checked = false;
            cbTeBaoTuyenCoTrong.Checked = false;
            cbTeBaoNoiMo.Checked = false;
            cbTeBaoTuyen.Checked = false;
            cbTeBaoTuyenCoTrongHuongDenU.Checked = false;
            cbTeBaoTuyenHuongDenU.Checked = false;
            cbCarcinomaTeBaoTuyenCoTron.Checked = false;
            cbCarcinomaTeBaoTuyen.Checked = false;
            cbTuyenCoTrong.Checked = false;
            cbTuyenNoiMac.Checked = false;
            cbTuyenNgoaiTuCung.Checked = false;
            cbTuyenKhongDacHieu.Checked = false;
            txtUAcTinhKhac.Text = "";

        }
        public void ResetHinhAnh()
        {
            NameAnh1 = ""; NameAnh2 = ""; NameAnh3 = ""; NameAnh4 = ""; NameAnh5 = ""; NameAnh6 = ""; NameAnh7 = ""; NameAnh8 = ""; NameAnh9 = "";
            Anh1 = ""; Anh2 = ""; Anh3 = ""; Anh4 = ""; Anh5 = ""; Anh6 = ""; Anh7 = ""; Anh8 = ""; Anh9 = "";
            pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null;
            pictureBox5.Image = null; pictureBox6.Image = null; pictureBox7.Image = null; pictureBox9.Image = null; pictureBox9.Image = null;
        }
        string Anh1 = ""; string Anh2 = ""; string Anh3 = ""; string Anh4 = ""; string Anh5 = ""; string Anh6 = ""; string Anh7 = ""; string Anh8 = ""; string Anh9 = "";

        string NameAnh1 = ""; string NameAnh2 = ""; string NameAnh3 = ""; string NameAnh4 = ""; string NameAnh5 = ""; string NameAnh6 = ""; string NameAnh7 = ""; string NameAnh8 = ""; string NameAnh9 = "";

        private void btnSendZalo_Click(object sender, EventArgs e)
        {
            if (CLSKetQua_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Bệnh Nhân!", "");
            }
            else
            {
                View.Zalo.GiaiPhauBenh bc = new View.Zalo.GiaiPhauBenh(this);
                bc.ShowDialog();
            }
        }


        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            //  Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            //                   ^  ^  ^  ^  ^  ^ 
            this.openFileDialog1.Title = "My Image Browser";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    if (pictureBox1.Image != null)
                    {
                        if (pictureBox2.Image != null)
                        {
                            if (pictureBox3.Image != null)
                            {
                                if (pictureBox4.Image != null)
                                {
                                    //MessageBox.Show("Đã đủ hình");
                                    if (pictureBox5.Image != null)
                                    {
                                        if (pictureBox6.Image != null)
                                        {
                                            if (pictureBox7.Image != null)
                                            {
                                                if (pictureBox8.Image != null)
                                                {
                                                    if (pictureBox9.Image != null)
                                                    {
                                                        MessageBox.Show("Đã đủ hình");
                                                    }
                                                    else
                                                    {
                                                        pictureBox9.Image = Image.FromFile(file);
                                                        NameAnh9 = pathImage + file;
                                                        string[] s = (file).Split('\\');
                                                        int count = s.Length;
                                                        Anh9 = s[count - 1];
                                                        pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                                                    }
                                                }
                                                else
                                                {
                                                    pictureBox8.Image = Image.FromFile(file);
                                                    NameAnh8 = pathImage + file;
                                                    string[] s = (file).Split('\\');
                                                    int count = s.Length;
                                                    Anh8 = s[count - 1];
                                                    pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                                                }
                                            }
                                            else
                                            {
                                                pictureBox7.Image = Image.FromFile(file);
                                                NameAnh7 = file;
                                                string[] s = (file).Split('\\');
                                                int count = s.Length;
                                                Anh7 = s[count - 1];
                                                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                                            }
                                        }
                                        else
                                        {
                                            pictureBox6.Image = Image.FromFile(file);
                                            NameAnh6 = file;
                                            string[] s = (file).Split('\\');
                                            int count = s.Length;
                                            Anh6 = s[count - 1];
                                            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                                        }
                                    }
                                    else
                                    {
                                        pictureBox5.Image = Image.FromFile(file);
                                        NameAnh5 = file;
                                        string[] s = (file).Split('\\');
                                        int count = s.Length;
                                        Anh5 = s[count - 1];
                                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }

                                }
                                else
                                {
                                    pictureBox4.Image = Image.FromFile(file);
                                    NameAnh4 = file;
                                    string[] s = (file).Split('\\');
                                    int count = s.Length;
                                    Anh4 = s[count - 1];
                                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                            else
                            {
                                pictureBox3.Image = Image.FromFile(file);
                                NameAnh3 = file;
                                string[] s = (file).Split('\\');
                                int count = s.Length;
                                Anh3 = s[count - 1];
                                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                        else
                        {
                            pictureBox2.Image = Image.FromFile(file);
                            NameAnh2 = file;
                            string[] s = (file).Split('\\');
                            int count = s.Length;
                            Anh2 = s[count - 1];
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = Image.FromFile(file);
                        NameAnh1 = file;
                        string[] s = (file).Split('\\');
                        int count = s.Length;
                        Anh1 = s[count - 1];
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có đồng ý xóa những ảnh đã chọn không?",
            "Thong Bao!", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    if (pnpictureBox1.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox1.Image = null;
                        NameAnh1 = "";
                        Anh1 = "";
                        pnpictureBox1.BackColor = Color.Transparent;
                    }
                    //ảnh 2
                    if (pnpictureBox2.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox2.Image = null;
                        NameAnh2 = "";
                        Anh2 = "";
                        pnpictureBox2.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh1 == "" && NameAnh2 != "")
                        {
                            pictureBox1.Image = Image.FromFile(NameAnh2);
                            pictureBox2.Image = null;
                            NameAnh1 = NameAnh2;
                            NameAnh2 = "";
                            Anh1 = Anh2;
                            Anh2 = "";
                        }
                    }
                    //ảnh 3
                    if (pnpictureBox3.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox3.Image = null;
                        NameAnh3 = "";
                        Anh3 = "";
                        pnpictureBox3.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh3 != "")
                        {
                            if (NameAnh1 == "" && NameAnh2 == "")
                            {
                                pictureBox1.Image = Image.FromFile(NameAnh3);
                                pictureBox3.Image = null;
                                NameAnh1 = NameAnh3;
                                NameAnh3 = "";
                                Anh1 = Anh3;
                                Anh3 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 == "")
                            {
                                pictureBox2.Image = Image.FromFile(NameAnh3);
                                pictureBox3.Image = null;
                                NameAnh2 = NameAnh3;
                                NameAnh3 = "";
                                Anh2 = Anh3;
                                Anh3 = "";
                            }
                        }
                    }
                    //ảnh 4
                    if (pnpictureBox4.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox4.Image = null;
                        NameAnh4 = "";
                        Anh4 = "";
                        pnpictureBox4.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh4 != "")
                        {
                            if (NameAnh1 == "" && NameAnh2 == "" && NameAnh3 == "")
                            {
                                pictureBox1.Image = Image.FromFile(NameAnh4);
                                pictureBox4.Image = null;
                                NameAnh1 = NameAnh4;
                                NameAnh4 = "";
                                Anh1 = Anh4;
                                Anh4 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 == "" && NameAnh3 == "")
                            {
                                pictureBox2.Image = Image.FromFile(NameAnh4);
                                pictureBox4.Image = null;
                                NameAnh2 = NameAnh4;
                                NameAnh4 = "";
                                Anh2 = Anh4;
                                Anh4 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 == "")
                            {
                                pictureBox3.Image = Image.FromFile(NameAnh4);
                                pictureBox4.Image = null;
                                NameAnh3 = NameAnh4;
                                NameAnh4 = "";
                                Anh3 = Anh4;
                                Anh4 = "";
                            }
                        }
                    }
                    //ảnh 5
                    if (pnpictureBox5.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox5.Image = null;
                        NameAnh5 = "";
                        Anh5 = "";
                        pnpictureBox5.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh5 != "")
                        {
                            if (NameAnh1 == "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "")
                            {
                                pictureBox1.Image = Image.FromFile(NameAnh5);
                                pictureBox5.Image = null;
                                NameAnh1 = NameAnh5;
                                NameAnh5 = "";
                                Anh1 = Anh5;
                                Anh5 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "")
                            {
                                pictureBox2.Image = Image.FromFile(NameAnh5);
                                pictureBox5.Image = null;
                                NameAnh2 = NameAnh5;
                                NameAnh5 = "";
                                Anh2 = Anh5;
                                Anh5 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 == "" && NameAnh4 == "")
                            {
                                pictureBox3.Image = Image.FromFile(NameAnh5);
                                pictureBox5.Image = null;
                                NameAnh3 = NameAnh5;
                                NameAnh5 = "";
                                Anh3 = Anh5;
                                Anh5 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 == "")
                            {
                                pictureBox4.Image = Image.FromFile(NameAnh5);
                                pictureBox5.Image = null;
                                NameAnh4 = NameAnh5;
                                NameAnh5 = "";
                                Anh4 = Anh5;
                                Anh5 = "";
                            }
                        }
                    }
                    //ảnh 6
                    if (pnpictureBox6.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox6.Image = null;
                        NameAnh6 = "";
                        Anh6 = "";
                        pnpictureBox6.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh6 != "")
                        {
                            if (NameAnh1 == "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "")
                            {
                                pictureBox1.Image = Image.FromFile(NameAnh6);
                                pictureBox6.Image = null;
                                NameAnh1 = NameAnh6;
                                NameAnh6 = "";
                                Anh1 = Anh6;
                                Anh6 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "")
                            {
                                pictureBox2.Image = Image.FromFile(NameAnh6);
                                pictureBox6.Image = null;
                                NameAnh2 = NameAnh6;
                                NameAnh6 = "";
                                Anh2 = Anh6;
                                Anh6 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "")
                            {
                                pictureBox3.Image = Image.FromFile(NameAnh6);
                                pictureBox6.Image = null;
                                NameAnh3 = NameAnh6;
                                NameAnh6 = "";
                                Anh3 = Anh6;
                                Anh6 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 == "" && NameAnh5 == "")
                            {
                                pictureBox4.Image = Image.FromFile(NameAnh6);
                                pictureBox6.Image = null;
                                NameAnh4 = NameAnh6;
                                NameAnh6 = "";
                                Anh4 = Anh6;
                                Anh6 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 == "")
                            {
                                pictureBox5.Image = Image.FromFile(NameAnh6);
                                pictureBox6.Image = null;
                                NameAnh5 = NameAnh6;
                                NameAnh6 = "";
                                Anh5 = Anh6;
                                Anh6 = "";
                            }
                        }
                    }
                    //ảnh 7
                    if (pnpictureBox7.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox7.Image = null;
                        NameAnh7 = "";
                        Anh7 = "";
                        pnpictureBox7.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh7 != "")
                        {
                            if (NameAnh1 == "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "")
                            {
                                pictureBox1.Image = Image.FromFile(NameAnh7);
                                pictureBox7.Image = null;
                                NameAnh1 = NameAnh7;
                                NameAnh7 = "";
                                Anh1 = Anh7;
                                Anh7 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "")
                            {
                                pictureBox2.Image = Image.FromFile(NameAnh7);
                                pictureBox7.Image = null;
                                NameAnh2 = NameAnh7;
                                NameAnh7 = "";
                                Anh2 = Anh7;
                                Anh7 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "")
                            {
                                pictureBox3.Image = Image.FromFile(NameAnh7);
                                pictureBox7.Image = null;
                                NameAnh3 = NameAnh7;
                                NameAnh7 = "";
                                Anh3 = Anh7;
                                Anh7 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "")
                            {
                                pictureBox4.Image = Image.FromFile(NameAnh7);
                                pictureBox7.Image = null;
                                NameAnh4 = NameAnh7;
                                NameAnh7 = "";
                                Anh4 = Anh7;
                                Anh7 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 == "" && NameAnh6 == "")
                            {
                                pictureBox5.Image = Image.FromFile(NameAnh7);
                                pictureBox7.Image = null;
                                NameAnh5 = NameAnh7;
                                NameAnh7 = "";
                                Anh5 = Anh7;
                                Anh7 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 != "" && NameAnh6 == "")
                            {
                                pictureBox6.Image = Image.FromFile(NameAnh7);
                                pictureBox7.Image = null;
                                NameAnh6 = NameAnh7;
                                NameAnh7 = "";
                                Anh6 = Anh7;
                                Anh7 = "";
                            }
                        }
                    }
                    //ảnh 8
                    if (pnpictureBox8.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox8.Image = null;
                        NameAnh8 = "";
                        Anh8 = "";
                        pnpictureBox8.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh8 != "")
                        {
                            if (NameAnh1 == "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "")
                            {
                                pictureBox1.Image = Image.FromFile(NameAnh8);
                                pictureBox8.Image = null;
                                NameAnh1 = NameAnh8;
                                NameAnh8 = "";
                                Anh1 = Anh8;
                                Anh8 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "")
                            {
                                pictureBox2.Image = Image.FromFile(NameAnh8);
                                pictureBox8.Image = null;
                                NameAnh2 = NameAnh8;
                                NameAnh8 = "";
                                Anh2 = Anh8;
                                Anh8 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "")
                            {
                                pictureBox3.Image = Image.FromFile(NameAnh8);
                                pictureBox8.Image = null;
                                NameAnh3 = NameAnh8;
                                NameAnh8 = "";
                                Anh3 = Anh8;
                                Anh8 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "")
                            {
                                pictureBox4.Image = Image.FromFile(NameAnh8);
                                pictureBox8.Image = null;
                                NameAnh4 = NameAnh8;
                                NameAnh8 = "";
                                Anh4 = Anh8;
                                Anh8 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "")
                            {
                                pictureBox5.Image = Image.FromFile(NameAnh8);
                                pictureBox8.Image = null;
                                NameAnh5 = NameAnh8;
                                NameAnh8 = "";
                                Anh5 = Anh8;
                                Anh8 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 != "" && NameAnh6 == "" && NameAnh7 == "")
                            {
                                pictureBox6.Image = Image.FromFile(NameAnh8);
                                pictureBox8.Image = null;
                                NameAnh6 = NameAnh8;
                                NameAnh8 = "";
                                Anh6 = Anh8;
                                Anh8 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 != "" && NameAnh6 != "" && NameAnh7 == "")
                            {
                                pictureBox7.Image = Image.FromFile(NameAnh8);
                                pictureBox8.Image = null;
                                NameAnh7 = NameAnh8;
                                NameAnh8 = "";
                                Anh7 = Anh8;
                                Anh8 = "";
                            }
                        }
                    }
                    //ảnh 9
                    if (pnpictureBox9.BackColor == Color.FromArgb(76, 209, 55))
                    {
                        pictureBox9.Image = null;
                        NameAnh9 = "";
                        Anh9 = "";
                        pnpictureBox9.BackColor = Color.Transparent;
                    }
                    else
                    {
                        if (NameAnh9 != "")
                        {
                            if (NameAnh1 == "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "" && NameAnh8 == "")
                            {
                                pictureBox1.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh1 = NameAnh9;
                                NameAnh9 = "";
                                Anh1 = Anh9;
                                Anh9 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 == "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "" && NameAnh8 == "")
                            {
                                pictureBox2.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh2 = NameAnh9;
                                NameAnh9 = "";
                                Anh2 = Anh9;
                                Anh9 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 == "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "" && NameAnh8 == "")
                            {
                                pictureBox3.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh3 = NameAnh9;
                                NameAnh9 = "";
                                Anh3 = Anh9;
                                Anh9 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 == "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "" && NameAnh8 == "")
                            {
                                pictureBox4.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh4 = NameAnh9;
                                NameAnh9 = "";
                                Anh4 = Anh9;
                                Anh9 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 == "" && NameAnh6 == "" && NameAnh7 == "" && NameAnh8 == "")
                            {
                                pictureBox5.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh5 = NameAnh9;
                                NameAnh9 = "";
                                Anh5 = Anh9;
                                Anh9 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 != "" && NameAnh6 == "" && NameAnh7 == "" && NameAnh8 == "")
                            {
                                pictureBox6.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh6 = NameAnh9;
                                NameAnh9 = "";
                                Anh6 = Anh9;
                                Anh9 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 != "" && NameAnh6 != "" && NameAnh7 == "" && NameAnh8 == "")
                            {
                                pictureBox7.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh7 = NameAnh9;
                                NameAnh9 = "";
                                Anh7 = Anh9;
                                Anh9 = "";
                            }
                            else if (NameAnh1 != "" && NameAnh2 != "" && NameAnh3 != "" && NameAnh4 != "" && NameAnh5 != "" && NameAnh6 != "" && NameAnh7 != "" && NameAnh8 == "")
                            {
                                pictureBox8.Image = Image.FromFile(NameAnh9);
                                pictureBox9.Image = null;
                                NameAnh8 = NameAnh9;
                                NameAnh9 = "";
                                Anh8 = Anh9;
                                Anh9 = "";
                            }
                        }
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnChupAnh_Click(object sender, EventArgs e)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HHmmss.ffff");
            string fileNameChuaSua = DateTime.Now.ToString("yyyy-MM-dd-HHmmss.ffffChuaSua");
            string filePath = Path.Combine(pathImage, fileNameChuaSua + ".jpg");
            cameraControl1.TakeSnapshot().Save(filePath, ImageFormat.Jpeg);

            int DoSang = Int32.Parse(txtDoSang.Text);
            int DoNet = Int32.Parse(txtDoNet.Text);
            //Model.ConvertImage.Imagecv(pathImage, fileName, fileNameChuaSua, DoSang, DoNet);

            if (pictureBox1.Image != null)
            {
                if (pictureBox2.Image != null)
                {
                    if (pictureBox3.Image != null)
                    {
                        if (pictureBox4.Image != null)
                        {
                            //MessageBox.Show("Đã đủ hình");
                            if (pictureBox5.Image != null)
                            {
                                if (pictureBox6.Image != null)
                                {
                                    if (pictureBox7.Image != null)
                                    {
                                        if (pictureBox8.Image != null)
                                        {
                                            if (pictureBox9.Image != null)
                                            {
                                                MessageBox.Show("Đã đủ hình");
                                            }
                                            else
                                            {
                                                pictureBox9.Image = Image.FromFile(pathImage + fileName + ".jpg");
                                                NameAnh9 = pathImage + fileName + ".jpg";
                                                Anh9 = fileName + ".jpg";
                                                pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                                            }
                                        }
                                        else
                                        {
                                            pictureBox8.Image = Image.FromFile(pathImage + fileName + ".jpg");
                                            NameAnh8 = pathImage + fileName + ".jpg";
                                            Anh8 = fileName + ".jpg";
                                            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                                        }
                                    }
                                    else
                                    {
                                        pictureBox7.Image = Image.FromFile(pathImage + fileName + ".jpg");
                                        NameAnh7 = pathImage + fileName + ".jpg";
                                        Anh7 = fileName + ".jpg";
                                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }
                                }
                                else
                                {
                                    pictureBox6.Image = Image.FromFile(pathImage + fileName + ".jpg");
                                    NameAnh6 = pathImage + fileName + ".jpg";
                                    Anh6 = fileName + ".jpg";
                                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                            else
                            {
                                pictureBox5.Image = Image.FromFile(pathImage + fileName + ".jpg");
                                NameAnh5 = pathImage + fileName + ".jpg";
                                Anh5 = fileName + ".jpg";
                                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                            }

                        }
                        else
                        {
                            pictureBox4.Image = Image.FromFile(pathImage + fileName + ".jpg");
                            NameAnh4 = pathImage + fileName + ".jpg";
                            Anh4 = fileName + ".jpg";
                            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        pictureBox3.Image = Image.FromFile(pathImage + fileName + ".jpg");
                        NameAnh3 = pathImage + fileName + ".jpg";
                        Anh3 = fileName + ".jpg";
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pictureBox2.Image = Image.FromFile(pathImage + fileName + ".jpg");
                    NameAnh2 = pathImage + fileName + ".jpg";
                    Anh2 = fileName + ".jpg";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pictureBox1.Image = Image.FromFile(pathImage + fileName + ".jpg");
                NameAnh1 = pathImage + fileName + ".jpg";
                Anh1 = fileName + ".jpg";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        private void GiaiPhauBenh_FormClosing(object sender, FormClosingEventArgs e)
        {
            TiepNhan_Id = "";
        }

        public void SendThongBaoZalo()
        {
            alertControl1.Show(this, "Thông báo", "Kết quả đã được gửi thành công qua zalo!", "");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (CLSKetQua_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Bệnh Nhân!", "");
            }
            else
            {
                LoadThongTinForm();
                LoadThongTinFormButton();
            }
        }

        private void GiaiPhauBenh_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.PageDown)
            {
                btnChupAnh.PerformClick();
            }
            if (e.KeyCode == Keys.PageUp)
            {
                XoaAnhLanLuot();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pnpictureBox1.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox1.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox1.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pnpictureBox2.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox2.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox2.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pnpictureBox3.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox3.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox3.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pnpictureBox4.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox4.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox4.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pnpictureBox5.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox5.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox5.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pnpictureBox6.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox6.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox6.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (pnpictureBox7.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox7.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox7.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (pnpictureBox8.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox8.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox8.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (pnpictureBox9.BackColor == Color.FromArgb(76, 209, 55))
            {
                pnpictureBox9.BackColor = Color.Transparent;
            }
            else
            {
                pnpictureBox9.BackColor = Color.FromArgb(76, 209, 55);
            }
        }

        void selectHinhAnh(string _ClsKetQua)
        {
            ResetHinhAnh();
            DataTable selectHinhAnh = Model.dbGPB.selectHinhAnh(CLSKetQua_Id);
            if (selectHinhAnh != null)
            {
                if (selectHinhAnh.Rows.Count > 0)
                {
                    if (selectHinhAnh.Rows.Count == 1)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (selectHinhAnh.Rows.Count == 2)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (selectHinhAnh.Rows.Count == 3)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox3.Image = Image.FromFile(selectHinhAnh.Rows[2]["Link"].ToString());
                        NameAnh3 = selectHinhAnh.Rows[2]["Link"].ToString();
                        Anh3 = selectHinhAnh.Rows[2]["Name"].ToString();
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (selectHinhAnh.Rows.Count == 4)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox3.Image = Image.FromFile(selectHinhAnh.Rows[2]["Link"].ToString());
                        NameAnh3 = selectHinhAnh.Rows[2]["Link"].ToString();
                        Anh3 = selectHinhAnh.Rows[2]["Name"].ToString();
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox4.Image = Image.FromFile(selectHinhAnh.Rows[3]["Link"].ToString());
                        NameAnh4 = selectHinhAnh.Rows[3]["Link"].ToString();
                        Anh4 = selectHinhAnh.Rows[3]["Name"].ToString();
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (selectHinhAnh.Rows.Count == 5)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox3.Image = Image.FromFile(selectHinhAnh.Rows[2]["Link"].ToString());
                        NameAnh3 = selectHinhAnh.Rows[2]["Link"].ToString();
                        Anh3 = selectHinhAnh.Rows[2]["Name"].ToString();
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox4.Image = Image.FromFile(selectHinhAnh.Rows[3]["Link"].ToString());
                        NameAnh4 = selectHinhAnh.Rows[3]["Link"].ToString();
                        Anh4 = selectHinhAnh.Rows[3]["Name"].ToString();
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox5.Image = Image.FromFile(selectHinhAnh.Rows[4]["Link"].ToString());
                        NameAnh5 = selectHinhAnh.Rows[4]["Link"].ToString();
                        Anh5 = selectHinhAnh.Rows[4]["Name"].ToString();
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (selectHinhAnh.Rows.Count == 6)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox3.Image = Image.FromFile(selectHinhAnh.Rows[2]["Link"].ToString());
                        NameAnh3 = selectHinhAnh.Rows[2]["Link"].ToString();
                        Anh3 = selectHinhAnh.Rows[2]["Name"].ToString();
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox4.Image = Image.FromFile(selectHinhAnh.Rows[3]["Link"].ToString());
                        NameAnh4 = selectHinhAnh.Rows[3]["Link"].ToString();
                        Anh4 = selectHinhAnh.Rows[3]["Name"].ToString();
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox5.Image = Image.FromFile(selectHinhAnh.Rows[4]["Link"].ToString());
                        NameAnh5 = selectHinhAnh.Rows[4]["Link"].ToString();
                        Anh5 = selectHinhAnh.Rows[4]["Name"].ToString();
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox6.Image = Image.FromFile(selectHinhAnh.Rows[5]["Link"].ToString());
                        NameAnh6 = selectHinhAnh.Rows[5]["Link"].ToString();
                        Anh6 = selectHinhAnh.Rows[5]["Name"].ToString();
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    else if (selectHinhAnh.Rows.Count == 7)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox3.Image = Image.FromFile(selectHinhAnh.Rows[2]["Link"].ToString());
                        NameAnh3 = selectHinhAnh.Rows[2]["Link"].ToString();
                        Anh3 = selectHinhAnh.Rows[2]["Name"].ToString();
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox4.Image = Image.FromFile(selectHinhAnh.Rows[3]["Link"].ToString());
                        NameAnh4 = selectHinhAnh.Rows[3]["Link"].ToString();
                        Anh4 = selectHinhAnh.Rows[3]["Name"].ToString();
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox5.Image = Image.FromFile(selectHinhAnh.Rows[4]["Link"].ToString());
                        NameAnh5 = selectHinhAnh.Rows[4]["Link"].ToString();
                        Anh5 = selectHinhAnh.Rows[4]["Name"].ToString();
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox6.Image = Image.FromFile(selectHinhAnh.Rows[5]["Link"].ToString());
                        NameAnh6 = selectHinhAnh.Rows[5]["Link"].ToString();
                        Anh6 = selectHinhAnh.Rows[5]["Name"].ToString();
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox7.Image = Image.FromFile(selectHinhAnh.Rows[6]["Link"].ToString());
                        NameAnh7 = selectHinhAnh.Rows[6]["Link"].ToString();
                        Anh7 = selectHinhAnh.Rows[6]["Name"].ToString();
                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (selectHinhAnh.Rows.Count == 8)
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox3.Image = Image.FromFile(selectHinhAnh.Rows[2]["Link"].ToString());
                        NameAnh3 = selectHinhAnh.Rows[2]["Link"].ToString();
                        Anh3 = selectHinhAnh.Rows[2]["Name"].ToString();
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox4.Image = Image.FromFile(selectHinhAnh.Rows[3]["Link"].ToString());
                        NameAnh4 = selectHinhAnh.Rows[3]["Link"].ToString();
                        Anh4 = selectHinhAnh.Rows[3]["Name"].ToString();
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox5.Image = Image.FromFile(selectHinhAnh.Rows[4]["Link"].ToString());
                        NameAnh5 = selectHinhAnh.Rows[4]["Link"].ToString();
                        Anh5 = selectHinhAnh.Rows[4]["Name"].ToString();
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox6.Image = Image.FromFile(selectHinhAnh.Rows[5]["Link"].ToString());
                        NameAnh6 = selectHinhAnh.Rows[5]["Link"].ToString();
                        Anh6 = selectHinhAnh.Rows[5]["Name"].ToString();
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox7.Image = Image.FromFile(selectHinhAnh.Rows[6]["Link"].ToString());
                        NameAnh7 = selectHinhAnh.Rows[6]["Link"].ToString();
                        Anh7 = selectHinhAnh.Rows[6]["Name"].ToString();
                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox8.Image = Image.FromFile(selectHinhAnh.Rows[7]["Link"].ToString());
                        NameAnh8 = selectHinhAnh.Rows[7]["Link"].ToString();
                        Anh8 = selectHinhAnh.Rows[7]["Name"].ToString();
                        pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox1.Image = Image.FromFile(selectHinhAnh.Rows[0]["Link"].ToString());
                        NameAnh1 = selectHinhAnh.Rows[0]["Link"].ToString();
                        Anh1 = selectHinhAnh.Rows[0]["Name"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox2.Image = Image.FromFile(selectHinhAnh.Rows[1]["Link"].ToString());
                        NameAnh2 = selectHinhAnh.Rows[1]["Link"].ToString();
                        Anh2 = selectHinhAnh.Rows[1]["Name"].ToString();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox3.Image = Image.FromFile(selectHinhAnh.Rows[2]["Link"].ToString());
                        NameAnh3 = selectHinhAnh.Rows[2]["Link"].ToString();
                        Anh3 = selectHinhAnh.Rows[2]["Name"].ToString();
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox4.Image = Image.FromFile(selectHinhAnh.Rows[3]["Link"].ToString());
                        NameAnh4 = selectHinhAnh.Rows[3]["Link"].ToString();
                        Anh4 = selectHinhAnh.Rows[3]["Name"].ToString();
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox5.Image = Image.FromFile(selectHinhAnh.Rows[4]["Link"].ToString());
                        NameAnh5 = selectHinhAnh.Rows[4]["Link"].ToString();
                        Anh5 = selectHinhAnh.Rows[4]["Name"].ToString();
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox6.Image = Image.FromFile(selectHinhAnh.Rows[5]["Link"].ToString());
                        NameAnh6 = selectHinhAnh.Rows[5]["Link"].ToString();
                        Anh6 = selectHinhAnh.Rows[5]["Name"].ToString();
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox7.Image = Image.FromFile(selectHinhAnh.Rows[6]["Link"].ToString());
                        NameAnh7 = selectHinhAnh.Rows[6]["Link"].ToString();
                        Anh7 = selectHinhAnh.Rows[6]["Name"].ToString();
                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox8.Image = Image.FromFile(selectHinhAnh.Rows[7]["Link"].ToString());
                        NameAnh8 = selectHinhAnh.Rows[7]["Link"].ToString();
                        Anh8 = selectHinhAnh.Rows[7]["Name"].ToString();
                        pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox9.Image = Image.FromFile(selectHinhAnh.Rows[8]["Link"].ToString());
                        NameAnh9 = selectHinhAnh.Rows[8]["Link"].ToString();
                        Anh9 = selectHinhAnh.Rows[8]["Name"].ToString();
                        pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                //
            }
        }
        public void XoaAnhLanLuot()
        {
            //ảnh 9
            if (pictureBox9.Image != null)
            {
                pictureBox9.Image = null;
                NameAnh9 = "";
                Anh9 = "";
                pnpictureBox9.BackColor = Color.Transparent;
            }
            else
            {
                //ảnh 8
                if (pictureBox8.Image != null)
                {
                    pictureBox8.Image = null;
                    NameAnh8 = "";
                    Anh8 = "";
                    pnpictureBox8.BackColor = Color.Transparent;
                }
                else
                {
                    //ảnh 7
                    if (pictureBox7.Image != null)
                    {
                        pictureBox7.Image = null;
                        NameAnh7 = "";
                        Anh7 = "";
                        pnpictureBox7.BackColor = Color.Transparent;
                    }
                    else
                    {
                        //ảnh 6
                        if (pictureBox6.Image != null)
                        {
                            pictureBox6.Image = null;
                            NameAnh6 = "";
                            Anh6 = "";
                            pnpictureBox6.BackColor = Color.Transparent;
                        }
                        else
                        {
                            //ảnh 5
                            if (pictureBox5.Image != null)
                            {
                                pictureBox5.Image = null;
                                NameAnh5 = "";
                                Anh5 = "";
                                pnpictureBox5.BackColor = Color.Transparent;
                            }
                            else
                            {
                                //ảnh 4
                                if (pictureBox4.Image != null)
                                {
                                    pictureBox4.Image = null;
                                    NameAnh4 = "";
                                    Anh4 = "";
                                    pnpictureBox4.BackColor = Color.Transparent;
                                }
                                else
                                {
                                    //ảnh 3
                                    if (pictureBox3.Image != null)
                                    {
                                        pictureBox3.Image = null;
                                        NameAnh3 = "";
                                        Anh3 = "";
                                        pnpictureBox3.BackColor = Color.Transparent;
                                    }
                                    else
                                    {
                                        //ảnh 2
                                        if (pictureBox2.Image != null)
                                        {
                                            pictureBox2.Image = null;
                                            NameAnh2 = "";
                                            Anh2 = "";
                                            pnpictureBox2.BackColor = Color.Transparent;
                                        }
                                        else
                                        {
                                            //ảnh 1
                                            if (pictureBox1.Image != null)
                                            {
                                                pictureBox1.Image = null;
                                                NameAnh1 = "";
                                                Anh1 = "";
                                                pnpictureBox1.BackColor = Color.Transparent;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //
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