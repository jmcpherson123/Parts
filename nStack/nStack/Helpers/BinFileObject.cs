using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nStack.Helpers
{
    [Serializable]
    public class BinFileObject
    {
        public Dictionary<string, Dictionary<string, List<string>>> container = new Dictionary<string, Dictionary<string, List<string>>>();
        public string CompanyName;
    }
}