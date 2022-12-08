using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;
using System.Windows.Forms;

namespace opacity_forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button4.BackColor = Color.FromArgb(125, Color.FromArgb(11, 46, 66));


            lbl_month.BackColor = Color.FromArgb(185, 35, 37, 39);
            button5.BackColor = Color.FromArgb(185, 100, 0, 0);
            button2.BackColor = Color.FromArgb(185, Color.DimGray);
            button3.BackColor = Color.FromArgb(185, Color.DimGray);



        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Set_Year()
        {
            SET_DAYS(M1_table, 31);
            SET_DAYS(M2_table, 31);
            SET_DAYS(M3_table, 31);
            SET_DAYS(M4_table, 31);
            SET_DAYS(M5_table, 31);
            SET_DAYS(M6_table, 31);
            SET_DAYS(M7_table, 30);
            SET_DAYS(M8_table, 30);
            SET_DAYS(M9_table, 30);
            SET_DAYS(M10_table, 30);
            SET_DAYS(M11_table, 30);
            if (is_kabise) SET_DAYS(M12_table, 30);
            else SET_DAYS(M12_table, 29);
        }
        int start_week = 2; bool is_kabise = false;
        private void SET_DAYS(DataGridView dataGrid, int days)
        {
            dataGrid.Rows.Clear();
            var arr = new string[7];
            List<int> arr_ = new List<int> { };
            int iday = 1;
            bool flag = false;
            while (iday <= days)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (i == start_week) flag = true;
                    if (iday > days) flag = false;
                    if (flag)
                    {
                        arr[i] = Convert.ToString(iday);
                        if (iday == 13) arr_.Add(i);
                        iday++;
                        start_week = i + 1;
                        if (start_week > 6) start_week = 0;
                    }
                    else arr[i] = "";

                }
                dataGrid.Rows.Add(arr);
                foreach (int k in arr_)
                {

                    dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[k].Style.BackColor = Color.FromArgb(0, 218, 255);
                    dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[k].Style.ForeColor = Color.Black;
                }
                arr_.Clear();


            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void M1_table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //if (int.TryParse(M1_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() , out int i) || i > 0) MessageBox.Show(M1_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //else MessageBox.Show("خالی");
            M1_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Blue;
            M1_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;


        }

        private void ماهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (month > 0 && day > 0)
            {
                MessageBox.Show($"{year}/{month}/{day}");
            }
        }
        int month = 0, day = 0, year = 0;


        private void button5_Click(object sender, EventArgs e)
        {
            pnl_select.Visible = false;
        }

        private void M1_table_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (int.TryParse((sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out int i) || i > 0) day = i;
            else day = 0;

            switch ((sender as DataGridView).Name)
            {
                case "M1_table":
                    month = 1;
                    break;
                case "M2_table":
                    month = 2;
                    break;
                case "M3_table":
                    month = 3;
                    break;
                case "M4_table":
                    month = 4;
                    break;
                case "M5_table":
                    month = 5;
                    break;
                case "M6_table":
                    month = 6;
                    break;
                case "M7_table":
                    month = 7;
                    break;
                case "M8_table":
                    month = 8;
                    break;
                case "M9_table":
                    month = 9;
                    break;
                case "M10_table":
                    month = 10;
                    break;
                case "M11_table":
                    month = 11;
                    break;
                case "M12_table":
                    month = 12;
                    break;
                default: month = 0; break;
            }
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        //======================================================================================

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txt_year.Text.Length < 4 || !int.TryParse(Convert.ToString(txt_year.Text), out int i) || i > 1500) return;
                year_ = i;
                FillDateTable();

                //MessageBox.Show("enter");
            }
        }
        int month_ = 1, year_ = 1400;

        private void button3_Click(object sender, EventArgs e)
        {
            month_--;
            if (month_ < 1) { month_ = 12; year_--; }
            txt_year.Text = year_.ToString();
            FillDateTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnl_select.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            month_++;
            if (month_ > 12) { month_ = 1; year_++; }
            txt_year.Text = year_.ToString();
            FillDateTable();
        }

        List<string> str_month_array = new List<string> {
            "فروردین","اردیبهشت","خرداد",
            "تیر","مرداد","شهریور",
            "مهر","آبان","آذر",
            "دی","بهمن","اسفند"};
        private void FillDateTable()
        {
            int start_week_ = 0;
            DateTime dateValue;
            PersianCalendar pc = new PersianCalendar();
            dateValue = new DateTime(year_, month_, 1, pc);
            lbl_month.Text = $"{str_month_array[month_ - 1]} {year_}";
            switch (dateValue.DayOfWeek.ToString())
            {
                case "Monday":
                    start_week_ = 2;
                    break;
                case "Tuesday":
                    start_week_ = 3;
                    break;
                case "Wednesday":
                    start_week_ = 4;
                    break;
                case "Thursday":
                    start_week_ = 5;
                    break;
                case "Friday":
                    start_week_ = 6;
                    break;
                case "Saturday":
                    start_week_ = 0;
                    break;
                case "Sunday":
                    start_week_ = 1;
                    break;
            }

            int days = 0;
            if (month_ <= 6 && month_ >= 1) days = 31;
            if (month_ <= 11 && month_ >= 7) days = 30;
            if (month_ == 12)
            {
                days = 29;
                dateValue = new DateTime(year_, month_, 29, pc).AddDays(1);
                if (pc.GetYear(dateValue).ToString().Trim() == year_.ToString().Trim()) days = 30;

            }

            date_table.Rows.Clear();
            var arr = new string[7];
            List<int> arr_ = new List<int> { };
            int iday = 1;
            bool flag = false;
            while (iday <= days)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (i == start_week_) flag = true;
                    if (iday > days) flag = false;
                    if (flag)
                    {
                        arr[i] = Convert.ToString(iday);
                        if (iday == 5) arr_.Add(i);
                        iday++;
                    }
                    else arr[i] = "";
                }
                date_table.Rows.Add(arr);
                foreach (int k in arr_)
                {
                    date_table.Rows[date_table.Rows.Count - 1].Cells[k].Style.BackColor = Color.FromArgb(0, 218, 255);
                    date_table.Rows[date_table.Rows.Count - 1].Cells[k].Style.ForeColor = Color.Black;
                }
                arr_.Clear();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (textBox1.Text.Length < 4 || !int.TryParse(Convert.ToString(textBox1.Text), out int i) || i > 1500) return;
                year = i;
                DateTime dateValue;
                PersianCalendar pc = new PersianCalendar();
                dateValue = new DateTime(i, 1, 1, pc);
                switch (dateValue.DayOfWeek.ToString())
                {
                    case "Monday":
                        start_week = 2;
                        break;
                    case "Tuesday":
                        start_week = 3;
                        break;
                    case "Wednesday":
                        start_week = 4;
                        break;
                    case "Thursday":
                        start_week = 5;
                        break;
                    case "Friday":
                        start_week = 6;
                        break;
                    case "Saturday":
                        start_week = 0;
                        break;
                    case "Sunday":
                        start_week = 1;
                        break;
                }
                is_kabise = false;
                dateValue = new DateTime(i, 12, 29, pc).AddDays(1);
                if (pc.GetYear(dateValue).ToString().Trim() == textBox1.Text.ToString().Trim()) is_kabise = true;
                Set_Year();
                lbl_year.Text = textBox1.Text;
            }
        }

        private Point MouseDownLocation;

        private void pnl_select_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
        }


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
            pnl_select.Cursor = System.Windows.Forms.Cursors.Default;
            if (e.X < 5) { l = true; pnl_select.Cursor = System.Windows.Forms.Cursors.SizeWE; }
            if (e.Y < 5) { u = true; pnl_select.Cursor = System.Windows.Forms.Cursors.SizeNS; }
            //if (Math.Abs(  pnl_search.Width - e.X ) < 10) { r = true; pnl_search.Cursor = System.Windows.Forms.Cursors.SizeWE; }
            //if (e.Y > pnl_search.Height - 10) { d = true; pnl_search.Cursor = System.Windows.Forms.Cursors.SizeNS;}
            if ((u && l)) { pnl_select.Cursor = System.Windows.Forms.Cursors.SizeNWSE; }
            //if ((u&&r) || (d&&l)) { pnl_search.Cursor = System.Windows.Forms.Cursors.SizeNESW;}

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pnl_select.Left = pnl_select.Left + (e.X - MouseDownLocation.X);
                pnl_select.Top = pnl_select.Top + (e.Y - MouseDownLocation.Y);

                if (l && MouseDownLocation.X < 5) pnl_select.Width = pnl_select.Width - (e.X - MouseDownLocation.X);
                //if(r) pnl_search.Width = pnl_search.Width + (e.X - MouseDownLocation.X);
                if (u && MouseDownLocation.Y < 5) pnl_select.Height = pnl_select.Height - (e.Y - MouseDownLocation.Y);
                //if(d) pnl_search.Height = pnl_search.Height + (e.Y - MouseDownLocation.Y);
            }
        }




        // |                                                    *==================================*
        // |                                                    |                                  |
        // |                                                    |                                  |
        // |<----------------->pnl_search.Left<---------------->|<-->* MouseDownLocation.X         |
        // |                                                    |<----->* e.X                      |
        // |                                                    |   --- (e.X - MouseDownLocation.X)|
        // |                                                    |                                  |
        // |                                                    *==================================*
        // |                                                    ---*==================================*
        // |                                                       |                                  |
        // |                                                       |                                  |
        // |<----------------->pnl_search.Left<------------------->|<-->* MouseDownLocation.X         |
        // |                                                       |<-->* e.X                         |
        // |                                                       |                                  |
        // |                                                       |                                  |
        // |                                                       *==================================*

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
        }

        private void date_table_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
            string msg = "1374";
            if (e.RowIndex < 0) return;
            if (int.TryParse(date_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out int i) || i > 0) msg = $"{date_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()}/{month_}/{year_} را کلیک کردین";
            else msg = $"خالی/{month_}/{year_} را کلیک کردین";
            MailAddress from = new MailAddress("Someone@domain.topleveldomain", "Name and stuff");
            MailAddress to = new MailAddress("m.malekshahi1995@gmail.com", "Name and stuff");
            List<MailAddress> cc = new List<MailAddress>();
            cc.Add(new MailAddress("m.malekshahi1995@gmail.com", "Name and stuff"));
            SendEmail(msg, from, to, cc);
        }

        protected void SendEmail(string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null)
        {
            string Text = "hi";
            SmtpClient mailClient = new SmtpClient("185.10.75.8:25");
            MailMessage msgMail;
            Text = "Stuff";
            msgMail = new MailMessage();
            msgMail.From = _from;
            msgMail.To.Add(_to);
            foreach (MailAddress addr in _cc)
            {
                msgMail.CC.Add(addr);
            }
            if (_bcc != null)
            {
                foreach (MailAddress addr in _bcc)
                {
                    msgMail.Bcc.Add(addr);
                }
            }
            msgMail.Subject = _subject;
            msgMail.Body = Text;
            msgMail.IsBodyHtml = true;

            //mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //mailClient.UseDefaultCredentials = false;
            //mailClient.Credentials = new System.Net.NetworkCredential("bob@internalhost.com", "password");
            //mailClient.Port = 25;

            mailClient.Send(msgMail);
            msgMail.Dispose();
        }


    }
}
