using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser.Logic
{
    internal interface IFunctions
    {
        public abstract List<string> ParsedLink(string html);
    }
}
