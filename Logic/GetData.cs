using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MainRequest
{
    // search systems which i using
    //Only Google and Bing. Other platforms i would like to add later.

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

        private readonly string html;

        public CollectData(SearchSystem search)
        {
            this.html = new System.Net.WebClient().DownloadString(search.google.ToString()); //Initialize html field from SearchSystem class
        }
        
        ~CollectData() //destructor
        {
            MessageBox.Show("Data has been loaded."); //Most simple to use VisualBasic message window
        }

        public List<string> ParsedLink(string html)
        {
            List<string> resources = new List<string>();

            MSHTML.HTMLDocument doc = null!;
            MSHTML.IHTMLDocument2 d2 = null!;
            MSHTML.IHTMLDocument3 d = null!;

            try
            {
                doc = new MSHTML.HTMLDocument(); 
                d2 = (MSHTML.IHTMLDocument2)doc;
                d2.designMode = "On";
                d2.write(html);

                d = (MSHTML.IHTMLDocument3)doc;
                var collection = d.getElementsByTagName("a"); //getting collection by tag name
                object? val;

                foreach (MSHTML.IHTMLElement element in collection) //getting elements by attribute
                {
                    val = element.getAttribute("href"); // add searched values to list
                    if (val == null) continue;
                    resources.Add((string)val);
                }
            }
            finally
            {
                if (doc != null) Marshal.ReleaseComObject(doc);
                if (d2 != null) Marshal.ReleaseComObject(d2);
                if (d != null) Marshal.ReleaseComObject(d);
            }
            return resources; //return list of values

        }
    }
}



