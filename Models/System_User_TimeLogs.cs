using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_User_TimeLogs
    {
        [Key]
        public int ID { get; set; }
        public string Employee_Name { get; set; }
        public string DT { get; set; }
        public string Time_IN { get; set; }
        public string Time_OUT { get; set; }

    }
}