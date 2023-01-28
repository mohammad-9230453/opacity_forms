using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace opacity_forms.Boxes.windows.helper
{
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
        }
        enum situation
        {
            copy,
            cut,
            non,
        }
        situation copy_sit = situation.non;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void attributes_table_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Classes.Helper.Function.sizeDGV((sender as DataGridView));
        }
        int cat_id = 0;
        int catIdForEdit;
        private void cat_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cat_name.Text.Trim().Length == 0)
                {
                    alert.alert("مقدار نمیتواند خالی باشد", Alert.Right_side.enmType.error);
                    return;
                }
                if (btn_cancel_cat.Visible)
                {

                    Classes.Helper.DB.SQL_QUERY($"UPDATE category SET name='{cat_name.Text}' WHERE id = {catIdForEdit}", has_alert: false);
                    FillCategoriesTable();//categoriesLoad();
                    btn_cancel_cat.Visible = false;
                    cat_name.Text = null;

                    Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
                    _Home.headersLoad();

                }
                else
                {
                    Classes.Helper.DB.SQL_QUERY($"INSERT INTO category(name,person_id,last_id,deep) VALUES('{cat_name.Text}',{Classes.global_inf.user_id},{cat_id},{deep})", has_alert: false);
                    FillCategoriesTable();// categoriesLoad();
                    cat_name.Text = null;
                }

                //MessageBox.Show("category");

            }
        }
        private void FillCategoriesTable()
        {
            this.table_categories.DataSource = Classes.Helper.DB.GET_DATA_TABLE($"SELECT id,name FROM category WHERE last_id = '{cat_id}' AND person_id = '{Classes.global_inf.user_id}' ;");
            this.table_categories.Columns["id"].Visible = false;
        }
        private void create_new_attribute(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_att_name.Text.Trim().Length == 0 || txt_att_text.Text.Trim().Length == 0)
                {
                    alert.shortAlert("مقادیر نمیتوانند خالی باشند", Alert.topShort.enmtype.error);
                    return;
                }
                if (btn_cancel.Visible == true)
                {
                    //MessageBox.Show("attribute_edit");
                    Classes.Helper.DB.SQL_QUERY($"UPDATE attributes SET name = '{txt_att_name.Text}' , text='{txt_att_text.Text}' WHERE id={att_id}");
                    btn_cancel.Visible = false;
                    FillAttTable();

                }
                else
                {
                    //MessageBox.Show("attribute_create");
                    if (cat_id == 0)
                    {
                        alert.shortAlert("در صفحه اصلی قادر به ایجاد مشخصات نمیباشید", Alert.topShort.enmtype.error);
                    }
                    else
                    {
                        Classes.Helper.DB.SQL_QUERY($"INSERT INTO attributes (name,text,cat_id) VALUES ('{txt_att_name.Text}','{txt_att_text.Text}',{cat_id})");
                        FillAttTable();

                    }
                }
                txt_att_text.Text = txt_att_name.Text = null;


            }
        }
        private void FillAttTable()
        {
            if (cat_id == 0)
            {
                attributes_table.DataSource = null;
            }
            else
            {
                attributes_table.DataSource = Classes.Helper.DB.GET_DATA_TABLE($"SELECT id , name AS 'نام' , text AS 'توضیحات' FROM attributes WHERE cat_id={cat_id}");
                attributes_table.Columns["id"].Visible = false;
            }
        }

        private void Categories_Load(object sender, EventArgs e)
        {

            this.BackColor = Color.FromArgb(90, Color.Black);
            label7.BackColor = label9.BackColor = label1.BackColor = Color.FromArgb(70, Color.Black);
            panel1.BackColor = panel2.BackColor = panel3.BackColor = Color.FromArgb(70, Color.Black);
            panel4.BackColor = panel7.BackColor = panel6.BackColor = Color.FromArgb(70, Color.Black);
            pnl_headers.BackColor = pnl_categories.BackColor = Color.FromArgb(70, Color.Black);

            btnDelete.BackColor = Color.FromArgb(60, 62, 10, 10);
            btnEdit.BackColor = Color.FromArgb(60, 229, 114, 0);
            btnEnter.BackColor = Color.FromArgb(60, 74, 102, 155);
            btnSelect.BackColor = Color.FromArgb(60, 71, 137, 106);


            FillCategoriesTable();//categoriesLoad();


            headersLoad();

            btn_back.BackColor = Color.FromArgb(60, 74, 102, 155);
            btn_cancel.BackColor = Color.FromArgb(60, 62, 10, 10);
            btn_cancel_cat.BackColor = Color.FromArgb(60, 62, 10, 10);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as Button).Name);
            Classes.global_inf.cat_id = int.Parse((sender as Button).Name.Split('_')[1]);
            Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
            _Home.date2.Set_Year();
            _Home.headersLoad();
            alert.alert("دسته بندی با موفقیت انتخاب شد", Alert.Right_side.enmType.success);

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as Button).Name);
            cat_id = int.Parse((sender as Button).Name.Split('_')[1]);
            deep = Classes.Helper.DB.GET_INT($"SELECT deep FROM category WHERE id = {cat_id}");
            FillCategoriesTable();//categoriesLoad();
            headersLoad();
            FillAttTable();

        }
        bool is_selected = false;
        private void btnDelete_Click(object sender, EventArgs e)
        {

            //  MessageBox.Show((sender as Button).Name);
            deleteCategory(int.Parse((sender as Button).Name.Split('_')[1]));
            FillCategoriesTable();//categoriesLoad();
            if (is_selected)
            {
                Classes.global_inf.cat_id = 0;
                Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
                _Home.date2.Set_Year();
                _Home.headersLoad();
            }
            is_selected = false;

        }
        private void deleteCategory(int id)
        {
            if (Classes.global_inf.cat_id == id) is_selected = true;
            DataTable data = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM category WHERE last_id = {id} AND person_id={Classes.global_inf.user_id}");
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    deleteCategory(int.Parse(data.Rows[i]["id"].ToString()));
                }
            }
            Classes.Helper.DB.SQL_QUERY($"DELETE FROM attributes WHERE cat_id={id}; DELETE FROM messages WHERE cat_id={id}; DELETE FROM category WHERE id={id};", has_alert: false);
        }
        Boxes.Alert.Alert alert = new Alert.Alert();
        private void btnEdit_Click(object sender, EventArgs e)
        {
            TextBox tbx = this.Controls.Find($"catName_{(sender as Button).Name.Split('_')[1]}", true).FirstOrDefault() as TextBox;
            if (tbx != null)
            {
                Classes.Helper.DB.SQL_QUERY($"UPDATE category SET name='{tbx.Text}' WHERE id = {(sender as Button).Name.Split('_')[1]}");
                FillCategoriesTable();//categoriesLoad();

                Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
                _Home.headersLoad();
            }
            else
            {
                alert.alert("مقدار نمیتواند خالی باشد", Alert.Right_side.enmType.error);
            }
            //MessageBox.Show((sender as Button).Name);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_cancel.Visible = false;
            txt_att_name.Text = txt_att_text.Text = null;
            //MessageBox.Show("btn_cancel_Click");

        }

        private void lblHead_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as Label).Name);
            cat_id = int.Parse((sender as Label).Name.Split('_')[1]);
            deep = cat_id == 0 ? 0 : Classes.Helper.DB.GET_INT($"SELECT deep FROM category WHERE id = {cat_id}");
            FillCategoriesTable();//categoriesLoad();
            headersLoad();
            FillAttTable();


        }
        string cat_name_, cat_id_;
        private void categoriesLoad()
        {
            pnl_categories.Controls.Clear();
            DataTable data = Classes.Helper.DB.GET_DATA_TABLE($"SELECT id,name FROM category WHERE last_id = '{cat_id}' AND person_id = '{Classes.global_inf.user_id}' ;");
            if (data.Rows.Count > 0)
            {

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    cat_name_ = data.Rows[i]["name"].ToString();
                    createNewCategory(data.Rows[i]["id"].ToString());
                }
            }
        }
        private void attributesLoad()
        {

        }
        private void headersLoad()
        {
            pnl_headers.Controls.Clear();
            DataTable data;
            int id = cat_id;
            if (cat_id != 0)
            {
                while (true)
                {
                    data = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM category WHERE id={id}");
                    cat_name_ = data.Rows[0]["name"].ToString();
                    if (cat_id == id) createNewHeader(id.ToString(), true);
                    else createNewHeader(id.ToString(), false);
                    id = int.Parse(data.Rows[0]["last_id"].ToString());
                    if (id == 0) break;
                }
            }
            cat_name_ = "صفحه اصلی";
            if (cat_id == 0) createNewHeader("0", true);
            else createNewHeader("0", false);
        }
        private void createNewHeader(string id, bool is_last_one = false)
        {
            this.lblSlash = new System.Windows.Forms.Label();
            this.lblHead = new System.Windows.Forms.Label();
            // 
            // pnl_headers
            // 
            if (!is_last_one) this.pnl_headers.Controls.Add(this.lblSlash);
            this.pnl_headers.Controls.Add(this.lblHead);
            // 
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSlash.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSlash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSlash.Location = new System.Drawing.Point(801, 0);
            this.lblSlash.Name = $"lblSlash_{id}";
            this.lblSlash.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblSlash.Size = new System.Drawing.Size(14, 23);
            this.lblSlash.TabIndex = 0;
            this.lblSlash.Text = "/";
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            if (!is_last_one) this.lblHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHead.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHead.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            if (is_last_one) this.lblHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(255)))), ((int)(((byte)(193)))));
            this.lblHead.Location = new System.Drawing.Point(815, 0);
            this.lblHead.Name = $"lblHead_{id}";
            this.lblHead.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblHead.Size = new System.Drawing.Size(92, 23);
            this.lblHead.TabIndex = 0;
            this.lblHead.Text = cat_name_;
            if (!is_last_one) this.lblHead.Click += new System.EventHandler(this.lblHead_Click);
        }
        int deep = 0;
        private void btn_back_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("btn_back_Click");
            if (cat_id == 0) return;
            cat_id = Classes.Helper.DB.GET_INT($"SELECT last_id FROM category WHERE id = {cat_id}");
            deep = cat_id == 0 ? 0 : Classes.Helper.DB.GET_INT($"SELECT deep FROM category WHERE id = {cat_id}");
            FillCategoriesTable();//categoriesLoad();
            headersLoad();
            FillAttTable();

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("مطمعنید که میخاهید این مورد را حذف کنید", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes && eve != null)
            {
                Classes.Helper.DB.SQL_QUERY($"DELETE FROM attributes WHERE id={attributes_table.Rows[eve.RowIndex].Cells["id"].Value.ToString()}");
                FillAttTable();
            }
        }
        DataGridViewCellMouseEventArgs eve;
        private void attributes_table_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            eve = e;
            attCMS.Enabled = true;
            if (e.RowIndex < 0 || e == null) attCMS.Enabled = false;
        }
        int att_id;
        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eve == null) return;
            att_id = int.Parse(attributes_table.Rows[eve.RowIndex].Cells["id"].Value.ToString());
            btn_cancel.Visible = true;
            txt_att_name.Text = attributes_table.Rows[eve.RowIndex].Cells["نام"].Value.ToString();
            txt_att_text.Text = attributes_table.Rows[eve.RowIndex].Cells["توضیحات"].Value.ToString();
        }

        private void table_categories_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cat_id = int.Parse(this.table_categories.Rows[e.RowIndex].Cells["id"].Value.ToString());
            deep = Classes.Helper.DB.GET_INT($"SELECT deep FROM category WHERE id = {cat_id}");
            FillCategoriesTable();//categoriesLoad();
            headersLoad();
            FillAttTable();
        }
        DataGridViewCellMouseEventArgs cat_eve;
        private void table_categories_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            categoriesCMS.Enabled = true;
            if (e == null || e.RowIndex < 0) categoriesCMS.Enabled = false;
            cat_eve = e;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteCategory(int.Parse(this.table_categories.Rows[cat_eve.RowIndex].Cells["id"].Value.ToString()));
            FillCategoriesTable();//categoriesLoad();
            if (is_selected)
            {
                Classes.global_inf.cat_id = 0;
                Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
                _Home.date2.Set_Year();
                _Home.headersLoad();
            }
            is_selected = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Classes.global_inf.cat_id = int.Parse(this.table_categories.Rows[cat_eve.RowIndex].Cells["id"].Value.ToString());
            Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
            _Home.date2.Set_Year();
            _Home.headersLoad();
            alert.alert("دسته بندی با موفقیت انتخاب شد", Alert.Right_side.enmType.success);
        }

        private void btn_cancel_cat_Click(object sender, EventArgs e)
        {
            cat_name.Text = null;
            btn_cancel_cat.Visible = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.btn_cancel_cat.Visible = true;
            this.cat_name.Text = this.table_categories.Rows[cat_eve.RowIndex].Cells["name"].Value.ToString();
            catIdForEdit = int.Parse(this.table_categories.Rows[cat_eve.RowIndex].Cells["id"].Value.ToString());
        }

        private void table_categories_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Back)
            {
                if (cat_id == 0) return;
                cat_id = Classes.Helper.DB.GET_INT($"SELECT last_id FROM category WHERE id = {cat_id}");
                deep = cat_id == 0 ? 0 : Classes.Helper.DB.GET_INT($"SELECT deep FROM category WHERE id = {cat_id}");
                FillCategoriesTable();//categoriesLoad();
                headersLoad();
                FillAttTable();
            }
            if (table_categories.SelectedCells.Count < 1) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("آیا میخواهید این مورد را حذف کنید؟", "حذف", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    deleteCategory(int.Parse(this.table_categories.Rows[table_categories.SelectedCells[0].RowIndex].Cells["id"].Value.ToString()));
                    FillCategoriesTable();//categoriesLoad();
                    if (is_selected)
                    {
                        Classes.global_inf.cat_id = 0;
                        Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
                        _Home.date2.Set_Year();
                        _Home.headersLoad();
                    }
                    is_selected = false;
                }
            }
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                Classes.global_inf.cat_id = int.Parse(this.table_categories.Rows[table_categories.SelectedCells[0].RowIndex].Cells["id"].Value.ToString());
                Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;

                //if (_Home.date2.Visible)
                    _Home.date2.Set_Year();
                //else { _Home.date2.Visible = true; _Home.date2.Set_Year();  _Home.enDates1.Visible = false; }

                //if (_Home.enDates1.Visible)
                    _Home.enDates1.Set_Year();
                //else { _Home.enDates1.Visible = true; _Home.enDates1.Set_Year();  _Home.enDates1.Visible = false; }

                _Home.headersLoad();
                //alert.alert("دسته بندی با موفقیت انتخاب شد", Alert.Right_side.enmType.success);
            }
            if (e.KeyCode == Keys.Enter && !e.Control)
            {
                catSelectedRowIndex = table_categories.SelectedCells[0].RowIndex;
                cat_id = int.Parse(this.table_categories.Rows[catSelectedRowIndex].Cells["id"].Value.ToString());
                deep = Classes.Helper.DB.GET_INT($"SELECT deep FROM category WHERE id = {cat_id}");
                FillCategoriesTable();//categoriesLoad();
                headersLoad();
                FillAttTable();
            }
            if (e.KeyCode == Keys.F2)
            {
                this.btn_cancel_cat.Visible = true;
                this.cat_name.Text = this.table_categories.Rows[table_categories.SelectedCells[0].RowIndex].Cells["name"].Value.ToString();
                catIdForEdit = int.Parse(this.table_categories.Rows[table_categories.SelectedCells[0].RowIndex].Cells["id"].Value.ToString());
            }
            if (e.KeyCode == Keys.X && e.Control)
            {
                copy_sit = situation.cut;
                copy_id = int.Parse(this.table_categories.Rows[table_categories.SelectedCells[0].RowIndex].Cells["id"].Value.ToString());
            }
            if (e.KeyCode == Keys.V && e.Control)
            {
                cut();
            }
        }
        int copy_id;
        int catSelectedRowIndex = 0;
        public void cut()
        {
            Classes.Helper.DB.SQL_QUERY($"UPDATE category SET last_id={cat_id} WHERE id = {copy_id}");
            FillCategoriesTable();//categoriesLoad();
        }
        private void table_categories_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void attributes_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e!=null && e.RowIndex > -1)
            {
                string s = this.attributes_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Clipboard.SetText(s);
                alert.shortAlert($"کپی شد  {s}", Alert.topShort.enmtype.success);
            }
        }

        private void createNewCategory(string id)
        {
            this.catPanel = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.catName = new System.Windows.Forms.TextBox();

            this.catPanel.SuspendLayout();

            this.pnl_categories.Controls.Add(this.catPanel);

            // 
            // catPanel
            // 
            this.catPanel.Controls.Add(this.btnEnter);
            this.catPanel.Controls.Add(this.btnSelect);
            this.catPanel.Controls.Add(this.btnEdit);
            this.catPanel.Controls.Add(this.btnDelete);
            this.catPanel.Controls.Add(this.catName);
            this.catPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.catPanel.Location = new System.Drawing.Point(0, 0);
            this.catPanel.Name = $"catPanel_{id}";
            this.catPanel.Size = new System.Drawing.Size(299, 76);
            this.catPanel.TabIndex = 2;
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.btnEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("MV Boli", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Image = global::opacity_forms.Properties.Resources.enter_16;
            this.btnEnter.Location = new System.Drawing.Point(37, 42);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnter.Name = $"btnEnter_{id}";
            this.btnEnter.Size = new System.Drawing.Size(24, 21);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("MV Boli", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Image = global::opacity_forms.Properties.Resources.select_16;
            this.btnSelect.Location = new System.Drawing.Point(105, 42);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = $"btnSelect_{id}";
            this.btnSelect.Size = new System.Drawing.Size(24, 21);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("MV Boli", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::opacity_forms.Properties.Resources.edit24;
            this.btnEdit.Location = new System.Drawing.Point(166, 42);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = $"btnEdit_{id}";
            this.btnEdit.Size = new System.Drawing.Size(27, 21);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("MV Boli", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::opacity_forms.Properties.Resources.close__24_;
            this.btnDelete.Location = new System.Drawing.Point(235, 42);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = $"btnDelete_{id}";
            this.btnDelete.Size = new System.Drawing.Size(27, 21);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // catName
            // 
            this.catName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.catName.BackColor = System.Drawing.Color.Black;
            this.catName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.catName.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.catName.ForeColor = System.Drawing.Color.White;
            this.catName.Location = new System.Drawing.Point(23, 12);
            this.catName.Name = $"catName_{id}";
            this.catName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.catName.Size = new System.Drawing.Size(249, 30);
            this.catName.Text = cat_name_;
            this.catName.TabIndex = 1;


            btnDelete.BackColor = Color.FromArgb(60, 62, 10, 10);
            btnEdit.BackColor = Color.FromArgb(60, 229, 114, 0);
            btnEnter.BackColor = Color.FromArgb(60, 74, 102, 155);
            btnSelect.BackColor = Color.FromArgb(60, 71, 137, 106);
        }


    }
}
