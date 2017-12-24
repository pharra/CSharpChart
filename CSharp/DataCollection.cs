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

        // 初始化类，从文本中读取所有数据
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

        // 进行数据分析
        public DataObject GetDataObject()
        {
            DataObject dataObject = new DataObject();
            dataObject.AllInfoObject = GetInfo(rawDataObject);
            // 获取地址和公司名
            List<string> companyName = new List<string>();
            List<string> address = new List<string>();
            foreach (var rawData in rawDataObject)
            {
                if (!companyName.Contains(rawData.CompanyName))
                {
                    companyName.Add(rawData.CompanyName);
                }
                if (!address.Contains(rawData.WorkPlace))
                {
                    address.Add(rawData.WorkPlace);
                }
            }

            foreach(string name in companyName) {
                dataObject.CompanyObject.Add(name, 
                    GetInfo(rawDataObject.FindAll(
                    delegate (RawDataObject rawData)
                    {
                        return rawData.CompanyName.Equals(name);
                    })
                ));
            }

            // 根据地址和公司名分类获取数据
            foreach (string addressName in address)
            {
                Dictionary<string, DataInfoObject> company = new Dictionary<string, DataInfoObject>();
                List<RawDataObject> addressData = rawDataObject.FindAll(
                        delegate (RawDataObject rawData)
                        {
                            return rawData.WorkPlace.Equals(addressName);
                        });
                foreach (string name in companyName)
                {
                    List<RawDataObject> companyData = addressData.FindAll(
                        delegate (RawDataObject rawData)
                        {
                            return rawData.CompanyName.Equals(name);
                        });
                    company.Add(name, GetInfo(companyData));
                    
                       
                }
                dataObject.AddressObject.Add(addressName, company);
            }

            Console.WriteLine("收集数据成功...");
            return dataObject;
        }


        // 根据传入数据进行收集整理，使用linq方法
        private DataInfoObject GetInfo(List<RawDataObject> partRawDataObject)
        {
            DataInfoObject dataInfoObject = new DataInfoObject();
            // 编程语言
            foreach (var programLanguage in Segmenter.ProgramLanguage)
            {
                var data =
                from rawData in partRawDataObject
                where rawData.ToString().Contains(programLanguage)
                select rawData;
                dataInfoObject.ProgramLanguage.Add(programLanguage, data.Count());
            }
            // 技术栈
            foreach (var technologyStack in Segmenter.TechnologyStack)
            {
                var data =
                from rawData in partRawDataObject
                where rawData.ToString().Contains(technologyStack)
                select rawData;
                dataInfoObject.TechnologyStack.Add(technologyStack, data.Count());
            }
            // 岗位
            foreach (var job in Segmenter.Job)
            {
                var data =
                from rawData in partRawDataObject
                where rawData.ToString().Contains(job)
                select rawData;
                dataInfoObject.Job.Add(job, data.Count());
            }
            // 地址
            foreach (var rawData in partRawDataObject)
            {
                if (dataInfoObject.Address.ContainsKey(rawData.WorkPlace))
                {
                    continue;
                }
                var fitler =
                from data in partRawDataObject
                where data.WorkPlace.Equals(rawData.WorkPlace)
                select data;
                dataInfoObject.Address.Add(rawData.WorkPlace, fitler.Count());
            }

            return dataInfoObject;
        }
    }
}
