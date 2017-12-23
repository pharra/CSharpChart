using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Analysis
    {
        public string DataAnalysis(DataObject dataObject)
        {
            Dictionary<string, int> programLanguage = dataObject.AllInfoObject.ProgramLanguage;
            var data =
            from language in programLanguage
            orderby language.Value descending
            select language;
            int maxAsked = data.First().Value;
            string maxLanguage = data.First().Key;
            return maxLanguage + maxAsked;
        }

    }
}
