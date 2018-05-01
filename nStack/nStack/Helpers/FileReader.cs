using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace nStack.Helpers
{
    public class FileReader: BinFileObject
    {
        public int MasterIterator = 0;

        public BinFileObject getBinFileObject(HttpPostedFileBase file, string CompanyName)
        {
            Dictionary<string, Dictionary<string, List<string>>> ReadData = new Dictionary<string, Dictionary<string, List<string>>>();
                int EndOfSection;
               
                BinaryReader bReader = new BinaryReader(file.InputStream);
                byte[] byteData = bReader.ReadBytes(file.ContentLength);
                using (var pkg = new ExcelPackage(file.InputStream))
                {
                    var sheet = pkg.Workbook.Worksheets;
                    var ListOfWorksheets = pkg.Workbook.Worksheets.ToList();

                    for (int iterator = 0; iterator < ListOfWorksheets.Count ; iterator++)
                    {
                        //Container single sheet

                        var sheetName = ListOfWorksheets[iterator].Name;
                        var WorksheetCellsContainer = ListOfWorksheets[iterator].Cells.ToList();
                        var NumberOfCells = WorksheetCellsContainer.Count();
                        MasterIterator = 0;
                        string secHeadTitle;

                        List<string> sectionData = new List<string>();
                        Dictionary<string, List<string>> DataBank = new Dictionary<string, List<string>>();
                        Dictionary<string, List<string>> containter = new Dictionary<string, List<string>>();

                        //Tester for a while loop RepleC
                        while (MasterIterator < NumberOfCells)
                        {
                            int nextCell = MasterIterator + 1;
                            if (WorksheetCellsContainer[MasterIterator].Address.Contains("A"))
                            {
                                if (WorksheetCellsContainer[nextCell].Text.Equals(""))  //Get the Head Title
                                {
                                    EndOfSection = GetSectionTitle(MasterIterator, NumberOfCells, WorksheetCellsContainer);
                                    secHeadTitle = WorksheetCellsContainer[EndOfSection].Text;
                                    sectionData = GetSectionData(EndOfSection, NumberOfCells, WorksheetCellsContainer);
                                    DataBank.Add(secHeadTitle, sectionData);
                                }
                                else
                                {
                                    MasterIterator++;
                                }
                            }
                            else
                            {
                                MasterIterator++;
                            }
                        }
                        ReadData.Add(ListOfWorksheets[iterator].Name, DataBank);
                    }
                }

            BinFileObject BinContainer = new BinFileObject();
            BinContainer.container = ReadData;
            BinContainer.CompanyName = CompanyName;
            return BinContainer;
        }

        public List<string> GetSectionData(int testIt, int numberOfCells, List<ExcelRangeBase> worksheetCellsContainer)
        {
            List<string> DataRead = new List<string>();
            int position = GetNextCell(testIt, numberOfCells, worksheetCellsContainer);
            int nextCell = position + 1;
            int swtch = 0;

            while (!(worksheetCellsContainer[position].Address.Contains("A") && worksheetCellsContainer[nextCell].Text.Equals("")) && swtch != 1)
            {
                if (worksheetCellsContainer[position].Address.Contains("B"))
                {
                    int prevCell = position - 1;
                    nextCell = position + 1;
                    if (worksheetCellsContainer[prevCell].Text.Equals("") && !worksheetCellsContainer[nextCell].Text.Equals(""))  //Get the Question
                    {
                        DataRead.Add(worksheetCellsContainer[position].Value.ToString());
                        DataRead.Add(worksheetCellsContainer[nextCell].Value.ToString());
                        position = nextCell;
                    }
                }
                //if block to sus out the last of the cell blocks that go over 886
                position = GetNextCell(nextCell, numberOfCells, worksheetCellsContainer);
                nextCell = position + 1;
                if ((position >= numberOfCells) || nextCell >= numberOfCells)
                {
                    swtch = 1;
                    position = 0;
                    nextCell = 1;
                }
            }
            if (swtch == 1)
            {
                MasterIterator = numberOfCells + 1;
            }
            else
            {
                MasterIterator = position;
            }
            return DataRead;
        }

        public static int GetSectionTitle(int testIt, int End, List<ExcelRangeBase> worksheetCellsContainer)
        {
            int address = 0;
            if (testIt == 0)
            {
                address = testIt + 1;
            }
            else
            {
                address = testIt;
            }

            //Need to set next after the iff for accurate up to date next
            int next = 1 + address;

            while (!worksheetCellsContainer[address].Address.Contains("A") || !worksheetCellsContainer[next].Text.Equals("")) //once the title is found
            {                                                                                                               //you exit the while loop
                address = GetNextCell(address, End, worksheetCellsContainer);
                next = address + 1;
            }
            return address; //returns the adress location of the list
        }

        public List<BinFileObject> getMasterFile()
        {
            List<BinFileObject> binContainer = new List<BinFileObject>();
            List<string> file = new List<string>();
            Dictionary<string, List<string>> Wrapper = new Dictionary<string, List<string>>();
            List<string> Titles = new List<string>();
            List<string> SectionHead = new List<string>();
            List<string> DataSec = new List<string>();

            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var BinFile = new System.IO.FileInfo(@"Master.bin");

            if (BinFile.Exists)
            {
                using (var binFile = BinFile.OpenRead())
                {
                    var binPosition = binFile.Position;
                    var binEnd = binFile.Length;
                   
                    while (binPosition < binEnd)
                    {
                        BinFileObject binTester = new BinFileObject();
                        binTester= ((BinFileObject)binaryFormatter.Deserialize(binFile));
                        binContainer.Add(binTester);
                        binPosition = binFile.Position;
                    }
                }
            }


            return binContainer;
        }

        public static int GetNextCell(int CurrentPosition, int End, List<ExcelRangeBase> RawWorkSheet)
        {
            int address = 0;
            if (CurrentPosition < (End - 2))
            {
                address = CurrentPosition + 1;
                while (RawWorkSheet[address].Text.Equals("") && address < End - 1)
                {
                    address++;
                }
            }
            else
            {
                address = End + 1;
            }
            return address;
        }
    }
}