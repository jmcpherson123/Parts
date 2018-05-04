using nStack.ModelObjects;
using nStack.Models;
using System.Collections.Generic;

namespace nStack.Helpers
{
    public class nStackHelper
    {
        //nStack Helper set up viewModel with Checkboxes and options. Get the selected checkbox
        public static nStackViewModel setUpnStackWithoutSelection()
        {
            Dictionary<string, List<CheckboxHelper>> CheckboxesUsed = new Dictionary<string, List<CheckboxHelper>>();
            Analyzer analyze = new Analyzer();
            FileReader fileReader = new FileReader();
            nStackViewModel vm = new nStackViewModel();
            vm.MasterFile = fileReader.getMasterFile();
            vm.SortedData = analyze.SortBySection(vm.MasterFile);
            var sheetName = analyze.SheetNames;
            vm.AcctAdminUsedBy = analyze.CompanySectionsUsed.AcctAdmin;
            vm.PCSupportUsedBy = analyze.CompanySectionsUsed.PCSupport;
            vm.MicrosoftUsedBy = analyze.CompanySectionsUsed.MicrOffSup;
            vm.PhoneSupportUsedBy = analyze.CompanySectionsUsed.PhoneSupport;
            vm.PrinterAdminUsedBy = analyze.CompanySectionsUsed.PrinterAdmin;
            vm.ShareDriveUsedBy = analyze.CompanySectionsUsed.ShareDrive;
            vm.Office365UsedBy = analyze.CompanySectionsUsed.Office365;
            vm.SoftwareProvisionUsedBy = analyze.CompanySectionsUsed.SoftwareProvision;
            vm.MonitoringUsedBy = analyze.CompanySectionsUsed.Monitoring;

            //tester for sub of checkbox

            vm.SheetCheckboxes = setUpCheckboxes(sheetName, analyze);
            vm.testOptions = setUpSlectionCheckboxes(sheetName);
            return vm;
        }

        public static nStackViewModel setUpnStackWithSelection(nStackViewModel vm)
        {
            Analyzer analyze = new Analyzer();
            FileReader fileReader = new FileReader();

            vm.MasterFile = fileReader.getMasterFile();
            if (vm.MasterFile.Count != 0)
            {
                vm.SortedData = analyze.SortBySection(vm.MasterFile);
                var sheetName = analyze.SheetNames;
                foreach(var Company in vm.SortedData)
                {
                    
                     
                    
                }
               
                vm.AcctAdminUsedBy = analyze.CompanySectionsUsed.AcctAdmin;
                vm.PCSupportUsedBy = analyze.CompanySectionsUsed.PCSupport;
                vm.MicrosoftUsedBy = analyze.CompanySectionsUsed.MicrOffSup;
                vm.PhoneSupportUsedBy = analyze.CompanySectionsUsed.PhoneSupport;
                vm.PrinterAdminUsedBy = analyze.CompanySectionsUsed.PrinterAdmin;
                vm.ShareDriveUsedBy = analyze.CompanySectionsUsed.ShareDrive;
                vm.SoftwareProvisionUsedBy = analyze.CompanySectionsUsed.SoftwareProvision;
                vm.MonitoringUsedBy = analyze.CompanySectionsUsed.Monitoring;

                vm.SheetCheckboxes = setUpCheckboxes(analyze.SheetNames, analyze);
                vm.SelectedCompany = getSelectedCompany(vm);
            }
            else
            {
                //no master file exist
            }

            return vm;
        }

        public static List<string> getSelectedCompany(nStackViewModel vm)
        {
            List<string> selected = new List<string>();
            foreach (var checkbox in vm.testOptions)
            {
                if (checkbox.Value == true)
                {
                    selected.Add(checkbox.Key);
                }
            }
            return selected;
        }

        public static List<CheckboxHelper> getCheckBoxes(CompanyServiceObject CompanyService, string sheet)
        {
            List<CheckboxHelper> CheckboxContainer = new List<CheckboxHelper>();

            if (sheet.Contains("ShareDrive"))
            {
                foreach (var CompanyName in CompanyService.ShareDrive)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("Account"))
            {
                foreach (var CompanyName in CompanyService.AcctAdmin)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("PhoneSupport"))
            {
                foreach (var CompanyName in CompanyService.PhoneSupport)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("SoftwareProvision"))
            {
                foreach (var CompanyName in CompanyService.SoftwareProvision)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("PrinterAdmin"))
            {
                foreach (var CompanyName in CompanyService.PrinterAdmin)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("PCSupport"))
            {
                foreach (var CompanyName in CompanyService.PCSupport)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("365"))
            {
                foreach (var CompanyName in CompanyService.Office365)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("Microsoft"))
            {
                foreach (var CompanyName in CompanyService.MicrOffSup)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = CompanyName;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            else if (sheet.Contains("Monit"))
            {
                foreach (var stat in CompanyService.Monitoring)
                {
                    CheckboxHelper checkbox = new CheckboxHelper();
                    checkbox.Name = stat;
                    checkbox.Checked = false;
                    CheckboxContainer.Add(checkbox);
                }
            }
            return CheckboxContainer;
        }

        public static Dictionary<string, List<CheckboxHelper>> setUpCheckboxes(List<string> SheetName, Analyzer analyzeObject)
        {
            Dictionary<string, List<CheckboxHelper>> CheckboxesUsed = new Dictionary<string, List<CheckboxHelper>>();
            foreach (var sheetTitle in SheetName)
            {
                List<CheckboxHelper> UsedSheetCheckboxList = new List<CheckboxHelper>();
                UsedSheetCheckboxList = getCheckBoxes(analyzeObject.CompanySectionsUsed, sheetTitle);
                CheckboxesUsed.Add(sheetTitle, UsedSheetCheckboxList);
            }
            return CheckboxesUsed;
        }

        public static Dictionary<string, bool> setUpSlectionCheckboxes(List<string> SheetNames)
        {
            Dictionary<string, bool> tempList = new Dictionary<string, bool>();
            foreach (var name in SheetNames)
            {
                tempList.Add(name, false);
            }
            return tempList;
        }
    }
}