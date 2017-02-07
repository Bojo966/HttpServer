using SimpleHttpServer.Enums;
using System.Text;

namespace SimpleHttpServer.Models
{
    public class HttpRequest
    {
        public RequestMethod Method { get; set; }

        public string Url { get; set; }

        public HttpRequest Header { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            StringBuilder requestSb = new StringBuilder();

            requestSb.AppendLine($"{this.Method} {Url} HTTP/1.0");
            requestSb.AppendLine($"{this.Header}");

            if (string.IsNullOrEmpty(Content))
            {
                requestSb.AppendLine(this.Content);
            }

            return requestSb.ToString();
        }
    }
}
