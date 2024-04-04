using DocumentFormat.OpenXml.Packaging;

namespace Languagewire.Utilities
{
    public static class DocumentUtilities
    {
        public static string ReadWordDocument(string filePath)
        {
            using (var wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                if (wordDoc.MainDocumentPart != null && wordDoc.MainDocumentPart.Document != null && wordDoc.MainDocumentPart.Document.Body != null)
                {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    return body.InnerText; 
                }
                else
                {
                    return "The document could be empty";
                }
            }
        }


        public static bool WaitForFile(string filePath, int timeoutInSeconds)
        {
            bool fileExists = false;
            int waited = 0;
            while (!fileExists && waited < timeoutInSeconds)
            {
                Thread.Sleep(2000); 
                fileExists = File.Exists(filePath);
                waited++;
            }
            return fileExists;
        }
    }
}
