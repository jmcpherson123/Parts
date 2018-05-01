using nStack.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nStack.Helpers
{
    public class Analyzer
    {
        public List<List<string>> sortedFileSection;
        public List<CheckboxHelper> CompanyCheck = new List<CheckboxHelper>();
       
        public List<SortedData[]> Container = new List<SortedData[]>();
        public Dictionary<string, string> tracker = new Dictionary<string, string>();
        public CompanyServiceObject CompanySectionsUsed = new CompanyServiceObject();
        public List<SortedData[]> SortBySection(List<BinFileObject> rawFile)
        {
            int NumberOfMasterFiles=rawFile.Count();
            foreach(BinFileObject binFile in rawFile)
            {
                List<string> TitleKeys = binFile.container.Keys.ToList();
                CheckboxHelper checkbox = new CheckboxHelper();
                var tt2 = binFile.container.Values;
                SortedData[] SortedData = new SortedData[binFile.container.Keys.Count];
                int iterator = 0;
                foreach (Dictionary<string, List<string>> form in binFile.container.Values)
                {
                    SortedData[iterator] = new SortedData();
                  
                    SortedData[iterator].CompanyName = binFile.CompanyName;
                    SortedData[iterator].SheetTitle = binFile.container.Keys.ElementAt(iterator);
                    SortedData[iterator].SubTitle = getSectionTitles(form);
                    SortedData[iterator].QandAData = getQuestionsAnswers(form);
                    SortedData[iterator].PermissionsData = getPermissionForSheet(SortedData[iterator].QandAData);
                    SortedData[iterator].KeyData.Add("Permission",getPermissionForSheet(SortedData[iterator].QandAData));
                    SortedData[iterator].InputData = getInputForSheet(SortedData[iterator].QandAData);
                    SortedData[iterator].KeyData.Add("Input",getInputForSheet(SortedData[iterator].QandAData));
                    SortedData[iterator].ApprovalData = getApprovalForSheet(SortedData[iterator].QandAData);
                    SortedData[iterator].KeyData.Add("Approval",getApprovalForSheet(SortedData[iterator].QandAData));
                    SortedData[iterator].ProvideData = getProvideForSheet(SortedData[iterator].QandAData);
                    SortedData[iterator].KeyData.Add("Provide",getProvideForSheet(SortedData[iterator].QandAData));
                    iterator++;
                }

                //Add by the file
                checkbox.Name = binFile.CompanyName;
                CompanyCheck.Add(checkbox);
                Container.Add(SortedData);

            }
            CompanySectionsUsed=CompaniesForAccountAdmin(Container);
            return Container;
        }
 
        public CompanyServiceObject CompaniesForAccountAdmin(List<SortedData[]> container)
        {
            CompanyServiceObject CompanyObject = new CompanyServiceObject();
            List<string> AcctAdminCompanies = new List<string>();
            List<string> PCSupportCompanies = new List<string>();
            List<string> MicroOfficeSuppCompanies = new List<string>();
            List<string> ShareDriveCompanies = new List<string>();
            List<string> PhoneSupportCompanies = new List<string>();
            List<string> PrinterAdminCompanies = new List<string>();
            List<string> Office365Companies = new List<string>();
            List<string> SoftwareProvCompanies = new List<string>();
            List<string> MonitoringCompanies = new List<string>();
            foreach (var Set in container)
            {
                for(int SortIterator=0; SortIterator < Set.Length; SortIterator++)
                {
                    if (Set[SortIterator].SheetTitle.Contains("Account Admin")&&Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!AcctAdminCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            AcctAdminCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("PC Support") && Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!PCSupportCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            PCSupportCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("Microsoft Office") && Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!MicroOfficeSuppCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            MicroOfficeSuppCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("Share Drive") && Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!ShareDriveCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            ShareDriveCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("Phone Support") && Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!PhoneSupportCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            PhoneSupportCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("Software Provision") && Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!SoftwareProvCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            SoftwareProvCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("Printer") && Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!PrinterAdminCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            PrinterAdminCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("365") && Set[SortIterator].QandAData[0].Count != 0)
                    {
                        if (!Office365Companies.Contains(Set[SortIterator].CompanyName))
                        {
                            Office365Companies.Add(Set[SortIterator].CompanyName);
                        }
                    }

                    if (Set[SortIterator].SheetTitle.Contains("Monit"))
                    {
                        if (!MonitoringCompanies.Contains(Set[SortIterator].CompanyName))
                        {
                            MonitoringCompanies.Add(Set[SortIterator].CompanyName);
                        }
                    }
                }
            }
            if (AcctAdminCompanies.Count != 0)
            {
                CompanyObject.AcctAdmin = AcctAdminCompanies;
            }

            if (PCSupportCompanies.Count != 0)
            {
                CompanyObject.PCSupport = PCSupportCompanies;
            }

            if (MicroOfficeSuppCompanies.Count != 0)
            {
                CompanyObject.MicrOffSup = MicroOfficeSuppCompanies;
            }

            if (ShareDriveCompanies.Count != 0)
            {
                CompanyObject.ShareDrive = ShareDriveCompanies;
            }

            if (PhoneSupportCompanies.Count != 0)
            {
                CompanyObject.PhoneSupport = PhoneSupportCompanies;
            }

            if (PrinterAdminCompanies.Count != 0)
            {
                CompanyObject.PrinterAdmin = PrinterAdminCompanies;
            }

            if (SoftwareProvCompanies.Count != 0)
            {
                CompanyObject.SoftwareProvision = SoftwareProvCompanies;
            }

            if (Office365Companies.Count != 0)
            {
                CompanyObject.Office365 = Office365Companies;
            }

            if (MonitoringCompanies.Count != 0)
            {
                CompanyObject.Monitoring = MonitoringCompanies;
            }
            return CompanyObject;
        }

        public List<string> getApprovalForSheet(List<List<string>> qandAList)
        {
            List<string> ApprovalList = new List<string>();
            foreach (var sect in qandAList)
            {
                int counter = 0;
                foreach (var line in sect)
                {
                    if (line.ToLower().Contains("approval"))
                    {
                        int location = counter;
                        ApprovalList.Add(line);
                        ApprovalList.Add(qandAList[1].ElementAt(location));
                    }
                    counter++;
                }
            }
            return ApprovalList;
        }

        public List<string> getInputForSheet(List<List<string>> qandAList)
        {
            List<string> InputList = new List<string>();
            foreach (var sect in qandAList)
            {
                int counter = 0;
                foreach (var line in sect)
                {
                    if (line.ToLower().Contains("input"))
                    {
                        int location = counter;
                        InputList.Add(line);
                        InputList.Add(qandAList[1].ElementAt(location));
                    }
                    counter++;
                }
            }
            return InputList;
        }

        public List<string> getPermissionForSheet(List<List<string>> qandAList)
        {
            List<string> permissionsList = new List<string>();
            foreach (var sect in qandAList)
            {
                int counter = 0;
                foreach (var line in sect)
                {
                    if (line.ToLower().Contains("permission"))
                    {
                        int location = counter;
                        permissionsList.Add(line);
                        permissionsList.Add(qandAList[1].ElementAt(location));
                    }
                    counter++;
                }
            }
            return permissionsList;
        }

        public List<string> getProvideForSheet(List<List<string>> qandAList)
        {
            List<string> ProvideList = new List<string>();
            foreach (var sect in qandAList)
            {
                int counter = 0;
                foreach (var line in sect)
                {
                    if (line.ToLower().Contains("provide"))
                    {
                        int location = counter;
                        ProvideList.Add(line);
                        ProvideList.Add(qandAList[1].ElementAt(location));
                    }
                    counter++;
                }
            }
            return ProvideList;
        }

        public List<string> getSectionTitles(Dictionary<string, List<string>> rawFile)
        {
            List<string> SectionTitles = new List<string>();
            SectionTitles = rawFile.Keys.ToList();
            return SectionTitles;
        }

        public List<List<string>> getQuestionsAnswers(Dictionary<string, List<string>> rawFile)
        {
            List<List<string>> QandAList = new List<List<string>>();
            List<string> AnswerList = new List<string>();
            List<string> QuestionList = new List<string>();
            foreach (var obj in rawFile.Values)
            {
                var testQuestion = obj;
                if (obj.Count != 0)
                {
                    foreach (var line in testQuestion)
                    {
                        if (!line.Contains("?") && !line.Equals(""))
                        {
                            AnswerList.Add(line);
                        }
                        else if (line.Contains("?"))
                        {
                            QuestionList.Add(line);
                        }
                    }
                }
            }
            QandAList.Add(QuestionList);
            QandAList.Add(AnswerList);
            return QandAList;
        }
    }
}