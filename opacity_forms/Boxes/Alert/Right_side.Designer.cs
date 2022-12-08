namespace opacity_forms.Boxes.Alert
{
    partial class Right_side
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
            this.msgLbl = new System.Windows.Forms.Label();
            this.msgBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.msgPic = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.msgPic)).BeginInit();
            this.SuspendLayout();
            // 
            // msgLbl
            // 
            this.msgLbl.AutoSize = true;
            this.msgLbl.Font = new System.Drawing.Font("B Titr", 12.25F, System.Drawing.FontStyle.Bold);
            this.msgLbl.ForeColor = System.Drawing.Color.White;
            this.msgLbl.Location = new System.Drawing.Point(82, 13);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(45, 30);
            this.msgLbl.TabIndex = 2;
            this.msgLbl.Text = "موفق";
            this.msgLbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.msgLbl_MouseMove);
            // 
            // msgBoxTimer
            // 
            this.msgBoxTimer.Interval = 10;
            this.msgBoxTimer.Tick += new System.EventHandler(this.msgBoxTimer_Tick_1);
            // 
            // msgPic
            // 
            this.msgPic.Image = global::opacity_forms.Properties.Resources.warning;
            this.msgPic.Location = new System.Drawing.Point(4, 4);
            this.msgPic.Name = "msgPic";
            this.msgPic.Size = new System.Drawing.Size(54, 47);
            this.msgPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.msgPic.TabIndex = 1;
            this.msgPic.TabStop = false;
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Image = global::opacity_forms.Properties.Resources.cross_circle_free_icon_font__1_;
            this.closeBtn.Location = new System.Drawing.Point(482, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(31, 35);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // Right_side
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(537, 57);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.msgPic);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Right_side";
            this.Text = "Right_side";
            ((System.ComponentModel.ISupportInitialize)(this.msgPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.PictureBox msgPic;
        private System.Windows.Forms.Label msgLbl;
        internal System.Windows.Forms.Timer msgBoxTimer;
    }
}