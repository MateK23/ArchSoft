using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            // if (selection != -1)
            // {
            //     DataGridViewRow row = dataGridView1.Rows[selection];
            //     type1.Text = row.Cells[0].Value.ToString();
            //     type2.Text = row.Cells[1].Value.ToString();
            //     scale.Text = row.Cells[2].Value.ToString();
            //     factor.Text = row.Cells[3].Value.ToString();
            //     result.Text = row.Cells[4].Value.ToString();
            // }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double parsedScale;
            try
            {
                if (factor.Text == "" && result.Text == "")
                {

                    if (Double.TryParse(scale.Text, out parsedScale))
                    {
                        obj1.GetValues(type1.Text, type2.Text, parsedScale, 0, 0);
                    }
                }
                else if (result.Text == "")
                {
                    if (Double.TryParse(scale.Text, out parsedScale))
                    {
                        obj1.GetValues(type1.Text, type2.Text, Convert.ToDouble(Int32.Parse(scale.Text)), double.Parse(factor.Text), 0);
                    }
                }
                else if (factor.Text == "")
                {
                    if (Double.TryParse(scale.Text, out parsedScale))
                    {
                        obj1.GetValues(type1.Text, type2.Text, Convert.ToDouble(Int32.Parse(scale.Text)), 0, Int32.Parse(result.Text));
                    }
                }
                else
                {
                    if (Double.TryParse(scale.Text, out parsedScale))
                    {
                        obj1.GetValues(type1.Text, type2.Text, Convert.ToDouble(Int32.Parse(scale.Text)), double.Parse(factor.Text),Int32.Parse(result.Text));
                    }
                }
            }
            catch (Exception exception)
            {
                // System.Diagnostics.Debug.WriteLine(exception);
            }

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

        private void factor_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            obj1.TableToPdf();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(selection);
            }
            catch (InvalidOperationException exception)
            {
                
            }
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}