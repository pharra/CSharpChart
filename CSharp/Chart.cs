using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Chart
    {
        public void CsChart(DataObject dataObject)
        {
            Dictionary<string, int> programLanguage = dataObject.AllInfoObject.ProgramLanguage;
            List<string> xData = new List<string>();
            List<int> yData = new List<int>();
            foreach(var data in programLanguage)
            {
                string language = data.Key;
                xData.Add(language);
                int num = data.Value;
                yData.Add(num);
            }
        }
        public List<string> xData;
        public List<int> yData;

        internal void CsChart()
        {
            throw new NotImplementedException();
        }
    }
}
