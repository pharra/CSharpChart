using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class DataAnalysis
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
            return maxLanguage + "语言的需求量最大，有" + maxCount + "个岗位可供选择。";
        }

        public string CompanyAnalysis(DataObject dataObject, string companyName)
        {
            Dictionary<string, DataInfoObject> allCompanyInfo = dataObject.CompanyObject;
            DataInfoObject companyInfo = new DataInfoObject();
            allCompanyInfo.TryGetValue(companyName, out companyInfo);
            var position =
                from technologyStack in companyInfo.TechnologyStack
                orderby technologyStack.Value descending
                select technologyStack;
            int maxCount = position.First().Value;
            string maxTecStack = position.First().Key;
            return companyName + "对" + maxTecStack + "岗位的需求最大，共有" + maxCount + "个需求";
        }

        public string AddressAnalysis(DataObject dataObject, string addressName)
        {
            Dictionary<string, Dictionary<string, DataInfoObject>> allAddress = dataObject.AddressObject;
            Dictionary<string, DataInfoObject> addressInfo = new Dictionary<string, DataInfoObject>();
            allAddress.TryGetValue(addressName, out addressInfo);
            int maxCount = 0;
            foreach (var company in addressInfo)
            {
                if (maxCount < company.Value.Job.Values.Sum())
                {
                    maxCount = company.Value.Job.Values.Sum();
                }
            }
            string needestCompany = addressInfo.ElementAt(maxCount).Key;
            return "在" + addressName + "，" + needestCompany + "公司对人才的需求最大，共有" + maxCount + "个岗位存在需求";
        }
    }
}
