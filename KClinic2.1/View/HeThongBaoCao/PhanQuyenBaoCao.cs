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

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class PhanQuyenBaoCao : DevExpress.XtraEditors.XtraForm
    {
        DanhSachBaoCao ds;
        public PhanQuyenBaoCao(DanhSachBaoCao ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        DataTable persmissionDataTable;

        private void PhanQuyenBaoCao_Load(object sender, EventArgs e)
        {
            persmissionDataTable = Model.dbReport.SelectPhongBanPermission();
            LoadItems();
            txtBaoCao.Text = ds.ReportName;
            LoadUserPermission(ds.Report_Id);
            tvPermissions.ExpandAll();
        }

        public void LoadItems()
        {
            foreach (DataRow menuItem in persmissionDataTable.Rows)
            {
                AddPhongBanItemToTreeView(menuItem, null);
            }
        }

        // Đưa từng hàng trong bảng vào trong treeview 
        private void AddPhongBanItemToTreeView(DataRow phongbanItem, TreeNode parentNode)
        {

            TreeNode newNode = new TreeNode();
            newNode.Name = phongbanItem["PhongBan_Id"].ToString();
            newNode.Text = phongbanItem["TenPhongBan"].ToString();
            newNode.ToolTipText = phongbanItem["Loai"].ToString();
            DataTable subItemTable = Model.dbReport.SelectUserPermissionParent(newNode.Name);
            if (subItemTable.Rows.Count > 0)
            {
                foreach (DataRow subItem in subItemTable.Rows)
                {
                    AddUserItemToTreeView(subItem, newNode);
                }
            }
            if (parentNode != null)
            {
                parentNode.Nodes.Add(newNode);
            }
            else
            {
                tvPermissions.Nodes.Add(newNode);
            }
        }

        private void AddUserItemToTreeView(DataRow UserItem, TreeNode parentNode)
        {

            TreeNode newNode = new TreeNode();
            newNode.Name = UserItem["User_Id"].ToString();
            newNode.Text = UserItem["UserName"].ToString();
            newNode.ToolTipText = UserItem["Loai"].ToString();
            parentNode.Nodes.Add(newNode);
        }

        public void LoadUserPermission(string _Report_Id)
        {
            DataTable persmissionUserDataTable = Model.dbReport.SelectUserPermissionReport_Id(ds.Report_Id);
            List<String> UserPermission = new List<string>();
            if (persmissionUserDataTable.Rows.Count > 0)
            {
                foreach (DataRow subItem in persmissionUserDataTable.Rows)
                {
                    UserPermission.Add(subItem["User_Id"].ToString());
                }
            }
            LoadPermissionNodes(tvPermissions.Nodes, UserPermission);

        }
        //từ list => checked vào treeView tvPermissions
        private void LoadPermissionNodes(TreeNodeCollection nodes, List<String> UserPermission)
        {
            foreach (TreeNode node in nodes)
            {
                // Set the Checked property of the node to true
                if (UserPermission.Contains(node.Name))
                {
                    if (node.ToolTipText == "Username")
                    {
                        node.Checked = true;
                    }
                }


                // Recursively check all child nodes
                if (node.Nodes.Count > 0)
                {
                    LoadPermissionNodes(node.Nodes, UserPermission);
                }
            }
        }

        private void tvPermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            SelectParents(e.Node, e.Node.Checked);
        }
        //Mặc định khi check parent thì tất cả child đều checked trên treeview
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        //Mặc định khi check child thì tất cả parent của child đó đều checked trên treeview
        private void SelectParents(TreeNode node, Boolean isChecked)
        {
            var parent = node.Parent;

            if (parent == null)
                return;

            //if (!isChecked && HasCheckedNode(parent))
            //    return;
            if (!isChecked)
                return;

            parent.Checked = isChecked;
            SelectParents(parent, isChecked);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<string> checkedPermissionList = new List<string>();
            GetCheckedNodes(tvPermissions.Nodes, checkedPermissionList);
            Model.dbReport.DeleteUserPermissionReport_Id(ds.Report_Id);
            SetListUser(ds.Report_Id, checkedPermissionList);
            alertControl1.Show(this, "Thông báo", "Đã cập nhật phân quyền thành công! ", "");
        }
        //lấy tất cả nodes đã check đưa vào list string
        private void GetCheckedNodes(TreeNodeCollection nodes, List<string> checkedNodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Check if the node is checked
                if (node.Checked)
                {
                    // Add the node's text to the list of checked nodes
                    if (node.ToolTipText == "Username")
                    {
                        checkedNodes.Add(node.Name);
                    }
                }

                // Recursively check all child nodes
                if (node.Nodes.Count > 0)
                {
                    GetCheckedNodes(node.Nodes, checkedNodes);
                }
            }
        }

        private void SetListUser(string _Report_Id, List<string> nameKeyPermissionList)
        {
            foreach (string _User_Id in nameKeyPermissionList)
            {
                Model.dbReport.InsertUserPermissionReport_Id(_User_Id, _Report_Id);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PhanQuyenBaoCao_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.Report_Id = "";
            ds.ReportName = "";
            ds.reloadDanhSach();
        }
    }
}