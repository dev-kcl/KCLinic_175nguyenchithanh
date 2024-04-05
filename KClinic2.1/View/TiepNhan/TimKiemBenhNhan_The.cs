using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.View.TiepNhan
{
    public partial class TimKiemBenhNhan_The : DevExpress.XtraEditors.XtraForm
    {
        TiepNhanTheThanhVien tn;

        public TimKiemBenhNhan_The(TiepNhanTheThanhVien tn)
        {
            InitializeComponent();
            this.tn = tn;
        }
    }
}