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
            int[] numbers = { 3, 6, 4, 8, 1, 7, 3, 9 };
            //var sorted =doBubbleSort(sentence);
            Console.WriteLine(sentence);
            //Console.WriteLine(sorted);
            doInsertSort(numbers);
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

        public static void doInsertSort(int[] ListOfNumbers)
        {
            int size = ListOfNumbers.Length;
            for(int i=0; i<size; i++)
            {
                int temp = ListOfNumbers[i];
                int prev = i - 1;
                while(prev>=0&& ListOfNumbers[prev] > temp)
                {
                    ListOfNumbers[prev + 1] = ListOfNumbers[prev];
                    prev = prev - 1;
                }
                ListOfNumbers[prev + 1] = temp;
            }

            foreach(int num in ListOfNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
