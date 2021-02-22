using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private double returnFactor;
        private string returnType;

        private double CompareTest(String value)
        {
            // var data = File.ReadAllLines(@"D:\Users\MateK23\Desktop\data.txt");

            string[] lineArr;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Users\MateK23\Desktop\data.txt");
            Dictionary<string, string> dict = new Dictionary<string, string>();

            while (file.ReadLine() != null)
            {
                line = file.ReadLine();
                lineArr = line.Split('=' /*, System.StringSplitOptions.RemoveEmptyEntries*/);
                System.Diagnostics.Debug.WriteLine(line.ToString());
                dict.Add(lineArr[0], lineArr[1]);
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
                    obj1.GetValues(returnType, type2.Text, double.Parse(scale.Text), double.Parse(factor.Text), 0);
                }
                else if (result.Text == "")
                {
                    obj1.GetValues(returnType, type2.Text, double.Parse(scale.Text), double.Parse(factor.Text), 0);
                }
                else if (factor.Text == "")
                {
                    obj1.GetValues(returnType, type2.Text, double.Parse(scale.Text), 0, Int32.Parse(result.Text));
                }
                else
                {
                    if (Double.TryParse(scale.Text, out parsedScale))
                    {
                        obj1.GetValues(returnType, type2.Text, parsedScale, double.Parse(factor.Text),
                            Int32.Parse(result.Text));
                    }
                    else
                    {
                        obj1.GetValues(returnType, type2.Text, Convert.ToDouble(Int32.Parse(scale.Text)),
                            double.Parse(factor.Text),
                            Int32.Parse(result.Text));
                    }
                }
            }
            catch (Exception exception)
            {
            }

            dataGridView1.DataSource = obj1.TableRetrun();
        }


        private void type1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (type1.Text)
            {
                case "თვ-1":
                    returnType = "თვ-1";
                    break;
                case "თვ-2 1.4":
                    returnType = "თვ-2"; // 18.6 +
                    break;
                case "თვ-2 18.6":
                    returnType = "თვ-2";
                    break;
                case "თვ-3 2.7":
                    returnType = "თვ-3"; // 9.3 1.4 +
                    break;
                case "თვ-3 9.3":
                    returnType = "თვ-3";
                    break;
                case "თვ-3 1.4":
                    returnType = "თვ-3";
                    break;
                case "თვ-4 ფიქსირებული":
                    returnType = "თვ-4"; // Fixed ----------------------
                    break;
                case "თვ-5":
                    returnType = "თვ-5";
                    break;
                case "სქ":
                    returnType = "სქ";
                    break;
                case "სგ 1.9":
                    returnType = "სგ"; // 4.7 +
                    break;
                case "სგ 4.7":
                    returnType = "სგ";
                    break;
                case "სმ-1":
                    returnType = "სმ-1";
                    break;
                case "სმ-2":
                    returnType = "სმ-2";
                    break;
                case "დსშ-1 ფიქსირებული":
                    returnType = "დსშ-1"; // Fixed ----------------------
                    break;
                case "დსშ-2 ფიქსირებული":
                    returnType = "დსშ-2"; // Fixed ----------------------
                    break;
                case "დსშ-3 ფიქსირებული":
                    returnType = "დსშ-3"; // Fixed ----------------------
                    break;
                case "დსშ-4 ფიქსირებული":
                    returnType = "დსშ-4"; // Fixed ----------------------
                    break;
                case "დსშ-5 ფიქსირებული":
                    returnType = "დსშ-5"; // Fixed ----------------------
                    break;
                case "დწ-1":
                    returnType = "დწ-1";
                    break;
                case "დწ-2":
                    returnType = "დწ-2";
                    break;
                case "დწ-3":
                    returnType = "დწ-3";
                    break;
                case "დწ-4":
                    returnType = "დწ-4";
                    break;
                case "სვ 2.8":
                    returnType = "სვ"; // 5.6 +
                    break;
                case "სვ 5.6":
                    returnType = "სვ";
                    break;
                case "სც-1":
                    returnType = "სც-1";
                    break;
                case "სც-2":
                    returnType = "სც-2";
                    break;
                case "სც-3":
                    returnType = "სც-3";
                    break;
                case "სც-4":
                    returnType = "სც-4";
                    break;
                case "სწ-1":
                    returnType = "სწ-1";
                    break;
                case "სწ-2":
                    returnType = "სწ-2";
                    break;
                case "დს":
                    returnType = "დს";
                    break;
                default:
                    returnType = "Error"; // Other
                    break;
            }

            switch (type1.Text)
            {
                case "თვ-1":
                    returnFactor = 2.7;
                    break;
                case "თვ-2 1.4":
                    returnFactor = 1.4; // 18.6 +
                    break;
                case "თვ-2 18.6":
                    returnFactor = 18.6;
                    break;
                case "თვ-3 2.7":
                    returnFactor = 2.7; // 9.3 1.4 +
                    break;
                case "თვ-3 9.3":
                    returnFactor = 9.3;
                    break;
                case "თვ-3 1.4":
                    returnFactor = 1.4;
                    break;
                case "თვ-4 ფიქსირებული":
                    returnFactor = 0; // Fixed ----------------------
                    break;
                case "თვ-5":
                    returnFactor = 0.5;
                    break;
                case "სქ":
                    returnFactor = 9.3;
                    break;
                case "სგ 1.9":
                    returnFactor = 1.9; // 4.7 +
                    break;
                case "სგ 4.7":
                    returnFactor = 4.7;
                    break;
                case "სმ-1":
                    returnFactor = 9.3;
                    break;
                case "სმ-2":
                    returnFactor = 9.3;
                    break;
                case "დსშ-1 ფიქსირებული":
                    returnFactor = 0; // Fixed ----------------------
                    break;
                case "დსშ-2 ფიქსირებული":
                    returnFactor = 0; // Fixed ----------------------
                    break;
                case "დსშ-3 ფიქსირებული":
                    returnFactor = 0; // Fixed ----------------------
                    break;
                case "დსშ-4 ფიქსირებული":
                    returnFactor = 0; // Fixed ----------------------
                    break;
                case "დსშ-5 ფიქსირებული":
                    returnFactor = 0; // Fixed ----------------------
                    break;
                case "დწ-1":
                    returnFactor = 9.3;
                    break;
                case "დწ-2":
                    returnFactor = 22.3;
                    break;
                case "დწ-3":
                    returnFactor = 11.2;
                    break;
                case "დწ-4":
                    returnFactor = 3.7;
                    break;
                case "სვ 2.8":
                    returnFactor = 2.8; // 5.6 +
                    break;
                case "სვ 5.6":
                    returnFactor = 5.6;
                    break;
                case "სც-1":
                    returnFactor = 18.6;
                    break;
                case "სც-2":
                    returnFactor = 18.6;
                    break;
                case "სც-3":
                    returnFactor = 18.6;
                    break;
                case "სც-4":
                    returnFactor = 18.6;
                    break;
                case "სწ-1":
                    returnFactor = 27.9;
                    break;
                case "სწ-2":
                    returnFactor = 27.9;
                    break;
                case "დს":
                    returnFactor = 27.9;
                    break;
                default:
                    returnFactor = 0; // Other
                    break;
            } // New Compare function

            type1.Text = returnType;
            factor.Text = returnFactor.ToString();
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

        private void type2_TextChanged(object sender, EventArgs e)
        {
        }

        private void print_Click(object sender, EventArgs e)
        {
            obj1.TableToPdf();
        }
    }
}