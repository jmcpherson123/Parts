using nStack.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nStack.Models
{
    public class UploadViewModel:BinFileObject
    {
        public BinFileObject ReadData;
        public Dictionary<string, List<List<string>>> sortedData;
        public string section;

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

    }
}