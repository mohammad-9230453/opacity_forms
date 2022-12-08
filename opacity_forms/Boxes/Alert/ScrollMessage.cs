using System;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Alert
{
    public partial class ScrollMessage : Form
    {
        string message;
        public ScrollMessage(string message)
        {
            InitializeComponent();
            this.message = message;
        }

        private void ScrollMessage_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
                return;
            textBox.Lines = message.Split('\n');
        }
    }
}
