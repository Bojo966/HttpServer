using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleHttpServer.Models
{
    public class CookieCollection : IEnumerable<Cookie>
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public IDictionary<string, Cookie> Cookies { get; private set; }

        public int Count => this.Cookies.Count;

        public bool Contains(string cookieNames) => this.Cookies.ContainsKey(cookieNames);

        public void Add(Cookie cookie)
        {
            if (!this.Cookies.ContainsKey(cookie.Name))
            {
                this.Cookies.Add(cookie.Name, new Cookie());
            }

            this.Cookies[cookie.Name] = cookie;
        }

        public Cookie this[string cookieName]
        {
            get { return this.Cookies[cookieName]; }
            set
            {
                if (!this.Cookies.ContainsKey(cookieName))
                {
                    this.Cookies.Add(cookieName, new Cookie());
                }

                this.Cookies[cookieName] = value;
            }
        }           

        public IEnumerator<Cookie> GetEnumerator() => this.Cookies.Values.GetEnumerator();      

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public override string ToString()
        {
            return string.Join("; ", Cookies.Values);
        }
    }
}
