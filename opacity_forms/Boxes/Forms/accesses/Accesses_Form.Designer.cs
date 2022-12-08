namespace opacity_forms.Boxes.Forms.accesses
{
    partial class Accesses_Form
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.تغییر_وضعیت = new System.Windows.Forms.ToolStripMenuItem();
            this.فعالToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.غیرفعالToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذف = new System.Windows.Forms.ToolStripMenuItem();
            this.ایجاد = new System.Windows.Forms.ToolStripMenuItem();
            this.تغییر = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.treeView1.ForeColor = System.Drawing.Color.Green;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(427, 520);
            this.treeView1.TabIndex = 31;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تغییر_وضعیت,
            this.حذف,
            this.ایجاد,
            this.تغییر});
            this.contextMenuStrip1.Name = "user_table_contactMS";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 100);
            // 
            // تغییر_وضعیت
            // 
            this.تغییر_وضعیت.BackColor = System.Drawing.Color.Black;
            this.تغییر_وضعیت.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.فعالToolStripMenuItem,
            this.غیرفعالToolStripMenuItem});
            this.تغییر_وضعیت.Font = new System.Drawing.Font("B Titr", 7.75F, System.Drawing.FontStyle.Bold);
            this.تغییر_وضعیت.ForeColor = System.Drawing.Color.White;
            this.تغییر_وضعیت.Name = "تغییر_وضعیت";
            this.تغییر_وضعیت.Size = new System.Drawing.Size(124, 24);
            this.تغییر_وضعیت.Text = "تغییر وضعیت";
            // 
            // فعالToolStripMenuItem
            // 
            this.فعالToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.فعالToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.فعالToolStripMenuItem.Name = "فعالToolStripMenuItem";
            this.فعالToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.فعالToolStripMenuItem.Text = "فعال";
            this.فعالToolStripMenuItem.Click += new System.EventHandler(this.فعالToolStripMenuItem_Click);
            // 
            // غیرفعالToolStripMenuItem
            // 
            this.غیرفعالToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.غیرفعالToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.غیرفعالToolStripMenuItem.Name = "غیرفعالToolStripMenuItem";
            this.غیرفعالToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.غیرفعالToolStripMenuItem.Text = "غیر فعال";
            this.غیرفعالToolStripMenuItem.Click += new System.EventHandler(this.غیرفعالToolStripMenuItem_Click);
            // 
            // حذف
            // 
            this.حذف.BackColor = System.Drawing.Color.Black;
            this.حذف.Font = new System.Drawing.Font("B Titr", 7.75F, System.Drawing.FontStyle.Bold);
            this.حذف.ForeColor = System.Drawing.Color.White;
            this.حذف.Name = "حذف";
            this.حذف.Size = new System.Drawing.Size(124, 24);
            this.حذف.Text = "حذف";
            this.حذف.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // ایجاد
            // 
            this.ایجاد.BackColor = System.Drawing.Color.Black;
            this.ایجاد.Font = new System.Drawing.Font("B Titr", 7.75F, System.Drawing.FontStyle.Bold);
            this.ایجاد.ForeColor = System.Drawing.Color.White;
            this.ایجاد.Name = "ایجاد";
            this.ایجاد.Size = new System.Drawing.Size(124, 24);
            this.ایجاد.Text = "ایجاد";
            this.ایجاد.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // تغییر
            // 
            this.تغییر.BackColor = System.Drawing.Color.Black;
            this.تغییر.Font = new System.Drawing.Font("B Titr", 7.75F, System.Drawing.FontStyle.Bold);
            this.تغییر.ForeColor = System.Drawing.Color.White;
            this.تغییر.Name = "تغییر";
            this.تغییر.Size = new System.Drawing.Size(124, 24);
            this.تغییر.Text = "تغییر";
            this.تغییر.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Accesses_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(427, 520);
            this.Controls.Add(this.treeView1);
            this.Name = "Accesses_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accesses_Form";
            this.Load += new System.EventHandler(this.Accesses_Form_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem حذف;
        private System.Windows.Forms.ToolStripMenuItem تغییر;
        private System.Windows.Forms.ToolStripMenuItem ایجاد;
        private System.Windows.Forms.ToolStripMenuItem تغییر_وضعیت;
        private System.Windows.Forms.ToolStripMenuItem فعالToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem غیرفعالToolStripMenuItem;
    }
}