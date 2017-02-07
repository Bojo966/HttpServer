using SimpleHttpServer.Enums;
using System.Linq;
using System.Text;

namespace SimpleHttpServer.Models
{
    public class HttpResponce
    {

        public HttpResponce()
        {
            this.Header = new Header(HeaderType.HttpResponce);
        }
        public ResponseStatusCode StatusCode { get; set; }

        public string StatusMessage => this.StatusCode.ToString();

        public Header Header;

        public byte[] Content { get; set; }

        public string ContentAsUtf8 { set { this.Content = Encoding.UTF8.GetBytes(value); } }

        public override string ToString()
        {
            return $"HTTP/1.0 {StatusCode} {StatusMessage}\n{Header}";
        }
    }
}
