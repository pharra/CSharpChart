using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Analysis
    {
        public string LanguageAnalysis(DataObject dataObject)
        {
            Dictionary<string, int> programLanguage = dataObject.AllInfoObject.ProgramLanguage;
            var data =
            from language in programLanguage
            orderby language.Value descending
            select language;
            int maxCount = data.First().Value;
            string maxLanguage = data.First().Key;
            return maxLanguage + maxCount;
        }

        public string CompanyAnalysis(DataObject dataObject, string placeName)
        {
            Dictionary<string, DataInfoObject> companyInfo = dataObject.CompanyObject;


            return null;
        }
    }
}
