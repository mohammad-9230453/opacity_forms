using System;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Forms.persons
{
    public partial class set_person_access_Form : Form
    {
        private string home_id, person_id, person_name;
        public set_person_access_Form(string home_id, string person_id, string person_name)
        {
            InitializeComponent();
            this.home_id = home_id;
            this.person_id = person_id;
            this.person_name = person_name;
        }

        private void set_person_access_Form_Load(object sender, EventArgs e)
        {
            lbl_person_name.Text = person_name;
            FillTable();
            FillSelectPart();
        }
        private void FillTable()
        {
            Classes.Helper.DB.FILL_TABLE($"" +
                $"SELECT " +
                $" a.id AS 'btn_id' " +
                $" , p.name AS 'قسمت' " +
                $" , a.name AS 'بخش' " +
                $" , p_a.id AS 'id' " +
                $" , p.id AS 'part_id' " +
                $" FROM  person_accesses p_a " +
                $" INNER JOIN accesses a ON p_a.access_id = a.id " +
                $" INNER JOIN (SELECT * FROM accesses) p ON a.parent_id = p.id " +
                $" WHERE p_a.person_id = {person_id} AND a.deep = 2 AND a.situation = 1 AND p.situation = 1 "
                , Table_assem);
            Table_assem.Columns["btn_id"].Visible = false;
            Table_assem.Columns["id"].Visible = false;
            Table_assem.Columns["part_id"].Visible = false;
        }

        private void select_part_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_btn.Text = null;
            FillSelectBtn();
        }
        Boxes.Alert.Alert alert = new Alert.Alert();
        private void btn_save_assem_Click(object sender, EventArgs e)
        {

            if (select_part.Items.Count <= 0 || !int.TryParse(Convert.ToString(select_part.SelectedValue), out int part_id) || part_id <= 0)
            {
                alert.shortAlert("لطفا قطعه را انتخاب کنید", Alert.topShort.enmtype.error);
                return;
            }
            string part_id_ = Convert.ToString(part_id);
            if (select_btn.Items.Count <= 0 || !int.TryParse(Convert.ToString(select_btn.SelectedValue), out int btn_id) || btn_id <= 0)
            {
                alert.shortAlert("لطفا بخش را انتخاب کنید", Alert.topShort.enmtype.error);
                return;
            }
            string btn_id_ = Convert.ToString(btn_id);
            if (!Classes.Helper.DB.GET_BOOL($"SELECT * FROM person_accesses WHERE person_id = {person_id} AND access_id = {part_id}"))
            {
                Classes.Helper.DB.SQL_QUERY($"INSERT INTO person_accesses (person_id,access_id) VALUES ({person_id},{part_id})");
            }
            Classes.Helper.DB.SQL_QUERY($"INSERT INTO person_accesses (person_id,access_id) VALUES ({person_id},{btn_id})");
            FillTable();
            var i_ = select_part.SelectedValue;
            select_part.SelectedIndex = -1;
            select_part.SelectedValue = i_;
        }

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
                (sender as DataGridView).ContextMenuStrip.Enabled = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Classes.Helper.DB.SQL_QUERY($"DELETE FROM person_accesses WHERE id = {Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["id"].Value)}");
            if (!Classes.Helper.DB.GET_BOOL($"SELECT * FROM accesses WHERE parent_id = {Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["part_id"].Value)} AND id IN ( SELECT access_id FROM person_accesses WHERE  person_id = {person_id} )"))
            {
                Classes.Helper.DB.SQL_QUERY($"DELETE FROM person_accesses WHERE access_id = {Convert.ToString(Table_assem.Rows[eve.RowIndex].Cells["part_id"].Value)} AND person_id = {person_id}");
            }
            FillTable();
            var i_ = select_part.SelectedValue;
            select_part.SelectedIndex = -1;
            select_part.SelectedValue = i_;
        }

        private void btn_close_assem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillSelectPart()
        {
            Classes.Helper.DB.FILL_SELECT($"SELECT id AS value , name FROM accesses WHERE deep = 1 AND situation = 1  AND parent_id = {home_id}", select_part);
            select_part.AutoCompleteMode = AutoCompleteMode.Suggest;
            select_part.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void FillSelectBtn()
        {
            if (select_part.Items.Count <= 0 || !int.TryParse(Convert.ToString(select_part.SelectedValue), out int part_id) || part_id <= 0)
                return;

            string part_id_ = Convert.ToString(part_id);
            Classes.Helper.DB.FILL_SELECT($"SELECT id AS value , name FROM accesses WHERE deep = 2 AND situation = 1  AND parent_id = {part_id_} AND id NOT IN (SELECT access_id FROM person_accesses WHERE person_id = {person_id})", select_btn);
            select_btn.AutoCompleteMode = AutoCompleteMode.Suggest;
            select_btn.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
