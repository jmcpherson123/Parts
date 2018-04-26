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
        public string exampleString;
        public string getSentence { get; set; }

     
        public void runTestString()
        {
            originalString = "this is a tester string";
            exampleString = SortString(originalString);  
        }

        public string SortString(string sentence)
        {
            StringSorter sorter = new StringSorter(sentence);
            string temporaryString = sorter.sortedString;
            return temporaryString;
        }
    }
}