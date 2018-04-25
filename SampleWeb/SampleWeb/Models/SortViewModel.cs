using SampleWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWeb.Models
{
    public class SortViewModel
    {
        public string originalString;
        public string sortedString;
        public string getSentence { get; set; }

     
        public void runTestString()
        {
            originalString = "this is a tester string";
            StringSorter sorter = new StringSorter(originalString);
            sortedString=sorter.sortedString;
            
        }
        public string getString()
        {
            return sortedString;
        }
    }
}