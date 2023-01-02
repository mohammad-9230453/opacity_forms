using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Forms.dateprojectstack
{
    public partial class DGV : Form
    {
        public DGV()
        {
            InitializeComponent();
        }
        private int[] daysInMonths;
        private void DGV_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            daysInMonths = new int[12];

            // Add a column for each day of the year; where
            // column name = the date (creates all unique column names)
            // column header text = the numeric day of the month
            for (int month = 1; month <= 12; month++)
            {
                daysInMonths[month - 1] = DateTime.DaysInMonth(year, month);

                // for days 1-31, 1-29, etc.
                for (int day = 1; day <= daysInMonths[month - 1]; day++)
                {
                    DateTime date = new DateTime(year, month, day);
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
                    {
                        Name = date.ToString(),
                        HeaderText = day.ToString(),
                        Width = 20
                    };

                    this.dataGridView1.Columns.Add(col);
                }
            }

            // add some default rows
            for (int r = 0; r < 4; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.HeaderCell.Value = $"Project {r + 1}";
                this.dataGridView1.Rows.Add(row);
            }

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView1.Paint += DataGridView1_Paint;
            this.dataGridView1.Scroll += DataGridView1_Scroll;
            this.dataGridView1.ColumnWidthChanged += DataGridView1_ColumnWidthChanged;
            this.dataGridView1.Resize += DataGridView1_Resize;
        }















        private void InvalidateHeader()
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
        }

        private void DataGridView1_Resize(object sender, EventArgs e)
        {
            this.InvalidateHeader();
        }

        private void DataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.InvalidateHeader();
        }

        private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.InvalidateHeader();
        }

        private void DataGridView1_Paint(object sender, PaintEventArgs e)
        {
            int col = 0;

            // For each month, create the display rectangle for the main title and draw it.
            foreach (int daysInMonth in daysInMonths)
            {
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(col, -1, true);

                // Start the rectangle from the first visible day of the month,
                // and add the width of the column for each following day.
                for (int day = 0; day < daysInMonth; day++)
                {
                    Rectangle r2 = this.dataGridView1.GetCellDisplayRectangle(col + day, -1, true);

                    if (r1.Width == 0) // Cell is not displayed.
                    {
                        r1 = r2;
                    }
                    else
                    {
                        r1.Width += r2.Width;
                    }
                }

                r1.X += 1;
                r1.Y += 1;
                r1.Height = r1.Height / 2 - 2;
                r1.Width -= 2;

                using (Brush back = new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor))
                using (Brush fore = new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor))
                using (Pen p = new Pen(this.dataGridView1.GridColor))
                using (StringFormat format = new StringFormat())
                {
                    string month = DateTime.Parse(this.dataGridView1.Columns[col].Name).ToString("MMMM");

                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    e.Graphics.FillRectangle(back, r1);
                    e.Graphics.DrawRectangle(p, r1);
                    e.Graphics.DrawString(month, this.dataGridView1.ColumnHeadersDefaultCellStyle.Font, fore, r1, format);
                }

                col += daysInMonth; // Move to the first column of the next month.
            }
        }
    }
}
