using System;
using System.Net;
using System.Runtime.InteropServices;

namespace MainRequest
{
    // search systems which i using
#warning "Only Google and Bing. Other platforms i would like to add later."

    class SearchSystem
    {
        private readonly string? searchRequest;
        public readonly Uri google;

        public SearchSystem(string searchRequest)
        {
            this.searchRequest = searchRequest;
            google = new Uri($"http://google.com/search?q={searchRequest}"); //initialize variable by searched word
        }

    }

    class CollectData
    {

        string html;

        public CollectData(string uri)
        {
            this.html = new WebClient().DownloadString(uri);
        }

        public List<object> ParsedLink(string html)
        {
            List<object> resources = new List<object>();

            MSHTML.HTMLDocument doc = null!;
            MSHTML.IHTMLDocument2 d2= null!;
            MSHTML.IHTMLDocument3 d = null!;

            try
            {
                doc = new MSHTML.HTMLDocument();
                d2 = (MSHTML.IHTMLDocument2)doc;
                d2.designMode = "On";
                d2.write(html);

                d = (MSHTML.IHTMLDocument3)doc;
                var coll = d.getElementsByTagName("a");//getting collection by tag name
                object val;

                foreach(MSHTML.IHTMLElement element in coll)
                {
                    val = element.getAttribute("href");
                    if (val == null) continue;
                    resources.Add(val.ToString());
                }
            }
            finally
            {
                if (doc != null) Marshal.ReleaseComObject(doc);
                if (d2 != null) Marshal.ReleaseComObject(d2);
                if (d != null) Marshal.ReleaseComObject(d);
            }
            return resources;

        }
    }
}



