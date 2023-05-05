using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Witnesses
    {
        [Key]
        public int id { get; set; }
        public int report_id { get; set; }
        public string full_name { get; set; }
        public int rgv_age_bracket_id { get; set; }
        public string rgv_age_bracket_code { get; set; }
        public string rgv_age_bracket_name { get; set; }
        public string rgv_age_bracket_description { get; set; }
        public string email { get; set; }
        public string mobile_number { get; set; }
        public string full_address { get; set; }
        public int rgv_marital_status_id { get; set; }
        public string rgv_marital_status_code { get; set; }
        public string rgv_marital_status_name { get; set; }
        public string rgv_marital_status_description { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}