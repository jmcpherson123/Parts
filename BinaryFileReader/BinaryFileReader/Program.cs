using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing testing 1 2 3");
            


            writeSampleDatFile("sample.dat");
            ReadDatFileSample();
            Console.ReadLine();
        }

        public static string ReadDatFileSample()
        {
            string readString=null;
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var BinFile = new System.IO.FileInfo(@"sample.DAT");
            if (BinFile.Exists)
            {
                using (var binFile = BinFile.OpenRead())
                {
                    var binPosition = binFile.Position;
                    var binEnd = binFile.Length;

                    while (binPosition < binEnd)
                    {
                        
                        var tester = ((string)binaryFormatter.Deserialize(binFile));
                        
                        binPosition = binFile.Position;
                    }
                }
            }
            return readString;
        }

        public static void writeSampleDatFile(string fileName)
        {
           
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var BinFile = new System.IO.FileInfo(@"sample.DAT");

            if (!BinFile.Exists)
            {
                using (var BinWriter = BinFile.Create())
                {
                    binaryFormatter.Serialize(BinWriter, "This is a tester pleas work");
                    BinWriter.Flush();
                }
            }
           else
            {
                using (var binAppend = new FileStream(@"sample.DAT", FileMode.Append))
                {
                    binaryFormatter.Serialize(binAppend, "This is aSecond attepmpt");
                    binAppend.Flush();
                }
            }

        }
    }
}
