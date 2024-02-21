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
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace KClinic2._1
{
    public partial class Laucher : DevExpress.XtraEditors.XtraForm
    {
        public static string pathPublicVersion = System.Configuration.ConfigurationManager.AppSettings["pathPublicVersion"];
        public Laucher()
        {
            InitializeComponent();
        }

        private void Laucher_Load(object sender, EventArgs e)
        {
            System.Xml.XmlDocument VersionInfo = new System.Xml.XmlDocument();
            //VersionInfo.LoadXml(GetWebPage("\\113.160.226.24\qlpk\Update\UpdateCheck.xml"));
            //VersionInfo.Load(@"\\113.160.226.24\qlpk\Update\PublicVersion.xml");
            VersionInfo.Load(pathPublicVersion);

            System.Xml.XmlDocument VersionPrivate = new System.Xml.XmlDocument();
            VersionPrivate.Load(System.IO.Directory.GetCurrentDirectory() + @"\PrivateVersion.xml");

            labelControl1.Text = "Updating Latest Version:  " + (VersionInfo.SelectSingleNode("//latestversion").InnerText);
            string version = VersionPrivate.SelectSingleNode("//latestversion").InnerText;
            string PublicVersion = VersionInfo.SelectSingleNode("//latestversion").InnerText;

            if (PublicVersion != version)
            {
                //System.Diagnostics.Process.Start(@"C:\Program Files (x86)\KCL\KClinic\LaucherKCLinic.exe");
                string Dir = System.IO.Directory.GetCurrentDirectory();
                //if (File.Exists(Dir))
                //{
                //    Process.Start("LaucherKCLinic.exe", "/select, " + Dir);
                //}
                string a = Dir + @"\LaucherKCLinic.exe";
                System.Diagnostics.Process.Start(a);
                this.Hide();
                this.Close();
            }
            else
            {
                Login frm = new Login();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }
        
    }
}