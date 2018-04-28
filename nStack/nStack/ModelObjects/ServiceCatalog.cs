using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nStack.ModelObjects
{
    public class ServiceCatalog
    {
        public string sys_created_by;
        public string RequestNumber;
        public string RequestName;
        public string short_description;
        public string approval;
        public string Description;
        public string upon_approval;
        public string TaskNumber;
        public string expected_start;
        public string Sys_Id;
        public string due_date;
        public List<string> sys_Ids_Values;
        public string approval_history;
    }
}