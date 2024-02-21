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
using System.Net;
using System.Net.Sockets;

namespace KClinic2._1.View.TiepNhan
{
    public partial class ManHinhHangDoi : DevExpress.XtraEditors.XtraForm
    {
        Model.UDPSocket s;
        string PhienKetNoi_Id;
        public string PhongBan_Id;
        public string token;
        public ManHinhHangDoi()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Location = new Point(1400, 0);
            this.WindowState = FormWindowState.Maximized;
        }

        private void ManHinhHangDoi_Load(object sender, EventArgs e)
        {
            //Thêm phiên đăng nhập
            string host = Dns.GetHostName();
            string ipadd = "";
            var hostk = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in hostk.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipadd = ip.ToString();
                }
            }
            //Model.UDPSocket s = new Model.UDPSocket();
            s = new Model.UDPSocket();
            s.Server(ipadd, 27000);

            DataTable ThemPhienKetNoi = Model.dbManHinhHangDoi.ThemPhienKetNoi(
                "N'ManHinhKhamBenh'"
                , "N'" + ipadd + "'"
                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                , "null"
                , "0"
                , "0"
                , Login.User_Id
                );
            PhienKetNoi_Id = ThemPhienKetNoi.Rows[0]["PhienKetNoi_Id"].ToString();

            LoadManHinhChoKham();
            LoadSTTDangKham(PhongBan_Id);
            FieldName();
            MainTime.Start();
            //ChayChu();
            //timerChayChu.Start();
        }
        DataTable CheckBenhNhanKhamBenh;
        void getCheckBenhNhanKhamBenh()
        {
            CheckBenhNhanKhamBenh = Model.dbKhamBenh.CheckBenhNhanKhamBenh();
        }
        public void FieldName()
        {
            DataTable Load_FieldName = Model.dbManHinhHangDoi.Field();
            lbKhachHangDangPhucVu.Text = Load_FieldName.Select("FieldType = 'lbKhachHangDangPhucVu'")[0]["FieldName"].ToString();
            lbSTTChoKham.Text = Load_FieldName.Select("FieldType = 'lbSTTChoKham'")[0]["FieldName"].ToString();
            lbTenBenhNhanChoKham.Text = Load_FieldName.Select("FieldType = 'lbTenBenhNhanChoKham'")[0]["FieldName"].ToString();
            lbTenBenhVien.Text = Load_FieldName.Select("FieldType = 'lbTenBenhVien'")[0]["FieldName"].ToString();
            lbSTTChoLayKetQua.Text = Load_FieldName.Select("FieldType = 'lbSTTChoLayKetQua'")[0]["FieldName"].ToString();
            //lbBenhNhanChoKetQua.Text = Load_FieldName.Select("FieldType = 'lbBenhNhanChoKetQua'")[0]["FieldName"].ToString();

            DataTable Token = Model.dbManHinhHangDoi.Token();
            token = "";
            if (Token != null)
            {
                if (Token.Rows.Count > 0)
                {
                    token = Token.Rows[0]["token"].ToString();
                }
            }
        }
        public void LoadManHinhChoKham()
        {
            DataTable ManHinhChoKham = Model.dbManHinhHangDoi.ManHinhChoKham();
            if (ManHinhChoKham != null)
            {
                if (ManHinhChoKham.Rows.Count > 0)
                {
                    txtSTT01.Text = "001";
                    txtSTT02.Text = "002";
                    txtSTT03.Text = "003";
                    txtSTT04.Text = "004";
                    txtSTT05.Text = "005";
                    txtSTT06.Text = "006";
                    //txtSTT07.Text = ManHinhChoKham.Rows[6]["STT"].ToString();
                    //txtSTT08.Text = ManHinhChoKham.Rows[7]["STT"].ToString();
                    txtTenBenhNhan01.Text = ManHinhChoKham.Rows[0]["TENBENHNHAN"].ToString();
                    txtTenBenhNhan02.Text = ManHinhChoKham.Rows[1]["TENBENHNHAN"].ToString();
                    txtTenBenhNhan03.Text = ManHinhChoKham.Rows[2]["TENBENHNHAN"].ToString();
                    txtTenBenhNhan04.Text = ManHinhChoKham.Rows[3]["TENBENHNHAN"].ToString();
                    txtTenBenhNhan05.Text = ManHinhChoKham.Rows[4]["TENBENHNHAN"].ToString();
                    txtTenBenhNhan06.Text = ManHinhChoKham.Rows[5]["TENBENHNHAN"].ToString();
                   
                }
            }
        }
        public void LoadSTTDangKham(string _PhongBan_Id)
        {
            DataTable ShowSTTDaKhamLoad = Model.dbManHinhHangDoi.ShowSTTDaKhamLoad(_PhongBan_Id);
            if (ShowSTTDaKhamLoad != null)
            {
                if (ShowSTTDaKhamLoad.Rows.Count > 0)
                {
                    txtBenhNhanDangKham.Text = ShowSTTDaKhamLoad.Rows[0]["STT"].ToString() + " - " + ShowSTTDaKhamLoad.Rows[0]["TENBENHNHAN"].ToString();
                }
                else
                {
                    txtBenhNhanDangKham.Text = "";
                }
            }
            else
            {
                txtBenhNhanDangKham.Text = "";
            }
        }
       
       
        private void MainTime_Tick(object sender, EventArgs e)
        {
            //
            s.SMS();
            if (s.BienSendSMS != "")
            {
                if (s.BienSendSMS == "0")
                {
                    LoadManHinhChoKham();
                    LoadSTTDangKham(PhongBan_Id);
                    ChayChu();
                    s.BienSendSMS = "";
                }
                else
                {
                    LoadManHinhChoKham();
                    ChayChu();
                    DataTable ShowSTTVuaGoiKhamBenh = Model.dbManHinhHangDoi.ShowSTTVuaGoiKhamBenh(s.BienSendSMS);
                    if (ShowSTTVuaGoiKhamBenh != null)
                    {
                        if (ShowSTTVuaGoiKhamBenh.Rows.Count > 0)
                        {
                            txtBenhNhanDangKham.Text = ShowSTTVuaGoiKhamBenh.Rows[0]["STT"].ToString() + " - " + ShowSTTVuaGoiKhamBenh.Rows[0]["TENBENHNHAN"].ToString();
                            string STT = ShowSTTVuaGoiKhamBenh.Rows[0]["STT"].ToString();
                            string Quay = ShowSTTVuaGoiKhamBenh.Rows[0]["STTPhongKham"].ToString();
                            string TenBenhNhan = ShowSTTVuaGoiKhamBenh.Rows[0]["TENBENHNHAN"].ToString();
                            //Mời Bệnh Nhân
                            if (KhamBenh.KhamBenh.BienSetGoi == "0")
                            {
                                Model.Sounds.MBNS();
                                Model.Sounds.SoundSTT(STT.Substring(0, 1));
                                Model.Sounds.SoundSTT(STT.Substring(1, 1));
                                Model.Sounds.SoundSTT(STT.Substring(2, 1));
                                Model.Sounds.SoundSTT(STT.Substring(3, 1));
                                Model.Sounds.VPKS();
                                Model.Sounds.SoundSTT(Quay);
                                s.BienSendSMS = "";
                            }
                            else if (KhamBenh.KhamBenh.BienSetGoi == "2")
                            {
                                string TenQuay = ShowSTTVuaGoiKhamBenh.Rows[0]["TenPhongKham"].ToString();

                                //byte[] result = Model.API.postVoice(token, "Mời bệnh nhân số, " + STT + ", " + TenBenhNhan + ", vào " + TenQuay + Quay);
                                byte[] result = Model.API.postVoice(token, "Mời bệnh nhân số, " + STT.Substring(0, 1) + " " + STT.Substring(1, 1) + " " + STT.Substring(2, 1) + " " + STT.Substring(3, 1) + ", " + TenBenhNhan + ", vào Phòng khám số, " + Quay);
                                Model.Sounds.GoiTen(result);

                                s.BienSendSMS = "";
                            }
                            else
                            {
                                Model.Sounds.dingdong();
                                s.BienSendSMS = "";
                            }
                        }
                        else { LoadSTTDangKham(PhongBan_Id); }
                    }
                    else { LoadSTTDangKham(PhongBan_Id); }
                }
            }
        }

        private void ManHinhHangDoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainTime.Stop();
            timerChayChu.Stop();
            s.Close();
            //SqlDependency.Stop(sql);
            DataTable KetThucPhienKetNoi = Model.dbManHinhHangDoi.KetThucPhienKetNoi(
                "N'ManHinhKhamBenh'"
                , "null"
                , "null"
                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                , "1"
                , "0"
                , Login.User_Id
                , PhienKetNoi_Id
                );
        }
        private int xpos;
        private int ypos = 5;
        public string mode = "Right-to-Left";
        public void ChayChu()
        {
            DataTable ManHinhChoKhamChayChu = Model.dbManHinhHangDoi.ManHinhChoKhamChayChu(PhongBan_Id);
            txtChayChu.Text = ManHinhChoKhamChayChu.Rows[0]["FieldText"].ToString();
            if (txtChayChu.Text == "Tiếp theo trong hàng chờ: ") { txtChayChu.Text = ""; }
            xpos = -(txtChayChu.DisplayRectangle.Width);
        }
        private void timerChayChu_Tick(object sender, EventArgs e)
        {
            int innn = -(txtChayChu.DisplayRectangle.Width);
            //label5.Text = innn.ToString();
            if (mode == "Left-to-Right")
            {
                if (this.Width == xpos)
                {
                    this.txtChayChu.Location = new System.Drawing.Point(0, ypos);
                    xpos = 0;
                }
                else
                {
                    this.txtChayChu.Location = new System.Drawing.Point(xpos, ypos);
                    xpos += 2;
                }

            }
            else if (mode == "Right-to-Left")
            {
                if (xpos <= innn)
                {
                    this.txtChayChu.Location = new System.Drawing.Point(this.Width, ypos);
                    xpos = this.Width;
                }
                else
                {
                    this.txtChayChu.Location = new System.Drawing.Point(xpos, ypos);
                    xpos -= 6;
                }
            }
        }
        public void SetBenhNhanDangKham(string TenBenhNhan)
        {
            txtBenhNhanDangKham.Text = TenBenhNhan;
        }
       
    }
}