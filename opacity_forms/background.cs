using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace opacity_forms
{
    public partial class background : Form
    {
        public background()
        {
            InitializeComponent();
            //btn_login.BackColor = Color.FromArgb(50, Color.DarkGreen);
            //btn_cancel.BackColor = Color.FromArgb(50, Color.DarkRed);



            string time = "23:59";//00:00 => 23:59
            DateTime dateTime = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
            //MessageBox.Show(dateTime.ToString("HH:mm"));
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
            panel1.Cursor = System.Windows.Forms.Cursors.Default;
            //if (e.X < 5) { l = true; panel1.Cursor = System.Windows.Forms.Cursors.SizeWE; }
            //if (e.Y < 5) { u = true; panel1.Cursor = System.Windows.Forms.Cursors.SizeNS; }
            //if ((u && l)) { panel1.Cursor = System.Windows.Forms.Cursors.SizeNWSE; }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = this.Left + (e.X - MouseDownLocation.X);
                this.Top = this.Top + (e.Y - MouseDownLocation.Y);

                //if (l && MouseDownLocation.X < 5) this.Width = this.Width - (e.X - MouseDownLocation.X);
                //if (u && MouseDownLocation.Y < 5) this.Height = this.Height - (e.Y - MouseDownLocation.Y);
            }
        }

        Boxes.Alert.Alert alert = new Boxes.Alert.Alert();
        private void login()
        {
            bool flag = true;
            string name_ = null, pass_ = null;
            name_ = Convert.ToString(txt_username.Text);
            pass_ = Convert.ToString(txt_password.Text);
            if (txt_username.Text.ToString().Trim().Length <= 2)
            {
                alert.shortAlert("نام کاربری نباید کمتر از 3 کاراکتر باشد", Boxes.Alert.topShort.enmtype.warning); return;
            }
            if (txt_password.Text.ToString().Trim().Length <= 3)
            {
                alert.shortAlert("رمز نباید نباید کمتر از 4 کاراکتر باشد", Boxes.Alert.topShort.enmtype.warning); return;
            }

            if (!Classes.Helper.DB.GET_BOOL($"SELECT * FROM persons p INNER JOIN accesses a ON p.access_id = a.id WHERE p.name = '{name_}' AND p.password = '{pass_}' AND p.role = 0 AND p.situation = 1 AND a.name = 'برنامه'"))
            {
                alert.shortAlert("نام کاربری یا کلمه عبور اشتباه است", Boxes.Alert.topShort.enmtype.warning);
                return;

            }
            DataTable person = Classes.Helper.DB.GET_DATA_TABLE($"SELECT p.welcome_name AS 'نام' ,p.id AS person_id , p.access_id as access_id FROM persons p INNER JOIN accesses a ON p.access_id = a.id WHERE p.name = '{name_}' AND p.password = '{pass_}' AND p.role = 0 AND p.situation = 1 AND a.name = 'برنامه'");
            Classes.global_inf.access_ = Boxes.Login.login_helper.ACCESS(access_id: Convert.ToString(person.Rows[0]["access_id"]), person_id: Convert.ToString(person.Rows[0]["person_id"]));
            Dashboard dashboard = new Dashboard(
            background: this
            );
            this.Hide();
            dashboard.lbl_username.Text = Convert.ToString(person.Rows[0]["نام"]);
            Classes.global_inf.user_id = Convert.ToString(person.Rows[0]["person_id"]);
            Classes.global_inf.cat_id = 0;
            if (dashboard.ShowDialog(this) == DialogResult.Cancel) this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boxes.Forms.persons.make_new_person_Form _New_Person_Form = new Boxes.Forms.persons.make_new_person_Form();
            _New_Person_Form.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boxes.Forms.accesses.Accesses_Form accesses_ = new Boxes.Forms.accesses.Accesses_Form();
            accesses_.ShowDialog(this);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) txt_username.UseSystemPasswordChar = false;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            txt_username.UseSystemPasswordChar = true;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) txt_password.UseSystemPasswordChar = false;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            txt_password.UseSystemPasswordChar = true;
        }

        private void background_KeyDown(object sender, KeyEventArgs e)
        {
            //***********************************************
            if (e.KeyCode == Keys.Enter)
                login();

            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F4 && e.Alt)) 
                this.Close();   

        }
    }
}
