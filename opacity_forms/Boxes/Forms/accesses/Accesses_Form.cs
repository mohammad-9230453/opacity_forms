using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Forms.accesses
{
    public partial class Accesses_Form : Form
    {
        public Accesses_Form()
        {
            InitializeComponent();
        }

        bool fill_tree = false;

        private void FillTree()
        {
            treeView1.Nodes.Clear();
            DataTable dt_0;
            DataTable dt_1;
            DataTable dt_2;
            DataTable dt_;
            TreeNode t_0;
            TreeNode t;
            TreeNode t_1;
            TreeNode t_2;
            TreeNode t_empty;
            int i, j, k;


            dt_0 = Classes.Helper.DB.GET_DATA_TABLE("SELECT id , name , situation FROM accesses WHERE deep = 0");

            if (dt_0.Rows.Count > 0)
            {
                //بخش ها
                for (i = 0; i < dt_0.Rows.Count; i++)
                {

                    t_0 = treeView1.Nodes.Add(Convert.ToString(dt_0.Rows[i]["name"]));
                    t_0.Name = "home_" + Convert.ToString(dt_0.Rows[i]["id"]);
                    if (Convert.ToString(dt_0.Rows[i]["situation"]) == "0")
                        t_0.ForeColor = Color.Red;
                    else
                        t_0.ForeColor = Color.Green;


                    //قسمت های بخش
                    dt_1 = Classes.Helper.DB.GET_DATA_TABLE("SELECT id , name , situation  FROM accesses WHERE deep = 1 AND parent_id = " + Convert.ToString(dt_0.Rows[i]["id"]));
                    if (dt_1.Rows.Count > 0)
                    {
                        for (j = 0; j < dt_1.Rows.Count; j++)
                        {
                            t_1 = t_0.Nodes.Add(Convert.ToString(dt_1.Rows[j]["name"]));
                            t_1.Name = "part_" + Convert.ToString(dt_1.Rows[j]["id"]);
                            if (Convert.ToString(dt_1.Rows[j]["situation"]) == "0")
                                t_1.ForeColor = Color.Red;
                            else
                                t_1.ForeColor = Color.Green;

                            //دکمه های قسمت
                            dt_2 = Classes.Helper.DB.GET_DATA_TABLE("SELECT id , name , situation  FROM accesses WHERE deep = 2 AND parent_id = " + Convert.ToString(dt_1.Rows[j]["id"]));
                            if (dt_2.Rows.Count > 0)
                            {
                                for (k = 0; k < dt_2.Rows.Count; k++)
                                {
                                    t_2 = t_1.Nodes.Add(Convert.ToString(dt_2.Rows[k]["name"]));
                                    t_2.Name = "btn_" + Convert.ToString(dt_2.Rows[k]["id"]);
                                    if (Convert.ToString(dt_2.Rows[k]["situation"]) == "0")
                                        t_2.ForeColor = Color.Red;
                                    else
                                        t_2.ForeColor = Color.Green;

                                }
                            }

                        }
                    }

                }
            }
            treeView1.ExpandAll();
            fill_tree = true;
        }




        private void Accesses_Form_Load(object sender, EventArgs e)
        {
            FillTree();
            fill_tree = false;
        }


        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            // Change the icon of the node to show closed folder after node gets expanded

            // if (sender is TreeNode)
            //
            // {
            //
            //     TreeNode node = sender as TreeNode;
            //
            //     node.ImageIndex = 0;
            //
            //     node.SelectedImageIndex = 0;
            //
            // }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            // Change the icon of the node to show opened folder after node gets expanded

            //if (sender is TreeNode)
            //
            //{
            //
            //    TreeNode node = sender as TreeNode;
            //
            //    node.ImageIndex = 1;
            //
            //    node.SelectedImageIndex = 1;
            //
            //}
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //MessageBox.Show("vvv");
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    string id = e.Node.Name.Split('_')[1];
                    // Stop editing without canceling the label change.
                    // e.Node.EndEdit(false);
                    Classes.Helper.DB.SQL_QUERY($"UPDATE accesses SET name = '{e.Label}' WHERE id = {id} ");


                }
            }
            // FillTree();

        }
        TreeNode mySelectedNode;
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            mySelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if (mySelectedNode == null)
            {
                تغییر.Visible = تغییر_وضعیت.Visible = حذف.Visible = false;
                ایجاد.Visible = true;
            }
            else
            {
                string[] arr = mySelectedNode.Name.Split('_');
                if (arr[0] == "btn")
                {
                    ایجاد.Visible = false;
                }
                else
                {
                    ایجاد.Visible = true;

                }
                //MessageBox.Show(arr[0]);
                تغییر.Visible = تغییر_وضعیت.Visible = حذف.Visible = true;

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string[] arr = mySelectedNode.Name.Split('_');
            if (MessageBox.Show("مطمعن هستین که میخایید این فیلد ها رو حذف کنید؟", "حذف", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                switch (arr[0])
                {
                    case "home":
                        Classes.Helper.DB.SQL_QUERY($"DELETE FROM accesses WHERE deep = 2 AND parent_id IN (  SELECT a.id FROM (SELECT * FROM accesses) AS a WHERE a.deep = 1 AND a.parent_id = {arr[1]} ) ");
                        Classes.Helper.DB.SQL_QUERY($"DELETE FROM accesses WHERE deep = 1 AND parent_id = {arr[1]} ");
                        Classes.Helper.DB.SQL_QUERY($"DELETE FROM accesses WHERE deep = 0 AND id = {arr[1]} ");
                        break;
                    case "part":
                        Classes.Helper.DB.SQL_QUERY($"DELETE FROM accesses WHERE deep = 2 AND parent_id = {arr[1]} ");
                        Classes.Helper.DB.SQL_QUERY($"DELETE FROM accesses WHERE deep = 1 AND id = {arr[1]} ");
                        break;
                    case "btn":
                        Classes.Helper.DB.SQL_QUERY($"DELETE FROM accesses WHERE deep = 2 AND id = {arr[1]} ");
                        break;
                }
                FillTree();
            }
        }



        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (mySelectedNode != null)
            //&& mySelectedNode.Parent != null)
            {
                treeView1.SelectedNode = mySelectedNode;
                treeView1.LabelEdit = true;
                if (!mySelectedNode.IsEditing)
                {
                    mySelectedNode.BeginEdit();
                }
            }
            else
            {
                MessageBox.Show("No tree node selected or selected node is a root node.\n" +
                   "Editing of root nodes is not allowed.", "Invalid selection");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (mySelectedNode == null)
            {
                Classes.Helper.DB.SQL_QUERY("INSERT INTO accesses (name,parent_id,deep) VALUES ('بخش جدید',0,0)");
                FillTree();

                return;
            }
            string[] arr = mySelectedNode.Name.Split('_');
            switch (arr[0])
            {
                case "home":
                    Classes.Helper.DB.SQL_QUERY($"INSERT INTO accesses (name,parent_id,deep) VALUES ('قسمت جدید',{arr[1]},1)");
                    FillTree();
                    break;
                case "part":
                    Classes.Helper.DB.SQL_QUERY($"INSERT INTO accesses (name,parent_id,deep) VALUES ('دکمه جدید',{arr[1]},2)");
                    FillTree();
                    break;
            }
        }

        private void فعالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] arr = mySelectedNode.Name.Split('_');
            Classes.Helper.CRUD.SET_Situation_To(table: "accesses", situation: "1", key: "id", arr[1]);
            mySelectedNode.ForeColor = Color.Green;
            //FillTree();
        }

        private void غیرفعالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] arr = mySelectedNode.Name.Split('_');
            Classes.Helper.CRUD.SET_Situation_To(table: "accesses", situation: "0", key: "id", arr[1]);
            mySelectedNode.ForeColor = Color.Red;
            //FillTree();
        }
    }
}
