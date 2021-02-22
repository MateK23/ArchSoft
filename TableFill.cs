extern alias spire;
using System;
using System.Data;
using System.Drawing;
using spire::Spire.Pdf;
using spire::Spire.Pdf.Graphics;
using spire::Spire.Pdf.Tables;


namespace ArchSoft
{
    class TableFill
    {
        DataTable table = new DataTable();
        private static double returnFactor;

        public TableFill()
        {
            table.Columns.Add("დაკავებულობა", typeof(string));
            table.Columns.Add("აღწერილობა", typeof(string));
            table.Columns.Add("ფართი", typeof(double));
            table.Columns.Add("დაკავებულობის დატვირთვის ფაქტორი", typeof(double));
            table.Columns.Add("დ.დ.", typeof(int));
        }

        private static decimal CustomRound(decimal x)
        {
            return decimal.Round(x - 0.001m, 2, MidpointRounding.AwayFromZero);
        }

        public void GetValues(string type1, string type2, double scale, double factor, int result)
        {
            System.Diagnostics.Debug.WriteLine(scale);
            if (factor == 0)
            {
                factor = Compare(type1);
                result = (int)Math.Floor(scale / factor);
            }
            if (result == 0 && factor != 0)
            {
                result = (int)Math.Round(scale / factor);
            }
            else if(factor == 0)
            {
                factor = 0;
                result = 0;
            }
            
            table.Rows.Add(type1, type2, scale, factor, result);
        }

        private static double Compare(string type)
        {
            
            switch (type)
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
            }
            return returnFactor;
        }

        public DataTable TableRetrun()
        {
            return table;
        }

        public void TableToPdf()
        {
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(2.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // New Page
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);
            float y = 10;

            // Title
            PdfBrush brush1 = PdfBrushes.Black;
            String fontFileName = "C:\\Fonts\\bpg_nino_mtavruli_normal.ttf";
            PdfTrueTypeFont fontTrue = new PdfTrueTypeFont(fontFileName, 14f);
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("დაკავებულობა", fontTrue, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + fontTrue.MeasureString("დაკავებულობა", format1).Height;
            y = y + 5;

            DataTable dt = this.table.Clone();
            for (int i = 0; i < this.table.Columns.Count; i++)
            {
                dt.Columns[i].DataType = typeof(Object);
            }
            foreach (DataRow row in this.table.Rows)
            {
                dt.ImportRow(row);
            }
            DataRow headerRow = dt.NewRow();
            for (int i = 0; i < this.table.Columns.Count; i++)
            {
                headerRow[i] = this.table.Columns[i].ColumnName;
            }

            dt.Rows.InsertAt(headerRow, 0);
            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(fontFileName, 10f);
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(fontFileName, 12f);
            table.DataSource = dt;
            table.Style.AlternateStyle.Font = new PdfTrueTypeFont(fontFileName, 10f);
            PdfLayoutResult result = table.Draw(page, new PointF(0, y));
            y = y + result.Bounds.Height + 5;

            doc.SaveToFile("TestTable.pdf");
            doc.Close();
            System.Diagnostics.Process.Start("TestTable.pdf");
        }
    }
}