using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.xml.simpleparser;
using System.IO;
using System.Data;
using System.Text;

namespace TestReports
{
    public class Report
    {
        public HttpResponse getReport(IEnumerable<ReportClass> list, HttpResponse Response)
        {
            string printingDate = DateTime.Now.Date.ToString("yyyy/MM/dd");
            Document doc = new Document(PageSize.A4.Rotate(), 0f, 0f, 10f, 1f);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                PdfAction pdfAction = new PdfAction(PdfAction.PRINTDIALOG);
                writer.SetOpenAction(pdfAction);
                doc.Open();

                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, false);
                Font font = new Font(bfTimes, 15, Font.ITALIC, BaseColor.BLUE);

                foreach (ReportClass reportData in list)
                {
                    string userIdNo = reportData.id;
                    string studentName = reportData.name;
                    string examDate = reportData.date;
                    string grade = reportData.grade;
                    string centerName = reportData.center;

                    doc.NewPage();

                    PdfDiv div = new PdfDiv();
                    div.PaddingLeft = 40f;
                    div.Width = 800f;
                    div.PaddingTop = 260f;
                    PdfPCell cell;
                    PdfPTable table = new PdfPTable(4);
                    table.TotalWidth = 900f;
                    table.SetWidths(new float[] { 0.20f, 0.45f, 0.20f, 0.15f });
                    table.SpacingBefore = 5f;

                    cell = new PdfPCell(new Phrase(" ", font));
                    cell.Border = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(studentName, font));
                    cell.Border = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(" ", font));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(userIdNo, font));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.PaddingLeft = 10f;
                    table.AddCell(cell);

                    PdfPTable table2 = new PdfPTable(1);
                    table2.TotalWidth = 900f;
                    table2.SetWidths(new float[] { 1f });
                    table2.SpacingBefore = 7f;

                    cell = new PdfPCell(new Phrase(" ", font));
                    cell.Border = 0;
                    table2.AddCell(cell);


                    PdfPTable table3 = new PdfPTable(3);
                    table3.TotalWidth = 900f;
                    table3.SetWidths(new float[] { 0.50f, 0.16f, 0.34f });
                    table3.SpacingBefore = 10.2f;

                    cell = new PdfPCell(new Phrase(" ", font));
                    cell.Border = 0;
                    table3.AddCell(cell);
                    cell = new PdfPCell(new Phrase(examDate, font));
                    cell.Border = 0;
                    cell.PaddingLeft = 20f;
                    table3.AddCell(cell);
                    cell = new PdfPCell(new Phrase(" ", font));
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table3.AddCell(cell);



                    PdfPTable table4 = new PdfPTable(3);
                    table4.SpacingBefore = 10f;
                    table4.TotalWidth = 900f;
                    table4.SetWidths(new float[] { 0.32f, 0.30f, 0.50f });

                    cell = new PdfPCell(new Phrase(centerName, font));
                    cell.Border = 0;
                    table4.AddCell(cell);
                    cell = new PdfPCell(new Phrase("", font));
                    cell.Border = 0;
                    table4.AddCell(cell);

                    cell = new PdfPCell(new Phrase(grade, font));
                    cell.Border = 0;
                    cell.PaddingLeft = 25f;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table4.AddCell(cell);


                    PdfPTable footertable = new PdfPTable(2);
                    footertable.TotalWidth = 900f;
                    footertable.SetWidths(new float[] { 0.1f, 0.5f });
                    footertable.SpacingBefore = 52f;


                    cell = new PdfPCell(new Phrase(printingDate, font));
                    cell.Border = 0;
                    cell.PaddingLeft = 25f;

                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    footertable.AddCell(cell);
                    cell = new PdfPCell(new Phrase(" ", font));
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    footertable.AddCell(cell);

                    div.AddElement(table);
                    div.AddElement(table2);
                    div.AddElement(table3);
                    div.AddElement(table4);
                    div.AddElement(footertable);
                    doc.Add(div);
                }

                doc.Close();

                
                Response.ContentType = "application/pdf";
                Response.Write(doc);
               // Response.Clear();
               // Response.End();

            }
            catch (Exception exception)
            { }
            return Response;

        }
    }
}