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
    public class ReportController : Controller
    {
        DBM_SystemReferenceGroupValues SystemReferenceGroupValues = new DBM_SystemReferenceGroupValues();
        DBM_Reports Reports = new DBM_Reports();
        DBM_Victims Victims = new DBM_Victims();
        DBM_Witnesses Witnesses = new DBM_Witnesses();
        DBM_Suspects Suspects = new DBM_Suspects();
        DBM_VictimFinancialTransactions VictimFinancialTransactions = new DBM_VictimFinancialTransactions();

        public string Module = "Reports";
        public string Section = "";
        public string Title = "DMS - Reports";
        public string Home = "Report";

        // GET: Report
        [HttpGet]
        public ActionResult Index()
        {
            if (!Convert.ToBoolean(Session["logged_on"]))
            {
                return RedirectToAction("Index", "Auth");
            }

            Session["active_module"] = Module.ToString();
            Session["active_section"] = Section.ToString();
            Session["active_page"] = Home.ToString();

            ViewBag.Module = Module.ToString();
            ViewBag.Section = Section.ToString();
            ViewBag.Action = "Index";
            ViewBag.Home = Home.ToString();
            ViewBag.Title = Title.ToString();

            var style_paths = new List<Styles_path>
            {
                new Styles_path {path = "/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"},
                new Styles_path {path = "/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"},
                new Styles_path {path = "/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/datatables/jquery.dataTables.min.js"},
                new Scripts_path {path = "/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js"},
                new Scripts_path {path = "/plugins/datatables-responsive/js/dataTables.responsive.min.js"},
                new Scripts_path {path = "/plugins/datatables-responsive/js/responsive.bootstrap4.min.js"},
                new Scripts_path {path = "/plugins/datatables-buttons/js/dataTables.buttons.min.js"},
                new Scripts_path {path = "/plugins/datatables-buttons/js/buttons.bootstrap4.min.js"},
                new Scripts_path {path = "/plugins/jszip/jszip.min.js"},
                new Scripts_path {path = "/plugins/pdfmake/pdfmake.min.js"},
                new Scripts_path {path = "/plugins/pdfmake/vfs_fonts.js"},
                new Scripts_path {path = "/plugins/datatables-buttons/js/buttons.html5.min.js"},
                new Scripts_path {path = "/plugins/datatables-buttons/js/buttons.print.min.js"},
                new Scripts_path {path = "/plugins/datatables-buttons/js/buttons.colVis.min.js"},
                new Scripts_path {path = "/dist/js/pages/report/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var List = Reports.ListAll();
            return View(List);
        }


        

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (!Convert.ToBoolean(Session["logged_on"]))
            {
                return RedirectToAction("Index", "Auth");
            }

            Session["active_module"] = Module.ToString();
            Session["active_section"] = Section.ToString();
            Session["active_page"] = Home.ToString();

            ViewBag.Module = Module.ToString();
            ViewBag.Section = Section.ToString();
            ViewBag.Action = "Index";
            ViewBag.Home = Home.ToString();
            ViewBag.Title = Title.ToString();

            var style_paths = new List<Styles_path>
            {
                new Styles_path {path = "/plugins/select2/css/select2.min.css"}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/select2/js/select2.full.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/report/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["report_types"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Report Type", 0, 0);
            ViewData["sexes"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Sex", 0, 0);
            ViewData["age_brackets"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Age Bracket", 0, 0);
            ViewData["marital_statuses"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Marital Status", 0, 0);

            return View();
        }

        // GET: Report/Create
        [HttpGet]
        public ActionResult Sample()
        {
            if (!Convert.ToBoolean(Session["logged_on"]))
            {
                return RedirectToAction("Index", "Auth");
            }

            Session["active_module"] = Module.ToString();
            Session["active_section"] = Section.ToString();
            Session["active_page"] = Home.ToString();

            ViewBag.Module = Module.ToString();
            ViewBag.Section = Section.ToString();
            ViewBag.Action = "Index";
            ViewBag.Home = Home.ToString();
            ViewBag.Title = Title.ToString();

            var style_paths = new List<Styles_path>
            {
                new Styles_path {path = "/plugins/select2/css/select2.min.css"}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/select2/js/select2.full.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/report/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["report_types"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Report Type", 0, 0);
            ViewData["sexes"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Sex", 0, 0);
            ViewData["age_brackets"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Age Bracket", 0, 0);
            ViewData["marital_statuses"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Marital Status", 0, 0);

            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Print_ComplaintForm(int report_id)
        {
            try
            {
                Session["active_module"] = Module.ToString();
                Session["active_section"] = Section.ToString();
                Session["active_page"] = Home.ToString();

                ViewBag.Module = Module.ToString(); 
                ViewBag.Section = Section.ToString();
                ViewBag.Action = "Print Complaint Form";
                ViewBag.Home = Home.ToString();
                ViewBag.Title = Title.ToString();

                var report = Reports.GetBy_ID(report_id);
                var victim = Victims.GetBy_ReportID(report_id);
                var victim_financial_transactions = VictimFinancialTransactions.ListBy_VictimID(victim.id);
                var witness = Witnesses.GetBy_ID(report_id);
                var suspects = Suspects.ListBy_ReportID(report_id);

                ViewData["report"] = report;
                ViewData["victim"] = victim;
                ViewData["victim_financial_transactions"] = victim_financial_transactions;
                ViewData["witness"] = witness;
                ViewData["suspects"] = suspects;
                return PartialView();
            }
            catch (Exception e)
            {
                var errMessage = e.Message;
                return RedirectToAction("Index", "Auth");
            }
        }
    }
}
