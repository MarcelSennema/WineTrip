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

        public void Create(Trip trip, Event evnt)
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
            const string filename = "Order.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            
            Process.Start(filename); // start a viewer.
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

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Size = 8;

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Wine", "Normal");
            style.Font.Size = 16;

            // Create a new style called Reference based on style Normal
            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();
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


            // Before you can add a row, you must define the columns
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
            // row.Shading.Color = TableBlue;
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
            foreach(Bottle bottle in evnt.bottles)
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(bottle.name).Style = "Wine";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].AddParagraph($"{bottle.vintage} {bottle.volume} {bottle.price}");
                foreach(Order order in bottle.orders)
                {
                    int colno = trip.members.IndexOf(order.member);
                    row.Cells[colno + 1].AddParagraph($"{order.count}");
                }
            }
            row = table.AddRow();
            row.Cells[0].AddParagraph("Total").Style = "Wine";
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;

            table.SetEdge(0, 0, trip.members.Count + 1, evnt.bottles.Count + 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

        //void FillContent()
        //{
        //    // Fill address in address text frame
        //    XPathNavigator item = SelectItem("/invoice/to");
        //    Paragraph paragraph = this.addressFrame.AddParagraph();
        //    paragraph.AddText(GetValue(item, "name/singleName"));
        //    paragraph.AddLineBreak();
        //    paragraph.AddText(GetValue(item, "address/line1"));
        //    paragraph.AddLineBreak();
        //    paragraph.AddText(GetValue(item, "address/postalCode") + " " + GetValue(item, "address/city"));

        //    // Iterate the invoice items
        //    double totalExtendedPrice = 0;
        //    XPathNodeIterator iter = this.navigator.Select("/invoice/items/*");
        //    while (iter.MoveNext())
        //    {
        //        item = iter.Current;
        //        double quantity = GetValueAsDouble(item, "quantity");
        //        double price = GetValueAsDouble(item, "price");
        //        double discount = GetValueAsDouble(item, "discount");

        //        // Each item fills two rows
        //        Row row1 = this.table.AddRow();
        //        Row row2 = this.table.AddRow();
        //        row1.TopPadding = 1.5;
        //        row1.Cells[0].Shading.Color = TableGray;
        //        row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
        //        row1.Cells[0].MergeDown = 1;
        //        row1.Cells[1].Format.Alignment = ParagraphAlignment.Left;
        //        row1.Cells[1].MergeRight = 3;
        //        row1.Cells[5].Shading.Color = TableGray;
        //        row1.Cells[5].MergeDown = 1;

        //        row1.Cells[0].AddParagraph(GetValue(item, "itemNumber"));
        //        paragraph = row1.Cells[1].AddParagraph();
        //        paragraph.AddFormattedText(GetValue(item, "title"), TextFormat.Bold);
        //        paragraph.AddFormattedText(" by ", TextFormat.Italic);
        //        paragraph.AddText(GetValue(item, "author"));
        //        row2.Cells[1].AddParagraph(GetValue(item, "quantity"));
        //        row2.Cells[2].AddParagraph(price.ToString("0.00") + " €");
        //        row2.Cells[3].AddParagraph(discount.ToString("0.0"));
        //        row2.Cells[4].AddParagraph();
        //        row2.Cells[5].AddParagraph(price.ToString("0.00"));
        //        double extendedPrice = quantity * price;
        //        extendedPrice = extendedPrice * (100 - discount) / 100;
        //        row1.Cells[5].AddParagraph(extendedPrice.ToString("0.00") + " €");
        //        row1.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;
        //        totalExtendedPrice += extendedPrice;

        //        this.table.SetEdge(0, this.table.Rows.Count - 2, 6, 2, Edge.Box, BorderStyle.Single, 0.75);
        //    }

        //    // Add an invisible row as a space line to the table
        //    Row row = this.table.AddRow();
        //    row.Borders.Visible = false;

        //    // Add the total price row
        //    row = this.table.AddRow();
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].AddParagraph("Total Price");
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;
        //    row.Cells[5].AddParagraph(totalExtendedPrice.ToString("0.00") + " €");

        //    // Add the VAT row
        //    row = this.table.AddRow();
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].AddParagraph("VAT (19%)");
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;
        //    row.Cells[5].AddParagraph((0.19 * totalExtendedPrice).ToString("0.00") + " €");

        //    // Add the additional fee row
        //    row = this.table.AddRow();
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].AddParagraph("Shipping and Handling");
        //    row.Cells[5].AddParagraph(0.ToString("0.00") + " €");
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;

        //    // Add the total due row
        //    row = this.table.AddRow();
        //    row.Cells[0].AddParagraph("Total Due");
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;
        //    totalExtendedPrice += 0.19 * totalExtendedPrice;
        //    row.Cells[5].AddParagraph(totalExtendedPrice.ToString("0.00") + " €");

        //    // Set the borders of the specified cell range
        //    this.table.SetEdge(5, this.table.Rows.Count - 4, 1, 4, Edge.Box, BorderStyle.Single, 0.75);

        //    // Add the notes paragraph
        //    paragraph = this.document.LastSection.AddParagraph();
        //    paragraph.Format.SpaceBefore = "1cm";
        //    paragraph.Format.Borders.Width = 0.75;
        //    paragraph.Format.Borders.Distance = 3;
        //    paragraph.Format.Borders.Color = TableBorder;
        //    paragraph.Format.Shading.Color = TableGray;
        //    item = SelectItem("/invoice");
        //    paragraph.AddText(GetValue(item, "notes"));
        //}
    }
}
