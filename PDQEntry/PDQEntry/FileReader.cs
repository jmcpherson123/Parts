using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt
{
    class FileReader
    {

        public static FileObject GetNumberofLines(string pathforFile)
        {
            StreamReader reader = new StreamReader(pathforFile);
            FileObject file = new FileObject();
           
            FileInfo fileI = new FileInfo(pathforFile);
            file.Name = fileI.Name;
            file.LastModifiedTime = fileI.LastWriteTime;
            string line = reader.ReadLine();
            int lineNumber = 0;
            while (line != null)
            {
                lineNumber++;
                line = reader.ReadLine();
            }
            file.NumberOfLines = lineNumber;
            reader.Close();
            return file;
        }

        public static int GetNumberofLines(string pathforFile, int LastLine)
        {
            int count =0;
            int AddedLinesCount = 0;
            StreamReader reader = new StreamReader(pathforFile);
            FileInfo fileI = new FileInfo(pathforFile);
            string line = reader.ReadLine();
            int lineNumber = 0;
            while (line != null)
            {
                lineNumber++;
                line = reader.ReadLine();
                if (count > LastLine)
                {
                    AddedLinesCount++;
                }
            }
            return count;
        }


    }        

}
