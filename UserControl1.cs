using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchSoft
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        TableFill obj1 = new TableFill();
        private int selection;

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selection = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selection];
            type1.Text = row.Cells[0].Value.ToString();
            type2.Text = row.Cells[1].Value.ToString();
            scale.Text = row.Cells[2].Value.ToString();
            factor.Text = row.Cells[3].Value.ToString();
            result.Text = row.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj1.GetValues(type1.Text,type2.Text, double.Parse(scale.Text));
            dataGridView1.DataSource = obj1.TableRetrun();
        }

        private void type1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void type2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void scale_TextChanged(object sender, EventArgs e)
        {

        }

        private void factor_Click(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[selection];
            newDataRow.Cells[0].Value = type1.Text;
            newDataRow.Cells[1].Value = type2.Text;
            newDataRow.Cells[2].Value = scale.Text;
            newDataRow.Cells[3].Value = factor.Text;
            newDataRow.Cells[4].Value = result.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            selection = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selection);
        }
    }
}
