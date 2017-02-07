using SimpleHttpServer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleHttpServer.Models
{
    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "Content-type: text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }

        public HeaderType Type { get; set; }

        public string ContentType { get; set; }

        public string ContentLenght { get; set; }

        public Dictionary<string, string> OtherParameters { get; set; }

        public CookieCollection Cookies { get; private set; }

        public override string ToString()
        {
            StringBuilder headerSb = new StringBuilder();

            headerSb.AppendLine(ContentType);
            if (Cookies.Count > 0)
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    headerSb.AppendLine($"Cookie: {this.Cookies.ToString()}");
                }
                else if (this.Type == HeaderType.HttpResponce)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        headerSb.AppendLine($"Set-Cookie: {cookie}");
                    }
                }
            }

            if (this.ContentLenght != null)
            {
                headerSb.AppendLine($"Content-Length: {this.ContentLenght}");
            }

            foreach (var other in OtherParameters)
            {
                headerSb.AppendLine($"{other.Key}: {other.Value}");
            }

            headerSb.AppendLine();
            headerSb.AppendLine();

            return headerSb.ToString();
        }

    }
}
