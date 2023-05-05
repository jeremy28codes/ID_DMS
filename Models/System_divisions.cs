using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_divisions
    {
        [Key]
        public int id { get; set; }
        public int system_department_id { get; set; }
        public string system_department_code { get; set; }
        public string system_department_name { get; set; }
        public string system_department_description { get; set; }
        public int system_department_ctr { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int ctr { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}