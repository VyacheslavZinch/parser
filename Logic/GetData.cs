using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using parser.Logic;

namespace MainRequest
{
    class CollectDataFromSearch : IFunctions
    {
        public readonly string _html;

        public CollectDataFromSearch(string siteURL)
        {
            this._html = new System.Net.WebClient().DownloadString(siteURL); //Initialize html field from SearchSystem class
        }
        
        ~CollectDataFromSearch() //destructor
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
                    val = element.getAttribute("href");// add searched values to list
                    if (val == null) continue;
                    else
                    {
                        resources.Add((string)val);
                        
                    }

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



