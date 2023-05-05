using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_user_role_section_access
    {
        [Key]
        public int id { get; set; }
        public int system_role_id { get; set; }
        public string system_role_code { get; set; }
        public string system_role_name { get; set; }
        public string system_role_description { get; set; }
        public int system_web_section_id { get; set; }
        public string system_web_section_code { get; set; }
        public string system_web_section_name { get; set; }
        public string system_web_section_description { get; set; }
        public string system_web_section_link { get; set; }
        public string system_web_section_icon { get; set; }
        public int system_web_section_ctr { get; set; }
        public int system_web_section_is_active { get; set; }
        public int can_access { get; set; }
        public int can_view { get; set; }
        public int can_create { get; set; }
        public int can_edit { get; set; }
        public int can_delete { get; set; }
        public string created_by { get; set; }
        public int system_web_module_id { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}