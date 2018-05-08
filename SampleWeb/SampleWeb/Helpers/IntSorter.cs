using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWeb.Helpers
{
    public class IntSorter
    {
        public int[] listOfInts = new int[10];
       
        public IntSorter(int[] originalInt)
        {
            listOfInts = originalInt;
            

        }

        public int[] SortInt()
        {
            int[] SortedList;
            for(int i=0; i< listOfInts.Length-2; i++)
            {
                for(int j=0; j < listOfInts.Length - 2; j++)
                {
                    if (listOfInts[j] > listOfInts[j + 1])
                    {
                        var temp = listOfInts[j + 1];
                        listOfInts[j + 1] = listOfInts[j];
                        listOfInts[j] = temp;
                    }
                }

            }
            SortedList = listOfInts;
            return SortedList;
        }
    }
}