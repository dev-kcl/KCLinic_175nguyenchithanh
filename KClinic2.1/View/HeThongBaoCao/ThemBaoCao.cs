using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KClinic2._1.Model;
using KClinic2._1.Service;
using KClinic2._1.View;

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class ThemBaoCao : DevExpress.XtraEditors.XtraForm
    {
        List<ItemSelect> itemSelectList = new List<ItemSelect>();
        List<ProcedureParameter> procedureParameterList = new List<ProcedureParameter>();
        private readonly ProcedureDefinitionService procedureDefinitionService = new ProcedureDefinitionService();
        DataTable controlInputTable;
        private bool isInitiallySaved = false;

        DanhSachBaoCao ds;

        public void ClearParameter()
        {
            txtOrderNumberParameter.Clear();
            txtTenNhan.Clear();
            txtParameterName.Clear();
            cbbTypeControl.SelectedValue = 1;


        }
        private string NameInputControlOfId(int i)
        {
            DataRow[] rows = controlInputTable.Select("Id = " + i.ToString());
            return rows[0]["ControlInputName"].ToString();
        }

        private void LoadProcedures()
        {
            procedureDropdown.Items.Clear();
            procedureDropdown.Items.AddRange(procedureDefinitionService.GetAllProcedureNames());
        }

        public ThemBaoCao(DanhSachBaoCao ds)
        {
            InitializeComponent();
            this.ds = ds;
            grbProcedure.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnSaveReport.Enabled = false;

            grbParameter.Enabled = false;
            pnlTypeOfValueKey.Enabled = false;
            pnlValueCheckBox.Enabled = false;
            numValueCBIntFalse.Enabled = false;
            numValueCBIntTrue.Enabled = false;
            pnlTypeLoadItem.Enabled = false;
            grpItem.Enabled = false;
            LoadParameter();
            LoadTypeOfControlInput();
            LoadProcedures();
        }

        private void QuanLyBaoCao_Load(object sender, EventArgs e)
        {
            if (ds.Report_Id != "")
            {
                grbProcedure.Enabled = false;
                btnNew.Enabled = false;
                btnEdit.Enabled = true;
                btnSaveReport.Enabled = false;
                loadReportwhenEdit();
            }
        }



        private void QuanLyBaoCao_FormClosed(object sender, FormClosedEventArgs e)
        {
            controlInputTable = null;
            ds.reloadDanhSach();
        }
        public void LoadTypeOfControlInput()
        {
            controlInputTable = Model.dbReport.getTypeOfControlInput();
            cbbTypeControl.DataSource = controlInputTable;
            cbbTypeControl.ValueMember = "Id";
            cbbTypeControl.DisplayMember = "ControlInputName";
        }

        public void LoadParameter()
        {
            lsvParameter.Items.Clear();
            if (procedureParameterList != null)
            {

                lsvParameter.Items.Clear();
                if (procedureParameterList != null)
                {
                    foreach (ProcedureParameter procedureParameter in procedureParameterList)
                    {
                        ListViewItem item = new ListViewItem(procedureParameter.NumericalOrder.ToString());
                        item.SubItems.Add(procedureParameter.NameShowLabel);
                        item.SubItems.Add(procedureParameter.ParameterName);
                        item.SubItems.Add(procedureParameter.TypeOfControlInputId.ToString());
                        item.SubItems.Add(NameInputControlOfId(procedureParameter.TypeOfControlInputId));
                        int k = procedureParameter.TypeOfItemSelect;
                        item.SubItems.Add(k.ToString());
                        //0 null, 1 string, 2 int,
                        switch (k)
                        {
                            case 0:
                                item.SubItems.Add("NULL");
                                break;
                            case 1:
                                item.SubItems.Add("String");
                                break;
                            case 2:
                                item.SubItems.Add("Int");
                                break;
                        }

                        int k2 = procedureParameter.TypeOfLoadItem;
                        item.SubItems.Add(k2.ToString());
                        switch (k2)
                        {
                            case 0:
                                item.SubItems.Add("NULL");
                                break;
                            case 1:
                                item.SubItems.Add("Fix Static");
                                break;
                            case 2:
                                item.SubItems.Add("Load Database");
                                break;
                        }
                        item.SubItems.Add(procedureParameter.ValueStringCheckBoxTrue);

                        item.SubItems.Add(procedureParameter.ValueStringCheckBoxFalse);


                        item.SubItems.Add(procedureParameter.ValueIntCheckBoxTrue.ToString());
                        item.SubItems.Add(procedureParameter.ValueIntCheckBoxFalse.ToString());

                        lsvParameter.Items.Add(item);

                    }
                }

            }
        }

        private void LoadItemsByOrderNumericParameter(int OrderNumericParameter)
        {
            lsvListItem.Items.Clear();
            List<ItemSelect> itemSelectByIDParameterList = itemSelectList.Where(s => s.procedureParameterNumericalOrder == OrderNumericParameter).ToList();
            foreach (ItemSelect itemSelect in itemSelectByIDParameterList)
            {
                ListViewItem item = new ListViewItem(itemSelect.NumericalOrder.ToString());
                if (!String.IsNullOrEmpty(itemSelect.ValueItemString)) item.SubItems.Add(itemSelect.ValueItemString);
                else item.SubItems.Add(itemSelect.ValueItemInt.ToString());
                item.SubItems.Add(itemSelect.ShowText);


                lsvListItem.Items.Add(item);
            }
        }

        public void ClearItems()
        {
            txtNumticalOrderItem.Clear();
            txtValueKeyString.Clear();
            txtParameterName.Clear();
            txtTextShow.Clear();
            cbbTypeControl.SelectedValue = 1;
        }

        private IEnumerable<ProcedureParameter> ToProcedureParameterList(ProcedureParam[] procedureDefs)
        {
            var result = new List<ProcedureParameter>();
            for (var index = 0; index < procedureDefs.Length; index++)
            {
                var typeOfItemSelect = procedureDefs[index].Type.Contains("nvarchar") ? 1 : 2;
                result.Add(new ProcedureParameter()
                {
                    NumericalOrder = index,
                    ParameterName = procedureDefs[index].ParamName,
                    TypeOfItemSelect = typeOfItemSelect,
                    TypeOfControlInputId = 1

                });
            }
            return result;
        }

        private IEnumerable<ProcedureParameter> ToProcedureParameterListEdit(ProcedureParamEdit[] procedureDefs)
        {
            var result = new List<ProcedureParameter>();
            for (var index = 0; index < procedureDefs.Length; index++)
            {
                var typeOfItemSelect = procedureDefs[index].Type.Contains("nvarchar") ? 1 : 2;

                ProcedureParameter procedureParameter = new ProcedureParameter();
                procedureParameter.Id = Int32.Parse(procedureDefs[index].Id);
                procedureParameter.NumericalOrder = index;
                procedureParameter.ParameterName = procedureDefs[index].ParamName;
                procedureParameter.NameShowLabel = procedureDefs[index].NameShowLabel;
                procedureParameter.TypeOfItemSelect = typeOfItemSelect;
                procedureParameter.TypeOfControlInputId = Int32.Parse(procedureDefs[index].typeOfControlInput);
                procedureParameter.ValueIntCheckBoxTrue = null;
                //int.TryParse(str, out int a)
                //if (string.IsNullOrEmpty(procedureDefs[index].ValueIntCheckBoxTrue))
                //{
                    
                    if (int.TryParse(procedureDefs[index].ValueIntCheckBoxTrue.ToString(), out int a))
                    {
                        procedureParameter.ValueIntCheckBoxTrue = a;
                    }
               
                //}

                //if (int.TryParse(string.IsNullOrEmpty(procedureDefs[index].ValueIntCheckBoxTrue, procedureParameter.ValueIntCheckBoxTrue)))
                //{
                //    procedureParameter.ValueIntCheckBoxTrue = int.Parse(procedureDefs[index].ValueIntCheckBoxTrue);
                //}
                procedureParameter.ValueIntCheckBoxFalse = null;
                if (int.TryParse(procedureDefs[index].ValueIntCheckBoxFalse.ToString(), out int b))
                {
                    procedureParameter.ValueIntCheckBoxFalse = b;
                }
                procedureParameter.TypeOfLoadItem = 0;
                if (int.TryParse(procedureDefs[index].TypeOfLoadItem.ToString(), out int c))
                {
                    procedureParameter.TypeOfLoadItem = c;
                }
                result.Add(procedureParameter);




                //result.Add(new ProcedureParameter()
                //{
                //    Id = Int32.Parse(procedureDefs[index].Id),
                //    NumericalOrder = index,
                //    ParameterName = procedureDefs[index].ParamName,
                //    NameShowLabel = procedureDefs[index].NameShowLabel,
                //    TypeOfItemSelect = typeOfItemSelect,
                //    TypeOfControlInputId = Int32.Parse(procedureDefs[index].typeOfControlInput),

                //    //ValueIntCheckBoxTrue = Int32.Parse(procedureDefs[index].ValueIntCheckBoxTrue),
                //    //ValueIntCheckBoxFalse = Int32.Parse(procedureDefs[index].ValueIntCheckBoxFalse),
                 
                //    //int.TryParse(procedureDefs[index].ValueIntCheckBoxTrue) ? ,

                //    //return string.IsNullOrEmpty(textbox1.text.trim()) ? 0 : int.Parse(textbox1.text.trim());

                //    //ValueIntCheckBoxFalse = Int32.Parse(procedureDefs[index].ValueIntCheckBoxFalse),
                //    TypeOfLoadItem = string.IsNullOrEmpty(procedureDefs[index].TypeOfLoadItem) ? 0 : int.Parse(procedureDefs[index].TypeOfLoadItem),
                //    ValueStringCheckBoxTrue = procedureDefs[index].ValueStringCheckBoxTrue,
                //    ValueStringCheckBoxFalse = procedureDefs[index].ValueStringCheckBoxFalse,

                //    //             public int Id { get; set; }
                //    //public int NumericalOrder { get; set; }
                //    //public string ParameterName { get; set; }
                //    //public string NameShowLabel { get; set; }
                //    //public int TypeOfItemSelect { get; set; }
                //    ////0 null, 1 string, 2 int,
                //    //public int TypeOfLoadItem { get; set; }
                //    //// 1 fix static, 2 load database
                //    //public int ProcedureBaoCaoId { get; set; }
                //    //public int TypeOfControlInputId { get; set; }
                //    //public int? ValueIntCheckBoxTrue { get; set; }
                //    //public int? ValueIntCheckBoxFalse { get; set; }
                //    //public string ValueStringCheckBoxTrue { get; set; }
                //    //public string ValueStringCheckBoxFalse { get; set; }

                //}
                
                
            }
            return result;
        }

        private IEnumerable<ItemSelect> ToItemSelectListEdit(GetItemSelectEdit[] procedureDefs)
        {
            var result = new List<ItemSelect>();
            for (var index = 0; index < procedureDefs.Length; index++)
            {
                result.Add(new ItemSelect()
                {
                    Id = procedureDefs[index].Id,
                    ValueItemString = procedureDefs[index].ValueItemString,
                    ValueItemInt = procedureDefs[index].ValueItemInt,
                    ShowText = procedureDefs[index].ShowText,
                    NumericalOrder = procedureDefs[index].NumericalOrder,
                    procedureParameterId = procedureDefs[index].procedureParameterId,
                    QueryDatabase = procedureDefs[index].QueryDatabase,
                    ColumnKey = procedureDefs[index].ColumnKey,
                    ColumnTextShow = procedureDefs[index].ColumnTextShow,
                    //procedureParameterNumericalOrder = procedureDefs[index].NumericalOrder
                    procedureParameterNumericalOrder = procedureDefs[index].procedureParameterNumericalOrder
    });
            }
            return result;
        }

        #region validate
        private void txtMaBaoCao_TextChanged(object sender, EventArgs e)
        {
            bool allTextBoxesHaveText = txtMaBaoCao.Text.Trim().Length > 0
               && procedureDropdown.SelectedItem != null
               && procedureDropdown.SelectedItem.ToString().Trim().Length > 0
               && txtTenBaoCao.Text.Trim().Length > 0;

            // Enable or disable the GroupBox based on the condition
            //grbParameter.Enabled = allTextBoxesHaveText;
            //btnSaveReport.Enabled = allTextBoxesHaveText;
        }

        private void txtTenBaoCao_TextChanged(object sender, EventArgs e)
        {
            bool allTextBoxesHaveText = txtMaBaoCao.Text.Trim().Length > 0
                && procedureDropdown.SelectedItem != null
                && procedureDropdown.SelectedItem.ToString().Trim().Length > 0
                && txtTenBaoCao.Text.Trim().Length > 0;

            // Enable or disable the GroupBox based on the condition
            //grbParameter.Enabled = allTextBoxesHaveText;
            //btnSaveReport.Enabled = allTextBoxesHaveText;
        }
        #endregion

        private void cbbTypeControl_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //int i = cbbTypeControl.SelectedIndex;
                int k = int.Parse(cbbTypeControl.SelectedValue.ToString());
                //MessageBox.Show("SelectedIndex = " + i + " SelectedValue: " + k);
                //if (k == 2 || k == 3 || k == 4) pnlTypeOfValueKey.Enabled = true;

                //else pnlTypeOfValueKey.Enabled = false;

                if (k == 4)
                {
                    pnlValueCheckBox.Enabled = true;
                    pnlTypeLoadItem.Enabled = false;
                    if (rdoParameterString.Checked)
                    {
                        txtValueCBStringTrue.Enabled = true;
                        txtValueCBStringFalse.Enabled = true;
                        numValueCBIntFalse.Enabled = false;
                        numValueCBIntTrue.Enabled = false;
                    }
                    else
                    {
                        txtValueCBStringTrue.Enabled = false;
                        txtValueCBStringFalse.Enabled = false;
                        numValueCBIntFalse.Enabled = true;
                        numValueCBIntTrue.Enabled = true;
                    }
                }
                else
                {
                    pnlValueCheckBox.Enabled = false;
                }
                if (k == 2 || k == 3) pnlTypeLoadItem.Enabled = true;


            }
            catch
            {
                //int i = cbbTypeControl.SelectedIndex;
                //MessageBox.Show("SelectedIndex = " + i);
            }
        }

        private void lsvParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddItems.Enabled = false;
            btnCloseParameter.Enabled = true;
            btnEditParameter.Enabled = true;

            if (lsvParameter.SelectedItems.Count == 0) return;
            ListViewItem item = lsvParameter.SelectedItems[0];
            txtOrderNumberParameter.Text = item.SubItems[0].Text;
            txtTenNhan.Text = item.SubItems[1].Text;
            txtParameterName.Text = item.SubItems[2].Text;
            int k = int.Parse(item.SubItems[3].Text);

            cbbTypeControl.SelectedValue = k;

            if (k == 1 || k == 2 || k == 3 || k == 4)
            {
                //pnlTypeOfValueKey.Enabled = true;
                if (int.Parse(item.SubItems[5].Text) == 1)
                {
                    rdoParameterString.Checked = true;
                }
                else rdoParameterNumber.Checked = true;

            }

            else
            {
                pnlTypeOfValueKey.Enabled = false;


            }

            if (k == 2 || k == 3)
            {
                btnAddItems.Enabled = true;
                if (int.Parse(item.SubItems[5].Text) == 1)
                {
                    rdoParameterString.Checked = true;
                }

                if (int.Parse(item.SubItems[7].Text) == 1)
                {
                    rdoFixStatic.Checked = true;
                }
                else
                {
                    rdoLoadDB.Checked = true;
                }
            }
            else
            {
                btnAddItems.Enabled = false;
            }


            if (k == 4)
            {
                pnlValueCheckBox.Enabled = true;
                if (rdoParameterString.Checked)
                {
                    txtValueCBStringTrue.Text = item.SubItems[9].Text;
                    txtValueCBStringFalse.Text = item.SubItems[10].Text;
                }
                else
                {
                    numValueCBIntTrue.Value = int.Parse(item.SubItems[11].Text);
                    numValueCBIntFalse.Value = int.Parse(item.SubItems[12].Text);
                }
            }

            else
            {
                pnlValueCheckBox.Enabled = false;
            }
        }

        private void btnEditParameter_Click(object sender, EventArgs e)
        {
            ProcedureParameter procedureParameter = procedureParameterList.Find(p => p.NumericalOrder == int.Parse(txtOrderNumberParameter.Text));

            procedureParameter.ParameterName = txtParameterName.Text;
            procedureParameter.NameShowLabel = txtTenNhan.Text;
            int k = int.Parse(cbbTypeControl.SelectedValue.ToString());
            procedureParameter.TypeOfControlInputId = k;


            if (k == 4)
            {
                if (rdoParameterString.Checked)
                {
                    procedureParameter.ValueStringCheckBoxTrue = txtValueCBStringTrue.Text;
                    procedureParameter.ValueStringCheckBoxFalse = txtValueCBStringFalse.Text;
                    procedureParameter.ValueIntCheckBoxTrue = 0;
                    procedureParameter.ValueIntCheckBoxFalse = 0;

                }
                else
                {
                    procedureParameter.ValueStringCheckBoxTrue = null;
                    procedureParameter.ValueStringCheckBoxFalse = null;
                    procedureParameter.ValueIntCheckBoxTrue = int.Parse(numValueCBIntTrue.Value.ToString());
                    procedureParameter.ValueIntCheckBoxFalse = int.Parse(numValueCBIntFalse.Value.ToString());
                }
            }
            else
            {
                pnlValueCheckBox.Enabled = false;
            }

            if (k == 2 || k == 3)
            {
                if (rdoFixStatic.Checked)
                {
                    procedureParameter.TypeOfLoadItem = 1;

                }
                else
                {
                    procedureParameter.TypeOfLoadItem = 2;
                }
            }
            else
            {
                procedureParameter.TypeOfLoadItem = 0;
            }

            ClearParameter();
            LoadParameter();


            btnEditParameter.Enabled = false;

            btnCloseParameter.Enabled = false;
            btnAddItems.Enabled = false;

            itemSelectList.RemoveAll(item => item.procedureParameterNumericalOrder == procedureParameter.NumericalOrder);
        }

        private void btnCloseParameter_Click(object sender, EventArgs e)
        {
            btnEditParameter.Enabled = false;

            btnCloseParameter.Enabled = false;
            pnlValueCheckBox.Enabled = false;
            ClearParameter();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            grpItem.Enabled = true;
            pnlLoadDB.Enabled = false;
            pnlFixStatic.Enabled = false;
            pnlParameterParent.Enabled = false;
            txtParameterNameItem.Text = txtParameterName.Text;
            txtOrderNumberParameterItem.Text = txtOrderNumberParameter.Text;
            btnAddItem.Enabled = true;
            ProcedureParameter procedureParameter = procedureParameterList.Find(s => s.NumericalOrder == int.Parse(txtOrderNumberParameterItem.Text));
            if (procedureParameter.TypeOfLoadItem == 1)
            {
                pnlFixStatic.Enabled = true;

                LoadItemsByOrderNumericParameter(int.Parse(txtOrderNumberParameterItem.Text));


                if (procedureParameter.TypeOfItemSelect == 1)
                {
                    //itemSelect.ValueItemString = txtValueKeyString.Text;
                    numValueKeyNumber.Enabled = false;
                }
                else if (procedureParameter.TypeOfItemSelect == 2)
                {
                    //itemSelect.ValueItemInt = int.Parse(numValueKeyNumber.Value.ToString());
                    txtValueKeyString.Enabled = false;
                }

                btnEditItem.Enabled = false;
                btnDeleteItem.Enabled = false;
                btnCloseItem.Enabled = false;
                pnlValueCheckBox.Enabled = false;
                pnlFixStatic.Enabled = true;
            }
            else
            {
                pnlLoadDB.Enabled = true;
                txtQueryDatabase.Enabled = true;
                txtColumnKey.Enabled = true;
                txtColumnTextShow.Enabled = true;
                List<ItemSelect> itemSelectByIDParameterList = itemSelectList.Where(s => s.procedureParameterNumericalOrder == int.Parse(txtOrderNumberParameterItem.Text)).ToList();
                if (itemSelectByIDParameterList.Count > 0)
                {
                    ItemSelect itemSelect = itemSelectByIDParameterList[0];

                    txtQueryDatabase.Text = itemSelect.QueryDatabase;
                    txtColumnKey.Text = itemSelect.ColumnKey;
                    txtColumnTextShow.Text = itemSelect.ColumnTextShow;

                }
                //txtQueryDatabase.Text = 
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int orderNumberParameter = int.Parse(txtOrderNumberParameterItem.Text);
            ProcedureParameter procedureParameter = procedureParameterList.Find(s => s.NumericalOrder == orderNumberParameter);
            List<ItemSelect> itemSelectByIDParameterList = itemSelectList.Where(s => s.procedureParameterNumericalOrder == orderNumberParameter).ToList();
            ItemSelect itemSelect = new ItemSelect();
            itemSelect.NumericalOrder = itemSelectByIDParameterList.Count == 0 ? 1 : itemSelectByIDParameterList.Max(x => x.NumericalOrder) + 1;
            if (procedureParameter.TypeOfItemSelect == 1)
            {
                itemSelect.ValueItemString = txtValueKeyString.Text;
                numValueKeyNumber.Enabled = false;
            }
            else if (procedureParameter.TypeOfItemSelect == 2)
            {
                itemSelect.ValueItemInt = int.Parse(numValueKeyNumber.Value.ToString());
                txtValueKeyString.Enabled = false;
            }
            itemSelect.ShowText = txtTextShow.Text;
            itemSelect.procedureParameterNumericalOrder = procedureParameter.NumericalOrder;
            itemSelect.procedureParameterId = procedureParameter.Id;
            itemSelectList.Add(itemSelect);
            LoadItemsByOrderNumericParameter(int.Parse(txtOrderNumberParameterItem.Text));
            ClearItems();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dbReport.CheckLoadDatabase(txtQueryDatabase.Text, txtColumnKey.Text, txtColumnTextShow.Text))
            {
                int orderNumberParameter = int.Parse(txtOrderNumberParameterItem.Text);
                ProcedureParameter procedureParameter = procedureParameterList.Find(s => s.NumericalOrder == orderNumberParameter);


                ItemSelect itemSelectProcedureParameterNumericalOrder = itemSelectList.Find(item => item.procedureParameterNumericalOrder == procedureParameter.NumericalOrder);
                

                ItemSelect itemSelect = new ItemSelect();
               
                if(itemSelectProcedureParameterNumericalOrder != null)
                {
                    itemSelect.Id = itemSelectProcedureParameterNumericalOrder.Id;
                    itemSelect.NumericalOrder = itemSelectProcedureParameterNumericalOrder.NumericalOrder;
                    itemSelect.procedureParameterId= itemSelectProcedureParameterNumericalOrder.procedureParameterId;
                }
                
                itemSelect.procedureParameterNumericalOrder = procedureParameter.NumericalOrder;
                itemSelect.QueryDatabase = txtQueryDatabase.Text;
                itemSelect.ColumnKey = txtColumnKey.Text;
                itemSelect.ColumnTextShow = txtColumnTextShow.Text;
                itemSelectList.RemoveAll(item => item.procedureParameterNumericalOrder == procedureParameter.NumericalOrder);
                itemSelectList.Add(itemSelect);

                txtQueryDatabase.Enabled = false;
                txtColumnKey.Enabled = false;
                txtColumnTextShow.Enabled = false;
            }
        }

        private void btnFinishItems_Click(object sender, EventArgs e)
        {
            txtValueKeyString.Enabled = true;
            numValueKeyNumber.Enabled = true;
            txtQueryDatabase.Text = "";
            txtColumnKey.Text = "";
            txtColumnTextShow.Text = "";

            lsvListItem.Items.Clear();
            pnlParameterParent.Enabled = true;
            grpItem.Enabled = false;
        }

        private void lsvListItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int orderNumberParameter = int.Parse(txtOrderNumberParameterItem.Text);
            ProcedureParameter procedureParameter = procedureParameterList.Find(s => s.NumericalOrder == orderNumberParameter);
            //   List<ItemSelect> itemSelectByIDParameterList = itemSelectList.Where(s => s.procedureParameterNumericalOrder == orderNumberParameter).ToList();


            btnFinishItems.Enabled = false;
            btnAddItem.Enabled = false;
            btnEditItem.Enabled = true;
            btnDeleteItem.Enabled = true;
            btnCloseItem.Enabled = true;
            if (lsvListItem.SelectedItems.Count == 0) return;
            ListViewItem item = lsvListItem.SelectedItems[0];
            txtNumticalOrderItem.Text = item.SubItems[0].Text;
            if (procedureParameter.TypeOfItemSelect == 1) txtValueKeyString.Text = item.SubItems[1].Text;
            else if (procedureParameter.TypeOfItemSelect == 2) numValueKeyNumber.Value = int.Parse(item.SubItems[1].Text);
            txtTextShow.Text = item.SubItems[2].Text;
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            int orderNumberParameter = int.Parse(txtOrderNumberParameterItem.Text);

            ProcedureParameter procedureParameter = procedureParameterList.Find(s => s.NumericalOrder == orderNumberParameter);

            ItemSelect itemSelect = itemSelectList.Find(p => p.NumericalOrder == int.Parse(txtNumticalOrderItem.Text) &&
            p.procedureParameterNumericalOrder == int.Parse(txtOrderNumberParameterItem.Text));

            if (procedureParameter.TypeOfItemSelect == 1)
            {
                itemSelect.ValueItemString = txtValueKeyString.Text;
                numValueKeyNumber.Enabled = false;
            }
            else if (procedureParameter.TypeOfItemSelect == 2)
            {
                itemSelect.ValueItemInt = int.Parse(numValueKeyNumber.Value.ToString());
                txtValueKeyString.Enabled = false;
            }
            itemSelect.ShowText = txtTextShow.Text;
            itemSelect.procedureParameterNumericalOrder = procedureParameter.NumericalOrder;

            ClearItems();
            LoadItemsByOrderNumericParameter(orderNumberParameter);
            btnEditItem.Enabled = false;
            btnDeleteItem.Enabled = false;
            btnFinishItems.Enabled = true;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            int orderNumberParameter = int.Parse(txtOrderNumberParameterItem.Text);

            ProcedureParameter procedureParameter = procedureParameterList.Find(s => s.NumericalOrder == orderNumberParameter);

            ItemSelect itemSelect = itemSelectList.Find(p => p.NumericalOrder == int.Parse(txtNumticalOrderItem.Text) &&
            p.procedureParameterNumericalOrder == int.Parse(txtOrderNumberParameterItem.Text));
            itemSelectList.Remove(itemSelect);
            ClearItems();
            LoadItemsByOrderNumericParameter(orderNumberParameter);
            numValueKeyNumber.Value = 0;

            btnFinishItems.Enabled = true;
        }

        private void btnCloseItem_Click(object sender, EventArgs e)
        {
            btnAddItem.Enabled = true;
            btnEditItem.Enabled = false;
            btnDeleteItem.Enabled = false;
            btnCloseItem.Enabled = false;
            btnFinishItems.Enabled = true;
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            if (ds.Report_Id == "")
            {
                if (dbReport.IsMaBaoCaoExists(txtMaBaoCao.Text))
                {
                    MessageBox.Show("Mã Báo Cáo đã tồn tại");
                }
                else
                {
                    string MaBaoCao = "null";
                    if (txtMaBaoCao.Text != "") { MaBaoCao = "N'" + txtMaBaoCao.Text.Replace("'", "''") + "'"; }
                    string TenBaoCao = "null";
                    if (txtTenBaoCao.Text != "") { TenBaoCao = "N'" + txtTenBaoCao.Text.Replace("'", "''") + "'"; }

                    string procedure = "null";
                    if (procedureDropdown.SelectedItem != null) { procedure = procedureDropdown.SelectedItem.ToString(); }

                    string ReportFile = "null";
                    if (txtReportFile.Text != "") { ReportFile = "N'" + txtReportFile.Text.Replace("'", "''") + "'"; }

                    string TamNgung = "null";
                    if (cbTamNgung.Checked == true) { TamNgung = "1"; } else { TamNgung = "0"; }

                    Model.dbReport.InsertProcedureParameterReport(MaBaoCao, TenBaoCao, procedure, ReportFile, "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", Login.User_Id, TamNgung);
                    int IdProcedure = 0;
                    DataTable GetBaoCaoByMaBaoCaoTable = Model.dbReport.GetProcedureByMaBaoCao(txtMaBaoCao.Text);
                    if (GetBaoCaoByMaBaoCaoTable.Rows.Count > 0)
                    {
                        IdProcedure = int.Parse(GetBaoCaoByMaBaoCaoTable.Rows[0]["Id"].ToString());
                    }

                    foreach (ProcedureParameter procedureParameter in procedureParameterList)
                    {

                        procedureParameter.ProcedureBaoCaoId = IdProcedure;
                        Model.dbReport.InsertProcedureParameter(procedureParameter);
                    }
                    DataTable ProcedureParameterByProcedureBaoCaoIdTable = Model.dbReport.GetProcedureParameterByProcedureBaoCaoId(IdProcedure.ToString());

                    foreach (ItemSelect itemSelect in itemSelectList)
                    {
                        int orderPara = itemSelect.procedureParameterNumericalOrder;
                        DataRow[] rows = ProcedureParameterByProcedureBaoCaoIdTable.Select("NumericalOrder = " + itemSelect.procedureParameterNumericalOrder.ToString());
                        itemSelect.procedureParameterId = int.Parse(rows[0]["Id"].ToString());
                    }

                    foreach (ItemSelect itemSelect in itemSelectList)
                    {
                        DataTable itemSelectTable = Model.dbReport.InsertItemSelect(itemSelect);
                    }

                    procedureDropdown.Enabled = false;
                    MessageBox.Show("Success");
                }
            }
            else
            {
                string MaBaoCao = "null";
                if (txtMaBaoCao.Text != "") { MaBaoCao = "N'" + txtMaBaoCao.Text.Replace("'", "''") + "'"; }
                string TenBaoCao = "null";
                if (txtTenBaoCao.Text != "") { TenBaoCao = "N'" + txtTenBaoCao.Text.Replace("'", "''") + "'"; }

                string procedure = "null";
                if (procedureDropdown.SelectedItem != null) { procedure = procedureDropdown.SelectedItem.ToString(); }

                string ReportFile = "null";
                if (txtReportFile.Text != "") { ReportFile = "N'" + txtReportFile.Text.Replace("'", "''") + "'"; }

                string TamNgung = "null";
                if (cbTamNgung.Checked == true) { TamNgung = "1"; } else { TamNgung = "0"; }

                Model.dbReport.UpdateProcedureBaoCao(MaBaoCao, TenBaoCao, procedure, ReportFile, "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", Login.User_Id, TamNgung, ds.Report_Id);
                int IdProcedure = 0;
                DataTable GetBaoCaoByMaBaoCaoTable = Model.dbReport.GetProcedureByMaBaoCao(txtMaBaoCao.Text);
                if (GetBaoCaoByMaBaoCaoTable.Rows.Count > 0)
                {
                    IdProcedure = int.Parse(GetBaoCaoByMaBaoCaoTable.Rows[0]["Id"].ToString());
                }

                foreach (ProcedureParameter procedureParameter in procedureParameterList)
                {

                    procedureParameter.ProcedureBaoCaoId = IdProcedure;
                    Model.dbReport.UpdateProcedureParameter(procedureParameter);
                }
                DataTable ProcedureParameterByProcedureBaoCaoIdTable = Model.dbReport.GetProcedureParameterByProcedureBaoCaoId(IdProcedure.ToString());

                foreach (ItemSelect itemSelect in itemSelectList)
                {
                    int orderPara = itemSelect.procedureParameterNumericalOrder;
                    DataRow[] rows = ProcedureParameterByProcedureBaoCaoIdTable.Select("NumericalOrder = " + itemSelect.procedureParameterNumericalOrder.ToString());
                    itemSelect.procedureParameterId = int.Parse(rows[0]["Id"].ToString());
                }

                foreach (ItemSelect itemSelect in itemSelectList)
                {
                    DataTable itemSelectTable = Model.dbReport.UpdateItemSelect(itemSelect);
                }

                procedureDropdown.Enabled = false;
                MessageBox.Show("Success");
            }
        }

        private void rdoParameterString_CheckedChanged(object sender, EventArgs e)
        {
            if (pnlValueCheckBox.Enabled)
            {
                if (rdoParameterString.Checked)
                {
                    txtValueCBStringTrue.Enabled = true;
                    txtValueCBStringFalse.Enabled = true;
                    numValueCBIntFalse.Enabled = false;
                    numValueCBIntTrue.Enabled = false;
                }
                else
                {
                    txtValueCBStringTrue.Enabled = false;
                    txtValueCBStringFalse.Enabled = false;
                    numValueCBIntFalse.Enabled = true;
                    numValueCBIntTrue.Enabled = true;
                }
            }
        }

        private void rdoFixStatic_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFixStatic.Checked)
            {
                pnlFixStatic.Enabled = true;
                pnlLoadDB.Enabled = false;
            }
            else
            {
                pnlFixStatic.Enabled = false;
                pnlLoadDB.Enabled = true;
            }
        }

        private void procedureDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool allTextBoxesHaveText = txtMaBaoCao.Text.Trim().Length > 0
                && procedureDropdown.SelectedItem != null
                && procedureDropdown.SelectedItem.ToString().Trim().Length > 0
                && txtTenBaoCao.Text.Trim().Length > 0;

            // Enable or disable the GroupBox based on the condition
            //grbParameter.Enabled = allTextBoxesHaveText;
            //btnSaveReport.Enabled = allTextBoxesHaveText;

            lsvParameter.Items.Clear();
            procedureParameterList.Clear();
            itemSelectList.Clear();


            if (procedureDropdown.Enabled)
            {
                var procedureDefs = procedureDefinitionService.GetDefinitions(procedureDropdown.SelectedItem.ToString());
                procedureParameterList.AddRange(ToProcedureParameterList(procedureDefs));
                LoadParameter();
            }
            else
            {
                if (ds.Report_Id != "")
                {
                    var procedureDefs = procedureDefinitionService.GetDefinitionsEdit(procedureDropdown.SelectedItem.ToString(), ds.Report_Id);
                    procedureParameterList.AddRange(ToProcedureParameterListEdit(procedureDefs));
                    LoadParameter();
                    var procedureDefsItemselect = procedureDefinitionService.GetDefinitionsItemSelectEdit(ds.Report_Id);
                    itemSelectList.AddRange(ToItemSelectListEdit(procedureDefsItemselect));
                }
            }
        }

        private void btnCheckQuery_Click(object sender, EventArgs e)
        {
            DataTable table = dbReport.ExcuteQuery(txtQueryDatabase.Text);
            if (table != null)
            {
                //frmExportReport formExportReport = new frmExportReport(txtQueryDatabase.Text);

                //formExportReport.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ds.reloadDanhSach();
            this.Close();
        }
        public void loadReportwhenEdit()
        {
            int IdProcedure = 0;
            IdProcedure = int.Parse(ds.Report_Id);
            DataTable GetBaoCaoById = Model.dbReport.GetBaoCaoById(ds.Report_Id);
            if (GetBaoCaoById != null)
            {
                if (GetBaoCaoById.Rows.Count > 0)
                {
                    IdProcedure = int.Parse(GetBaoCaoById.Rows[0]["Id"].ToString());
                    txtMaBaoCao.Text = GetBaoCaoById.Rows[0]["MaBaoCao"].ToString();
                    txtTenBaoCao.Text = GetBaoCaoById.Rows[0]["TenBaoCao"].ToString();
                    txtReportFile.Text = GetBaoCaoById.Rows[0]["ReportFile"].ToString();
                    string procedureName = GetBaoCaoById.Rows[0]["procedureName"].ToString();
                    if (!String.IsNullOrEmpty(procedureName))
                    {
                        procedureDropdown.SelectedItem = procedureName;
                    }
                }
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            grbProcedure.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSaveReport.Enabled = true;
            grbParameter.Enabled = true;
            if (ds.Report_Id != "")
            {
                ds.Report_Id = "";
                pnlTypeOfValueKey.Enabled = false;
                pnlValueCheckBox.Enabled = false;
                numValueCBIntFalse.Enabled = false;
                numValueCBIntTrue.Enabled = false;
                pnlTypeLoadItem.Enabled = false;
                grpItem.Enabled = false;
                LoadParameter();
                LoadTypeOfControlInput();
                LoadProcedures();
            }
            reset();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            grbProcedure.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSaveReport.Enabled = true;
            grbParameter.Enabled = true;
        }

        private void btnCancer_Click(object sender, EventArgs e)
        {
            if (ds.Report_Id != "")
            {
                grbProcedure.Enabled = false;
                btnNew.Enabled = false;
                btnEdit.Enabled = true;
                btnSaveReport.Enabled = false;
                grbParameter.Enabled = false;
            }
            else
            {
                grbProcedure.Enabled = false;
                btnNew.Enabled = true;
                btnEdit.Enabled = false;
                btnSaveReport.Enabled = false;
                grbParameter.Enabled = false;
            }
        }

        public void reset()
        {
            txtMaBaoCao.Text = "";
            txtTenBaoCao.Text = "";
            txtReportFile.Text = "";
            LoadParameter();
            LoadTypeOfControlInput();
            LoadProcedures();
        }
    }
}