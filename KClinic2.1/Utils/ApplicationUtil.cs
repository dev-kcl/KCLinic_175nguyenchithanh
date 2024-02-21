using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.Utils
{
    class ApplicationUtil
    {
        public static T FindOpenForm<T>(string formName) where T : Form
        {
            return (T) Application.OpenForms[formName];
        }
    }
}
