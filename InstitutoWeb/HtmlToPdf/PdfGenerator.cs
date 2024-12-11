using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;

using System.Text;

namespace InstitutoWeb.HtmlToPdf
{
    public class PdfGenerator
    {
        public async Task<byte[]> GeneratePdfAsync(string html)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(html));
            ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
            PdfWriter writer = new PdfWriter(byteArrayOutputStream);
            PdfDocument pdfDocument = new PdfDocument(writer);
            pdfDocument.SetDefaultPageSize(PageSize.A4);
            // Configurar la URI base
            ConverterProperties converterProperties = new ConverterProperties();
            converterProperties.SetBaseUri("http://localhost:7189/");

            HtmlConverter.ConvertToPdf(stream, pdfDocument, converterProperties);
            pdfDocument.Close();

            return byteArrayOutputStream.ToArray();
        }
    }

        
}
