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

namespace KClinic2._1.View.KhamBenh
{
    public partial class HangDoiKhamBenh : DevExpress.XtraEditors.XtraForm
    {

        public HangDoiKhamBenh()
        {
            InitializeComponent();
        }
       

        private void HangDoiKhamBenh_Load(object sender, EventArgs e)
        {
            lbDangKham.Text = "";
            lb01.Text = "";
            lb02.Text = "";
            lb03.Text = "";
            lb04.Text = "";
            lb05.Text = "";
            DataTable HangDoiBenhNhanKhamBenh = Model.dbKhamBenh.HangDoiBenhNhanKhamBenh();
            if (HangDoiBenhNhanKhamBenh != null)
            {
                if (HangDoiBenhNhanKhamBenh.Rows.Count == 1)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 2)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 3)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";

                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 4)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";
                    lb03.Text = HangDoiBenhNhanKhamBenh.Rows[3]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[3]["Tuoi"].ToString() + " tuổi";
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 5)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";
                    lb03.Text = HangDoiBenhNhanKhamBenh.Rows[3]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[3]["Tuoi"].ToString() + " tuổi";
                    lb04.Text = HangDoiBenhNhanKhamBenh.Rows[4]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[4]["Tuoi"].ToString() + " tuổi";
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 6)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";
                    lb03.Text = HangDoiBenhNhanKhamBenh.Rows[3]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[3]["Tuoi"].ToString() + " tuổi";
                    lb04.Text = HangDoiBenhNhanKhamBenh.Rows[4]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[4]["Tuoi"].ToString() + " tuổi";
                    lb05.Text = HangDoiBenhNhanKhamBenh.Rows[5]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[5]["Tuoi"].ToString() + " tuổi";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDangKham.Text = "";
            lb01.Text = "";
            lb02.Text = "";
            lb03.Text = "";
            lb04.Text = "";
            lb05.Text = "";
            DataTable HangDoiBenhNhanKhamBenh = Model.dbKhamBenh.HangDoiBenhNhanKhamBenh();
            if (HangDoiBenhNhanKhamBenh != null)
            {
                if (HangDoiBenhNhanKhamBenh.Rows.Count == 1)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 2)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 3)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";

                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 4)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";
                    lb03.Text = HangDoiBenhNhanKhamBenh.Rows[3]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[3]["Tuoi"].ToString() + " tuổi";
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 5)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";
                    lb03.Text = HangDoiBenhNhanKhamBenh.Rows[3]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[3]["Tuoi"].ToString() + " tuổi";
                    lb04.Text = HangDoiBenhNhanKhamBenh.Rows[4]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[4]["Tuoi"].ToString() + " tuổi";
                }
                else if (HangDoiBenhNhanKhamBenh.Rows.Count == 6)
                {
                    lbDangKham.Text = HangDoiBenhNhanKhamBenh.Rows[0]["TenBenhNhan"].ToString();
                    lb01.Text = HangDoiBenhNhanKhamBenh.Rows[1]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[1]["Tuoi"].ToString() + " tuổi";
                    lb02.Text = HangDoiBenhNhanKhamBenh.Rows[2]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[2]["Tuoi"].ToString() + " tuổi";
                    lb03.Text = HangDoiBenhNhanKhamBenh.Rows[3]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[3]["Tuoi"].ToString() + " tuổi";
                    lb04.Text = HangDoiBenhNhanKhamBenh.Rows[4]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[4]["Tuoi"].ToString() + " tuổi";
                    lb05.Text = HangDoiBenhNhanKhamBenh.Rows[5]["TenBenhNhan"].ToString() + " - " + HangDoiBenhNhanKhamBenh.Rows[5]["Tuoi"].ToString() + " tuổi";
                }
            }
        }
    }
}