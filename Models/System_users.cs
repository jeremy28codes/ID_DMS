using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_users
    {
        [Key]
        public int id { get; set; }
        public string reference_number { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string prefix { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string suffix { get; set; }
        public int rgv_sex_id { get; set; }
        public string rgv_sex_code { get; set; }
        public string rgv_sex_name { get; set; }
        public string rgv_sex_description { get; set; }
        public string about { get; set; }
        public int department_id { get; set; }
        public string department_code { get; set; }
        public string department_name { get; set; }
        public string department_description { get; set; }
        public int division_id { get; set; }
        public string division_code { get; set; }
        public string division_name { get; set; }
        public string division_description { get; set; }
        public int unit_id { get; set; }
        public string unit_code { get; set; }
        public string unit_name { get; set; }
        public string unit_description { get; set; }
        public int section_id { get; set; }
        public string section_code { get; set; }
        public string section_name { get; set; }
        public string section_description { get; set; }
        public string job_title { get; set; }
        public string address { get; set; }
        public string mobile_number { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string linked_in { get; set; }
        public string pic_img_path { get; set; }
        public string sig_img_path { get; set; }
        public string qr_img_path { get; set; }
        public string qr_code { get; set; }
        public string biometric_number { get; set; }
        public int login_attempt { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}