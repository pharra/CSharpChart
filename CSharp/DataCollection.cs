﻿using System;
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
            dataObject.AllInfoObject = GetInfo(rawDataObject);
            List<string> companyName = new List<string>();
            foreach (var rawData in rawDataObject)
            {
                if (!companyName.Contains(rawData.CompanyName))
                {
                    companyName.Add(rawData.CompanyName);
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
            
            return dataObject;
        }



        private DataInfoObject GetInfo(List<RawDataObject> partRawDataObject)
        {
            DataInfoObject dataInfoObject = new DataInfoObject();
            foreach (var programLanguage in Segmenter.ProgramLanguage)
            {
                var data =
                from rawData in partRawDataObject
                where rawData.ToString().Contains(programLanguage)
                select rawData;
                dataInfoObject.ProgramLanguage.Add(programLanguage, data.Count());
            }
            foreach (var technologyStack in Segmenter.TechnologyStack)
            {
                var data =
                from rawData in partRawDataObject
                where rawData.ToString().Contains(technologyStack)
                select rawData;
                dataInfoObject.TechnologyStack.Add(technologyStack, data.Count());
            }
            foreach (var job in Segmenter.Job)
            {
                var data =
                from rawData in partRawDataObject
                where rawData.ToString().Contains(job)
                select rawData;
                dataInfoObject.Job.Add(job, data.Count());
            }
            foreach (var rawData in rawDataObject)
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
