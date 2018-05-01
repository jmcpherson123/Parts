using nStack.ModelObjects;
using nStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nStack.Helpers
{
    public class nStackHelper
    {
       //nStack Helper set up viewModel with Checkboxes and options. Get the selected checkbox 
        public static nStackViewModel setUpnStackWithoutSelection()
        {
            Analyzer analyze = new Analyzer();
            FileReader fileReader = new FileReader();
            nStackViewModel vm = new nStackViewModel();
            vm.MasterFile = fileReader.getMasterFile();
            vm.SortedData = analyze.SortBySection(vm.MasterFile);
            vm.AcctAdminUsedBy = analyze.CompanySectionsUsed.AcctAdmin;
            vm.PcSupportUsedBy = analyze.CompanySectionsUsed.PCSupport;
            vm.MicrosoftOfficeUsedBy = analyze.CompanySectionsUsed.MicrOffSup;
            vm.PhoneSupportUsedBy = analyze.CompanySectionsUsed.PhoneSupport;
            vm.PrinterAdminUsedBy = analyze.CompanySectionsUsed.PrinterAdmin;
            vm.ShareDriveUsedBy = analyze.CompanySectionsUsed.ShareDrive;
            vm.Office365UsedBy = analyze.CompanySectionsUsed.Office365;
            vm.SoftwareProvisionUsedBy = analyze.CompanySectionsUsed.SoftwareProvision;
            vm.MonitoringUsedBy = analyze.CompanySectionsUsed.Monitoring;
            vm.AdminCheckBoxes = analyze.CompanyCheck;
            vm.ShareDriveCheckBoxes = getCheckBoxes(analyze.CompanySectionsUsed, "ShareDrive");
            vm.PhoneSupportCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "PhoneSupport");
            vm.SoftwareProvisionCheckboxes= getCheckBoxes(analyze.CompanySectionsUsed, "SoftwareProvision");
            vm.PrinterAdminCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "PrinterAdmin");
            vm.PCSupportCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "PCSupport");
            vm.Office365Checkboxes = getCheckBoxes(analyze.CompanySectionsUsed, "365");
            vm.MicrosoftCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "Microsoft");
            vm.MonitoringCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "Monit");
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
                vm.AcctAdminUsedBy = analyze.CompanySectionsUsed.AcctAdmin;
                vm.PcSupportUsedBy = analyze.CompanySectionsUsed.PCSupport;
                vm.MicrosoftOfficeUsedBy = analyze.CompanySectionsUsed.MicrOffSup;
                vm.PhoneSupportUsedBy = analyze.CompanySectionsUsed.PhoneSupport;
                vm.PrinterAdminUsedBy = analyze.CompanySectionsUsed.PrinterAdmin;
                vm.ShareDriveUsedBy = analyze.CompanySectionsUsed.ShareDrive;
                vm.SoftwareProvisionUsedBy = analyze.CompanySectionsUsed.SoftwareProvision;
                vm.MonitoringUsedBy = analyze.CompanySectionsUsed.Monitoring;
                vm.SelectedCompany = getSelectedCompany(vm);
                vm.AdminCheckBoxes = analyze.CompanyCheck;
                vm.ShareDriveCheckBoxes = getCheckBoxes(analyze.CompanySectionsUsed, "ShareDrive");
                vm.PhoneSupportCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "PhoneSupport");
                vm.SoftwareProvisionCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "SoftwareProvision");
                vm.PrinterAdminCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "PrinterAdmin");
                vm.PCSupportCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "PCSupport");
                vm.Office365Checkboxes = getCheckBoxes(analyze.CompanySectionsUsed, "365");
                vm.MicrosoftCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "Microsoft");
                vm.MonitoringCheckboxes = getCheckBoxes(analyze.CompanySectionsUsed, "Monit");
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
            if (vm.AccountAdminOption == true)
            {
                foreach (var Company in vm.AdminCheckBoxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
                }
            }

            if (vm.ShareDriveOption == true)
            {
                foreach (var Company in vm.ShareDriveCheckBoxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
                }
            }

            if (vm.PhoneSupportOption == true)
            {
                foreach (var Company in vm.PhoneSupportCheckboxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
                }
            }

            if (vm.SoftwareProvOption == true)
            {
                foreach (var Company in vm.SoftwareProvisionCheckboxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
                }
            }

            if (vm.PrinterAdminOption == true)
            {
                if (vm.PrinterAdminCheckboxes!=null)
                {
                    foreach (var Company in vm.PrinterAdminCheckboxes)
                    {
                        if (Company.Checked == true)
                        {
                            selected.Add(Company.Name);
                        }
                    }
                }
                else
                {
                    selected.Add("None");
                }
                
            }

            if (vm.PCSupportOption == true)
            {
                foreach (var Company in vm.PCSupportCheckboxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
                }
            }

            if (vm.Office365Option == true)
            {
                foreach (var Company in vm.Office365Checkboxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
                }
            }

            if (vm.MicrosoftOfficeSupportOption == true)
            {
                foreach (var Company in vm.MicrosoftCheckboxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
                }
            }

            if (vm.MonitoringOption == true)
            {
                foreach (var Company in vm.MonitoringCheckboxes)
                {
                    if (Company.Checked == true)
                    {
                        selected.Add(Company.Name);
                    }
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
    }
}