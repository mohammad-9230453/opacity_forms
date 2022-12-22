using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace opacity_forms.Boxes.windows
{
    public partial class Date : UserControl
    {
        public Date()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (textBox1.Text.Length < 4 || !int.TryParse(Convert.ToString(textBox1.Text), out int i) || i > 1500) return;
                year = i;
                Set_Year();

            }
        }
        private string today;
        List<Classes.model.messages> messages = new List<Classes.model.messages>();
        List<Classes.model.freedays> freedays = new List<Classes.model.freedays>();
        private List<Classes.model.messages> dt_to_messages(DataTable dt)
        {
            var convertToList = (from rw in dt.AsEnumerable()
                                 select new Classes.model.messages()
                                 {
                                     id = Convert.ToInt32(rw["id"]),
                                     msg = Convert.ToString(rw["msg"]),
                                     Y = Convert.ToInt32(rw["Y"]),
                                     M = Convert.ToInt32(rw["M"]),
                                     D = Convert.ToInt32(rw["D"]),
                                     W = Convert.ToInt32(rw["W"]),
                                     has_end = Convert.ToInt32(rw["has_end"]),
                                     date = DateTime.Parse(Convert.ToString(rw["date"]).Split(' ')[0],
                      System.Globalization.CultureInfo.InvariantCulture),
                                     end_date = DateTime.Parse(Convert.ToString(rw["end_date"]).Split(' ')[0],
                      System.Globalization.CultureInfo.InvariantCulture),
                                 }).ToList();
            return convertToList;
        }
        private List<Classes.model.freedays> dt_to_freedays(DataTable dt)
        {
            var convertToList = (from row in dt.AsEnumerable()
                                 select new Classes.model.freedays()
                                 {
                                     D = Classes.Helper.Function.RowConvertToInt(row, "D"),
                                     M = Classes.Helper.Function.RowConvertToInt(row, "M"),
                                     Y = Classes.Helper.Function.RowConvertToInt(row, "Y"),
                                     user_id = Classes.Helper.Function.RowConvertToInt(row, "user_id"),
                                     id = Classes.Helper.Function.RowConvertToInt(row, "id"),
                                     color = Classes.Helper.Function.RowConvertToStr(row, "color"),

                                 }).ToList();
            return convertToList;
        }
        public void Set_Year()
        {

            PersianCalendar pc = new PersianCalendar();
            DateTime start_year = new DateTime(year, 1, 1, pc);
            DateTime end_year = new DateTime(year, 12, pc.GetDaysInMonth(year, 12), pc);
            DataTable dt = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM messages WHERE (Y=-1 OR Y={year})AND(has_end=0 OR (has_end=1 AND end_date>='{start_year.Year.ToString()}/{start_year.Month.ToString()}/{start_year.Day.ToString()}' )) AND cat_id={Classes.global_inf.cat_id}");
            messages = dt_to_messages(dt);
            DataTable _dt = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM freedays WHERE Y={year} AND user_id={Classes.global_inf.user_id} AND ( cat_id={Classes.global_inf.cat_id} OR cat_id = 0 ) ORDER BY cat_id DESC");
            freedays = dt_to_freedays(_dt);
            DateTime tdy = Classes.global_inf.today;
            today = $"{pc.GetYear(tdy)}/{pc.GetMonth(tdy)}/{pc.GetDayOfMonth(tdy)}";
            month = 1;
            SET_DAYS(dataGrid: M1_table, days: (new PersianCalendar()).GetDaysInMonth(year, 1), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 1, 1, (new PersianCalendar())).DayOfWeek));//فروردین
            month = 2;
            SET_DAYS(dataGrid: M2_table, days: (new PersianCalendar()).GetDaysInMonth(year, 2), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 2, 1, (new PersianCalendar())).DayOfWeek));//اردیبهشت
            month = 3;
            SET_DAYS(dataGrid: M3_table, days: (new PersianCalendar()).GetDaysInMonth(year, 3), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 3, 1, (new PersianCalendar())).DayOfWeek));//خرداد
            month = 4;
            SET_DAYS(dataGrid: M4_table, days: (new PersianCalendar()).GetDaysInMonth(year, 4), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 4, 1, (new PersianCalendar())).DayOfWeek));//تیر
            month = 5;
            SET_DAYS(dataGrid: M5_table, days: (new PersianCalendar()).GetDaysInMonth(year, 5), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 5, 1, (new PersianCalendar())).DayOfWeek));//مرداد
            month = 6;
            SET_DAYS(dataGrid: M6_table, days: (new PersianCalendar()).GetDaysInMonth(year, 6), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 6, 1, (new PersianCalendar())).DayOfWeek));//شهریور
            month = 7;
            SET_DAYS(dataGrid: M7_table, days: (new PersianCalendar()).GetDaysInMonth(year, 7), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 7, 1, (new PersianCalendar())).DayOfWeek));//مهر
            month = 8;
            SET_DAYS(dataGrid: M8_table, days: (new PersianCalendar()).GetDaysInMonth(year, 8), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 8, 1, (new PersianCalendar())).DayOfWeek));//آبان
            month = 9;
            SET_DAYS(dataGrid: M9_table, days: (new PersianCalendar()).GetDaysInMonth(year, 9), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 9, 1, (new PersianCalendar())).DayOfWeek));//آذر
            month = 10;
            SET_DAYS(dataGrid: M10_table, days: (new PersianCalendar()).GetDaysInMonth(year, 10), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 10, 1, (new PersianCalendar())).DayOfWeek));//دی
            month = 11;
            SET_DAYS(dataGrid: M11_table, days: (new PersianCalendar()).GetDaysInMonth(year, 11), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 11, 1, (new PersianCalendar())).DayOfWeek));//بهمن
            month = 12;
            SET_DAYS(dataGrid: M12_table, days: (new PersianCalendar()).GetDaysInMonth(year, 12), start_week: Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, 12, 1, (new PersianCalendar())).DayOfWeek));//اسفند
            if ((new PersianCalendar()).GetDaysInYear(year) >= 366) lbl_year.Text = year.ToString() + " سال کبیسه";
            else lbl_year.Text = year.ToString();
        }
        private void SET_DAYS(DataGridView dataGrid, int days, int start_week)
        {
            IDictionary<int, string> daysMsgs = new Dictionary<int, string>();
            IDictionary<int, List<int>> dayFreeOrNot = new Dictionary<int, List<int>>();
            string msg;
            DataGridViewCell cell;
            dataGrid.Rows.Clear();
            DateTime date;
            PersianCalendar pc = new PersianCalendar();
            var arr = new string[7];
            List<int> arr_ = new List<int> { };
            int iday = 1;
            bool flag = false;
            string color = null;
            int tdy = -1;
            while (iday <= days)
            {
                for (int i = 0; i < 7; i++)
                {

                    if (i == start_week) flag = true;
                    if (iday > days) flag = false;
                    if (flag)
                    {
                        date = new DateTime(year, month, iday, pc);
                        msg = String.Join("\n_________________________________________________\n", messages.Where(e => ((e.M == -1 || e.M == month) && (((e.D == -1)) || (e.D == iday && e.W == -1) || (e.D != -1 && e.W == Classes.Helper.Function.TO_INT_WEEK(date.DayOfWeek))) && ((e.has_end == 0) || ((e.has_end == 1) && (e.end_date >= date) && (e.date <= date))))).Select(e => e.msg).ToArray());
                        color = freedays.Where(e => (e.Y == year && e.M == month && e.D == iday)).Select(e => e.color).FirstOrDefault();
                        color=color??"null";
                        //MessageBox.Show(color);
                        
                        if (msg.Trim(' ', '\n').Length > 0) daysMsgs.Add(i, msg);
                        arr[i] = Convert.ToString(iday);
                        if (iday == 13) arr_.Add(i);
                        if ($"{year}/{month}/{iday}" == today) tdy = i;
                        if (color.Length > 0 && color != "null") dayFreeOrNot.Add(i, color.Trim().Split(',', '-', '_', '@', '.', '#').Select(c => Convert.ToInt32(c.Trim())).ToList());
                        //new List<int>() {100,12,12,255,255,255});
                        //new List<int>() {255,255,255,0,0,0});
                        iday++;
                        start_week = i + 1;
                        if (start_week > 6) start_week = 0;
                    }
                    else arr[i] = "";

                }
                dataGrid.Rows.Add(arr);
                //تعطیلیها
                foreach (KeyValuePair<int, List<int>> keyValuePair in dayFreeOrNot)
                {
                    cell = dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[keyValuePair.Key];
                    cell.Style.BackColor = Color.FromArgb(keyValuePair.Value[0] , keyValuePair.Value[1] , keyValuePair.Value[2] );
                    cell.Style.ForeColor = Color.FromArgb(keyValuePair.Value[3] , keyValuePair.Value[4] , keyValuePair.Value[5] );
                }
                //today
                if (tdy != -1)
                {
                    cell = dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[tdy];
                    cell.Style.BackColor = Color.FromArgb(69, 32, 96);
                    cell.Style.ForeColor = Color.White;
                    cell.ToolTipText = "امروز";
                    tdy = -1;
                }
                //comments
                foreach (KeyValuePair<int, string> keyValuePair in daysMsgs)
                {
                    cell = dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[keyValuePair.Key];
                    //cell.Style.BackColor = Color.FromArgb(100, 12, 12);
                    //cell.Style.ForeColor = Color.FromArgb(255, 0, 130);
                    cell.ToolTipText = keyValuePair.Value;
                    cell.Style.Font = new System.Drawing.Font("Segoe Print", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                arr_.Clear();
                daysMsgs.Clear();
                dayFreeOrNot.Clear();

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
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = new DateTime(int.Parse(year.ToString()), int.Parse(month.ToString()), int.Parse(day.ToString()), pc);

                MessageBox.Show(
                    $"{year}/{month}/{day}\n" +
                    $"{dt.Year}/{dt.Month}/{dt.Day}\n" +
                    $"{dt.ToString("MMMM")}\n" +
                    $"{dt.ToString("MMM")}\n" +
                    $"اختلاف روزها = {(dt - Classes.global_inf.today).Days}\n" +
                    $"{dt.DayOfWeek} = {Classes.Helper.Function.TO_INT_WEEK(dt.DayOfWeek)} = {Classes.Helper.Function.TO_STR_WEEK(dt.DayOfWeek)}\n" +
                    $"{Classes.Helper.Function.TO_INT_WEEK(new DateTime(year, month, 1, (new PersianCalendar())).DayOfWeek)}\n" +
                    $"user_id:{Classes.global_inf.user_id}"
                    );
                Set_Year();

            }
        }
        int month = 0, day = 0, year = (new PersianCalendar()).GetYear(DateTime.UtcNow.ToLocalTime());

        private void افزودنپیغامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (month > 0 && day > 0)
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = new DateTime(int.Parse(year.ToString()), int.Parse(month.ToString()), int.Parse(day.ToString()), pc);
                Boxes.Forms.messege.message msg = new Forms.messege.message();
                msg.WEEK = Classes.Helper.Function.TO_STR_WEEK(dt.DayOfWeek);
                msg.W = Classes.Helper.Function.TO_INT_WEEK(dt.DayOfWeek).ToString();
                msg.Y = year.ToString();
                msg.D = day.ToString();
                msg.M = month.ToString();
                msg.date = dt;
                msg.ShowDialog(this);
            }
        }

        private void تعطیلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string color = "100,12,12_255,255,255";
            if (month > 0 && day > 0)
            {
                if (Classes.Helper.DB.GET_BOOL($"SELECT * FROM freedays WHERE D={day} AND M={month} AND Y={year} AND user_id = {Classes.global_inf.user_id}"))
                {
                    Classes.Helper.DB.SQL_QUERY($"UPDATE freedays SET color='{color}' WHERE D={day} AND M={month} AND Y={year} AND user_id = {Classes.global_inf.user_id}");
                    this.Set_Year();
                    return;
                }
                Classes.Helper.DB.SQL_QUERY($"INSERT INTO freedays (D,M,Y,color,user_id) VALUES({day},{month},{year},'{color}',{Classes.global_inf.user_id})");
                this.Set_Year();
            }

        }

        private void آزادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string color = "255,255,255_0,0,0";
            if (month > 0 && day > 0)
            {
                if (Classes.Helper.DB.GET_BOOL($"SELECT * FROM freedays WHERE D={day} AND M={month} AND Y={year} AND user_id = {Classes.global_inf.user_id}"))
                {
                    Classes.Helper.DB.SQL_QUERY($"UPDATE freedays SET color='{color}' WHERE D={day} AND M={month} AND Y={year} AND user_id = {Classes.global_inf.user_id}");
                    this.Set_Year();
                    return;
                }
                Classes.Helper.DB.SQL_QUERY($"INSERT INTO freedays (D,M,Y,color,user_id) VALUES({day},{month},{year},'{color}',{Classes.global_inf.user_id})");
                this.Set_Year();
            }
        }

        private void Color_Click(object sender, EventArgs e)
        {
            string text = (sender as ToolStripMenuItem).Text.Trim();
            string color =
                text == "مشکی" ?
                "0,0,0_255,255,255":
                text == "سبز" ?
                "39,135,71_255,255,255":
                text == "آبی" ?
                "39,86,135_255,255,255":
                text == "بنفش" ?
                "125,39,135_255,255,255":
                text == "زرد" ?
                "135,123,39_255,255,255":
                text == "بنفش2" ?
                "78,0,76_255,255,255":
                text == "سرمه ای" ?
                "45,0,78_255,255,255":
                text == "آبی تیره" ?
                "16,0,78_255,255,255":
                text == "لجنی" ?
                "0,75,78_255,255,255":
                text == "قهوه ای" ?
                "78,43,0_255,255,255":
                text == "دریا" ?
                "0,46,60_255,255,255":
                text == "نارنجی" ?
                "175,73,0_255,255,255":
                text == "فسفری" ?
                "52,255,208_0,0,0":
                text == "بنفش روشن" ?
                "255,52,249_0,0,0":
                text == "زرد روشن" ?
                "233,255,52_0,0,0":
                text == "c01" ?
                "248,187,255_0,0,0" :
                text == "c02" ?
                "255,187,187_0,0,0" :
                text == "c03" ?
                "255,187,231_0,0,0" :
                text == "c04" ?
                "187,255,246_0,0,0" :
                text == "c05" ?
                "254,255,187_0,0,0" :
                text == "c06" ?
                "187,255,217_0,0,0" :
                text == "c07" ?
                "255,187,243_0,0,0" :
                "0,0,0_255,255,255"
                ;
            if (month > 0 && day > 0 && Classes.global_inf.cat_id !=0) 
            {
                if (Classes.Helper.DB.GET_BOOL($"SELECT * FROM freedays WHERE D={day} AND M={month} AND Y={year} AND user_id = {Classes.global_inf.user_id} AND cat_id = {Classes.global_inf.cat_id}"))
                {
                    Classes.Helper.DB.SQL_QUERY($"UPDATE freedays SET color='{color}' WHERE D={day} AND M={month} AND Y={year} AND user_id = {Classes.global_inf.user_id} AND cat_id = {Classes.global_inf.cat_id}");
                    this.Set_Year();
                    return;
                }
                Classes.Helper.DB.SQL_QUERY($"INSERT INTO freedays (D,M,Y,color,user_id,cat_id) VALUES({day},{month},{year},'{color}',{Classes.global_inf.user_id},{Classes.global_inf.cat_id})");
                this.Set_Year();
            }
        }

        private void حذفرنگToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (month > 0 && day > 0 && Classes.global_inf.cat_id != 0)
            {
                
                Classes.Helper.DB.SQL_QUERY($"DELETE FROM freedays WHERE D={day} AND M={month} AND Y={year} AND user_id = {Classes.global_inf.user_id} AND cat_id = {Classes.global_inf.cat_id}");
                this.Set_Year();
            }
        }

        private void Date_Load(object sender, EventArgs e)
        {
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

    }
}

