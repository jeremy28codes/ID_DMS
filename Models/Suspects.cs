using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Suspects
    {
        [Key]
        public int id { get; set; }
        public int report_id { get; set; }
        public string full_name { get; set; }
        public string business_name { get; set; }
        public string email { get; set; }
        public string mobile_number { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int country_id { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string country_description { get; set; }
        public int province_id { get; set; }
        public string province_code { get; set; }
        public string province_name { get; set; }
        public string province_description { get; set; }
        public int city_id { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string city_description { get; set; }
        public string zip_code { get; set; }
        public string website_link { get; set; }
        public string ip_address { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}