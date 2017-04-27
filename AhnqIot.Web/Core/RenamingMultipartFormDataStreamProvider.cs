using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AhnqIot.Web.Core
{
    public class RenamingMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public string Root { get; set; }
        //public Func<FileUpload.PostedFile, string> OnGetLocalFileName { get; set; }

        public RenamingMultipartFormDataStreamProvider(string root)
            : base(root)
        {
            Root = root;
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string filePath = headers.ContentDisposition.FileName;

            // Multipart requests with the file name seem to always include quotes.
            if (filePath.StartsWith(@"""") && filePath.EndsWith(@""""))
                filePath = filePath.Substring(1, filePath.Length - 2);

            var filename = Path.GetFileName(filePath);
            var extension = Path.GetExtension(filePath);
            var contentType = headers.ContentType.MediaType;

            return filename;
        } 
    }
}