using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaucherKCLinic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var progress = new Progress<int>(percent =>
            //{
            //    progressBar1.Value = percent;

            //});
            //await Task.Run(() => DoProcessingCP(progress));
            //string Dir = System.IO.Directory.GetCurrentDirectory();
            //string a = Dir + @"\KCLinic2.1.exe";
            //System.Diagnostics.Process.Start(a);
            //this.Hide();
            //this.Close();
        }
        //public void DoProcessing(IProgress<int> progress)
        //{
        //    for (int i = 0; i != 100; ++i)
        //    {
        //        if (i == 50) { copyFile(); }
        //        if (i == 99) { copySetup(); }
        //        //if (i == 90) { System.Diagnostics.Process.Start(@"C:\Users\Public\Downloads\setup.msi"); }
        //        //if (i == 90) { timer1.Start(); }
        //        Thread.Sleep(100);
        //        if (progress != null)
        //            progress.Report(i);
        //    }
        //}

        //public void DoProcessingCP()
        //{
        //    string pathFolder = @"\\10.0.2.58\qlpk\Update\Public";
        //    string copyFolder = @"C:\Users\Public\Downloads";
        //    DirectoryInfo d = new DirectoryInfo(pathFolder);
        //    FileInfo[] Files = d.GetFiles();

        //    progressBar1.Minimum = 0; //Đặt giá trị nhỏ nhất cho ProgressBar
        //    progressBar1.Maximum = Files.Length; //Đặt giá trị lớn nhất cho ProgressBar
        //    int i = 0;
        //    foreach (FileInfo file in Files)
        //    {
        //        progressBar1.Value = i + 1;
        //        string sourceFile = pathFolder + @"\" + file.Name;
        //        string copyFile = copyFolder + @"\" + file.Name;
        //        try
        //        {
        //            File.Copy(sourceFile, copyFile);
        //        }
        //        catch (IOException iox)
        //        {
        //            MessageBox.Show(iox.Message);
        //        }
        //        i = i + 1;
        //    }

        //}
        //public void files(string pathFolder)
        //{
        //    // tham số đầu : pathFolder - đường dẫn thư mục
        //    // tham số thứ hai : "*" - tất cả các loại file
        //    // tham số thứ 3 enum : SearchOption nhận giá trị AllDirectories - tất cả cấp thư mục bên trong
        //    string[] FileList = Directory.GetFiles(pathFolder, "*", SearchOption.AllDirectories);

        //    //Console.WriteLine("===============Using GetFiles method of Class================");
        //    //Console.WriteLine("Number of files :" + FileList.Length);

        //    //Hiển thị danh sách file
        //    foreach (var item in FileList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
        //public void copyFile()
        //{
        //    string fileName = "PrivateVersion.xml";
        //    string sourcePath = @"\\113.160.226.24\qlpk\Update\files";
        //    string targetPath = @"C:\Users\Public\Downloads";

        //    // Use Path class to manipulate file and directory paths.
        //    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        //    string destFile = System.IO.Path.Combine(targetPath, fileName);

        //    // To copy a folder's contents to a new location:
        //    // Create a new target folder.
        //    // If the directory already exists, this method does not create a new directory.
        //    System.IO.Directory.CreateDirectory(targetPath);

        //    // To copy a file to another location and
        //    // overwrite the destination file if it already exists.
        //    System.IO.File.Copy(sourceFile, destFile, true);

        //    // To copy all the files in one directory to another directory.
        //    // Get the files in the source folder. (To recursively iterate through
        //    // all subfolders under the current directory, see
        //    // "How to: Iterate Through a Directory Tree.")
        //    // Note: Check for target path was performed previously
        //    //       in this code example.
        //    if (System.IO.Directory.Exists(sourcePath))
        //    {
        //        string[] files = System.IO.Directory.GetFiles(sourcePath);

        //        // Copy the files and overwrite destination files if they already exist.
        //        foreach (string s in files)
        //        {
        //            // Use static Path methods to extract only the file name from the path.
        //            fileName = System.IO.Path.GetFileName(s);
        //            destFile = System.IO.Path.Combine(targetPath, fileName);
        //            System.IO.File.Copy(s, destFile, true);
        //        }
        //    }
        //    //else
        //    //{
        //    //    Console.WriteLine("Source path does not exist!");
        //    //}
        //}
        //public void copySetup()
        //{
        //    string fileName = "KClinic2.1.exe";
        //    string sourcePath = @"\\113.160.226.24\qlpk\Update\Public";
        //    string targetPath = @"C:\Program Files (x86)\KCL\KCLinic";

        //    // Use Path class to manipulate file and directory paths.
        //    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        //    string destFile = System.IO.Path.Combine(targetPath, fileName);

        //    // To copy a folder's contents to a new location:
        //    // Create a new target folder.
        //    // If the directory already exists, this method does not create a new directory.
        //    System.IO.Directory.CreateDirectory(targetPath);

        //    // To copy a file to another location and
        //    // overwrite the destination file if it already exists.
        //    System.IO.File.Copy(sourceFile, destFile, true);

        //    // To copy all the files in one directory to another directory.
        //    // Get the files in the source folder. (To recursively iterate through
        //    // all subfolders under the current directory, see
        //    // "How to: Iterate Through a Directory Tree.")
        //    // Note: Check for target path was performed previously
        //    //       in this code example.
        //    if (System.IO.Directory.Exists(sourcePath))
        //    {
        //        string[] files = System.IO.Directory.GetFiles(sourcePath);

        //        // Copy the files and overwrite destination files if they already exist.
        //        foreach (string s in files)
        //        {
        //            // Use static Path methods to extract only the file name from the path.
        //            fileName = System.IO.Path.GetFileName(s);
        //            destFile = System.IO.Path.Combine(targetPath, fileName);
        //            System.IO.File.Copy(s, destFile, true);
        //        }
        //    }
        //    //else
        //    //{
        //    //    Console.WriteLine("Source path does not exist!");
        //    //}
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //DoProcessingCP();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //DoProcessingCP();
        }
    }
}
