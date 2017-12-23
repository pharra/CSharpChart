using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class DataCollection
    {
        private List<RawDataObject> rawDataObject;

        public DataCollection()
        {
            try
            {
                StreamReader reader = new StreamReader(@"..\..\data.txt", Encoding.UTF8);
                rawDataObject = new List<RawDataObject>();

                String data = reader.ReadLine();
                while (data != null)
                {
                    String[] rows = data.Split('\t');
                    rawDataObject.Add(new RawDataObject(rows[0], rows[1], rows[2],
                        rows[3], rows[4], rows[5], rows[6]));
                    data = reader.ReadLine();
                }
                Console.WriteLine("读取数据成功...");
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public DataObject GetDataObject()
        {
            DataObject dataObject = new DataObject();
            foreach(var programLanguage in Segmenter.ProgramLanguage)
            {
                var data =
                from rawData in rawDataObject
                where rawData.ToString().Contains(programLanguage)
                select rawData;
                dataObject.AllInfoObject.ProgramLanguage.Add(programLanguage, data.Count());
            }

            foreach (var technologyStack in Segmenter.TechnologyStack)
            {
                var data =
                from rawData in rawDataObject
                where rawData.ToString().Contains(technologyStack)
                select rawData;
                dataObject.AllInfoObject.TechnologyStack.Add(technologyStack, data.Count());
            }
            return dataObject;
        }
    }
}
