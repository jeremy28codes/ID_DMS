using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Documents
    {
        [Key]
        public int id { get; set; }
        public string reference_number { get; set; }
        public string routing_number { get; set; }
        public string title { get; set; }
        public int rgv_document_particular_id { get; set; }
        public string rgv_document_particular_code { get; set; }
        public string rgv_document_particular_name { get; set; }
        public string rgv_document_particular_description { get; set; }
        public int rgv_document_particular_ctr { get; set; }
        public int rgv_document_type_id { get; set; }
        public string rgv_document_type_code { get; set; }
        public string rgv_document_type_name { get; set; }
        public string rgv_document_type_description { get; set; }
        public int rgv_document_type_ctr { get; set; }
        public int rgv_document_status_id { get; set; }
        public string rgv_document_status_code { get; set; }
        public string rgv_document_status_name { get; set; }
        public string rgv_document_status_description { get; set; }
        public int rgv_document_status_ctr { get; set; }
        public string completed_at { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}