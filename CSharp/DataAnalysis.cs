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
            Dictionary<string, int> technologyStack = dataObject.AllInfoObject.TechnologyStack;
            Dictionary<string, int> job = dataObject.AllInfoObject.Job;
            Dictionary<string, int> address = dataObject.AllInfoObject.Address;
            var data1 =
            from language in programLanguage
            orderby language.Value descending
            select language;
            int maxCount1 = data1.First().Value;
            string maxLanguage = data1.First().Key;
            string result1 = maxLanguage + "语言的需求量最大，有" + maxCount1 + "个岗位可供选择。";
            string advise1 = "建议学习者可以倾向于学习" + maxLanguage + "以便日后求职时能够有较多选择；而求职者则可以加深对" + maxLanguage +"的研究，以便在激烈的竞争中脱颖而出。";
            var data2 =
                from stack in technologyStack
                orderby stack.Value descending
                select stack;
            int maxCount2 = data2.First().Value;
            string maxStack = data2.First().Key;
            string result2 = maxStack + "技术栈的需求量最大，有" + maxCount2 + "个岗位可供选择。";
            string advise2 = "建议学习者可以倾向于学习" + maxStack + "技术栈方面的知识，以便日后求职时能够有较多选择；而求职者则可以加深对" + maxStack + "的研究，以便在激烈的竞争中脱颖而出。";
            var data3 =
            from yourJob in job
            orderby yourJob.Value descending
            select yourJob;
            int maxCount3 = data3.First().Value;
            string maxJob = data3.First().Key;
            string result3 = maxJob + "岗位的需求量最大，有" + maxCount3 + "个岗位可供选择。";
            string advise3 = "建议学习者可以倾向于学习" + maxJob + "方面的知识，以便日后求职时能够有较多选择；而求职者则可以加深对" + maxJob + "的研究，以便在激烈的竞争中脱颖而出。";
            var data4 =
            from theAddress in address
            orderby theAddress.Value descending
            select theAddress;
            int maxCount4 = data4.First().Value;
            string maxAddress = data4.First().Key;
            string result4 = maxAddress + "的人才需求量最大，有" + maxCount4 + "个岗位急需人才。";
            string advise4 = "建议求职者可以前往" + maxAddress + "进行求职";
            return result1 + "\n" + advise1 + "\n" + result2 + "\n" + advise2 + "\n" + result3 + "\n" + advise3 + "\n" + result4 + "\n" + advise4;
        }

        public string CompanyAnalysis(DataObject dataObject, string companyName)
        {
            Dictionary<string, DataInfoObject> allCompanyInfo = dataObject.CompanyObject;
            DataInfoObject companyInfo = new DataInfoObject();
            allCompanyInfo.TryGetValue(companyName, out companyInfo);
            var data1 =
                from technologyStack in companyInfo.TechnologyStack
                orderby technologyStack.Value descending
                select technologyStack;
            int maxCount1 = data1.First().Value;
            string maxTecStack = data1.First().Key;
            string result1 = companyName + "对" + maxTecStack + "岗位的需求最大，共有" + maxCount1 + "个需求。";
            string advise1 = "建议对" + companyName + "感兴趣的求职者多了解" + maxTecStack + "方面的知识，以便提高进入心仪公司的概率。";
            var data2 =
                from programLanguage in companyInfo.ProgramLanguage
                orderby programLanguage.Value descending
                select programLanguage;
            int maxCount2 = data2.First().Value;
            string maxLanguage = data2.First().Key;
            string result2 = companyName + "对了解" + maxLanguage + "语言的人才需求最大，共有" + maxCount2 + "个需求。";
            string advise2 = "建议对" + companyName + "感兴趣的求职者多学习" + maxLanguage + "相关的知识，以便提高进入心仪公司的概率。";
            var data3 =
                from yourJob in companyInfo.Job
                orderby yourJob.Value descending
                select yourJob;
            int maxCount3 = data3.First().Value;
            string maxJob = data3.First().Key;
            string result3 = companyName + "对" + maxJob + "的需求最大，共有" + maxCount3 + "个需求。";
            string advise3 = "建议对" + companyName + "感兴趣的求职者多了解" + maxJob + "方面的知识，以便提高进入心仪公司的概率。";
            var data4 =
                from address in companyInfo.Address
                orderby address.Value descending
                select address;
            int maxCount4 = data4.First().Value;
            string maxAddress = data4.First().Key;
            string result4 = companyName + "在" + maxAddress + "对人才的需求最大，共有" + maxCount4 + "个需求。";
            string advise4 = "建议对" + companyName + "感兴趣的求职者前往" + maxAddress + "，以便提高进入心仪公司的概率。";
            return result1 +"\n" + advise1 + "\n" + result2 + "\n" + advise2 + "\n" + result3 + "\n" + advise3 + "\n" + result4 + "\n" + advise4;
        }

        public string AddressAnalysis(DataObject dataObject, string addressName)
        {
            Dictionary<string, Dictionary<string, DataInfoObject>> allAddress = dataObject.AddressObject;
            Dictionary<string, DataInfoObject> addressInfo = new Dictionary<string, DataInfoObject>();
            allAddress.TryGetValue(addressName, out addressInfo);
            int maxCount1 = 0;
            foreach (var company in addressInfo)
            {
                if (maxCount1 < company.Value.Job.Values.Sum())
                {
                    maxCount1 = company.Value.Job.Values.Sum();
                }
            }
            string needestCompany = addressInfo.ElementAt(maxCount1).Key;
            string result1 =  "在" + addressName + "，" + needestCompany + "公司对人才的需求最大，共有" + maxCount1 + "个岗位存在需求";
            string advise1 = "对于家在" + addressName + "的求职者，建议前往" + needestCompany + "进行求职，成功性较高。";
            int maxCount2 = 0;
            foreach (var company in addressInfo)
            {
                if (maxCount2 < company.Value.ProgramLanguage.Values.Sum())
                {
                    maxCount2 = company.Value.ProgramLanguage.Values.Sum();
                }
            }
            string maxLanguage = addressInfo.ElementAt(maxCount2).Key;
            string result2 = "在" + addressName + "，" + needestCompany + "公司对" + maxLanguage + "语言的人才需求最大，共有" + maxCount2 + "个岗位存在需求";
            string advise2 = "对于家在" + addressName + "的求职者，如果擅长" + maxLanguage + "，则建议前往" + needestCompany + "进行求职，成功性较高。";
            int maxCount3 = 0;
            foreach (var company in addressInfo)
            {
                if (maxCount3 < company.Value.TechnologyStack.Values.Sum())
                {
                    maxCount3 = company.Value.TechnologyStack.Values.Sum();
                }
            }
            string maxStack = addressInfo.ElementAt(maxCount3).Key;
            string result3 = "在" + addressName + "，" + needestCompany + "公司对" + maxStack + "编程的人才需求最大，共有" + maxCount3 + "个岗位存在需求";
            string advise3 = "对于家在" + addressName + "的求职者，如果擅长" + maxStack + "方面的编程，则建议前往" + needestCompany + "进行求职，成功性较高。";
            return result1 + "\n" + advise1 + "\n"+ result2 + "\n" + advise2 + "\n"+result3 + "\n" + advise3;
        }
    }
}
