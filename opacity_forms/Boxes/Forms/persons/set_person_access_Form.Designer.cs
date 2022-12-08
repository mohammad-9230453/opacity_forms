namespace opacity_forms.Boxes.Forms.persons
{
    partial class set_person_access_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Table_assem = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_save_assem = new System.Windows.Forms.Button();
            this.select_btn = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.select_part = new System.Windows.Forms.ComboBox();
            this.btn_close_assem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_person_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Table_assem)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table_assem
            // 
            this.Table_assem.AllowUserToAddRows = false;
            this.Table_assem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Table_assem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Table_assem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Table_assem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Table_assem.BackgroundColor = System.Drawing.Color.White;
            this.Table_assem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Table_assem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Table_assem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table_assem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Table_assem.ColumnHeadersHeight = 30;
            this.Table_assem.ContextMenuStrip = this.contextMenu;
            this.Table_assem.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Table_assem.DefaultCellStyle = dataGridViewCellStyle7;
            this.Table_assem.EnableHeadersVisualStyles = false;
            this.Table_assem.GridColor = System.Drawing.Color.Black;
            this.Table_assem.Location = new System.Drawing.Point(4, 4);
            this.Table_assem.MaximumSize = new System.Drawing.Size(743, 533);
            this.Table_assem.Name = "Table_assem";
            this.Table_assem.ReadOnly = true;
            this.Table_assem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table_assem.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Table_assem.RowHeadersVisible = false;
            this.Table_assem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Table_assem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Table_assem.ShowCellErrors = false;
            this.Table_assem.ShowCellToolTips = false;
            this.Table_assem.ShowEditingIcon = false;
            this.Table_assem.ShowRowErrors = false;
            this.Table_assem.Size = new System.Drawing.Size(743, 533);
            this.Table_assem.TabIndex = 19;
            this.Table_assem.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Table_assem_CellMouseDown);
            this.Table_assem.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Table_assem_DataBindingComplete);
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.Color.White;
            this.contextMenu.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenu.Name = "user_table_contactMS";
            this.contextMenu.Size = new System.Drawing.Size(107, 32);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.toolStripMenuItem1.Font = new System.Drawing.Font("B Titr", 10.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Image = global::opacity_forms.Properties.Resources.delete_16_white;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(106, 28);
            this.toolStripMenuItem1.Text = "حذف";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // btn_save_assem
            // 
            this.btn_save_assem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_assem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_save_assem.FlatAppearance.BorderSize = 0;
            this.btn_save_assem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_assem.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save_assem.ForeColor = System.Drawing.Color.White;
            this.btn_save_assem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_assem.Location = new System.Drawing.Point(766, 197);
            this.btn_save_assem.Name = "btn_save_assem";
            this.btn_save_assem.Size = new System.Drawing.Size(363, 40);
            this.btn_save_assem.TabIndex = 23;
            this.btn_save_assem.Text = "ثبت";
            this.btn_save_assem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_assem.UseVisualStyleBackColor = false;
            this.btn_save_assem.Click += new System.EventHandler(this.btn_save_assem_Click);
            // 
            // select_btn
            // 
            this.select_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.select_btn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_btn.Font = new System.Drawing.Font("B Morvarid", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.select_btn.ForeColor = System.Drawing.Color.White;
            this.select_btn.FormattingEnabled = true;
            this.select_btn.ItemHeight = 21;
            this.select_btn.Location = new System.Drawing.Point(766, 162);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(363, 29);
            this.select_btn.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("B Titr", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(1082, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 26);
            this.label3.TabIndex = 24;
            this.label3.Text = ": بخش";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("B Titr", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(1082, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = ": قسمت";
            // 
            // select_part
            // 
            this.select_part.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.select_part.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.select_part.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_part.Font = new System.Drawing.Font("B Morvarid", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.select_part.ForeColor = System.Drawing.Color.White;
            this.select_part.FormattingEnabled = true;
            this.select_part.ItemHeight = 21;
            this.select_part.Location = new System.Drawing.Point(766, 102);
            this.select_part.Name = "select_part";
            this.select_part.Size = new System.Drawing.Size(363, 29);
            this.select_part.TabIndex = 22;
            this.select_part.SelectedIndexChanged += new System.EventHandler(this.select_part_SelectedIndexChanged);
            // 
            // btn_close_assem
            // 
            this.btn_close_assem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close_assem.BackColor = System.Drawing.Color.Black;
            this.btn_close_assem.FlatAppearance.BorderSize = 0;
            this.btn_close_assem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close_assem.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.btn_close_assem.ForeColor = System.Drawing.Color.DimGray;
            this.btn_close_assem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close_assem.Location = new System.Drawing.Point(1119, 14);
            this.btn_close_assem.Name = "btn_close_assem";
            this.btn_close_assem.Size = new System.Drawing.Size(25, 28);
            this.btn_close_assem.TabIndex = 26;
            this.btn_close_assem.Text = "x";
            this.btn_close_assem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close_assem.UseVisualStyleBackColor = false;
            this.btn_close_assem.Click += new System.EventHandler(this.btn_close_assem_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("B Titr", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(960, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 26);
            this.label4.TabIndex = 25;
            this.label4.Text = "تعیین دسترسی های کاربر";
            // 
            // lbl_person_name
            // 
            this.lbl_person_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_person_name.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_person_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbl_person_name.Location = new System.Drawing.Point(766, 14);
            this.lbl_person_name.Name = "lbl_person_name";
            this.lbl_person_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_person_name.Size = new System.Drawing.Size(188, 75);
            this.lbl_person_name.TabIndex = 25;
            this.lbl_person_name.Text = "محمد غلوم قلمراد زاده خوش قیافه";
            // 
            // set_person_access_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1156, 542);
            this.Controls.Add(this.btn_close_assem);
            this.Controls.Add(this.lbl_person_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_save_assem);
            this.Controls.Add(this.select_part);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Table_assem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "set_person_access_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "set_person_access_Form";
            this.Load += new System.EventHandler(this.set_person_access_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table_assem)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Table_assem;
        private System.Windows.Forms.Button btn_save_assem;
        private System.Windows.Forms.ComboBox select_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox select_part;
        private System.Windows.Forms.Button btn_close_assem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_person_name;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}