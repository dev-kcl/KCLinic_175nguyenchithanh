using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace KClinic2._1.View.ChanDoanHinhAnh
{
    public partial class Camera : Form
    {
        ChanDoanHinhAnh tn;
       public static string NameAnh1 = "", NameAnh2 = "", NameAnh3 = "", NameAnh4 = "", NameAnh5 = "", NameAnh6 = "", NameAnh7 = "", NameAnh8 = "", NameAnh9 = "";

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        public static string Anh1 = "", Anh2 = "", Anh3 = "", Anh4 = "", Anh5 = "", Anh6 = "", Anh7 = "", Anh8 = "", Anh9 = "";

        public Camera(ChanDoanHinhAnh tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void Camera_Load(object sender, EventArgs e)
        {

        }

        private void btnChupAnh_Click(object sender, EventArgs e)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HHmmss.ffff");
            string filePath = Path.Combine(tn.pathImage, fileName + ".jpg");
            cameraControl1.TakeSnapshot().Save(filePath, ImageFormat.Jpeg);
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
                                                pictureBox9.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                                                NameAnh9 = tn.pathImage + fileName + ".jpg";
                                                Anh9 = fileName + ".jpg";
                                                pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                                            }
                                        }
                                        else
                                        {
                                            pictureBox8.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                                            NameAnh8 = tn.pathImage + fileName + ".jpg";
                                            Anh8 = fileName + ".jpg";
                                            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                                        }
                                    }
                                    else
                                    {
                                        pictureBox7.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                                        NameAnh7 = tn.pathImage + fileName + ".jpg";
                                        Anh7 = fileName + ".jpg";
                                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }
                                }
                                else
                                {
                                    pictureBox6.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                                    NameAnh6 = tn.pathImage + fileName + ".jpg";
                                    Anh6 = fileName + ".jpg";
                                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                            else
                            {
                                pictureBox5.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                                NameAnh5 = tn.pathImage + fileName + ".jpg";
                                Anh5 = fileName + ".jpg";
                                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                            }

                        }
                        else
                        {
                            pictureBox4.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                            NameAnh4 = tn.pathImage + fileName + ".jpg";
                            Anh4 = fileName + ".jpg";
                            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        pictureBox3.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                        NameAnh3 = tn.pathImage + fileName + ".jpg";
                        Anh3 = fileName + ".jpg";
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pictureBox2.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                    NameAnh2 = tn.pathImage + fileName + ".jpg";
                    Anh2 = fileName + ".jpg";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pictureBox1.Image = Image.FromFile(tn.pathImage + fileName + ".jpg");
                NameAnh1 = tn.pathImage + fileName + ".jpg";
                Anh1 = fileName + ".jpg";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            tn.LoadHinhAnh();
            
        }

    }
 }

