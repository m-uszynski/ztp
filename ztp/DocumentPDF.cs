using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Tables;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ztp
{

    class DocumentPDF : IDocument
    {
        DataFacade data = new DataFacade();
        public void Generate(int id)
        {
            Order order = data.getOrder(id);
            
            List<OrderedProduct> products = data.GetOrderedProducts(id);

            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for a page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                graphics.DrawString("Faktura z dnia: " + $"{order.OrderDate.ToShortDateString()}r.", font, PdfBrushes.Black, new System.Drawing.PointF(0, 0));
                font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                graphics.DrawString("Kupiec: " + $"{order.Firstname}" + $" {order.Lastname}" + $" (PESEL: {order.Pesel})",font,PdfBrushes.Black, new System.Drawing.PointF(0,25));

                font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                graphics.DrawString("Lista produktów: ",font,PdfBrushes.Black, new System.Drawing.PointF(0,60));

                // DataTable with ordered products
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();
                table.Columns.Add("Lp.");
                table.Columns.Add("Nazwa");
                table.Columns.Add("Ilosc");
                table.Columns.Add("Cena");
                table.Columns.Add("VAT");

                int lp = 1;
                table.Rows.Add(new string[] { "Lp.", "Nazwa", "Ilosc", "Cena", "VAT" });
                foreach (OrderedProduct product in products)
                {
                    table.Rows.Add(new string[] { $"{lp++}", $"{product.Name}", $"{product.Count}", $"{product.Price} zl", $"{product.VAT} %" });
                }

                pdfLightTable.DataSource = table;
                pdfLightTable.Draw(page, new System.Drawing.PointF(0, 100));

                font = new PdfStandardFont(PdfFontFamily.Helvetica, 15);
                graphics.DrawString("Do zaplaty: " + $"{String.Format("{0:0.00}", order.TotalCost)} zl", font, PdfBrushes.Black, new System.Drawing.PointF(320, 0));


                // Path to save
                string fileName = "";
                Microsoft.Win32.OpenFileDialog diag = new Microsoft.Win32.OpenFileDialog();
                diag.ValidateNames = false;
                diag.CheckFileExists = false;
                diag.CheckPathExists = true;
                diag.FileName = "Faktura_" + $"{order.Firstname}_"+$"{order.Lastname}_"+$"{order.OrderDate.ToShortDateString()}";
                if (diag.ShowDialog() == true)
                {
                    fileName = diag.FileName;
                }


                //Save the document
                try
                {
                    document.Save(fileName + ".pdf");
                    System.Windows.MessageBox.Show("Pomyślnie zapisano dokument", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd: " + ex.Message);
                }
            }
        }
    }
}
