using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Chart
    {
        public static Dictionary<List<string>,List<int>> ChartRender(Dictionary<string,int> dataObject)
        {
            Dictionary<List<string>, List<int>> pair = new Dictionary<List<string>, List<int>>();
            List<string> xData = new List<string>();
            List<int> yData = new List<int>();
            foreach(var data in dataObject)
            {
                string language = data.Key;
                xData.Add(language);
                int num = data.Value;
                yData.Add(num);
            }
            pair.Add(xData, yData);
            return pair;
        }
    }
}
