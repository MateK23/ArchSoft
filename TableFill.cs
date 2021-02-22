extern alias spire;
using System;
using System.Data;
using System.Drawing;
using spire::Spire.Pdf;
using spire::Spire.Pdf.Graphics;
using spire::Spire.Pdf.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArchSoft
{
    class TableFill
    {
        DataTable table = new DataTable();

        public TableFill()
        {
            table.Columns.Add("დაკავებულობა", typeof(string));
            table.Columns.Add("აღწერილობა", typeof(string));
            table.Columns.Add("ფართი", typeof(double));
            table.Columns.Add("დაკავებულობის დატვირთვის ფაქტორი", typeof(double));
            table.Columns.Add("დ.დ.", typeof(int));
        }

        public void GetValues(string type1, string type2, double scale, double factor, int result)
        {
            if (result == 0 || result == null)
            {
                if (factor != 0)
                {
                    result = (int)Math.Floor(scale / factor);
                }

                if (result == 0 && factor != 0)
                {
                    result = (int)Math.Round(scale / factor);
                }
                else if (factor == 0)
                {
                    factor = 0;
                    result = 0;
                }
            }

            table.Rows.Add(type1, type2, scale, factor, result);
        }

        public DataTable TableRetrun()
        {
            return table;
        }

        public void TableToPdf()
        {
            string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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
            String fontFileName = "C:\\Fonts\\font.ttf";
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

            // doc.SaveToFile($@"{PathToDesktop}\Archsoft Generated.pdf");
            doc.SaveToFile("Archsoft Generated.pdf");
            doc.Close();
            System.Diagnostics.Process.Start("Archsoft Generated.pdf");
        }
    }
}