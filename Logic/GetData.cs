using System.Net;

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

            mshtml.HTMLDocument doc = null;
            mshtml.IHTMLDocument2 d2 = null;
            mshtml.IHTMLDocument3 d = null;

#nullable disable
            try
            {
                doc = new mshtml.HTMLDocument();//инициализация IE
                d2 = (mshtml.IHTMLDocument2)doc;
                d2.designMode = "On";
                d2.write(html);

                d = (mshtml.IHTMLDocument3)doc;
                var coll = d.getElementsByTagName("a");//получить коллекцию элементов по имени тега
                object val;

            }
            finally
            {

            }
#nullable restore
            return resources;

        }
    }
}



