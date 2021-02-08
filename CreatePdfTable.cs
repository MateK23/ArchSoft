extern alias spire;

using System;
using System.Data;
using System.Drawing;
using spire::Spire.Pdf;
using spire::Spire.Pdf.Graphics;
using spire::Spire.Pdf.Tables;

namespace ArchSoft
{
    class CreatePdfTable
    {
        public CreatePdfTable()
        {
            

            // Margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
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
            y = y + fontTrue.MeasureString("Country List", format1).Height;
            y = y + 5;

            // PDF table's data Source

            String[] data = {
                    "დაკავებულობა;აღწერილობა;ფართი მ;დაკავებულობის დატვირთვის ფაქტორი;დ.დ.",
                    "SV-4;Test;57;27.5;4",
            };

            String[][] dataSource = new string[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
                
            }
            
            // Creating Table, Setting formats

            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(fontFileName, 10f);
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(fontFileName, 6f);
            table.DataSource = dataSource;
            table.Style.AlternateStyle.Font = new PdfTrueTypeFont(fontFileName, 10f);
            PdfLayoutResult result = table.Draw(page, new PointF(0, y));
            y = y + result.Bounds.Height + 5;
            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont fontTrue3 = new PdfTrueTypeFont(fontFileName, 8f);
            page.Canvas.DrawString(String.Format("სია შეიცავს {0} ობიექტს.", data.Length - 1), fontTrue3, brush2, 5, y);

            // Save and preview

            doc.SaveToFile("TestTable.pdf");
            doc.Close();
            System.Diagnostics.Process.Start("TestTable.pdf");
        }
    }
}
