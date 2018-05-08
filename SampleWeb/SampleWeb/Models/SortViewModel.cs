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
        public int[] testInt;
        public string sortedString;
        public string exampleString;
        public int[] sortedInt;
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

        public void runTestInt()
        {
            testInt = new int[]{ 9, 4, 14, 3, 5, 1};
            sortedInt = SortInteger(testInt);
        }

        public int[] SortInteger(int[] IntList)
        {
            int[] sortedInt;
            IntSorter intSorter = new IntSorter(IntList);
            sortedInt = intSorter.SortInt();
            return sortedInt;

        }
    }
}