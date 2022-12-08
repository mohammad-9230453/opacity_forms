using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace opacity_forms.Boxes.Forms.messege
{
    internal class helper : Boxes.Forms.messege.message
    {

        public void setMsgsPnlBox()
        {
            for (int i = 0; i < 10; i++)
            {
                setNewBOX(i);
            }
        }

        private void setNewBOX(int i)
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
            this.selectHasEnd = new System.Windows.Forms.CheckBox();
            this.pnlBox.SuspendLayout();

            this.pnl_list.Controls.Add(this.pnlBox);

            // 
            // pnlBox
            // 
            this.pnlBox.AutoScroll = true;
            this.pnlBox.BackColor = System.Drawing.Color.Black;
            this.pnlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBox.Controls.Add(this.selectEveryYear);
            this.pnlBox.Controls.Add(this.txtMsg);
            this.pnlBox.Controls.Add(this.btnDelete);
            this.pnlBox.Controls.Add(this.selectEveryWeek);
            this.pnlBox.Controls.Add(this.selectHasEnd);
            this.pnlBox.Controls.Add(this.selectEveryMonth);
            this.pnlBox.Controls.Add(this.btnEdit);
            this.pnlBox.Controls.Add(this.lblHasEnd);
            this.pnlBox.Controls.Add(this.txtEndDate);
            this.pnlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBox.Location = new System.Drawing.Point(0, 0);
            this.pnlBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pnlBox.Name = $"pnlBox_{i}";
            this.pnlBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBox.Size = new System.Drawing.Size(525, 153);
            this.pnlBox.TabIndex = 0;
            // 
            // selectEveryYear
            // 
            this.selectEveryYear.AutoSize = true;
            this.selectEveryYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectEveryYear.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectEveryYear.ForeColor = System.Drawing.Color.White;
            this.selectEveryYear.Location = new System.Drawing.Point(310, 86);
            this.selectEveryYear.Name = $"selectEveryYear_{i}";
            this.selectEveryYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectEveryYear.Size = new System.Drawing.Size(60, 27);
            this.selectEveryYear.TabIndex = 8;
            this.selectEveryYear.Text = "هر سال";
            this.selectEveryYear.UseVisualStyleBackColor = true;
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
            this.txtMsg.Name = $"txtMsg_{i}";
            this.txtMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(477, 72);
            this.txtMsg.TabIndex = 3;
            this.txtMsg.Text ="سلام";
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
            this.btnDelete.Name = $"btnDelete_{i}";
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
            this.selectEveryWeek.Location = new System.Drawing.Point(428, 86);
            this.selectEveryWeek.Name = $"selectEveryWeek_{i}";
            this.selectEveryWeek.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectEveryWeek.Size = new System.Drawing.Size(61, 27);
            this.selectEveryWeek.TabIndex = 8;
            this.selectEveryWeek.Text = "هر هفته";
            this.selectEveryWeek.UseVisualStyleBackColor = true;
            // 
            // selectHasEnd
            // 
            this.selectHasEnd.AutoSize = true;
            this.selectHasEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectHasEnd.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectHasEnd.ForeColor = System.Drawing.Color.White;
            this.selectHasEnd.Location = new System.Drawing.Point(376, 117);
            this.selectHasEnd.Name = $"selectHasEnd_{i}";
            this.selectHasEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectHasEnd.Size = new System.Drawing.Size(47, 27);
            this.selectHasEnd.TabIndex = 8;
            this.selectHasEnd.Text = "دارد";
            this.selectHasEnd.UseVisualStyleBackColor = true;
            this.selectHasEnd.CheckedChanged += new System.EventHandler(this.selectHasEnd_CheckedChanged);
            // 
            // selectEveryMonth
            // 
            this.selectEveryMonth.AutoSize = true;
            this.selectEveryMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectEveryMonth.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.selectEveryMonth.ForeColor = System.Drawing.Color.White;
            this.selectEveryMonth.Location = new System.Drawing.Point(368, 86);
            this.selectEveryMonth.Name = $"selectEveryMonth_{i}";
            this.selectEveryMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectEveryMonth.Size = new System.Drawing.Size(56, 27);
            this.selectEveryMonth.TabIndex = 8;
            this.selectEveryMonth.Text = "هر ماه";
            this.selectEveryMonth.UseVisualStyleBackColor = true;
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
            this.btnEdit.Name = $"btnEdit_{i}";
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
            this.lblHasEnd.Name = $"lblHasEnd_{i}";
            this.lblHasEnd.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblHasEnd.Size = new System.Drawing.Size(67, 27);
            this.lblHasEnd.TabIndex = 7;
            this.lblHasEnd.Text = ": تاریخ پایان";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEndDate.Enabled = false;
            this.txtEndDate.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEndDate.ForeColor = System.Drawing.Color.White;
            this.txtEndDate.Location = new System.Drawing.Point(194, 119);
            this.txtEndDate.Name = $"txtEndDate_{i}";
            this.txtEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEndDate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEndDate.Size = new System.Drawing.Size(180, 23);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.Text = "\r\n";




            this.pnlBox.ResumeLayout(false);
            this.pnlBox.PerformLayout();

            btnDelete.BackColor = Color.FromArgb(130, 62, 10, 10);
            btnEdit.BackColor = Color.FromArgb(130, 87, 8, 137);
            pnlBox.BackColor = Color.FromArgb(90, Color.Black);


            lblHasEnd.BackColor = Color.FromArgb(0, Color.Black);
            selectHasEnd.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryMonth.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryWeek.BackColor = Color.FromArgb(0, Color.Black);
            selectEveryYear.BackColor = Color.FromArgb(0, Color.Black);
        }
    }
}
