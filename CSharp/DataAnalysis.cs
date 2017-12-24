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
            string result = maxLanguage + "语言的需求量最大，有" + maxCount + "个岗位可供选择。";
            string advise = "建议学习者可以倾向于学习" + maxLanguage + "以便日后求职时能够有较多选择；而求职者则可以加深对" + maxLanguage +"的研究，以便在激烈的竞争中脱颖而出。";
            return result + advise;
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
            string result = companyName + "对" + maxTecStack + "岗位的需求最大，共有" + maxCount + "个需求。";
            string advise = "建议对" + companyName + "感兴趣的求职者多了解" + maxTecStack + "方面的知识，以便提高进入心仪公司的概率。";
            return result + advise;
        }

        public string Address(DataObject dataObject, string addressName)
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
            string result =  "在" + addressName + "，" + needestCompany + "公司对人才的需求最大，共有" + maxCount + "个岗位存在需求";
            string advise = "对于家在" + addressName + "的求职者，建议前往" + needestCompany + "进行求职，该公司人才需求相较其他公司较大，求职成功性较高。";
            return result + advise;
        }
    }
}
