using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Chart
    {
        public Dictionary<List<string>,List<int>> LanguageChart(DataObject dataObject)
        {
            Dictionary<List<string>, List<int>> pair = new Dictionary<List<string>, List<int>>();
            List<string> xData = new List<string>();
            List<int> yData = new List<int>();
            foreach(var data in dataObject.AllInfoObject.ProgramLanguage)
            {
                string language = data.Key;
                xData.Add(language);
                int num = data.Value;
                yData.Add(num);
            }
            pair.Add(xData, yData);
            return pair;
        }

        public Dictionary<List<string>, List<int>> StackChart(DataObject dataObject)
        {
            Dictionary<List<string>, List<int>> pair = new Dictionary<List<string>, List<int>>();
            List<string> xData = new List<string>();
            List<int> yData = new List<int>();
            foreach (var data in dataObject.AllInfoObject.TechnologyStack)
            {
                string technologyStack = data.Key;
                xData.Add(technologyStack);
                int num = data.Value;
                yData.Add(num);
            }
            pair.Add(xData, yData);
            return pair;
        }

        public Dictionary<List<string>, List<int>> JobChart(DataObject dataObject)
        {
            Dictionary<List<string>, List<int>> pair = new Dictionary<List<string>, List<int>>();
            List<string> xData = new List<string>();
            List<int> yData = new List<int>();
            foreach (var data in dataObject.AllInfoObject.Job)
            {
                string job = data.Key;
                xData.Add(job);
                int num = data.Value;
                yData.Add(num);
            }
            pair.Add(xData, yData);
            return pair;
        }

        public Dictionary<List<string>, List<int>> AddressChart(DataObject dataObject)
        {
            Dictionary<List<string>, List<int>> pair = new Dictionary<List<string>, List<int>>();
            List<string> xData = new List<string>();
            List<int> yData = new List<int>();
            foreach (var data in dataObject.AllInfoObject.Address)
            {
                string address = data.Key;
                xData.Add(address);
                int num = data.Value;
                yData.Add(num);
            }
            pair.Add(xData, yData);
            return pair;
        }
    }
}
