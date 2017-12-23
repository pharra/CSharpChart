using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class DataObject
    {
        public DataObject()
        {
            CompanyObject = new Dictionary<string, DataInfoObject>();
            AllInfoObject = new Dictionary<string, DataInfoObject>();
        }

        public Dictionary<string, DataInfoObject> AllInfoObject { get; set; }
        public Dictionary<string, DataInfoObject> CompanyObject { get; set; }

    }

    class DataInfoObject
    {
        public DataInfoObject()
        {
            ProgramLanguage = new Dictionary<string, int>();
            TechnologyStack = new Dictionary<string, int>();
            Job = new Dictionary<string, int>();
        }

        public Dictionary<string, int> ProgramLanguage;
        public Dictionary<string, int> TechnologyStack;
        public Dictionary<string, int> Job;
    }

    class RawDataObject
    {
        public RawDataObject()
        {
        }

        public RawDataObject(string jobName, string jobDuty, string jobRequirement, string workPlace, string companyName, string companyProfile, string companyWebSite)
        {
            JobName = jobName;
            CompanyWebSite = companyWebSite;
            JobDuty = jobDuty;
            JobRequirement = jobRequirement;
            WorkPlace = workPlace;
            CompanyProfile = companyProfile;
            CompanyName = companyName;
        }

        public String JobName { set; get; }
        public String CompanyWebSite { set; get; }
        public String JobDuty { set; get; }
        public String JobRequirement { set; get; }
        public String WorkPlace { set; get; }
        public String CompanyProfile { set; get; }
        public String CompanyName { set; get; }

        public override string ToString()
        {
            return String.Format(@"{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                JobName,
                JobDuty,
                JobRequirement,
                WorkPlace,
                CompanyProfile,
                CompanyName,
                CompanyWebSite);
        }
    }


}
