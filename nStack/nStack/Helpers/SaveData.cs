using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;

namespace nStack.Helpers
{
    public  class SaveData:BinFileObject
    {
        public  SaveData(BinFileObject ReadFile)
        {
            Dictionary<string, string> sortedData = new Dictionary<string, string>();
            var NameOfSheets =ReadFile.container.Keys;      


            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var BinFile = new System.IO.FileInfo(@"Master.bin");
            
            if (!BinFile.Exists)
            {
                using (var BinWriter = BinFile.Create())
                {
                    binaryFormatter.Serialize(BinWriter, ReadFile);
                    BinWriter.Flush();
                }
            }

            else
            {
                using (var fs = new FileStream(@"Master.bin", FileMode.Append))
                {
                    var bFomitter = new BinaryFormatter();
                    bFomitter.Serialize(fs, ReadFile);
                }              
            }            
        }
    }
}