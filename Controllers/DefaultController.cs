using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.DBManagement;
using DMS.Models;
using DMS.ViewModels;

namespace DMS.Controllers
{
    public class DefaultController : Controller
    {
        DBM_SystemReferenceGroupValues SystemReferenceGroupValues = new DBM_SystemReferenceGroupValues();
        DBM_Reports Reports = new DBM_Reports();
        DBM_Victims Victims = new DBM_Victims();
        DBM_Witnesses Witnesses = new DBM_Witnesses();
        DBM_Suspects Suspects = new DBM_Suspects();
        DBM_VictimFinancialTransactions VictimFinancialTransactions = new DBM_VictimFinancialTransactions();
        public string Module = "Default";
        public string Section = "Index";
        public string Title = "File A Complaint";
        public string Home = "Default";

        public int rgv_report_type_id_WALKIN = 57; // WALK-IN
        public int system_division_id = 3; // Investigation Division

        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["sexes"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Sex", 0, 0);
            ViewData["age_brackets"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Age Bracket", 0, 0);
            ViewData["marital_statuses"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Marital Status", 0, 0);

            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FormCollection collection)
        {
            bool isInserted = true;
            var sMessage = "Successfully saved!";

            var reference_number = "";
            int report_id = 0;
            try
            {

                var generate_ref_num = Reports.GenerateReferenceNumber(system_division_id, rgv_report_type_id_WALKIN);
                reference_number = generate_ref_num.reference_number;

                //START: REPORTS
                var reports = new Reports();
                reports.reference_number = reference_number;
                reports.date_received = DateTime.Now.ToString("yyyy-MM-dd");
                reports.time_received = DateTime.Now.ToString("HH:mm") + ":00";
                reports.rgv_report_type_id = rgv_report_type_id_WALKIN;
                reports.rgv_report_category_id = 0;
                reports.started_at = null;
                reports.completed_at = null;
                reports.description_of_incident = collection["description_of_incident"].ToString();
                reports.is_spoofed_email = 0;
                reports.is_similar_domain = 0;
                reports.is_email_intrusion = 0;
                reports.is_others = 0;
                reports.others = "";
                reports.digital_signature = collection["digital_signature"].ToString();
                reports.created_by = collection["digital_signature"].ToString();
                reports.created_at = DateTime.Now;
                reports.remarks = "";
                //END: REPORTS

                if (ModelState.IsValid)
                {
                    report_id = Reports.Insert(reports);

                    if(report_id <= 0)
                    {
                        isInserted = false;
                        sMessage = "Something went wrong! Please contact technical support.";
                    }

                    //START: REFERENCE NUMBER
                    var report_reference_numbers = new Report_reference_numbers();
                    report_reference_numbers.report_id = report_id;
                    report_reference_numbers.rgv_report_type_id = rgv_report_type_id_WALKIN;
                    report_reference_numbers.system_division_id = system_division_id;
                    report_reference_numbers.created_by = collection["digital_signature"].ToString();
                    report_reference_numbers.created_at = DateTime.Now;
                    int ref_id = Reports.Insert_ReferenceNumber(report_reference_numbers);
                    //END: REFERENCE NUMBER

                    if (ref_id <= 0)
                    {
                        isInserted = false;
                        sMessage = "Something went wrong! Please contact technical support.";
                    }

                    //START: VICTIMS
                    var victims = new Victims();
                    victims.report_id = report_id;
                    victims.last_name = collection["last_name"].ToString();
                    victims.first_name = collection["first_name"].ToString();
                    victims.middle_name = collection["middle_name"].ToString();
                    victims.rgv_age_bracket_id = Convert.ToInt32(collection["rgv_age_bracket_id"]);
                    victims.rgv_sex_id = Convert.ToInt32(collection["rgv_sex_id"]);
                    victims.rgv_marital_status_id = Convert.ToInt32(collection["rgv_marital_status_id"]);
                    victims.is_impacting_business_operations = Convert.ToInt32(collection["is_impacting_business_operations"]);
                    victims.business_name = collection["business_name"].ToString();
                    victims.country_id = Convert.ToInt32(collection["country_id"]);
                    victims.province_id = Convert.ToInt32(collection["province_id"]);
                    victims.city_id = Convert.ToInt32(collection["city_id"]);
                    victims.address1 = collection["address1"].ToString();
                    victims.zip_code = collection["zip_code"].ToString();
                    victims.mobile_number = collection["mobile_number"].ToString();
                    victims.email = collection["email"].ToString();
                    victims.business_it_poc = collection["business_it_poc"].ToString();
                    victims.other_busines_poc = collection["other_busines_poc"].ToString();
                    victims.created_by = collection["digital_signature"].ToString();
                    victims.created_at = DateTime.Now;
                    //END: VICTIMS

                    int victim_id = Victims.Insert(victims);
                    if (victim_id <= 0)
                    {
                        isInserted = false;
                        sMessage = "Something went wrong! Please contact technical support.";
                    }

                    //START: VICTIM TRANSACTIONS
                    if (victim_id > 0)
                    {
                        
                        int ft_ctr = Convert.ToInt32(collection["ft_ctr"]);
                        if (ft_ctr > 0)
                        {
                            for (int i = 1; i <= ft_ctr; i++)
                            {
                                var victim_financial_transactions = new Victim_financial_transactions();
                                victim_financial_transactions.victim_id = victim_id;
                                victim_financial_transactions.rgv_transaction_type_id = Convert.ToInt32(collection["ft_rgv_transaction_type_id_" + i.ToString()]);
                                victim_financial_transactions.is_others = (collection["ft_others_" + i.ToString()].ToString() == "" ? 0 : 1);
                                victim_financial_transactions.others = collection["ft_others_" + i.ToString()].ToString();
                                victim_financial_transactions.transaction_date = collection["ft_transaction_date_" + i.ToString()].ToString();
                                victim_financial_transactions.amount = Convert.ToDouble(collection["ft_amount_" + i.ToString()]);
                                victim_financial_transactions.is_sent = Convert.ToInt32(collection["ft_is_sent_" + i.ToString()]);
                                victim_financial_transactions.victim_bank_name = collection["ft_victim_bank_name_" + i.ToString()].ToString();
                                victim_financial_transactions.victim_account_name = collection["ft_victim_account_name_" + i.ToString()].ToString();
                                victim_financial_transactions.victim_account_number = collection["ft_victim_account_number_" + i.ToString()].ToString();
                                victim_financial_transactions.victim_bank_country_id = Convert.ToInt32(collection["ft_victim_bank_country_id_" + i.ToString()]);
                                victim_financial_transactions.victim_bank_province_id = Convert.ToInt32(collection["ft_victim_bank_province_id_" + i.ToString()]);
                                victim_financial_transactions.victim_bank_city_id = Convert.ToInt32(collection["ft_victim_bank_city_id_" + i.ToString()]);
                                victim_financial_transactions.victim_bank_address1 = collection["ft_victim_bank_address_" + i.ToString()].ToString();
                                victim_financial_transactions.victim_bank_zip_code = collection["ft_victim_bank_zip_code_" + i.ToString()].ToString();

                                victim_financial_transactions.receipient_bank_name = collection["ft_receipient_bank_name_" + i.ToString()].ToString();
                                victim_financial_transactions.receipient_account_name = collection["ft_receipient_account_name_" + i.ToString()].ToString();
                                victim_financial_transactions.receipient_account_number = collection["ft_receipient_account_number_" + i.ToString()].ToString();
                                victim_financial_transactions.receipient_bank_country_id = Convert.ToInt32(collection["ft_receipient_bank_country_id_" + i.ToString()]);
                                victim_financial_transactions.receipient_bank_province_id = Convert.ToInt32(collection["ft_receipient_bank_province_id_" + i.ToString()]);
                                victim_financial_transactions.receipient_bank_city_id = Convert.ToInt32(collection["ft_receipient_bank_city_id_" + i.ToString()]);
                                victim_financial_transactions.receipient_bank_address1 = collection["ft_receipient_bank_address_" + i.ToString()].ToString();
                                victim_financial_transactions.receipient_bank_zip_code = collection["ft_receipient_bank_zip_code_" + i.ToString()].ToString();
                                victim_financial_transactions.created_by = collection["digital_signature"].ToString();
                                victim_financial_transactions.created_at = DateTime.Now;

                                int ft_id = VictimFinancialTransactions.Insert(victim_financial_transactions);
                                if (ft_id <= 0)
                                {
                                    isInserted = false;
                                    sMessage = "Something went wrong! Please contact technical support.";
                                }
                            }
                        }                    }
                    //END: VICTIM TRANSACTIONS

                    //START: SUSPECTS
                    int s_ctr = Convert.ToInt32(collection["s_ctr"]);
                    if (s_ctr > 0)
                    {
                        for (int i = 1; i <= s_ctr; i++)
                        {
                            var suspects = new Suspects();
                            suspects.report_id = report_id;
                            suspects.full_name = collection["s_full_name_" + i.ToString()].ToString();
                            suspects.business_name = collection["s_business_name_" + i.ToString()].ToString();
                            suspects.country_id = Convert.ToInt32(collection["s_country_id_" + i.ToString()]);
                            suspects.province_id = Convert.ToInt32(collection["s_province_id_" + i.ToString()]);
                            suspects.city_id = Convert.ToInt32(collection["s_city_id_" + i.ToString()]);
                            suspects.address1 = collection["s_address_" + i.ToString()].ToString();
                            suspects.zip_code = collection["s_zip_code_" + i.ToString()].ToString();
                            suspects.mobile_number = collection["s_mobile_number_" + i.ToString()].ToString();
                            suspects.email = collection["s_email_" + i.ToString()].ToString();
                            suspects.ip_address = collection["s_ip_address_" + i.ToString()].ToString();
                            suspects.website_link = collection["s_website_link_" + i.ToString()].ToString();
                            suspects.created_by = collection["digital_signature"].ToString();
                            suspects.created_at = DateTime.Now;

                            int sus_id = Suspects.Insert(suspects);
                            if (sus_id <= 0)
                            {
                                isInserted = false;
                                sMessage = "Something went wrong! Please contact technical support.";
                            }
                        }
                    }
                    //END: SUSPECTS

                    //START: WITNESS
                    if (collection["w_full_name"].ToString() != "")
                    {
                       
                        var witnesses = new Witnesses();
                        witnesses.report_id = report_id;
                        witnesses.full_name = collection["w_full_name"].ToString();
                        witnesses.rgv_age_bracket_id = Convert.ToInt32(collection["w_rgv_age_bracket_id"]);
                        witnesses.rgv_marital_status_id = Convert.ToInt32(collection["w_rgv_marital_status_id"]);
                        witnesses.email = collection["w_email"].ToString();
                        witnesses.mobile_number = collection["w_mobile_number"].ToString();
                        witnesses.full_address = collection["w_full_address"].ToString();
                        witnesses.created_by = collection["digital_signature"].ToString();
                        witnesses.created_at = DateTime.Now;
                        

                        int w_id = Witnesses.Insert(witnesses);
                        if (w_id <= 0)
                        {
                            isInserted = false;
                            sMessage = "Something went wrong! Please contact technical support.";
                        }
                    }
                    //END: WITNESS
                }

                var result = new { status = isInserted, message = sMessage };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var error = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}   