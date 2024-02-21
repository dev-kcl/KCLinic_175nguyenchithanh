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
using System.Net.Mail;
using System.Net;

namespace KClinic2._1.View.HeThong
{
    public partial class ReportError : DevExpress.XtraEditors.XtraForm
    {
        public string pathImage = System.Configuration.ConfigurationManager.AppSettings["pathImage"];
        public string DM_Id;
        public string ThaoTac;
        public ReportError()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTieuDe.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tiêu đề mẫu không được để trống!", "");
            }
            else if (txtNoiDung.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Nội dung không được để trống!", "");
            }
            else
            {
                string TieuDe = "N'" + txtTieuDe.Text.Replace("'", "''") + "'";
                string NoiDung = "null"; if (txtNoiDung.Document.Text != "") { NoiDung = "N'" + txtNoiDung.Document.HtmlText.Replace("'", "''") + "'"; }
                string NoiDungText = "null"; if (txtNoiDung.Document.Text != "") { NoiDungText = "N'" + txtNoiDung.Document.Text.Replace("'", "''") + "'"; }

                DataTable Insert = Model.db.InsertNoiDungEmail(
                        TieuDe
                        , NoiDung
                        , NoiDungText
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        );
                if (Insert.Rows.Count > 0)
                {
                    DM_Id = Insert.Rows[0]["NoiDungMail_Id"].ToString();
                    DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                    //insert hình ảnh
                    DataTable DeleteHinhAnhMail = Model.db.DeleteHinhAnhMail(DM_Id);
                    if (NameAnh1 != "")
                    {
                        if (NameAnh1.Replace("\\", @"\") != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh1)
                        {
                            pictureBox1.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh1);
                        }
                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh1 + "'", "N'" + Anh1 + "'");
                    }
                    if (NameAnh2 != "")
                    {
                        if (NameAnh2 != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh2)
                        {
                            pictureBox2.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh2);
                        }

                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh2 + "'", "N'" + Anh2 + "'");
                    }
                    if (NameAnh3 != "")
                    {
                        if (NameAnh3 != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh3)
                        {
                            pictureBox3.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh3);
                        }
                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh3 + "'", "N'" + Anh3 + "'");
                    }
                    if (NameAnh4 != "")
                    {
                        if (NameAnh4 != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh4)
                        {
                            pictureBox4.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh4);
                        }
                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh4 + "'", "N'" + Anh4 + "'");
                    }
                    if (NameAnh5 != "")
                    {
                        if (NameAnh5 != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh5)
                        {
                            pictureBox5.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh5);
                        }
                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh5 + "'", "N'" + Anh5 + "'");
                    }
                    if (NameAnh6 != "")
                    {
                        if (NameAnh6 != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh6)
                        {
                            pictureBox6.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh6);
                        }
                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh6 + "'", "N'" + Anh6 + "'");
                    }
                    if (NameAnh7 != "")
                    {
                        if (NameAnh7 != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh7)
                        {
                            pictureBox7.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh7);
                        }
                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh7 + "'", "N'" + Anh7 + "'");
                    }
                    if (NameAnh8 != "")
                    {
                        if (NameAnh8 != DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh8)
                        {
                            pictureBox8.Image.Save(DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh8);
                        }
                        DataTable InsertHinhAnh = Model.db.InsertHinhAnhMail(DM_Id, "N'" + DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh8 + "'", "N'" + Anh8 + "'");
                    }
                    DataTable Email = Model.db.Email();
                    if (Email != null)
                    {
                        if (Email.Rows.Count > 0)
                        {
                            sendMail_UseGmail(Email.Rows[0]["Email"].ToString(), Email.Rows[0]["MKUD"].ToString(), Email.Rows[1]["Email"].ToString(), txtTieuDe.Text, txtNoiDung.Document.HtmlText
                                , DuongDanHinhAnh.Rows[0]["DuongDan"].ToString() + Anh1
                                );
                        }
                    }
                    
                    alertControl1.Show(this, "Thông báo", "Đã Gửi phản hồi: " + Insert.Rows[0]["TieuDe"].ToString() +" thành công! ", "");
                }
                //
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                An();
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
                DM_Id = "";
            }
            else if (ThaoTac == "Sua")
            {
                btnThem.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportError_Load(object sender, EventArgs e)
        {
            An();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            Hien();
            ThaoTac = "Them";
            DM_Id = "";
            Reset();
            txtTieuDe.Focus();
        }
        public void Hien()
        {
            txtNoiDung.Enabled = true;
            txtTieuDe.Enabled = true;
            btnChonAnh.Enabled = true;
            btnXoaAnh.Enabled = true;
        }
        public void An()
        {
            txtNoiDung.Enabled = false;
            txtTieuDe.Enabled = false;
            btnChonAnh.Enabled = false;
            btnXoaAnh.Enabled = false;
        }
        public void Reset()
        {
            txtNoiDung.Text = "";
            txtTieuDe.Text = "";
        }

        public static string NameAnh1 = "", NameAnh2 = "", NameAnh3 = "", NameAnh4 = "", NameAnh5 = "", NameAnh6 = "", NameAnh7 = "", NameAnh8 = "";

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

        private void pnpictureBox2_Click(object sender, EventArgs e)
        {
            
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

        string Anh1 = "", Anh2 = "", Anh3 = "", Anh4 = "", Anh5 = "", Anh6 = "", Anh7 = "", Anh8 = "";

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
                    break;
                case DialogResult.No:
                    break;
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
                                                    MessageBox.Show("Đã đủ hình");
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
        public static bool sendMail_UseGmail(string strFrom, string strFromMKUD,string strTo, string strSubject, string strBody, string attachmentIMG)
        {
            MailMessage ms = new MailMessage(strFrom, strTo, strSubject, strBody);

            ms.BodyEncoding = System.Text.Encoding.UTF8;
            ms.SubjectEncoding = System.Text.Encoding.UTF8;
            if (NameAnh1 != "")
            {
                Attachment attachment = new Attachment(NameAnh1);
                ms.Attachments.Add(attachment);
            }
            if (NameAnh2 != "")
            {
                Attachment attachment = new Attachment(NameAnh2);
                ms.Attachments.Add(attachment);
            }
            if (NameAnh3 != "")
            {
                Attachment attachment = new Attachment(NameAnh3);
                ms.Attachments.Add(attachment);
            }
            if (NameAnh4 != "")
            {
                Attachment attachment = new Attachment(NameAnh4);
                ms.Attachments.Add(attachment);
            }
            if (NameAnh5 != "")
            {
                Attachment attachment = new Attachment(NameAnh5);
                ms.Attachments.Add(attachment);
            }
            if (NameAnh6 != "")
            {
                Attachment attachment = new Attachment(NameAnh6);
                ms.Attachments.Add(attachment);
            }
            if (NameAnh7 != "")
            {
                Attachment attachment = new Attachment(NameAnh7);
                ms.Attachments.Add(attachment);
            }
            if (NameAnh8 != "")
            {
                Attachment attachment = new Attachment(NameAnh8);
                ms.Attachments.Add(attachment);
            }
            
            ms.IsBodyHtml = true;

            //ms.ReplyTo = new MailAddress("cnttbenhvienungbuoudanang@gmail.com");
            ms.Sender = new MailAddress(strFrom);

            SmtpClient SmtpMail = new SmtpClient("smtp.gmail.com", 587);
            SmtpMail.Credentials = new NetworkCredential(strFrom, strFromMKUD);
            SmtpMail.EnableSsl = true;

            try
            {
                SmtpMail.Send(ms);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}