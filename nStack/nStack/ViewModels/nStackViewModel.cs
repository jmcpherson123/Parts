using nStack.Helpers;
using nStack.ModelObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nStack.Models
{
    public class nStackViewModel
    {
        public List<BinFileObject> MasterFile;
        public Dictionary<string, List<string>> TabData;
        public List<string> SheetList;
        public List<SortedData[]> SortedData;
        //Section Checkbox select
        public List<string> AcctAdminUsedBy = new List<string>();
        public List<string> PcSupportUsedBy = new List<string>();
        public List<string> MicrosoftOfficeUsedBy = new List<string>();
        public List<string> Office365UsedBy = new List<string>();
        public List<string> PhoneSupportUsedBy = new List<string>();
        public List<string> SoftwareProvisionUsedBy = new List<string>();
        public List<string> ShareDriveUsedBy = new List<string>();
        public List<string> PrinterAdminUsedBy = new List<string>();
        public List<string> MonitoringUsedBy = new List<string>();

        //Sheet selected Company Checkbox 
        public List<CheckboxHelper>AdminCheckBoxes { get; set; }
        public List<CheckboxHelper> ShareDriveCheckBoxes { get; set; }
        public List<CheckboxHelper> PhoneSupportCheckboxes { get; set; }
        public List<CheckboxHelper> SoftwareProvisionCheckboxes { get; set; }
        public List<CheckboxHelper> PrinterAdminCheckboxes { get; set; }
        public List<CheckboxHelper> PCSupportCheckboxes { get; set; }
        public List<CheckboxHelper> Office365Checkboxes { get; set; }
        public List<CheckboxHelper> MicrosoftCheckboxes { get; set; }
        public List<CheckboxHelper> MonitoringCheckboxes { get; set; }
        public List<string> SelectedCompany = new List<string>();
        public int Switch = 0;


        [Display(Name = "Account Admin")]
        public bool AccountAdminOption { get; set; }

        [Display(Name = "Share Drive ")]
        public bool ShareDriveOption { get; set; }

        [Display(Name = "Phone Support")]
        public bool PhoneSupportOption { get; set; }

        [Display(Name = "Software Provision")]
        public bool SoftwareProvOption { get; set; }

        [Display(Name = "Printer Admin")]
        public bool PrinterAdminOption { get; set; }

        [Display(Name = "PC Support")]
        public bool PCSupportOption { get; set; }

        [Display(Name = "Office 365")]
        public bool Office365Option { get; set; }

        [Display(Name = "Microsoft Office Support")]
        public bool MicrosoftOfficeSupportOption { get; set; }

        [Display(Name = "Office 365")]
        public bool MonitoringOption { get; set; }
    }
}