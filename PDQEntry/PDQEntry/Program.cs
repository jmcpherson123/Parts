using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Attempt 
{
    class Program 
    {
        static string path;
        static FileSystem fileSystem;
        static void Main(string[] args)
        {
            DateTime current = DateTime.Now;
            path = @"C:\Users\jspice\documents\visual studio 2017\Projects\PDQEntry\PDQEntry\TestData";

            Timer timer = new Timer(10000);
            timer.Elapsed += new ElapsedEventHandler(ScanForChange);
            timer.AutoReset = true;
            timer.Enabled=true;
            fileSystem = new FileSystem();

            Console.WriteLine(current);
            List<string> fileNames = new List<string>();        
            //read user input for directory will be called file path
       
            Console.ReadLine();
        }
        public static void ScanForChange( object source, ElapsedEventArgs e)
        {
            DateTime current = DateTime.Now;
            var changes=fileSystem.getChanges(current, path);
            Console.WriteLine("Scanning for Changes ");
            ChangeHelper.ChangedFiles.Clear();
        }     
    }
}
