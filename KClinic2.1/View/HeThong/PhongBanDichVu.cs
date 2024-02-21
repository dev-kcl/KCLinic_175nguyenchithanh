using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.View.HeThong
{
    public partial class PhongBanDichVu : DevExpress.XtraEditors.XtraForm
    {
        public PhongBanDichVu()
        {
            InitializeComponent();
        }
        DataTable phongbantable;
        public string PhongBan_Id = "";



        public void LoadItems()
        {
            foreach (DataRow menuItem in phongbantable.Rows)
            {
                AddMenuItemToTreeView(menuItem, null);
            }
        }

        // Đưa từng hàng trong bảng vào trong treeview 
        private void AddMenuItemToTreeView(DataRow menuItem, TreeNode parentNode)
        {

            TreeNode newNode = new TreeNode();
            newNode.Name = menuItem["Dich_Id"].ToString();
            newNode.Text = menuItem["TenDichVu"].ToString();


            DataTable subItemTable = Model.dbDanhMuc.SelectDichVuPhongBanParent(newNode.Name);
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
                treeView1.Nodes.Add(newNode);
            }
        }




        public void LoadPhongBanPermission(string PhongBan_Id)

        {
            List<String> PhongBanPermission = new List<string>();
            DataTable persmissionPhongBanDataTable = Model.dbDanhMuc.SelectPermissionPhongBanId(PhongBan_Id);


            if (persmissionPhongBanDataTable.Rows.Count > 0)
            {
                foreach (DataRow subItem in persmissionPhongBanDataTable.Rows)
                {
                    PhongBanPermission.Add(subItem["Dich_Id"].ToString());
                }
            }
            LoadPermissionNodes(treeView1.Nodes, PhongBanPermission);


        }
        private void LoadPermissionNodes(TreeNodeCollection nodes, List<String> PhongBanPermission)
        {
            foreach (TreeNode node in nodes)
            {
                // Set the Checked property of the node to true
                if (PhongBanPermission.Contains(node.Name))
                {
                    node.Checked = true;
                }


                if (node.Nodes.Count > 0)
                {
                    LoadPermissionNodes(node.Nodes, PhongBanPermission);
                }
            }

        }


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

        private void SetListMenu(string _PhongBan_Id, List<string> nameKeyPermissionList)
        {
            foreach (string Dich_Id in nameKeyPermissionList)
            {
                Model.dbDanhMuc.InsertPermissionPhongBanId(PhongBan_Id, Dich_Id);
            }
        }
        private void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false; // Đặt Checked thành false để bỏ dấu tick
                if (node.Nodes.Count > 0)
                {
                    UncheckAllNodes(node.Nodes); // Đệ quy vào các nút con nếu có
                }
            }
        }


        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            UncheckAllNodes(treeView1.Nodes);

            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                txtTenDichVu.Text = gridView1.GetRowCellValue(n, "TenPhongBan").ToString();
                PhongBan_Id = gridView1.GetRowCellValue(n, "PhongBan_Id").ToString();
                LoadPhongBanPermission(gridView1.GetRowCellValue(n, "PhongBan_Id").ToString());


            }

        }

        private void PhongBanDichVu_Load(object sender, EventArgs e)
        {
            DataTable SelectPhongBan = Model.dbDanhMuc.CBBPhongBan();
            gridControl1.DataSource = SelectPhongBan;
            phongbantable = Model.dbDanhMuc.SelectDichVuPhongBan();
            LoadItems();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<string> checkedPermissionList = new List<string>();
            GetCheckedNodes(treeView1.Nodes, checkedPermissionList);
            Model.dbDanhMuc.DeletePermissionPhongBanId(PhongBan_Id);
            SetListMenu(PhongBan_Id, checkedPermissionList);
            alertControl1.Show(this, "Thông báo", "Đã cập nhật phân quyền thành công! ", "");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
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

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



