using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt
{
    class FileSystem
    {
        public List<FileObject> Files = new List<FileObject>();

        public FileSystem()
        {
           string path = @"C:\Users\jspice\documents\visual studio 2017\Projects\PDQEntry\PDQEntry\TestData";
            var ListOfAllFiles = Directory.GetFiles(path);
            foreach( string file in ListOfAllFiles)
            {
                FileObject ReadFile=FileReader.GetNumberofLines(file);
                Files.Add(ReadFile);
            }
        }

        public List<FileObject> getChanges(DateTime current, string path)
        {
            List<FileObject> changedFiles = new List<FileObject>();
            //Find difference in every file
            List<string> directory = new List<string>();
            FileObject file = new FileObject();
            directory = Directory.GetFiles(path).ToList();
           foreach(string filePath in directory)
            {
                findDifferenceInFile(filePath, current);
            }
            return changedFiles;

        }

        public static void findDifferenceInFile(string path, DateTime iterationTime)
        {
            FileObject file = new FileObject();
            FileInfo fileInfo = new FileInfo(path);
            var createdTime = fileInfo.CreationTime;
            var lastMod = fileInfo.LastWriteTime;
            var PrevTime = iterationTime.AddSeconds(-10);
            if (createdTime > PrevTime)
            {
                file.Name = fileInfo.Name;
                //make new thread where it would count lines
                
            }
        }
    }
}
