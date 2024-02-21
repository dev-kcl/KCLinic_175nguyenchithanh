using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KClinic2._1.Components;
using KClinic2._1.Desktop;
using KClinic2._1.Model;
using KClinic2._1.Service;
using KClinic2._1.Utils;

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class HeThongBaoCao : DevExpress.XtraEditors.XtraForm
    {
        public string Report_Id = string.Empty;
        private List<Desktop.ProcedureParameter> procedureParameters = new List<Desktop.ProcedureParameter>();
        private static readonly IProcedureBaoCaoService procedureBaoCaoService = new ProcedureBaoCaoService();
        public DataTable DuLieu;
        public HeThongBaoCao()
        {
            InitializeComponent();
        }
       
        private void HeThongBaoCao_Load(object sender, EventArgs e)
        {
            var baoCaos = procedureBaoCaoService.GetBaoCaosByUserId(int.Parse(Login.User_Id));
            foreach (var baoCao in baoCaos)
            {
                AddReportItemToTreeView(baoCao);
            }
        }
        private void AddReportItemToTreeView(ProcedureBaoCao baoCao)
        {

            TreeNode newNode = new TreeNode();
            newNode.Name = baoCao.Id.ToString();
            newNode.Text = baoCao.TenBaoCao;
            newNode.ToolTipText = baoCao.MaBaoCao;
            newNode.ImageIndex = 0;
            newNode.SelectedImageIndex = 0;
            treeViewBC.Nodes.Add(newNode);
        }

        private void treeViewBC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var reportId = int.Parse(treeViewBC.SelectedNode.Name);
            //To be refactored.
            Report_Id = reportId.ToString();
            flowLayoutPanel1.Controls.Clear();
            var baoCao = procedureBaoCaoService.GetBaoCaoById(reportId);
            lblMaBaoCao.Text = baoCao.MaBaoCao;
            lblTenBaoCao.Text = baoCao.TenBaoCao;
            lblProcedureBaoCao.Text = baoCao.procedureName;
            procedureParameters = baoCao.ProcedureParameter.OrderBy(p => p.NumericalOrder).ToList();
            foreach (var procedureParameter in baoCao.ProcedureParameter)
            {

                switch (procedureParameter.TypeOfControlInputId)
                {
                    case 1: // TextBox
                        AddTextBox(procedureParameter);
                        break;
                    case 2: // ComboBox
                        AddComboBox(procedureParameter);
                        break;
                    case 3: // Radio Buttons
                        AddRadioButtons(procedureParameter);
                        break;
                    case 4: // Check Boxes
                        AddCheckBoxes(procedureParameter);
                        break;
                    case 5: // Date Picker
                        AddDatePicker(procedureParameter);
                        break;
                    case 6: // Date Time Picker
                        AddDateTimePicker(procedureParameter);
                        break;
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a digit or a control key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!int.TryParse(textBox.Text, out _))
            {
                textBox.Text = ""; // Clear the textbox if the input is not a valid number
            }
        }
        private void AddTextBox(Desktop.ProcedureParameter procedureParameter)
        {
            Label label = new Label();
            label.Name = "lb_" + procedureParameter.NumericalOrder;
            label.Text = procedureParameter.NameShowLabel;
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            //l.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font("Times New Roman", 9);
            label.Width = 100;
            label.Height = 20;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Margin = new Padding(5);
            flowLayoutPanel1.Controls.Add(label);


            TextBox t = new TextBox();
            t.Name = "t_" + procedureParameter.NumericalOrder;
            t.Font = new Font("Times New Roman", 9);
            t.Width = 250;
            t.Height = 20;
            t.Margin = new Padding(5);


            if (procedureParameter.typeOfItemSelect == 2)
            {
                t.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                t.TextChanged += TextBox_TextChanged;
            }
            flowLayoutPanel1.Controls.Add(t);
            flowLayoutPanel1.SetFlowBreak(t, true);
        }

        private void AddComboBox(Desktop.ProcedureParameter procedureParameter)
        {
            var itemSelects = OrderItemSelects(procedureParameter.ItemSelect.ToArray(), procedureParameter.typeOfItemSelect);
            Label label = new Label();
            label.Name = "lb_" + procedureParameter.NumericalOrder;
            label.Text = procedureParameter.NameShowLabel;
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            //l.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font("Times New Roman", 9);
            label.Width = 100;
            label.Height = 20;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Margin = new Padding(5);
            flowLayoutPanel1.Controls.Add(label);

            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            comboBox.Name = "c_" + procedureParameter.NumericalOrder;
            comboBox.Font = new Font("Times New Roman", 9);
            comboBox.Width = 250;
            comboBox.Height = 20;
            comboBox.Margin = new Padding(5);

            if (procedureParameter.TypeOfLoadItem == 1)
            {
                comboBox.DataSource = itemSelects;
                comboBox.DisplayMember = "ShowText";
                comboBox.ValueMember = procedureParameter.typeOfItemSelect == 1
                    ? "ValueItemString"
                    : "ValueItemInt";
            }
            else
            {
                DataTable ThongTinComBoBox = Model.dbReport.ThongTinComBoBox(itemSelects[0].QueryDatabase);
                comboBox.DataSource = ThongTinComBoBox;
                comboBox.DisplayMember = itemSelects[0].ColumnTextShow;
                comboBox.ValueMember = itemSelects[0].ColumnKey;
            }
            flowLayoutPanel1.Controls.Add(comboBox);
            flowLayoutPanel1.SetFlowBreak(comboBox, true);
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.SelectedItem = null;
        }

        private void AddRadioButtons(Desktop.ProcedureParameter procedureParameter)
        {

            var itemSelects = OrderItemSelects(procedureParameter.ItemSelect.ToArray(), procedureParameter.typeOfItemSelect);

            Label label = new Label();
            label.Name = "lb_" + procedureParameter.NumericalOrder;
            label.Text = procedureParameter.NameShowLabel;
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Times New Roman", 9);
            label.Width = 100;
            label.Height = 20;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Margin = new Padding(5);
            flowLayoutPanel1.Controls.Add(label);

            Panel radioButtonPanel = new Panel();
            radioButtonPanel.Name = "r_" + procedureParameter.NumericalOrder;
            radioButtonPanel.Font = new Font("Times New Roman", 9);
            radioButtonPanel.Width = 250;
            radioButtonPanel.Height = 20;
            radioButtonPanel.Margin = new Padding(5);
            int radioY = 0;
            int radioX = 0;
            int k = 0;

            if (procedureParameter.TypeOfLoadItem == 1)
            {
                foreach (var item in itemSelects)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Name = procedureParameter.typeOfItemSelect == 1
                        ? item.ValueItemString
                        : item.ValueItemInt.ToString();
                    radioButton.Text = item.ShowText;
                    radioButton.AutoSize = true;
                    radioButton.Location = new Point(radioX, 0);
                    if (k == 0) radioButton.Checked = true;
                    radioButtonPanel.Controls.Add(radioButton);
                    radioButtonPanel.Width += radioButton.Width + 5;
                    radioX += radioButton.Width + 3;
                    radioY += radioButton.Height;
                    radioButtonPanel.Height = radioButton.Height + 5;
                    k++;
                }
            }
            else
            {
                DataTable ThongTinRadios = Model.dbReport.ThongTinComBoBox(itemSelects[0].QueryDatabase);


                //foreach (var item in ThongTinRadios)
                //{
                //    RadioButton radioButton = new RadioButton();
                //    radioButton.Name = procedureParameter.typeOfItemSelect == 1
                //        ? item.ValueItemString
                //        : item.ValueItemInt.ToString();
                //    radioButton.Text = item.ShowText;
                //    radioButton.AutoSize = true;
                //    radioButton.Location = new Point(radioX, 0);
                //    if (k == 0) radioButton.Checked = true;
                //    radioButtonPanel.Controls.Add(radioButton);
                //    radioButtonPanel.Width += radioButton.Width + 5;
                //    radioX += radioButton.Width + 3;
                //    radioY += radioButton.Height;
                //    radioButtonPanel.Height = radioButton.Height + 5;
                //    k++;
                //}

                DataTable ThongTinComBoBox = Model.dbReport.ThongTinComBoBox(itemSelects[0].QueryDatabase);
                //comboBox.DataSource = ThongTinComBoBox;
                //comboBox.DisplayMember = itemSelects[0].ColumnTextShow;
                //comboBox.ValueMember = itemSelects[0].ColumnKey;


                foreach (DataRow rowSub in ThongTinRadios.Rows)
                {
                    RadioButton radioButton = new RadioButton();
                    //string key = itemSelects[0].ColumnKey.ToString();
                    radioButton.Name = rowSub[itemSelects[0].ColumnKey.ToString()].ToString();
                    radioButton.Text = rowSub[itemSelects[0].ColumnTextShow.ToString()].ToString();
                    radioButton.AutoSize = true;
                    radioButton.Location = new Point(radioX, 0);
                    if (k == 0) radioButton.Checked = true;
                    radioButtonPanel.Controls.Add(radioButton);
                    radioButtonPanel.Width += radioButton.Width + 5;
                    radioX += radioButton.Width + 3;
                    radioY += radioButton.Height;
                    radioButtonPanel.Height = radioButton.Height + 5;
                    k++;




                    //ItemSelect itemSelect = new ItemSelect();
                    //itemSelect.Id = int.Parse(row["Id"].ToString());
                    //orderNumber++;
                    //itemSelect.NumericalOrder = orderNumber;
                    //if (TypeKey == 1)
                    //{
                    //    itemSelect.ValueItemString = rowSub[row["ColumnKey"].ToString()].ToString();
                    //    itemSelect.ShowText = rowSub[row["ColumnTextShow"].ToString()].ToString();
                    //}
                    //if (TypeKey == 2)
                    //{

                    //    itemSelect.ValueItemInt = int.Parse(rowSub[row["ColumnKey"].ToString()].ToString());
                    //    itemSelect.ShowText = rowSub[row["ColumnTextShow"].ToString()].ToString();
                    //}


                    //itemSelectList.Add(itemSelect);
                }
            }
              

            flowLayoutPanel1.Controls.Add(radioButtonPanel);
            flowLayoutPanel1.SetFlowBreak(radioButtonPanel, true);
        }

        private void AddCheckBoxes(Desktop.ProcedureParameter procedureParameter)
        {
            var checkBox = new ValueCheckbox();
            checkBox.TrueValue = procedureParameter.typeOfItemSelect == 1
                ? procedureParameter.ValueStringCheckBoxTrue
                : procedureParameter.ValueIntCheckBoxTrue.ToString();
            checkBox.FalseValue = procedureParameter.typeOfItemSelect == 1
                ? procedureParameter.ValueStringCheckBoxFalse
                : procedureParameter.ValueIntCheckBoxFalse.ToString();
            checkBox.AutoSize = true;
            checkBox.Name = "cb" + procedureParameter.NumericalOrder.ToString();
            checkBox.Text = procedureParameter.NameShowLabel;
            checkBox.Font = new Font("Times New Roman", 9);
            checkBox.Width = 250;
            checkBox.Height = 20;
            checkBox.Margin = new Padding(5);
            flowLayoutPanel1.Controls.Add(checkBox);
            flowLayoutPanel1.SetFlowBreak(checkBox, true);
        }

        private void AddDatePicker(Desktop.ProcedureParameter procedureParameter)
        {
            Label l = new Label();
            l.Name = "lb_" + procedureParameter.NumericalOrder;
            l.Text = procedureParameter.NameShowLabel;
            l.ForeColor = Color.Black;
            l.BackColor = Color.Transparent;
            //l.BorderStyle = BorderStyle.FixedSingle;
            l.Font = new Font("Times New Roman", 9);
            l.Width = 100;
            l.Height = 20;
            l.TextAlign = ContentAlignment.MiddleLeft;
            l.Margin = new Padding(5);
            flowLayoutPanel1.Controls.Add(l);

            DateTimePicker datePicker = new DateTimePicker();
            datePicker.Name = "ID" + procedureParameter.Id.ToString();
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.Font = new Font("Times New Roman", 9);
            datePicker.Width = 250;
            datePicker.Height = 20;
            datePicker.Margin = new Padding(5);
            datePicker.CustomFormat = "dd/MM/yyyy";
            flowLayoutPanel1.Controls.Add(datePicker);
            flowLayoutPanel1.SetFlowBreak(datePicker, true);
        }

        private void AddDateTimePicker(Desktop.ProcedureParameter procedureParameter)
        {
            Label label = new Label();
            label.Name = "lb_" + procedureParameter.NumericalOrder;
            label.Text = procedureParameter.NameShowLabel;
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            //l.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font("Times New Roman", 9);
            label.Width = 100;
            label.Height = 20;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Margin = new Padding(5);
            flowLayoutPanel1.Controls.Add(label);

            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Name = "ID" + procedureParameter.Id.ToString();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            dateTimePicker.Font = new Font("Times New Roman", 9);
            dateTimePicker.Width = 250;
            dateTimePicker.Height = 20;
            dateTimePicker.Margin = new Padding(5);
            flowLayoutPanel1.Controls.Add(dateTimePicker);
            flowLayoutPanel1.SetFlowBreak(dateTimePicker, true);

        }

        private Desktop.ItemSelect[] OrderItemSelects(Desktop.ItemSelect[] itemSelects, int? typeOfItemSelect)
        {
            foreach (var itemSelect in itemSelects)
            {
                if (itemSelect.NumericalOrder != 0)
                {
                    continue;
                }
                DataTable tableExecute = dbReport.ExcuteQuery(itemSelect.QueryDatabase);
                int orderNumber = 0;

                foreach (DataRow rowSub in tableExecute.Rows)
                {
                    orderNumber++;
                    itemSelect.NumericalOrder = orderNumber;
                    if (typeOfItemSelect == 1)
                    {
                        itemSelect.ValueItemString = rowSub[itemSelect.ColumnKey].ToString();
                        itemSelect.ShowText = rowSub[itemSelect.ColumnTextShow].ToString();
                    }
                    if (typeOfItemSelect == 2)
                    {
                        itemSelect.ValueItemInt = int.Parse(rowSub[itemSelect.ColumnKey].ToString());
                        itemSelect.ShowText = rowSub[itemSelect.ColumnTextShow].ToString();
                    }
                }
            }
            return itemSelects.OrderBy(i => i.NumericalOrder).ToArray();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetDuLieu();
            View.HeThongBaoCao.ViewReport bc = new View.HeThongBaoCao.ViewReport(this);
            bc.Show();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            GetDuLieu();
            gridDanhSach.DataSource = DuLieu;
        }
        public Dictionary<string,object> GetDuLieu()
        {
            var result = new Dictionary<string, object>();
            string ThongTinStored = $"exec {lblProcedureBaoCao.Text} ";
            int countPara = 0;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Label)
                {
                    continue;
                }
                object value = ComponentUtils.GetValueFromComponent(control);
                if (value == null)
                {
                    ThongTinStored += $"null,";
                } else
                {
                    ThongTinStored += $"N'{value}',";
                }
                result.Add(procedureParameters[countPara].ParameterName, value);
                countPara++;
            }
            // remove last comma in procedure.
            if (countPara != 0) { ThongTinStored = ThongTinStored.Substring(0, ThongTinStored.Length - 1); }
            DuLieu = Model.dbReport.ThongTinComBoBox(ThongTinStored);
            return result;
        }

        private void btnExel_Click(object sender, EventArgs e)
        {
            var procedureParams = GetDuLieu();
            gridDanhSach.DataSource = DuLieu;
            SaveFileDialog.Title = $"{lblTenBaoCao.Text}";
            SaveFileDialog.FileName = $"{lblTenBaoCao.Text}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}";
            var result = SaveFileDialog.ShowDialog();
            if (result == DialogResult.OK && SaveFileDialog.FileName != string.Empty)
            {
                var maBaoCao = lblMaBaoCao.Text;
                ExcelService.Run(maBaoCao, SaveFileDialog.FileName, DuLieu, procedureParams);
            }
        }
    }
}