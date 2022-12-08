using System;
using System.Drawing;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Forms.persons
{
    public partial class make_new_person_Form : Form
    {
        public make_new_person_Form()
        {
            InitializeComponent();
        }
        Alert.Alert alert = new Alert.Alert();
        private void Table_assem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Classes.Helper.Function.sizeDGV(sender as DataGridView);
        }
        DataGridViewCellMouseEventArgs eve;
        private void Table_assem_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            eve = e;
            if (e.RowIndex < 0)
                (sender as DataGridView).ContextMenuStrip.Enabled = false;
            else
            {
                (sender as DataGridView).ContextMenuStrip.Enabled = true;
                تعیین_دسترسی.Visible = تغییر_وضعیت.Visible = حذف.Visible = true;
                if (Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["role"].Value) == "1")
                {
                    int i = Classes.Helper.DB.GET_INT("SELECT COUNT(*) FROM persons WHERE role = 1 AND situation = 1");
                    تعیین_دسترسی.Visible = false;
                    if (i <= 1 && Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["وضعیت"].Value) == "فعال")
                    {
                        تغییر_وضعیت.Visible = false;
                        حذف.Visible = false;
                    }

                }

            }
        }

        private void btn_close_assem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void make_new_person_Form_Load(object sender, EventArgs e)
        {
            FillTable();
            Fill_Select();
        }
        private void Fill_Select()
        {
            Classes.Helper.DB.FILL_SELECT("SELECT id AS value , name FROM accesses WHERE deep = 0 AND situation = 1 ", select_home);
            select_home.AutoCompleteMode = AutoCompleteMode.Suggest;
            select_home.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void FillTable()
        {
            Classes.Helper.DB.FILL_TABLE("" +
                "SELECT " +
                "   p.id AS 'person_id' " +
                " , p.name AS 'نام کاربری' " +
                " , p.welcome_name AS 'نام' " +
                " , p.password AS 'رمز عبور' " +
                " , p.role AS 'role' " +
                " , a.name AS 'بخش' " +
                " , CASE WHEN p.situation = 0 THEN 'غیر فعال' ELSE 'فعال' END AS 'وضعیت' " +
                " , a.id AS 'access_id' " +
                " FROM persons p " +
                " INNER JOIN accesses a " +
                " ON p.access_id = a.id " +
                " WHERE p.role = 0  AND a.situation = 1 " +
                " UNION " +
                "SELECT " +
                "   p.id AS 'person_id' " +
                " , p.name AS 'نام کاربری' " +
                " , p.welcome_name AS 'نام' " +
                " , p.password AS 'رمز عبور' " +
                " , p.role AS 'role' " +
                " , 'مدیریت کاربران' AS 'بخش' " +
                " , CASE WHEN p.situation = 0 THEN 'غیر فعال' ELSE 'فعال' END AS 'وضعیت' " +
                " , '0' AS 'access_id' " +
                " FROM persons p " +
                " WHERE p.role = 1 "
                , Table_assem);
            Table_assem.Columns["person_id"].Visible = false;
            Table_assem.Columns["role"].Visible = false;
            Table_assem.Columns["access_id"].Visible = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Text == "فعال")
                Classes.Helper.CRUD.SET_Situation_To(table: "persons", situation: "1", key: "id", id: Table_assem.Rows[eve.RowIndex].Cells["person_id"].Value.ToString());
            else if ((sender as ToolStripMenuItem).Text == "غیر فعال")
                Classes.Helper.CRUD.SET_Situation_To(table: "persons", situation: "0", key: "id", id: Table_assem.Rows[eve.RowIndex].Cells["person_id"].Value.ToString());
            FillTable();

        }

        private void btn_save_assem_Click(object sender, EventArgs e)
        {
            string name, s_id, pass, welcome_name;
            if (txt_name.Text.Length < 2)
            {
                alert.alert("نام کاربری نباید کمتر از 2 کاراکتر باشد", Alert.Right_side.enmType.error);
                return;
            }
            if (txt_welcome_name.Text.Length < 2)
            {
                alert.alert("نام نمایش نباید کمتر از 2 کاراکتر باشد", Alert.Right_side.enmType.error);
                return;
            }
            if (txt_pass.Text.Length < 8)
            {
                alert.alert("کلمه عبور نباید کمتر از 8 کاراکتر باشد", Alert.Right_side.enmType.error);
                return;
            }
            name = Convert.ToString(txt_name.Text);
            pass = Convert.ToString(txt_pass.Text);
            welcome_name = Convert.ToString(txt_welcome_name.Text);
            if (btn_save_assem.Text == "ثبت")
            {

                if (select_home.Items.Count <= 0 || !int.TryParse(Convert.ToString(select_home.SelectedValue), out int selected_id) || selected_id < 0)
                {
                    alert.alert("لطفا بخش را انتخاب نمایید", Alert.Right_side.enmType.error);
                    return;
                }
                s_id = Convert.ToString(selected_id);
                if (Convert.ToString(select_home.Text).Trim() == "مدیریت کاربران")
                {
                    if (Classes.Helper.DB.GET_BOOL($"SELECT * FROM persons WHERE name = '{name}' AND role = 1"))
                    {
                        alert.alert("قبلا کاربری با این نام کاربری برای این قسمت تعریف شده", Alert.Right_side.enmType.error);
                        return;
                    }
                    Classes.Helper.DB.SQL_QUERY($"INSERT INTO persons (name,welcome_name,password,access_id,role) VALUES ('{name}','{welcome_name}','{pass}','0',1)");

                }
                else
                {

                    if (Classes.Helper.DB.GET_BOOL($"SELECT * FROM persons WHERE name = '{name}' AND role = 0 AND access_id = {s_id}"))
                    {
                        alert.alert("قبلا کاربری با این نام کاربری برای این قسمت تعریف شده", Alert.Right_side.enmType.error);
                        return;
                    }
                    Classes.Helper.DB.SQL_QUERY($"INSERT INTO persons (name,welcome_name,password,access_id,role) VALUES ('{name}','{welcome_name}','{pass}','{s_id}',0)");

                }
            }
            if (btn_save_assem.Text == "تغییر")
            {
                string id_ = Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["person_id"].Value);
                s_id = Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["access_id"].Value);
                if (s_id == "0")
                {
                    if (Classes.Helper.DB.GET_BOOL($"SELECT * FROM persons WHERE name = '{name}' AND role = 1 AND id != {id_}"))
                    {
                        alert.alert("قبلا کاربری با این نام کاربری برای این قسمت تعریف شده", Alert.Right_side.enmType.error);
                        return;
                    }

                }
                else
                {

                    if (Classes.Helper.DB.GET_BOOL($"SELECT * FROM persons WHERE name = '{name}' AND role = 0 AND access_id = {s_id} AND id != {id_}"))
                    {
                        alert.alert("قبلا کاربری با این نام کاربری برای این قسمت تعریف شده", Alert.Right_side.enmType.error);
                        return;
                    }

                }
                s_id = Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["person_id"].Value);
                Classes.Helper.DB.SQL_QUERY($"UPDATE persons SET name='{name}',password='{pass}',welcome_name='{welcome_name}' WHERE id = '{s_id}'");

            }
            clear();
            FillTable();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["person_id"].Value);
            Classes.Helper.DB.SQL_QUERY($"DELETE FROM person_accesses WHERE person_id = {id}");
            Classes.Helper.DB.SQL_QUERY($"DELETE FROM persons WHERE id = {id}");
            FillTable();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Boxes.Forms.persons.set_person_access_Form access_Form = new set_person_access_Form(
                person_name: Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["نام کاربری"].Value),
                home_id: Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["access_id"].Value),
                person_id: Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["person_id"].Value)
                );
            access_Form.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            btn_save_assem.Text = "تغییر";
            btn_save_assem.BackColor = Color.FromArgb(64, 0, 64);
            txt_welcome_name.Text = Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["نام"].Value);
            txt_name.Text = Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["نام کاربری"].Value);
            txt_pass.Text = Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["رمز عبور"].Value);
            select_home.Enabled = false;
        }
        private void clear()
        {
            btn_save_assem.Text = "ثبت";
            btn_save_assem.BackColor = Color.FromArgb(0, 64, 64);
            txt_name.Text = txt_pass.Text = txt_welcome_name.Text = null;
            select_home.Enabled = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void select_home_SelectedIndexChanged(object sender, EventArgs e)
        {
            //alert.scroll(Convert.ToString(select_home.Text).Trim());
        }
    }

}
