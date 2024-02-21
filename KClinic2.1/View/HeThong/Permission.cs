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

namespace KClinic2._1.View.HeThong
{
    public partial class Permission : DevExpress.XtraEditors.XtraForm
    {
        public string User_Id = "";
        public Permission()
        {
            InitializeComponent();
        }
        DataTable persmissionDataTable;
        private void Permission_Load(object sender, EventArgs e)
        {
            DataTable SelectUserPermission = Model.db.SelectUserPermission();
            gridDichVu.DataSource = SelectUserPermission;
            persmissionDataTable = Model.db.SelectMenuPermission();
            //lblId.Text = id.ToString();
            LoadItems();
        }
        public void LoadItems()
        {
            foreach (DataRow menuItem in persmissionDataTable.Rows)
            {
                AddMenuItemToTreeView(menuItem, null);
            }
        }

        // Đưa từng hàng trong bảng vào trong treeview 
        private void AddMenuItemToTreeView(DataRow menuItem, TreeNode parentNode)
        {

            TreeNode newNode = new TreeNode();
            newNode.Name = menuItem["Menu_Id"].ToString();
            newNode.Text = menuItem["MenuName"].ToString();
            DataTable subItemTable = Model.db.SelectMenuPermissionParent(newNode.Name);
            if (subItemTable.Rows.Count > 0)
            {
                foreach (DataRow subItem in subItemTable.Rows)
                {
                    AddMenuItemToTreeView(subItem, newNode);
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                txtUserName.Text = gridView1.GetRowCellValue(n, "UserName").ToString();
                User_Id = gridView1.GetRowCellValue(n, "User_Id").ToString();
                LoadUserPermission(gridView1.GetRowCellValue(n, "User_Id").ToString());
            }
        }
        public void LoadUserPermission(string User_Id)
        {
            DataTable persmissionUserDataTable = Model.db.SelectMenuPermissionUserId(User_Id);
            List<String> UserPermission = new List<string>();
            if (persmissionUserDataTable.Rows.Count > 0)
            {
                foreach (DataRow subItem in persmissionUserDataTable.Rows)
                {
                    UserPermission.Add(subItem["Menu_Id"].ToString());
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
                    node.Checked = true;
                }


                // Recursively check all child nodes
                if (node.Nodes.Count > 0)
                {
                    LoadPermissionNodes(node.Nodes, UserPermission);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<string> checkedPermissionList = new List<string>();
            GetCheckedNodes(tvPermissions.Nodes, checkedPermissionList);
            Model.db.DeletePermissionUserId(User_Id);
            SetListMenu(User_Id, checkedPermissionList);
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
                    checkedNodes.Add(node.Name);
                }

                // Recursively check all child nodes
                if (node.Nodes.Count > 0)
                {
                    GetCheckedNodes(node.Nodes, checkedNodes);
                }
            }
        }

        private void SetListMenu(string _User_Id, List<string> nameKeyPermissionList)
        {
            foreach (string Menu_id in nameKeyPermissionList)
            {
                Model.db.InsertPermissionUserId(User_Id, Menu_id);
            }
        }
        //gọi event sau khi check
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
    }
}