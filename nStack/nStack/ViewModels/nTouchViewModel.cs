using nStack.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace nStack.Models
{
    public class nTouchViewModel
    {
        public string sc_item_option_otom { get; set; }
        public string sc_item_option { get; set; }

        public string sc_task { get; set; }

        public string sc_req_item { get; set; }
        public string request_variable { get; set; }



        public CatalogTaskVariable RequestVariable { get; set; }

        public List<CatalogTaskVariable> VariableContainer { get; set; }

        public string SubCategorySectionTech { get; set; }

        public string SubCategorySectionService{ get; set; }

        public string GetListOfCategories { get; set; }

        public List<ServiceCatalog> ListOfRequestItems { get; set; }

        public List<string> rawCategoriesTech { get; set; }

        public List<string> rawCategoriesService { get; set; }
    }
}