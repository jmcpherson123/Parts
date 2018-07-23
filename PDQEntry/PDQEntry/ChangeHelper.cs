using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt
{
    class ChangeHelper
    {
        public static List<string> ChangedFiles = new List<string>();
   
        public static  List<FileObject> getChanges ( string DirectoryPath, DateTime iterationTime)
        {

            FileReader fileReader = new FileReader();
            List<FileObject> changes = new List<FileObject>();

            var listOfFiles = Directory.GetFiles(DirectoryPath);
            foreach (var file in listOfFiles)
            {
                FileObject modFile = getDateModified(file, iterationTime);
                if (!modFile.Name.Equals(""))
                {
                    changes.Add(modFile);
                }

            }

            return changes;

        }

        public static FileObject getDateModified(string path, DateTime iterationTime)
        {
            FileObject modFile = new FileObject();
            FileInfo fileInfo = new FileInfo(path);
            var createdTime = fileInfo.CreationTime;
            var lastMod = fileInfo.LastWriteTime;
            var PrevTime=iterationTime.AddSeconds(-10);
            if (createdTime > PrevTime)
            {
                modFile.Name = fileInfo.Name;
        //        modFile.NumberOfLines = FileReader.GetNumberofLines(path);
            }
            return modFile;
        }
    }
}
