using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nStack.ModelObjects
{
    public class CatalogTaskVariable
    {
        public string RequestItem;
        public Dictionary<string, string> Variables = new Dictionary<string, string>();
    }
}