using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser.Logic
{
    class CollectDataFromResultsOfSearch : IFunctions
    {
        private List<string> listofAllResults = new List<string>();
        private readonly List<string> inputData;
        public CollectDataFromResultsOfSearch(List<string> resources)
        {
            this.inputData = resources;

        }
        public List<string> ParsedLink(string html)
        {
            foreach (var item in inputData)
            {
                Task.Run(() =>
                {
                    try
                    {

                        MSHTML.HTMLDocument doc = new MSHTML.HTMLDocument();
                        MSHTML.IHTMLDocument2 d2 = (MSHTML.IHTMLDocument2)doc;
                        MSHTML.IHTMLDocument3 d = null;

                        d2.designMode = "On";
                        d2.write(html);
                    }
                    finally
                    {

                    }

                });
            }
            return listofAllResults;
        }
    }
}
