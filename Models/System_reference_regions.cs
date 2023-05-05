using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_reference_regions
    {
        [Key]
        public int id { get; set; }
        public int rgv_region_gorup_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string population { get; set; }
        public string kilometer_area { get; set; }
        public string region_center { get; set; }
        public int ctr { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}