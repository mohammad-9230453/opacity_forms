using System;
using System.Drawing;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Alert
{
    public partial class topShort : Form
    {
        public topShort()
        {
            InitializeComponent();
        }

        public enum enmaction
        {
            start,
            wait,
            stop
        }
        public enum enmtype
        {
            warning,
            error,
            success,
            info,
        }
        private topShort.enmaction action;
        private int x, y;

        private void timerMsg_Tick(object sender, EventArgs e)
        {
            switch (action)
            {
                case enmaction.start:
                    timerMsg.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.y > this.Location.Y)
                    {
                        this.Top++;
                    }
                    else if (this.Opacity == 1)
                    {
                        action = enmaction.wait;
                    }

                    break;
                case enmaction.wait:
                    timerMsg.Interval = 4000;
                    action = enmaction.stop;
                    break;
                case enmaction.stop:
                    timerMsg.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Top++;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
                default:
                    break;
            }
        }

        public void showAlert(string msg, enmtype type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string filename;
            for (int i = 0; i < (Screen.PrimaryScreen.WorkingArea.Size.Height / (this.Height + 5)); i++)
            {
                filename = "shortAlert" + i.ToString(); // new msgBox name
                topShort frm = (topShort)Application.OpenForms[filename];

                if (frm == null) // if dont have this name in alerts?
                {
                    this.Name = filename;
                    this.x = Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - this.Width / 2;
                    this.y = (this.Height + 5) * i;
                    this.Location = new Point(x, y);
                    break;
                }
            }
            this.y = 0;

            switch (type)
            {
                case enmtype.warning:
                    this.colorMsg.BackColor = Color.DarkOrange;
                    this.lblMsg.ForeColor = Color.DarkOrange;
                    break;
                case enmtype.error:

                    this.colorMsg.BackColor = Color.DarkRed;
                    this.lblMsg.ForeColor = Color.DarkRed;
                    break;
                case enmtype.success:

                    this.colorMsg.BackColor = Color.SeaGreen;
                    this.lblMsg.ForeColor = Color.SeaGreen;
                    break;
                case enmtype.info:

                    this.colorMsg.BackColor = Color.RoyalBlue;
                    this.lblMsg.ForeColor = Color.RoyalBlue;
                    break;
                default:
                    break;

            }
            this.lblMsg.Text = msg;
            this.Show();
            this.timerMsg.Interval = 1;
            this.action = enmaction.start;
            timerMsg.Start();


        }
    }
}
