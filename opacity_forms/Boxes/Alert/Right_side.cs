using opacity_forms.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Alert
{
    public partial class Right_side : Form
    {
        public Right_side()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            success,
            error,
            warning,
            info
        }

        private int x, y;

        private Right_side.enmAction action;



        private void msgBoxTimer_Tick_1(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.start:
                    msgBoxTimer.Interval = 1; // یک هزارم ثانیه در میان این کارو بکن
                    this.Opacity += 0.1;

                    // کم کم شفافش کن
                    if (this.x < this.Location.X) // اگه به جای خودش نرسیده
                    {
                        this.Left--; // بیارش اینور 
                    }
                    else
                    {
                        if (this.Opacity == 1) // اگه جا خودش رسیده و کاملا شفاف شده
                        {
                            action = enmAction.wait; // برو تو وضعیت نگه داشت
                        }
                    }
                    break;

                case enmAction.wait:
                    msgBoxTimer.Interval = 4000; // 4 ثانیه صبر کن تو همین وضع فعلی
                    action = enmAction.close; // بعد از 4 ثانیه که اومدی برو تو وضعیت بستنش
                    break;

                case enmAction.close:
                    msgBoxTimer.Interval = 1; // هر یک هزارم ثانیه یکبار::
                    this.Opacity -= 0.06; // از شفافیت کم کن
                    this.Left -= 1; // باکسو ببر سمت چپ صفحه
                    if (base.Opacity == 0.0) // اگه کاملا ناپدید شد؟
                    {
                        base.Close();// پنجره رو کامل ببندش
                    }
                    break;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            msgBoxTimer.Interval = 1;// تایمرو ببر تو وضعیت یک هزارم ثانیه
            action = enmAction.close;// سریع برو تو وضعیت بستن
        }



        private void msgLbl_MouseMove(object sender, MouseEventArgs e)
        {
            msgBoxTimer.Interval = 1;
            this.Left = this.x;
            action = enmAction.start;
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            string fname; // new alert name

            for (int i = 1; i < (Screen.PrimaryScreen.WorkingArea.Height / (this.Height + 5)); i++)
            {
                fname = "alert" + i.ToString(); // new msgBox name
                Right_side frm = (Right_side)Application.OpenForms[fname];

                if (frm == null) // if dont have this name in alerts?
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - (this.Height - 5) * i;
                    this.Location = new Point(x, y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.success:
                    this.msgPic.Image = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.error:
                    this.msgPic.Image = Resources.error;
                    this.BackColor = Color.DarkRed;

                    break;
                case enmType.warning:
                    this.msgPic.Image = Resources.warning;
                    this.BackColor = Color.DarkOrange;

                    break;
                case enmType.info:
                    this.msgPic.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;

                    break;
            }

            this.msgLbl.Text = msg;

            this.Show();


            this.action = enmAction.start;
            this.msgBoxTimer.Interval = 1;
            msgBoxTimer.Start();
        }
    }
}


//          (0,0)
//               @==========================================================
//               |                                                         |
//               |                                                         |
//               |                                                         |
//               |                                                         |
//               |                                                         |
//               |                                                         |
//               |                                                         |
//               |                                                         |
//               |                                                         |
//               |                                           this.Height   |
//               |                                        ^^^^^^^^^^^^^^^^^|
//               |                         Location(x,y) @=================|
//               |                                       |                 |>
//               |                                       |                 |> thix.width
//               |                                       |                 |>
//               ==========================================================@
//                                                                          (x_max , y_max)