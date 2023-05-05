using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Victim_financial_transactions
    {
        [Key]
        public int id { get; set; }
        public int victim_id { get; set; }
        public string transaction_date { get; set; }
        public int rgv_transaction_type_id { get; set; }
        public string rgv_transaction_type_code { get; set; }
        public string rgv_transaction_type_name { get; set; }
        public string rgv_transaction_type_description { get; set; }
        public int is_others { get; set; }
        public string others { get; set; }
        public Double amount { get; set; }
        public int is_sent { get; set; }
        public string victim_bank_name { get; set; }
        public string victim_bank_address1 { get; set; }
        public string victim_bank_address2 { get; set; }
        public int victim_bank_country_id { get; set; }
        public string victim_bank_country_code { get; set; }
        public string victim_bank_country_name { get; set; }
        public string victim_bank_country_description { get; set; }
        public int victim_bank_province_id { get; set; }
        public string victim_bank_province_code { get; set; }
        public string victim_bank_province_name { get; set; }
        public string victim_bank_province_description { get; set; }
        public int victim_bank_city_id { get; set; }
        public string victim_bank_city_code { get; set; }
        public string victim_bank_city_name { get; set; }
        public string victim_bank_city_description { get; set; }
        public string victim_bank_zip_code { get; set; }
        public string victim_account_name { get; set; }
        public string victim_account_number { get; set; }
        public string receipient_bank_name { get; set; }
        public string receipient_bank_address1 { get; set; }
        public string receipient_bank_address2 { get; set; }
        public int receipient_bank_country_id { get; set; }
        public string receipient_bank_country_code { get; set; }
        public string receipient_bank_country_name { get; set; }
        public string receipient_bank_country_description { get; set; }
        public int receipient_bank_province_id { get; set; }
        public string receipient_bank_province_code { get; set; }
        public string receipient_bank_province_name { get; set; }
        public string receipient_bank_province_description { get; set; }
        public int receipient_bank_city_id { get; set; }
        public string receipient_bank_city_code { get; set; }
        public string receipient_bank_city_name { get; set; }
        public string receipient_bank_city_description { get; set; }
        public string receipient_bank_zip_code { get; set; }
        public string receipient_bank_swift_code { get; set; }
        public string receipient_account_name { get; set; }
        public string receipient_account_number { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string remarks { get; set; }
    }
}