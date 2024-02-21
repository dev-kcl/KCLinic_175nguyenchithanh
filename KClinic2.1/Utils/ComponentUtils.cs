using DevExpress.XtraEditors;
using KClinic2._1.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.Utils
{
    class ComponentUtils
    {
        public static void Enable(Control[] controls, bool enabled)
        {
            foreach (var control in controls)
            {
                control.Enabled = enabled;
            }
        }
        public static object GetValueFromComponent(Control control)
        {
            if (control is TextBox textBox)
            {
                return textBox.Text;
            }
            if (control is System.Windows.Forms.ComboBox comboBox)
            {
                return comboBox.SelectedItem != null
                    ? comboBox.SelectedValue.ToString()
                    : null;
            }
            if (control is Panel panelControl)
            {
                foreach (Control subControl in panelControl.Controls)
                {
                    if (subControl is RadioButton radioButton && radioButton.Checked)
                    {
                        return radioButton.Name;
                    }
                }
            }
            if (control is ValueCheckbox checkBox)
            {
                return checkBox.Checked ? checkBox.TrueValue : checkBox.FalseValue;
            }
            if (control is DateTimePicker dateTimePicker)
            {
                return dateTimePicker.CustomFormat.Equals("dd/MM/yyyy")
                    ? dateTimePicker.Value.ToString("yyyy-MM-dd")
                    : dateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            throw new Exception($"Không hỗ trợ lấy dữ liệu từ Control: {control.Name}");
        }
    }
}
