using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;
using WineTrip.DataModel;
using MigraDoc.DocumentObjectModel.Shapes;
using System.Xml.XPath;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace WineTrip
{
    public class OrderPDF
    {
        private Event evnt;
        private Trip trip;
        private Document document;
        private Table table;

        public OrderPDF()
        {
        }

        public void Create(Trip trip, Event evnt, string filename)
        {
            PdfDocumentRenderer pdfRenderer = PrepareDocument(trip, evnt);
            try
            {
                pdfRenderer.PdfDocument.Save(filename);
            }
            catch(Exception)
            {
                System.Windows.Forms.MessageBox.Show("Can not update preview, file may be in use...");
            }
        }


        private PdfDocumentRenderer PrepareDocument(Trip trip, Event evnt)
        {
            this.trip = trip;
            this.evnt = evnt;
            document = new Document();
            document.Info.Title = $" Order for {evnt.name}";
            document.Info.Subject = "Ordering wine";
            document.Info.Author = "Wine trip solutions (c)2017 Marcel Sennema";
            DefineStyles();
            CreatePage();

            document.UseCmykColor = true;
            const bool unicode = false;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);

            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            return pdfRenderer;
        }

        void DefineStyles()
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            style = document.Styles.AddStyle("Table", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            style.Font.Size = 9;

            style = document.Styles.AddStyle("Wine", "Table");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            style.Font.Size = 16;

            style = document.Styles.AddStyle("Count", "Table");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.Font.Size = 16;

            style = document.Styles.AddStyle("Price", "Table");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.Font.Size = 9;


            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = Orientation.Landscape;
            section.PageSetup.TopMargin = "3cm";
            section.PageSetup.LeftMargin = "0.5cm";
            section.PageSetup.RightMargin = "0.5cm";
            section.PageSetup.BottomMargin = "2.0cm";

            // Put a logo in the header
            Image image = section.Headers.Primary.AddImage("PageLogo.png");
            image.Height = "2.5cm";
            image.LockAspectRatio = true;
            image.RelativeVertical = RelativeVertical.Page;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = "0.5cm";
            image.Left = ShapePosition.Right;
            image.WrapFormat.Style = WrapStyle.Through;

            // Create the text frame for the winemaker and date
            TextFrame frame = section.Headers.Primary.AddTextFrame();
            frame.Top = "1cm";
            frame.Height = "2.0cm";
            frame.Width = "10.0cm";
            frame.Left = ShapePosition.Left;
            frame.RelativeHorizontal = RelativeHorizontal.Margin;
            frame.RelativeVertical = RelativeVertical.Page;

            Paragraph paragraph = frame.AddParagraph();
            paragraph.AddText($"{evnt.name}");
            paragraph.Format.Font.Size = 16;
            paragraph = frame.AddParagraph();
            paragraph.AddText($"{trip.startDate.AddDays(evnt.day).ToLongDateString()} {evnt.startString}");
            paragraph.Format.Font.Size = 10;

            // Create footer
            paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Wine trip solutions (c)2017 Marcel Sennema");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Create the item table
            table = section.AddTable();
            table.Style = "Table";
            table.Borders.Color = Colors.Gray;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;


            // Before adding rows we need to define the columns
            Column column = table.AddColumn("5cm");
            column.Format.Alignment = ParagraphAlignment.Left; // bottle description
            Unit width = new Unit(297, UnitType.Millimeter) - column.Width - section.PageSetup.LeftMargin - section.PageSetup.RightMargin;

            Unit columnWidth = width / (trip.members.Count + 1);
            for (int i = 0; i <= trip.members.Count; i++)
            {
                column = table.AddColumn(columnWidth);
                column.Format.Alignment = ParagraphAlignment.Center;
            }
            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Wine");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            for (int i = 0; i < trip.members.Count; i++)
            {
                row.Cells[i + 1].AddParagraph(trip.members[i].Name);
                row.Cells[i + 1].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[i + 1].VerticalAlignment = VerticalAlignment.Bottom;
            }
            row.Cells[trip.members.Count+1].AddParagraph("Total");
            row.Cells[trip.members.Count + 1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[trip.members.Count + 1].VerticalAlignment = VerticalAlignment.Bottom;
            // create the body of the table
            foreach(Bottle bottle in evnt.bottles.Where(x => x.TotalOrderCount > 0))
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(bottle.name).Style = "Wine";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].AddParagraph($"{bottle.vintage} {bottle.volume} {bottle.price}");
                foreach(Order order in bottle.orders)
                {
                    int colno = trip.members.IndexOf(order.member);
                    row.Cells[colno + 1].AddParagraph($"{order.count}").Style = "Count";
                    row.Cells[colno + 1].AddParagraph($"{order.count * bottle.price}").Style = "Price";
                }
                if (bottle.TotalOrderCount != 0)
                {
                    row.Cells[trip.members.Count + 1].AddParagraph($"{bottle.TotalOrderCount}").Style = "Count";
                    row.Cells[trip.members.Count + 1].AddParagraph($"{bottle.TotalOrderPrice}").Style = "Price";
                }
            }
            // create the totals
            row = table.AddRow();
            row.Cells[0].AddParagraph("Total").Style = "Wine";
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            for (int i = 0; i < trip.members.Count; i++)
            {
                if (evnt.TotalBottleCount(trip.members[i]) != 0)
                {
                    row.Cells[i + 1].AddParagraph($"{evnt.TotalBottleCount(trip.members[i])}").Style = "Count";
                    row.Cells[i + 1].AddParagraph($"{evnt.TotalPrice(trip.members[i])}").Style = "Price";
                }
            }
            row.Cells[trip.members.Count + 1].AddParagraph($"{evnt.TotalBottleCount(null)}").Style = "Count";
            row.Cells[trip.members.Count + 1].AddParagraph($"{evnt.TotalPrice(null)}").Style = "Price";
            // show the grid
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

     }
}
