using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Reports
    {
        [Key]
        public int id { get; set; }
        public string reference_number { get; set; }
        public string date_received { get; set; }
        public string time_received { get; set; }
        public int rgv_report_type_id { get; set; }
        public string rgv_report_type_code { get; set; }
        public string rgv_report_type_name { get; set; }
        public string rgv_report_type_description { get; set; }
        public int rgv_report_category_id { get; set; }
        public string rgv_report_category_code { get; set; }
        public string rgv_report_category_name { get; set; }
        public string rgv_report_category_description { get; set; }
        public string started_at { get; set; }
        public string completed_at { get; set; }
        public string description_of_incident { get; set; }
        public int is_spoofed_email { get; set; }
        public int is_similar_domain { get; set; }
        public int is_email_intrusion { get; set; }
        public int is_others { get; set; }
        public string others { get; set; }
        public string digital_signature { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}