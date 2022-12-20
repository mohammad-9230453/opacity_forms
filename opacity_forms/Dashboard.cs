using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace opacity_forms
{
    public partial class Dashboard : Form
    {
        public string username;
        background background;
        public Dashboard(background background)
        {
            InitializeComponent();
            //===================================================
            //PictureBox pb;
            //pb = new PictureBox();
            //panel1.Controls.Add(pb);
            //pb.Location = new Point(0,0);
            //pb.Size = new Size(this.Width/2 , this.Height/2);
            //Bitmap img_ = new Bitmap(this.BackgroundImage);
            //pb.BackgroundImage = img_;
            //Bitmap bmp = Screenshot.TakeSnapshot(pb);
            //BitmapFilter.GaussianBlur(bmp, -4);
            //
            //pb.BackgroundImage = bmp;
            //pb.BackgroundImageLayout = ImageLayout.Zoom;
            //pb.BringToFront();
            //======================================================
            //Bitmap img = new Bitmap(this.BackgroundImage);
            //var r = 10;
            //img.SetResolution(r, r);
            //Graphics g = Graphics.FromImage(img);
            //g.PixelOffsetMode = PixelOffsetMode.Half;
            //g.DrawImage(img, new Rectangle(Point.Empty, img.Size));
            //this.BackgroundImage = img;


            pnl_list.BackColor = Color.FromArgb(125, Color.Black);

            //panel1.BackColor = Color.FromArgb(150,Color.DimGray);
            btn_تنضیمات.BackColor = Color.FromArgb(185, 0, 64, 64);

            pnl_header.BackColor = Color.FromArgb(150, Color.DimGray);
            setting_box.BackColor = Color.FromArgb(180, Color.Black);
            pnl_logo.BackColor = Color.FromArgb(30, Color.Black);
            label4.BackColor = Color.FromArgb(0, Color.Black);
            label5.BackColor = Color.FromArgb(0, Color.Black);
            label2.BackColor = Color.FromArgb(0, Color.Black);
            label1.BackColor = Color.FromArgb(0, Color.Black);
            pnl_headers.BackColor = Color.FromArgb(195, Color.Black);
            lbl_username.BackColor = Color.FromArgb(0, Color.Black);
            lbl_day.BackColor  = Color.FromArgb(0, Color.Black);
            lbl_time.BackColor = Color.FromArgb(0, Color.Black);
            panel2.BackColor = Color.FromArgb(0, Color.Black);
            btn_exit.BackColor = Color.FromArgb(165, 62, 10, 10);
            this.background = background;
            SetDrop();


            Fill_SELECT(select_reshte, new[] {
                new {  Text = "تجربی", Value = "0" },
                new {  Text = "ریاضی", Value = "1" },
                new {  Text = "انسانی", Value = "2" },
                new {  Text = "فنی", Value = "3" },
                new {  Text = "کار و دانش", Value = "4" },
            });
            Fill_SELECT(select_student, new[] {
                new {  Text = "علی ملکشاهی", Value = "0" },
                new {  Text = "رضا ملکشاهی", Value = "1" },
                new {  Text = "امیر دولتشاهی", Value = "2" },
                new {  Text = "طاها خسروی", Value = "3" },
                new {  Text = "حسین فولادوند", Value = "4" },
            });
        }


        private void Fill_SELECT(ComboBox select, object items)
        {
            //----------------------------------------------------------- **
            select.DisplayMember = "text";
            select.ValueMember = "value";
            select.DataSource = items;
            select.SelectedIndex = 0;
            select.AutoCompleteMode = AutoCompleteMode.Suggest;
            select.AutoCompleteSource = AutoCompleteSource.ListItems;
            //-----------------------------------------------------------

        }



        IDictionary<string, string> BTNS = new Dictionary<string, string>()
        {
            { "btn_تنضیمات" , "setting_box" },
            { "btn_ثبت_برنامه_روزانه" , "date2" },
        };
        Button last_btn = null;
        Color last_color;

        private void button1_Click(object sender, EventArgs e)
        {
            Button click_btn = (sender as Button);
            Control click_usercontrol = this.Controls.Find(BTNS[click_btn.Name], true).FirstOrDefault() as Control;
            Control last_usercontrol;
            if (last_btn == null)
            {
                click_usercontrol.Visible = true;
                last_color = click_btn.BackColor;
                last_btn = click_btn;
                click_btn.BackColor = Color.FromArgb(90, Color.White);
                click_btn.ForeColor = Color.Black;
            }
            else if (last_btn == click_btn)
            {
                click_usercontrol.Visible = false;
                click_btn.BackColor = last_color;
                click_btn.ForeColor = Color.White;
                last_btn = null;

            }
            else
            {
                last_btn.BackColor = last_color;
                last_btn.ForeColor = Color.White;
                last_usercontrol = this.Controls.Find(BTNS[last_btn.Name], true).FirstOrDefault() as Control;
                last_usercontrol.Visible = false;

                last_color = click_btn.BackColor;
                last_btn = click_btn;

                click_btn.BackColor = Color.FromArgb(90, Color.White);
                click_btn.ForeColor = Color.Black;
                click_usercontrol.Visible = true;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

            this.background.Close();
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
            bool u = false, r = false, l = false, d = false;
            pnl_header.Cursor = System.Windows.Forms.Cursors.Default;
            //if (e.X < 5) { l = true; pnl_header.Cursor = System.Windows.Forms.Cursors.SizeWE; }
            //if (e.Y < 5) { u = true; pnl_header.Cursor = System.Windows.Forms.Cursors.SizeNS; }
            //if ((u && l)) { pnl_header.Cursor = System.Windows.Forms.Cursors.SizeNWSE; }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = this.Left + (e.X - MouseDownLocation.X);
                this.Top = this.Top + (e.Y - MouseDownLocation.Y);

                //if (l && MouseDownLocation.X < 5) this.Width = this.Width - (e.X - MouseDownLocation.X);
                //if (u && MouseDownLocation.Y < 5) this.Height = this.Height - (e.Y - MouseDownLocation.Y);
            }
        }

        private void pnl_header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pnl_header_MouseMove(object sender, MouseEventArgs e)
        {
            int x, y;
            bool u = false, r = false, l = false, d = false;
            pnl_header.Cursor = System.Windows.Forms.Cursors.Default;
            //if (e.X < 5) { l = true; pnl_header.Cursor = System.Windows.Forms.Cursors.SizeWE; }
            //if (e.Y < 5) { u = true; pnl_header.Cursor = System.Windows.Forms.Cursors.SizeNS; }
            //if ((u && l)) { pnl_header.Cursor = System.Windows.Forms.Cursors.SizeNWSE; }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = this.Left + (e.X - MouseDownLocation.X);
                this.Top = this.Top + (e.Y - MouseDownLocation.Y);

                //if (l && MouseDownLocation.X < 5) this.Width = this.Width - (e.X - MouseDownLocation.X);
                //if (u && MouseDownLocation.Y < 5) this.Height = this.Height - (e.Y - MouseDownLocation.Y);
            }
        }
        //=========
        IDictionary<Button, Panel> drop_btn_pnl = new Dictionary<Button, Panel>();
        private void SetDrop()
        {
            drop_btn_pnl.Add(btn_drop_name, pnl_drop_name); drop_background_setup(btn_drop_name);
            drop_btn_pnl.Add(btn_drop_2, pnl_drop_2); drop_background_setup(btn_drop_2);
            drop_btn_pnl.Add(btn_drop_3, pnl_drop_3); drop_background_setup(btn_drop_3);
        }
        //========
        private void drop_background_setup(Button btn)
        {
            drop_btn_pnl[btn].BackColor = Color.FromArgb(120, 22, 3, 56);
            foreach (Button button in drop_btn_pnl[btn].Controls.OfType<Button>())
            {
                (button as Button).BackColor = Color.FromArgb(150, 22, 3, 56);
            }
            btn.BackColor = Color.FromArgb(150, 46, 11, 110);
        }
        private void btn_drop_name_Click(object sender, EventArgs e)
        {
            if (button == null) button = (sender as Button);
            if (situation != drop_situation.stop)
            {
                if (situation == drop_situation.close && (sender as Button) == button) situation = drop_situation.open;
                else if ((sender as Button) == button && situation == drop_situation.open) situation = drop_situation.close;
                return;
            }
            button = (sender as Button);
            if (drop_btn_pnl[button].Height <= button.Height) situation = drop_situation.open;
            else situation = drop_situation.close;

            timer1.Start();




        }
        enum drop_situation
        {
            open,
            close,
            stop
        }
        drop_situation situation = drop_situation.stop;
        Button button;
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (situation)
            {
                case drop_situation.open:
                    timer1.Interval = 1;
                    //drop_btn_pnl[button].Height+=10;   //1
                    drop_btn_pnl[button].Height = drop_btn_pnl[button].MaximumSize.Height;   //2
                    if (drop_btn_pnl[button].Height == drop_btn_pnl[button].MaximumSize.Height) situation = drop_situation.stop;
                    break;
                case drop_situation.close:
                    timer1.Interval = 1;
                    //drop_btn_pnl[button].Height-=10;  //1
                    drop_btn_pnl[button].Height = drop_btn_pnl[button].MinimumSize.Height;  //2
                    if (drop_btn_pnl[button].Height == drop_btn_pnl[button].MinimumSize.Height) situation = drop_situation.stop;
                    break;
                case drop_situation.stop:
                    timer1.Stop();
                    break;
                default:
                    break;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            StringBuilder clipboard = new StringBuilder();
            clipboard.Append(label1.Text + "\n");
            clipboard.Append(label2.Text + "\n");
            clipboard.Append(label5.Text + "\n");
            clipboard.Append(label4.Text + "\n");
            Clipboard.SetText(clipboard.ToString());
        }

        private void date1_Load(object sender, EventArgs e)
        {
            //change(date1, Color.FromArgb(180, Color.Black));
            date2.panel14.BackColor = Color.FromArgb(180, Color.Black);
            date2.panel1.BackColor = Color.FromArgb(180, Color.Black);
            date2.lbl_year.BackColor = Color.FromArgb(0, Color.Black);
        }
        private void change(Control ctrs, Color color)
        {
            if (ctrs.Controls.Count > 0)
            {
                foreach (Control ctr in ctrs.Controls)
                {
                    change(ctr, color);

                }

            }
            if (ctrs is Panel || ctrs is Label)
            {

                ctrs.BackColor = color;
            }
        }



        string cat_name_;
        public void headersLoad()
        {
            pnl_headers.Controls.Clear();
            DataTable data;
            int id = Classes.global_inf.cat_id;
            if (id != 0)
            {
                while (true)
                {
                    data = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM category WHERE id={id}");
                    cat_name_ = data.Rows[0]["name"].ToString();
                    if (Classes.global_inf.cat_id == id) createNewHeader(id.ToString(), true);
                    else createNewHeader(id.ToString(), false);
                    id = int.Parse(data.Rows[0]["last_id"].ToString());
                    if (id == 0) break;
                }
            }
            cat_name_ = "صفحه اصلی";
            if (Classes.global_inf.cat_id == 0) createNewHeader("0", true);
            else createNewHeader("0", false);
        }
        System.Windows.Forms.Label lblSlash;
        System.Windows.Forms.Label lblHead;
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

            this.lblHead.BackColor = this.lblSlash.BackColor = Color.FromArgb(0, Color.Black);
        }
        private void lblHead_Click(object sender, EventArgs e)
        {
            Classes.global_inf.cat_id = int.Parse((sender as Label).Name.Split('_')[1]);
            this.date2.Set_Year();
            headersLoad();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Boxes.Forms.category.Category category = new Boxes.Forms.category.Category();
            category.Show();
        }
        string date;
        private void tik_tok_date_time_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.UtcNow.ToLocalTime();
            lbl_time.Text = dt.ToString("HH:mm:ss");//ساعت
            // تاریخ فارسی
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            //روز هفته
            switch (date = pc.GetDayOfWeek(dt).ToString().ToLower())
            {
                case "monday":
                    date = "دوشنبه";
                    break;
                case "tuesday":
                    date = "سه شنبه";
                    break;
                case "wednesday":
                    date = "چهارشنبه";
                    break;
                case "thursday":
                    date = "پنجشنبه";
                    break;
                case "friday":
                    date = "جمعه";
                    break;
                case "saturday":
                    date = "شنبه";
                    break;
                case "sunday":
                    date = "یکشنبه";
                    break;
            }

            date += $" {pc.GetYear(dt)}/{pc.GetMonth(dt)}/{pc.GetDayOfMonth(dt)} ";
            if (lbl_day.Text != date) 
            {
                lbl_day.Text = date;
                Classes.global_inf.today = dt;
                this.date2.Set_Year();
            }
        }
    }
}
