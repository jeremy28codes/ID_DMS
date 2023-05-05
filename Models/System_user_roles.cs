using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_user_roles
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int role_id { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}