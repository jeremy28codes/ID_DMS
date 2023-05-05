using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Victims
    {
        [Key]
        public int id { get; set; }
        public int report_id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public int is_in_behalf_of_business { get; set; }
        public string business_name { get; set; }
        public int is_impacting_business_operations { get; set; }
        public int rgv_age_bracket_id { get; set; }
        public string rgv_age_bracket_code { get; set; }
        public string rgv_age_bracket_name { get; set; }
        public string rgv_age_bracket_description { get; set; }
        public int rgv_marital_status_id { get; set; }
        public string rgv_marital_status_code { get; set; }
        public string rgv_marital_status_name { get; set; }
        public string rgv_marital_status_description { get; set; }
        public int rgv_sex_id { get; set; }
        public string rgv_sex_code { get; set; }
        public string rgv_sex_name { get; set; }
        public string rgv_sex_description { get; set; }
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
        public string business_it_poc { get; set; }
        public string other_busines_poc { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}