using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nStack.ModelObjects
{
    public class SortedData
    {
        public string SheetTitle;
        public string CompanyName;
        public List<string> SubTitle = new List<string>();
        public List<string> PermissionsData = new List<string>();
        public List<string> InputData = new List<string>();
        public List<string> ApprovalData = new List<string>();
        public List<string> ProvideData = new List<string>();
        public List<string> MonitoringData = new List<string>();
        public Dictionary<string, List<string>> KeyData = new Dictionary<string, List<string>>();
        public List<List<string>> QandAData = new List<List<string>>();
    }
}