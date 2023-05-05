using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Document_route_logs
    {
        [Key]
        public int id { get; set; }
        public int document_id { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string route_date { get; set; }
        public string sroute_date { get; set; }
        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = true)]
        public string route_time { get; set; }
        public int from_system_department_id { get; set; }
        public string from_system_department_code { get; set; }
        public string from_system_department_name { get; set; }
        public string from_system_department_description { get; set; }
        public int from_system_department_ctr { get; set; }
        public int from_system_division_id { get; set; }
        public string from_system_division_code { get; set; }
        public string from_system_division_name { get; set; }
        public string from_system_division_description { get; set; }
        public int from_system_division_ctr { get; set; }
        public int from_system_unit_id { get; set; }
        public string from_system_unit_code { get; set; }
        public string from_system_unit_name { get; set; }
        public string from_system_unit_description { get; set; }
        public int from_system_unit_ctr { get; set; }
        public string from_name { get; set; }
        public int to_system_department_id { get; set; }
        public string to_system_department_code { get; set; }
        public string to_system_department_name { get; set; }
        public string to_system_department_description { get; set; }
        public int to_system_department_ctr { get; set; }
        public int to_system_division_id { get; set; }
        public string to_system_division_code { get; set; }
        public string to_system_division_name { get; set; }
        public string to_system_division_description { get; set; }
        public int to_system_division_ctr { get; set; }
        public int to_system_unit_id { get; set; }
        public string to_system_unit_code { get; set; }
        public string to_system_unit_name { get; set; }
        public string to_system_unit_description { get; set; }
        public int to_system_unit_ctr { get; set; }
        public string to_name { get; set; }
        public int rgv_document_status_id { get; set; }
        public string rgv_document_status_code { get; set; }
        public string rgv_document_status_name { get; set; }
        public string rgv_document_status_description { get; set; }
        public int rgv_document_status_ctr { get; set; }
        public int rgv_action_type_id { get; set; }
        public string rgv_action_type_code { get; set; }
        public string rgv_action_type_name { get; set; }
        public string rgv_action_type_description { get; set; }
        public int rgv_action_type_ctr { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}