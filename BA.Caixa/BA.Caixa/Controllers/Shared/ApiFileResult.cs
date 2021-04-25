using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Caixa.Controllers.Shared
{
    public class ApiFileResult
    {
        public IEnumerable<Notification> ErrorMessages { get; }
        public bool Success { get; }
        public string Data { get; }
        public string FileName { get; }
        public string FileExtension { get; }
        public bool Failure => !Success;


        public static ApiFileResult Ok(string filename, string extension, byte[] content)
        {
            return new ApiFileResult(true, filename, extension, content);
        }

        public static ApiFileResult Ok(string filename, string extension, string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);

            return Ok(filename, extension, bytes);
        }

        public static ApiFileResult Fail(Notification[] errorMessages)
        {
            return new ApiFileResult(false, "none", "none", null, errorMessages);
        }


        private ApiFileResult(bool isSuccess, string filename, string extension, byte[] content, params Notification[] errorMessages)
        {
            var stream = new System.IO.MemoryStream();
            stream.Write(content, 0, content.Length);
            stream.Position = 0;

            Data = Convert.ToBase64String(content, 0, content.Length);
            FileName = filename;
            FileExtension = extension;
            Success = isSuccess;
            ErrorMessages = errorMessages;
        }

    }
}
