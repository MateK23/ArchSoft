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
        private string log;
        private double res;

        private double Compare(String value)
        {
            // var data = File.ReadAllLines(@"D:\Users\MateK23\Desktop\data.txt");

            string[] lineArr;
            string line;
            
            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Users\MateK23\Desktop\data.txt");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            
            while (file.ReadLine() != null)
            {
                line = file.ReadLine();
                lineArr = line.Split('='/*, System.StringSplitOptions.RemoveEmptyEntries*/);
                System.Diagnostics.Debug.WriteLine(line.ToString());
                dict.Add(lineArr[0],lineArr[1]);
            }

            foreach (var item in dict)
            {
                if (value == item.Key)
                {
                    
                    res = double.Parse(item.Value);
                }
            }
            file.Close();
            
            return res;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selection = e.RowIndex;
            try
            {
                DataGridViewRow row = dataGridView1.Rows[selection];
                type1.Text = row.Cells[0].Value.ToString();
                type2.Text = row.Cells[1].Value.ToString();
                scale.Text = row.Cells[2].Value.ToString();
                factor.Text = row.Cells[3].Value.ToString();
                result.Text = row.Cells[4].Value.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                obj1.GetValues(type1.Text, type2.Text, double.Parse(scale.Text), Compare(type1.Text));
            }
            catch (Exception exception)
            {

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

        private void factor_Click(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow newDataRow = dataGridView1.Rows[selection];
                newDataRow.Cells[0].Value = type1.Text;
                newDataRow.Cells[1].Value = type2.Text;
                newDataRow.Cells[2].Value = scale.Text;
                newDataRow.Cells[3].Value = factor.Text;
                newDataRow.Cells[4].Value = result.Text;
            }
            catch (Exception exception)
            {
                

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                selection = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selection);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
