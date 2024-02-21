using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace KClinic2._1.Model
{
    class Sounds
    {
        public static void MBNS()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "MoiBenhNhanSo.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(1400);
        }
        public static void SoundSTT(string _So)
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            switch (_So)
            {
                case "0":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "0.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "1":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "1.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "2":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "2.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "3":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "3.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "4":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "4.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "5":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "5.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "6":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "6.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "7":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "7.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "8":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "8.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
                case "9":
                    new System.Threading.Thread(() =>
                    {
                        WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                        p2.URL = @"" + DuongDan + "9.wav";
                        p2.controls.play();
                    }).Start();
                    //sound.Play();
                    System.Threading.Thread.Sleep(700);
                    //
                    break;
            }
        }
        public static void DQDKKB()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p1 = new WindowsMediaPlayer();
                p1.URL = @"" + DuongDan + "DenQuayDangKyKhamBenh.wav";
                p1.controls.play();
            }).Start();
            System.Threading.Thread.Sleep(1800);
        }
        public static void VPKS()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p1 = new WindowsMediaPlayer();
                p1.URL = @"" + DuongDan + "VaoPhongKhamSo.wav";
                p1.controls.play();
            }).Start();
            System.Threading.Thread.Sleep(1800);
        }
        public static void DQTTS()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p1 = new WindowsMediaPlayer();
                p1.URL = @"" + DuongDan + "VaoQuayThuVienPhiSo.wav";
                p1.controls.play();
            }).Start();
            System.Threading.Thread.Sleep(2000);
        }
        public static void dingdong()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "dingdong.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(1300);
        }
        public static void VaoPhongSieuAmSo()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoPhongSieuAmSo.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(1900);
        }
        public static void VaoPhongXQuangSo()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoPhongXQuangSo.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(2000);
        }
        public static void VaoPhongNoiSoiSo()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoPhongNoiSoiSo.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(1800);
        }
        public static void VaoPhongLayMauXetNghiemSo()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoPhongLayMauXetNghiemSo.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(2500);
        }
        public static void VaoPhongCTSo()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoPhongCTSo.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(1800);
        }
        public static void VaoPhongDoLoangXuong()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoPhongDoLoangXuong.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(2000);
        }
        public static void VaoPhongDienTim()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoPhongDienTim.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(1800);
        }
        public static void VaoNhaThuocSo()
        {
            string DuongDan = "";
            DataTable DuongDanAmThanh = Model.dbManHinhHangDoi.DuongDanAmThanh();
            if (DuongDanAmThanh != null)
            {
                if (DuongDanAmThanh.Rows.Count > 0)
                {
                    DuongDan = DuongDanAmThanh.Rows[0][0].ToString();
                }
            }
            new System.Threading.Thread(() =>
            {
                WindowsMediaPlayer p2 = new WindowsMediaPlayer();
                p2.URL = @"" + DuongDan + "VaoNhaThuocSo.wav";
                p2.controls.play();
            }).Start();
            //
            System.Threading.Thread.Sleep(1800);
        }
        public static void GoiTen(Byte[] _Url)
        {
            using (Stream s = new MemoryStream(_Url))
            {
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer(s);
                myPlayer.Play();
            }
        }
    }
}
