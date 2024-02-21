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

namespace LaucherKCLinic
{
    public partial class Laucher : DevExpress.XtraEditors.XtraForm
    {
        public static string pathFolderUpdate = System.Configuration.ConfigurationManager.AppSettings["pathFolderUpdate"];
        public static string pathPublicVersion = System.Configuration.ConfigurationManager.AppSettings["pathPublicVersion"];

        public Laucher()
        {
            InitializeComponent();
        }

        private void Laucher_Shown(object sender, EventArgs e)
        {
            DoProcessingCP();
            string Dir = System.IO.Directory.GetCurrentDirectory();
            string a = Dir + @"\KCLinic2.1.exe";
            System.Diagnostics.Process.Start(a);
            this.Hide();
            this.Close();
        }
        public void DoProcessingCP()
        {
            string pathFolder = pathFolderUpdate;//@"\\113.160.226.24\qlpk\Update\Public";
            string copyFolder = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo d = new DirectoryInfo(pathFolder);
            FileInfo[] Files = d.GetFiles();

            progressBar1.Minimum = 0; //Đặt giá trị nhỏ nhất cho ProgressBar
            progressBar1.Maximum = Files.Length; //Đặt giá trị lớn nhất cho ProgressBar
            int i = 0;
            foreach (FileInfo file in Files)
            {
                progressBar1.Value = i + 1;
                string sourceFile = pathFolder + @"\" + file.Name;
                string copyFile = copyFolder + @"\" + file.Name;
                try
                {
                    System.IO.File.Copy(sourceFile, copyFile, true);
                }
                catch (IOException iox)
                {
                    MessageBox.Show(iox.Message);
                }
                i = i + 1;
            }

        }
        
        private void Laucher_Load(object sender, EventArgs e)
        {
            System.Xml.XmlDocument VersionInfo = new System.Xml.XmlDocument();
            VersionInfo.Load(pathPublicVersion);//Load(@"\\113.160.226.24\qlpk\Update\PublicVersion.xml");
            label1.Text = "Updating version: " + VersionInfo.SelectSingleNode("//latestversion").InnerText + " ...";
        }
    }
}