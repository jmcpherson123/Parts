using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insertion Sort
            Console.WriteLine("Hello World!");
            string sentence = " This is a tester, please work";

            var sorted =doBubbleSort(sentence);
            Console.WriteLine(sentence);
            Console.WriteLine(sorted);
            Console.ReadLine();

        }

        public  static string doBubbleSort(string sentence)
        {
            string sortedLine = null;
            var brokenLine = sentence.Split(' ');
            int size = brokenLine.Length;
            for(int iterator =1; iterator<size-1; iterator++)
            {
                brokenLine[iterator]=brokenLine[iterator].ToLower();
                for(int secondIterator=iterator+1; secondIterator>0; secondIterator--)
                {
                    if (brokenLine[secondIterator - 1].Length > brokenLine[secondIterator].Length)
                    {
                        var temp = brokenLine[secondIterator - 1];
                        brokenLine[secondIterator -1] = brokenLine[secondIterator];
                        brokenLine[secondIterator] = temp;
                    }      
                }
            }

            
            foreach(var word in brokenLine)
            {
                //Console.WriteLine(word);
                sortedLine = sortedLine + word+" ";
            }

                return sortedLine;
        }
    }
}
