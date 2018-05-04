using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWeb.Helpers
{
    public class StringSorter
    {
        public string sentence;
        public string sortedString;
        public StringSorter(string originalSentence)
        {
            sentence = originalSentence;
            SortString();
        }

        public string SortString()
        {
            
            var brokenLine = sentence.Split(' ');
            int size = brokenLine.Length;
            for (int iterator = 1; iterator < size - 1; iterator++)
            {
                brokenLine[iterator] = brokenLine[iterator].ToLower();
                for (int secondIterator = iterator + 1; secondIterator > 0; secondIterator--)
                {
                    if (brokenLine[secondIterator - 1].Length > brokenLine[secondIterator].Length)
                    {
                        var temp = brokenLine[secondIterator - 1];
                        brokenLine[secondIterator - 1] = brokenLine[secondIterator];
                        brokenLine[secondIterator] = temp;
                    }
                }
            }

            foreach (var word in brokenLine)
            {
                sortedString = sortedString + word + " ";
            }
            return sortedString;
        }
    }
}