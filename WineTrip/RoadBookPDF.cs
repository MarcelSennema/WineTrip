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
using System.IO;

namespace WineTrip
{
    public class RoadBookPDF
    {

        public RoadBookPDF()
        {
        }

        public static void  Create(Trip trip, string filename)
        {
            PdfDocumentRenderer pdfRenderer = PrepareDocument(trip);
            pdfRenderer.PdfDocument.Save(filename);        }


        private static PdfDocumentRenderer PrepareDocument(Trip trip)
        {
            Document document = new Document();
            document.Info.Title = $"Roadbook for {trip.region} { trip.startDate}";
            document.Info.Subject = "Roadbook";
            document.Info.Author = "Wine trip solutions (c)2017 Marcel Sennema";
            DefineStyles(document);
            CreatePages(document, trip);

            document.UseCmykColor = true;
            const bool unicode = false;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);

            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            return pdfRenderer;
        }

        private static void DefineStyles(Document document)
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

        private static void CreatePages(Document document, Trip trip)
        {
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = Orientation.Portrait;
            section.PageSetup.TopMargin = "3cm";
            section.PageSetup.LeftMargin = "2cm";
            section.PageSetup.RightMargin = "2cm";
            section.PageSetup.BottomMargin = "3cm";

            // Put a logo in the header
            Image image = section.Headers.Primary.AddImage("PageLogo.png");
            image.Height = "2cm";
            image.LockAspectRatio = true;
            image.RelativeVertical = RelativeVertical.Page;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = "0.5cm";
            image.Left = ShapePosition.Right;
            image.WrapFormat.Style = WrapStyle.Through;
            // create header
            Paragraph paragraph = section.Headers.Primary.AddParagraph();
            paragraph.AddText($"Roadbook for {trip.region}");
            paragraph.Format.Font.Size = 10;
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph = section.Headers.Primary.AddParagraph();
            paragraph.AddText($"{ trip.startDate.ToShortDateString()} - {trip.startDate.AddDays(trip.numberOfDays).ToShortDateString()}");
            paragraph.Format.Font.Size = 10;
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph = section.Headers.Primary.AddParagraph();
            var hrBorder = new Border();
            hrBorder.Width = "1pt";
            hrBorder.Color = Colors.DarkGray;
            paragraph.Format.Borders.Bottom = hrBorder;
            paragraph.Format.LineSpacing = 0;
            paragraph.Format.SpaceAfter = 15;

            // Create footer
            paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Wine trip solutions (c)2017 Marcel Sennema");
            paragraph.Format.Font.Size = 8;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            AddParagraph(section, "", $"Description", 14);
            AddParagraph(section, "", $"{trip.description}", 10);
            AddParagraph(section, "", $"", 10);
            AddRuler(section);

            paragraph = section.AddParagraph();
            paragraph.AddText($"Party members");
            paragraph.Format.Font.Size = 14;
            foreach (Member member in trip.members)
                AddParagraph(section, "",  $"{member.ShortName}", 10);
            AddRuler(section);
            foreach (Event evnt in trip.events)
                CreateWineMakerSection(section, trip, evnt);
        }

        private static void CreateWineMakerSection(Section section, Trip trip,  Event evnt)
        {
            section.AddPageBreak();
            AddParagraph(section, "", $"{trip.startDate.AddDays(evnt.day).ToLongDateString()} start: {evnt.startString} duration {evnt.duration}minutes", 10);
            AddParagraph(section, "", $"{evnt.name}", 16);
            AddParagraph(section, "", $"{evnt.address}", 16);
            AddParagraph(section, "", $"{evnt.description}", 10);
            AddParagraph(section, "GPS location: ", $"{evnt.GPSLocation}", 10);
            AddParagraph(section, "eMail: ", $"{evnt.eMail}", 10);
            AddParagraph(section, "Web site: ", $"{evnt.webSite}", 10);
            AddImage(section, evnt.transferFrom?.map);
            AddRuler(section);
        }

        private static void AddParagraph( Section section, string prefix, string text, int fontsize, string spaceAfter = null)
        {
            if (text != string.Empty)
            {
                Paragraph paragraph = section.AddParagraph();
                paragraph.AddText(prefix);
                paragraph.AddText(text);
                paragraph.Format.Font.Size = fontsize;
                if (spaceAfter != null)
                    paragraph.Format.SpaceAfter = spaceAfter;
            }
        }

        private static void AddRuler(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            var hrBorder = new Border();
            hrBorder.Width = "1pt";
            hrBorder.Color = Colors.DarkGray;
            paragraph.Format.Borders.Bottom = hrBorder;
            paragraph.Format.LineSpacing = 0;
            paragraph.Format.SpaceBefore = 15;
        }

        private static void AddImage(Section section, System.Drawing.Bitmap img)
        {
            if (img != null)
            {
                string imageFilename = Path.GetTempFileName();
                img.Save(imageFilename);
                Image image = section.AddImage(imageFilename);
                image.Width = "6cm";
                image.LockAspectRatio = true;
                File.Delete(imageFilename);
            }
        }
    }
}
