using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DMS.Models
{
    public class Document_attachments
    {
        [Key]
        public int id { get; set; }
        public int document_id { get; set; }
        public int document_route_log_id { get; set; }
        public string file_name { get; set; }
        public string file_type { get; set; }
        public string file_size { get; set; }
        public string file_path { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}