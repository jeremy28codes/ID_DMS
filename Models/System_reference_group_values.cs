using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_reference_group_values
    {
        [Key]
        public int id { get; set; }
        public int system_reference_group_id { get; set; }
        public int system_reference_group_department_id { get; set; }
        public string system_reference_group_department_code { get; set; }
        public string system_reference_group_department_name { get; set; }
        public string system_reference_group_department_description { get; set; }
        public int system_reference_group_division_id { get; set; }
        public string system_reference_group_division_code { get; set; }
        public string system_reference_group_division_name { get; set; }
        public string system_reference_group_division_description { get; set; }
        public string system_reference_group_code { get; set; }
        public string system_reference_group_name { get; set; }
        public string system_reference_group_description { get; set; }
        public int system_reference_group_ctr { get; set; }
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