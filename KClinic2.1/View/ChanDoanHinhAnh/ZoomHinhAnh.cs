using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.View.ChanDoanHinhAnh
{
    public partial class ZoomHinhAnh : Form
    {
        

        // Constructor
        public ZoomHinhAnh(string Picture)
        {
            InitializeComponent();

            // Assign the passed PictureBox to the local variable
            pictureBox1.Image = Image.FromFile(Picture);
        }

        private void ZoomHinhAnh_Load(object sender, EventArgs e)
        {
           // pictureBox1.Image = Image.FromFile(Picture);
        }
    }
}
