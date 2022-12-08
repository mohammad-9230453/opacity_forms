namespace opacity_forms.Boxes.Alert
{
    partial class topShort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMsg = new System.Windows.Forms.Label();
            this.colorMsg = new System.Windows.Forms.Panel();
            this.timerMsg = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg.Font = new System.Drawing.Font("B Titr", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsg.Location = new System.Drawing.Point(0, 17);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(856, 26);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "عملیات ثبت با موفقیت تمام انجام شد";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorMsg
            // 
            this.colorMsg.BackColor = System.Drawing.Color.Lime;
            this.colorMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorMsg.Location = new System.Drawing.Point(0, 0);
            this.colorMsg.Name = "colorMsg";
            this.colorMsg.Size = new System.Drawing.Size(856, 14);
            this.colorMsg.TabIndex = 1;
            // 
            // timerMsg
            // 
            this.timerMsg.Interval = 10;
            this.timerMsg.Tick += new System.EventHandler(this.timerMsg_Tick);
            // 
            // topShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 43);
            this.Controls.Add(this.colorMsg);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "topShort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "topShort";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel colorMsg;
        internal System.Windows.Forms.Timer timerMsg;
        private System.Windows.Forms.Label lblMsg;
    }
}