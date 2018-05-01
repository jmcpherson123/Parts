using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using nStack.ModelObjects;
using nStack.Models;
using System.Collections.Generic;

namespace nStack.Helpers
{
    public class ServiceNowScriptHelper
    {
        public List<ServiceCatalog> clean_sc_task(string jsonObject, List<string> compareList)
        {
            List<ServiceCatalog> RequestItemsContainer = new List<ServiceCatalog>();
            string tester = jsonObject.Replace("\"", "").Replace("[", "").Replace("result:", "").Replace("subcategory", "^").Replace("category", "*");
            var BrokenDictionaries = tester.Split('}');

            List<string> ValueList = new List<string>();
            string[] brokenParts;
            foreach (var part in BrokenDictionaries)
            {
                foreach(var comp in compareList)
                {
                    if (part.Contains(comp))
                    {
                        ServiceCatalog RequestItem = new ServiceCatalog();
                        RequestItem.Description = "New Hire Form";
                        
                        brokenParts = part.Split(',');
                        foreach (var line in brokenParts)
                        {
                            if (!line.Equals(""))
                            {
                                if (line.Contains("sys_created_by"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.sys_created_by = res[1];
                                }
                                if (line.Contains("sys_id"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.Sys_Id = res[1];
                                }
                                if (line.Contains("parent"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.RequestNumber = res[1];
                                }
                                if (line.Contains("upon_approval"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.upon_approval = res[1];
                                }
                                if (line.Contains("expected_start"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.expected_start = res[1];
                                }
                                if (line.Contains("short_description"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.RequestName = res[1];

                                    RequestItem.short_description = res[1];
                                }
                                if (line.Contains("number"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.TaskNumber = res[1];
                                }
                                if (line.Contains("due_date"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.due_date = res[1];
                                }
                                if (line.Contains("approval_history"))
                                {
                                    var res = line.Split(':');
                                    RequestItem.approval_history = res[1];
                                }
                                if (line.Contains("approval"))
                                {
                                    var res = line.Split(':');

                                    RequestItem.approval = res[1];
                                }
                            }
                        }
                        RequestItemsContainer.Add(RequestItem);
                    }
                }
                   
            }
            return RequestItemsContainer;
        }
        public List<string> get_sc_req_items(string sc_req)
        {
            List<CatalogTaskVariable> container = new List<CatalogTaskVariable>();
            List<string> compareDateValue = new List<string>();
            string tester = sc_req.Replace("\"", "").Replace("[", "").Replace("result:", "").Replace("subcategory", "^").Replace("category", "*");
            var BrokenDictionaries = tester.Split('*');
            List<string> ValueList = new List<string>();
            string[] brokenParts;
            foreach (var part in BrokenDictionaries)
            {
                if (part.Contains("New Hire Form") || part.Contains("New Scotia") || part.Contains("New Employee"))
                {
                    var value = part.Split(',');
                    foreach(var param in value)
                    {
                      
                        if (param.Contains("number"))
                        {
                            var tempVal = param.Split(':');
                            compareDateValue.Add(tempVal[1]);
                        }
                    }
                }
            }
            return compareDateValue;
        }

        public nTouchViewModel clean_sc_item_option_otom(string jsonObject,nTouchViewModel vm)
        {
            CatalogTaskVariable TaskVariable = new CatalogTaskVariable();
            string tester = jsonObject.Replace("\"", "").Replace("[", "").Replace("result:", "");
            var BrokenDictionaries = tester.Split('}');

            List<string> ValueList = new List<string>();

            string[] brokenParts;
            foreach (var part in vm.ListOfRequestItems)
            {
                part.sys_Ids_Values = new List<string>();
                foreach (var line in BrokenDictionaries)
                {
                    if (line.Contains(part.RequestNumber))
                    {
                        brokenParts = line.Split(',');
                        var spaceholder = "spaceholder";
                        foreach(var section in brokenParts)
                        {
                            if (section.Contains("sc_item_option"))
                            {
                                var broken = section.Split(':');
                                part.sys_Ids_Values.Add(broken[1]);
                            }
                        }   
                    }
                }
            }
            return vm;
        }

        public List<ServiceCatalog> SortedCatalogs(List<string> serviceCatalogTitle, List<string> sys_IDList, List<bool> has_Items)
        {
            List<ServiceCatalog> ListOfCatalog = new List<ServiceCatalog>();

            return ListOfCatalog;
        }

        public void makeContact()
        {
            ScriptEngine engine = Python.CreateEngine();
        }

        public List<string> TaskItems (string sc_item_options, string ReqNumber)
        {
            List<string> values = new List<string>();

            return values;
        }
    }
}