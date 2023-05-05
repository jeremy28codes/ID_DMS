using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_web_sections
    {
        [Key]
        public int id { get; set; }
        public int system_web_module_id { get; set; }
        public string system_web_module_code { get; set; }
        public string system_web_module_name { get; set; }
        public string system_web_module_description { get; set; }
        public string system_web_module_link { get; set; }
        public string system_web_module_icon { get; set; }
        public int system_web_module_ctr { get; set; }
        public int system_web_module_is_active { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string icon { get; set; }
        public int ctr { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public int is_active { get; set; }
    }
}