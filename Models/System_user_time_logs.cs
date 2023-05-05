using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class System_user_time_logs
    {
        [Key]
        public int id { get; set; }
        public int system_user_id { get; set; }
        public string log_date { get; set; }
        public int dt_day { get; set; }
        public string dtr_duration { get; set; }
        public string log_in { get; set; }
        public string log_out { get; set; }
        public string sAM_log_in { get; set; }
        public string sAM_log_out { get; set; }
        public string sPM_log_in { get; set; }
        public string sPM_log_out { get; set; }
        public int total_minutes_rendered { get; set; }
        public string stotal_minutes_rendered { get; set; }
        public int overtime { get; set; }
        public string sovertime { get; set; }
        public int undertime { get; set; }
        public string sundertime { get; set; }
        public string day_of_the_week { get; set; }
        public int is_included { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}