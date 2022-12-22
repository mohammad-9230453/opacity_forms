using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Forms.messege
{
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
            pnl_header.BackColor = Color.FromArgb(150, Color.DimGray);
            pnl_form.BackColor = Color.FromArgb(150, Color.Black);
            pnl_logo.BackColor = Color.FromArgb(30, Color.Black);
            lbl_software_bank.BackColor = Color.FromArgb(0, Color.Black);
            lbl_head.BackColor = Color.FromArgb(0, Color.Black);
            label1.BackColor = Color.FromArgb(0, Color.Black);
            select_every_week.BackColor = Color.FromArgb(0, Color.Black);
            select_every_month.BackColor = Color.FromArgb(0, Color.Black);
            select_every_year.BackColor = Color.FromArgb(0, Color.Black);
            btn_exit.BackColor = Color.FromArgb(165, 62, 10, 10);
            btn_add.BackColor = Color.FromArgb(90, Color.DarkGreen);
            btn_cancel.BackColor = Color.FromArgb(90, 62, 10, 10);




            btnDelete.BackColor = Color.FromArgb(130, 62, 10, 10);
            btnEdit.BackColor = Color.FromArgb(130, 87, 8, 137);
            pnlBox.BackColor = Color.FromArgb(90, Color.Black);

            label2.BackColor = Color.FromArgb(0, Color.Black);
            label3.BackColor = Color.FromArgb(0, Color.Black);
            select_hasEnd.BackColor = Color.FromArgb(0, Color.Black);
            panel1.BackColor = Color.FromArgb(0, Color.Black);
            label7.BackColor = Color.FromArgb(0, Color.Black);
            lbl_day.BackColor = Color.FromArgb(0, Color.Black);
            lbl_month.BackColor = Color.FromArgb(0, Color.Black);
            lbl_week.BackColor = Color.FromArgb(0, Color.Black);
            lbl_year.BackColor = Color.FromArgb(0, Color.Black);


            lblHasEnd.BackColor = Color.FromArgb(0, Color.Black);
            selectHasEnd.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryMonth.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryWeek.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryYear.BackColor = Color.FromArgb(0, Color.Black);
            select_everyDay.BackColor = Color.FromArgb(0, Color.Black);


        }
        public string FarsiOrEn = null;
        Boxes.Alert.Alert alert = new Alert.Alert();
        List<Classes.model.test> tests = new List<Classes.model.test>();
        //List<Classes.model.messages> messages = new List<Classes.model.messages>();
        string msg, end_date, makeDate_, id;
        bool evry_week, evry_day, evry_month, evry_year, has_end;
        private void setPnlBoxBoxes()
        {
            string[] arr;
            this.pnl_list.Controls.Clear();
            DataTable dt = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM {FarsiOrEn}messages WHERE (Y=-1 OR Y={Y})AND(M=-1 OR M={M})AND((D=-1) OR (D={D} AND W=-1)OR(W={W} AND D!=-1))AND(has_end=0 OR (has_end=1 AND end_date>='{date.Year.ToString()}/{date.Month.ToString()}/{date.Day.ToString()}' AND date<='{date.Year.ToString()}/{date.Month.ToString()}/{date.Day.ToString()}')) AND cat_id={Classes.global_inf.cat_id}");
            if (dt.Rows.Count > 0)
            {
                if(FarsiOrEn != "en")Classes.Helper.Function.FIX_DT_DATE(dt, new[] { "date", "end_date" });
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id = dt.Rows[i]["id"].ToString();
                    end_date = dt.Rows[i]["end_date"].ToString();
                    makeDate_ = dt.Rows[i]["date"].ToString();
                    if (FarsiOrEn == "en") 
                    {
                        arr = dt.Rows[i]["end_date"].ToString().Split(' ')[0].Split('/');
                        end_date = $"{arr[2]}/{arr[0]}/{arr[1]}";
                        arr = dt.Rows[i]["date"].ToString().Split(' ')[0].Split('/');
                        makeDate_ = $"{arr[2]}/{arr[0]}/{arr[1]}";
                    }
                    msg = dt.Rows[i]["msg"].ToString();
                    evry_week = dt.Rows[i]["W"].ToString().Trim() != "-1";
                    evry_day = dt.Rows[i]["D"].ToString().Trim() == "-1";
                    evry_month = dt.Rows[i]["M"].ToString().Trim() == "-1";
                    evry_year = dt.Rows[i]["Y"].ToString().Trim() == "-1";
                    has_end = dt.Rows[i]["has_end"].ToString().Trim() == "1";
                    setNewBOX();
                }
            }

            Dashboard _Home = Application.OpenForms["Dashboard"] as Dashboard;
            if (FarsiOrEn == "en")
                _Home.enDates1.Set_Year();
            else
                _Home.date2.Set_Year();
        }
        private void setNewBOX()
        {
            this.pnlBox = new System.Windows.Forms.Panel();
            this.selectEveryYear = new System.Windows.Forms.CheckBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.selectEveryWeek = new System.Windows.Forms.CheckBox();
            this.selectEveryMonth = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.lblHasEnd = new System.Windows.Forms.Label();
            this.makeDate = new System.Windows.Forms.Label();
            this.selectHasEnd = new System.Windows.Forms.CheckBox();
            this.selectEveryDay = new System.Windows.Forms.CheckBox();
            this.pnlBox.SuspendLayout();

            this.pnl_list.Controls.Add(this.pnlBox);

            // 
            // pnlBox
            // 
            this.pnlBox.AutoScroll = true;
            this.pnlBox.BackColor = System.Drawing.Color.Black;
            this.pnlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBox.Controls.Add(this.txtEndDate);
            this.pnlBox.Controls.Add(this.selectEveryYear);
            this.pnlBox.Controls.Add(this.txtMsg);
            this.pnlBox.Controls.Add(this.btnDelete);
            this.pnlBox.Controls.Add(this.selectEveryWeek);
            this.pnlBox.Controls.Add(this.selectHasEnd);
            this.pnlBox.Controls.Add(this.selectEveryDay);
            this.pnlBox.Controls.Add(this.selectEveryMonth);
            this.pnlBox.Controls.Add(this.btnEdit);
            this.pnlBox.Controls.Add(this.lblHasEnd);
            this.pnlBox.Controls.Add(this.makeDate);
            this.pnlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBox.Location = new System.Drawing.Point(0, 0);
            this.pnlBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pnlBox.Name = $"pnlBox_{id}";
            this.pnlBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBox.Size = new System.Drawing.Size(525, 153);
            this.pnlBox.TabIndex = 0;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEndDate.Enabled = has_end;
            this.txtEndDate.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEndDate.ForeColor = System.Drawing.Color.White;
            this.txtEndDate.Location = new System.Drawing.Point(194, 119);
            this.txtEndDate.Name = $"txtEndDate_{id}";
            this.txtEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEndDate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEndDate.Size = new System.Drawing.Size(180, 23);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.Text = has_end ? end_date : null;
            // 
            // selectEveryYear
            // 
            this.selectEveryYear.AutoSize = true;
            this.selectEveryYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectEveryYear.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectEveryYear.ForeColor = System.Drawing.Color.White;
            this.selectEveryYear.Location = new System.Drawing.Point(272, 82);
            this.selectEveryYear.Name = $"selectEveryYear_{id}";
            this.selectEveryYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectEveryYear.Size = new System.Drawing.Size(60, 27);
            this.selectEveryYear.TabIndex = 8;
            this.selectEveryYear.Text = "هر سال";
            this.selectEveryYear.UseVisualStyleBackColor = true;
            this.selectEveryYear.Checked = evry_year;
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsg.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtMsg.ForeColor = System.Drawing.Color.White;
            this.txtMsg.Location = new System.Drawing.Point(15, 7);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = $"txtMsg_{id}";
            this.txtMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(477, 72);
            this.txtMsg.TabIndex = 3;
            this.txtMsg.Text = msg;
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
            this.btnDelete.Location = new System.Drawing.Point(493, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = $"btnDelete_{id}";
            this.btnDelete.Size = new System.Drawing.Size(26, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // selectEveryWeek
            // 
            this.selectEveryWeek.AutoSize = true;
            this.selectEveryWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectEveryWeek.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectEveryWeek.ForeColor = System.Drawing.Color.White;
            this.selectEveryWeek.Location = new System.Drawing.Point(390, 82);
            this.selectEveryWeek.Name = $"selectEveryWeek_{id}";
            this.selectEveryWeek.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectEveryWeek.Size = new System.Drawing.Size(61, 27);
            this.selectEveryWeek.TabIndex = 8;
            this.selectEveryWeek.Text = "هر هفته";
            this.selectEveryWeek.UseVisualStyleBackColor = true;
            this.selectEveryWeek.Checked = evry_week;
            // 
            // selectHasEnd
            // 
            this.selectHasEnd.AutoSize = true;
            this.selectHasEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectHasEnd.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectHasEnd.ForeColor = System.Drawing.Color.White;
            this.selectHasEnd.Location = new System.Drawing.Point(376, 117);
            this.selectHasEnd.Name = $"selectHasEnd_{id}";
            this.selectHasEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectHasEnd.Size = new System.Drawing.Size(47, 27);
            this.selectHasEnd.TabIndex = 8;
            this.selectHasEnd.Text = "دارد";
            this.selectHasEnd.UseVisualStyleBackColor = true;
            this.selectHasEnd.CheckedChanged += new System.EventHandler(this.selectHasEnd_CheckedChanged);
            this.selectHasEnd.Checked = has_end;
            // 
            // selectEveryMonth
            // 
            this.selectEveryMonth.AutoSize = true;
            this.selectEveryMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectEveryMonth.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectEveryMonth.ForeColor = System.Drawing.Color.White;
            this.selectEveryMonth.Location = new System.Drawing.Point(330, 82);
            this.selectEveryMonth.Name = $"selectEveryMonth_{id}";
            this.selectEveryMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectEveryMonth.Size = new System.Drawing.Size(56, 27);
            this.selectEveryMonth.TabIndex = 8;
            this.selectEveryMonth.Text = "هر ماه";
            this.selectEveryMonth.UseVisualStyleBackColor = true;
            this.selectEveryMonth.Checked = evry_month;
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
            this.btnEdit.Location = new System.Drawing.Point(493, 35);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = $"btnEdit_{id}";
            this.btnEdit.Size = new System.Drawing.Size(26, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblHasEnd
            // 
            this.lblHasEnd.AutoSize = true;
            this.lblHasEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHasEnd.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHasEnd.ForeColor = System.Drawing.Color.White;
            this.lblHasEnd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblHasEnd.Location = new System.Drawing.Point(425, 114);
            this.lblHasEnd.Margin = new System.Windows.Forms.Padding(0);
            this.lblHasEnd.Name = $"lblHasEnd_{id}";
            this.lblHasEnd.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblHasEnd.Size = new System.Drawing.Size(67, 27);
            this.lblHasEnd.TabIndex = 7;
            this.lblHasEnd.Text = ": تاریخ پایان";
            // 
            // selectEveryDay
            // 
            this.selectEveryDay.AutoSize = true;
            this.selectEveryDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectEveryDay.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectEveryDay.ForeColor = System.Drawing.Color.White;
            this.selectEveryDay.Location = new System.Drawing.Point(447, 82);
            this.selectEveryDay.Name = $"selectEveryDay_{id}";
            this.selectEveryDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectEveryDay.Size = new System.Drawing.Size(59, 27);
            this.selectEveryDay.TabIndex = 8;
            this.selectEveryDay.Text = "هر روز";
            this.selectEveryDay.UseVisualStyleBackColor = true;
            this.selectEveryDay.Checked = evry_day;
            // 
            // makeDate
            // 
            this.makeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.makeDate.AutoSize = true;
            this.makeDate.Font = new System.Drawing.Font("B Titr", 8.9F, System.Drawing.FontStyle.Bold);
            this.makeDate.ForeColor = System.Drawing.Color.White;
            this.makeDate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.makeDate.Location = new System.Drawing.Point(13, 78);
            this.makeDate.Name = $"makeDate_{id}";
            this.makeDate.Size = new System.Drawing.Size(68, 21);
            this.makeDate.TabIndex = 4;
            this.makeDate.Text = makeDate_;



            this.pnlBox.ResumeLayout(false);
            this.pnlBox.PerformLayout();

            btnDelete.BackColor = Color.FromArgb(60, 62, 10, 10);
            btnEdit.BackColor = Color.FromArgb(60, 229, 114, 0);
            pnlBox.BackColor = Color.FromArgb(90, Color.Black);


            lblHasEnd.BackColor = Color.FromArgb(0, Color.Black);
            selectHasEnd.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryMonth.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryWeek.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryYear.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryDay.BackColor = Color.FromArgb(0, Color.Black);
            makeDate.BackColor = Color.FromArgb(0, Color.Black);
        }


        private Point MouseDownLocation;

        private void MOVE_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void MOVE_MouseMove(object sender, MouseEventArgs e)
        {
            int x, y;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = this.Left + (e.X - MouseDownLocation.X);
                this.Top = this.Top + (e.Y - MouseDownLocation.Y);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void select_hasEnd_CheckedChanged(object sender, EventArgs e)
        {
            txt_endDate.Text = null;
            txt_endDate.Enabled = select_hasEnd.Checked;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string msg_, W_, D_, M_, Y_, has_end_, end_date_, date_;
            bool flag , is_en = FarsiOrEn == "en";
            DateTime dateTime = DateTime.UtcNow.ToLocalTime();
            string[] end_arr; int i, j, k;
            if (txt_msg.Text.Length == 0 || txt_msg.Text.Length > 500)
            {
                alert.shortAlert("پیام وارد شده نباید خالی یا بیش از 500 کاراکتر باشد", Alert.topShort.enmtype.error);
                return;
            }
            has_end_ = select_hasEnd.Checked ? "1" : "0";
            end_arr = txt_endDate.Text.Split('/');
            flag = false;
            PersianCalendar pc = new PersianCalendar();
            if (select_hasEnd.Checked)
            {
                if (end_arr.Length == 3)
                {
                    if (end_arr[0].Length == 4 && int.TryParse(end_arr[0], out i) && i > 0 &&
                        (end_arr[1].Length == 1 || end_arr[1].Length == 2) && int.TryParse(end_arr[1], out i) && i > 0 && i <= 12 &&
                        (end_arr[2].Length == 1 || end_arr[2].Length == 2) && int.TryParse(end_arr[2], out i) && i > 0)
                    {
                        if (int.Parse(end_arr[2]) <= pc.GetDaysInMonth(int.Parse(end_arr[0]), int.Parse(end_arr[1])))
                        {
                            if ( !is_en &&  (new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]), (new PersianCalendar()))) >= date) flag = true;
                            if ( is_en &&  (new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]))) >= date) flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    alert.shortAlert("ورودی تاریخ را درست وارد کنید", Alert.topShort.enmtype.error);
                    return;
                }
                dateTime = new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]), (new PersianCalendar()));
                if (is_en) dateTime = new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]));
            }

            if (select_everyDay.Checked)
            {
                select_every_month.Checked = true;
                if (flag) { if (pc.GetYear(dateTime) > pc.GetYear(date)) select_every_year.Checked = true; }
                else select_every_year.Checked = true;
            }
            msg_ = txt_msg.Text;
            W_ = select_every_week.Checked ? W : "-1";
            D_ = select_everyDay.Checked ? "-1" : D;
            M_ = select_every_month.Checked ? "-1" : M;
            Y_ = select_every_year.Checked ? "-1" : Y;
            end_date_ = flag ?
                $"{dateTime.Year}/{dateTime.Month}/{dateTime.Day}"
                : $"{DateTime.UtcNow.Year}/{DateTime.UtcNow.Month}/{DateTime.UtcNow.Day}";
            date_ = $"{date.Year}/{date.Month}/{date.Day}";
            if (Classes.global_inf.cat_id == 0)
            {
                alert.shortAlert("شما هنوز دسته بندی ای را انتخاب نکرده اید", Alert.topShort.enmtype.error);
                return;
            }
            Classes.Helper.DB.SQL_QUERY($"INSERT INTO {FarsiOrEn}messages (Y,M,D,W,has_end,end_date,date,msg,cat_id)" +
                                                        $"VALUES({Y_},{M_},{D_},{W_},{has_end_},'{end_date_}','{date_}','{msg_}',{Classes.global_inf.cat_id})");
            setPnlBoxBoxes();
            txt_msg.Text = txt_endDate.Text = null;
            select_everyDay.Checked = select_every_month.Checked = select_every_year.Checked = select_hasEnd.Checked = select_every_week.Checked = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as Button).Name.Split('_')[1]);
            var id = (sender as Button).Name.Split('_')[1];
            //var item = this.Controls.Find($"pnlBox_{id}", true)[0] as Panel;
            //pnl_list.Controls.Remove(item);
            if (MessageBox.Show("مطمعن هستین که میخایید این فیلد رو حذف کنید؟", "حذف", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Classes.Helper.DB.SQL_QUERY($"DELETE FROM {FarsiOrEn}messages  WHERE id={id}");
                setPnlBoxBoxes();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string msg_, W_, D_, M_, Y_, has_end_, end_date_, date_, id_ = (sender as Button).Name.Split('_')[1];
            string[] end_arr; int i, j, k;
            bool flag , is_en = FarsiOrEn == "en";
            DateTime dateTime = DateTime.UtcNow.ToLocalTime();
            string str_date = Classes.Helper.DB.GET_STR($"SELECT date FROM {FarsiOrEn}messages WHERE id={id_}", "date");
            PersianCalendar pc = new PersianCalendar();
            DateTime _date = DateTime.Parse(str_date.Split(' ')[0],
                      System.Globalization.CultureInfo.InvariantCulture);
            if (txt_msg.Text.Length == 0 || txt_msg.Text.Length > 500)
            {
                alert.shortAlert("پیام وارد شده نباید خالی یا بیش از 500 کاراکتر باشد", Alert.topShort.enmtype.error);
                return;
            }
            var txtMsg_ = this.Controls.Find($"txtMsg_{id}", true)[0] as TextBox;
            var selectEveryWeek_ = this.Controls.Find($"selectEveryWeek_{id}", true)[0] as CheckBox;
            var selectEveryDay_ = this.Controls.Find($"selectEveryDay_{id}", true)[0] as CheckBox;
            var selectEveryMonth_ = this.Controls.Find($"selectEveryMonth_{id}", true)[0] as CheckBox;
            var selectEveryYear_ = this.Controls.Find($"selectEveryYear_{id}", true)[0] as CheckBox;
            var selectHasEnd_ = this.Controls.Find($"selectHasEnd_{id}", true)[0] as CheckBox;
            var txtEndDate_ = this.Controls.Find($"txtEndDate_{id}", true)[0] as TextBox;
            msg_ = txtMsg_.Text;
            W_ = selectEveryWeek_.Checked ? W : "-1";
            D_ = selectEveryDay_.Checked ? "-1" : D;
            M_ = selectEveryMonth_.Checked ? "-1" : M;
            Y_ = selectEveryYear_.Checked ? "-1" : Y;
            has_end_ = selectHasEnd_.Checked ? "1" : "0";
            end_arr = txtEndDate_.Text.Split('/');
            flag = false;
            if (selectHasEnd_.Checked)
            {
                if (end_arr.Length == 3)
                {
                    if (end_arr[0].Length == 4 && int.TryParse(end_arr[0], out i) && i > 0 &&
                        (end_arr[1].Length == 1 || end_arr[1].Length == 2) && int.TryParse(end_arr[1], out i) && i > 0 && i <= 12 &&
                        (end_arr[2].Length == 1 || end_arr[2].Length == 2) && int.TryParse(end_arr[2], out i) && i > 0)
                    {
                        if (int.Parse(end_arr[2]) <= pc.GetDaysInMonth(int.Parse(end_arr[0]), int.Parse(end_arr[1])))
                        {
                            if (!is_en && (new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]), (new PersianCalendar()))) >= date) flag = true;
                        }   if ( is_en &&  (new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]))) >= date) flag = true;
                    }
                }
                if (!flag)
                {
                    alert.shortAlert("ورودی تاریخ را درست وارد کنید", Alert.topShort.enmtype.error);
                    return;
                }
                dateTime = new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]), (new PersianCalendar()));
                if (is_en) dateTime = new DateTime(int.Parse(end_arr[0]), int.Parse(end_arr[1]), int.Parse(end_arr[2]));
            }

            if (selectEveryDay_.Checked)
            {
                selectEveryMonth_.Checked = true;
                if (flag) { if (pc.GetYear(dateTime) > pc.GetYear(_date)) selectEveryYear_.Checked = true; }
                else selectEveryYear_.Checked = true;
            }
            msg_ = txtMsg_.Text;
            W_ = selectEveryWeek_.Checked ? W : "-1";
            D_ = selectEveryDay_.Checked ? "-1" : D;
            M_ = selectEveryMonth_.Checked ? "-1" : M;
            Y_ = selectEveryYear_.Checked ? "-1" : Y;
            end_date_ = flag ?
                $"{dateTime.Year}/{dateTime.Month}/{dateTime.Day}"
                : $"{DateTime.UtcNow.Year}/{DateTime.UtcNow.Month}/{DateTime.UtcNow.Day}";
            date_ = $"{date.Year}/{date.Month}/{date.Day}";
            Classes.Helper.DB.SQL_QUERY($"UPDATE {FarsiOrEn}messages SET Y={Y_},M={M_},D={D_},W={W_},has_end={has_end_},end_date='{end_date_}',msg='{msg_}' WHERE id={id_}");
            setPnlBoxBoxes();

        }


        private void selectHasEnd_CheckedChanged(object sender, EventArgs e)
        {
            var id_ = (sender as CheckBox).Name.Split('_')[1];
            var txtbox = this.Controls.Find($"txtEndDate_{id_}", true)[0] as TextBox;
            //if (!(sender as CheckBox).Checked)txtbox.Text = null;
            txtbox.Enabled = (sender as CheckBox).Checked;
        }
        public string W, D, M, Y, WEEK;
        public DateTime date;
        private void message_Load(object sender, EventArgs e)
        {
            lbl_day.Text = D;
            
            lbl_month.Text = Classes.Helper.Function.TO_STR_MONTH(int.Parse(M));
            if (FarsiOrEn == "en")lbl_month.Text = date.ToString(" MMMM ");
            lbl_week.Text = WEEK;
            lbl_year.Text = Y;
            setPnlBoxBoxes();
        }
    }
}
