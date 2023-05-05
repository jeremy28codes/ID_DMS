using DMS.DBManagement;
using DMS.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DMS.Controllers
{
    public class TimeLogsIndividualController : Controller
    {
        DBM_SystemReferenceGroupValues SystemReferenceGroupValues = new DBM_SystemReferenceGroupValues();
        DBM_SystemDepartments SystemDepartments = new DBM_SystemDepartments();
        DBM_SystemDivisions SystemDivisions = new DBM_SystemDivisions();
        DBM_SystemUsers SystemUsers = new DBM_SystemUsers();
        DBM_SystemUserTimeLogs SystemUserTimeLogs = new DBM_SystemUserTimeLogs();
        public string Module = "Time Logs";
        public string Section = "Print Individual";
        public string Title = "DMS - Print Individual";
        public string Home = "TimeLogsIndividual";

        // GET: TimeLogsIndividual
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
                new Styles_path {path = "/plugins/select2/css/select2.min.css"}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/select2/js/select2.full.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/time_logs_individual/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["sys_users"] = SystemUsers.ListAll();
            return View();
        }

        // GET: TimeLogsIndividual/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeLogsIndividual/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeLogsIndividual/Create
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

        // GET: TimeLogsIndividual/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeLogsIndividual/Edit/5
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

        // GET: TimeLogsIndividual/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeLogsIndividual/Delete/5
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
        public ActionResult PrintReport(int system_user_id, string date_from, string date_to)
        {
            try
            {
                //int system_user_id = Convert.ToInt32(collection["system_user_id"]);
                //var date_from = collection["date_from"].ToString();
                //var date_to = collection["date_to"].ToString();

                //var sys_users = SystemUsers.ListBy_DepartmentDivisionID(system_department_id, system_division_id);
                //ViewData["sys_users"] = sys_users;

                return PartialView();
            }
            catch (Exception e)
            {
                var errMessage = e.Message;
                return PartialView();
            }
        }

        [HttpPost]
        public ActionResult Print(FormCollection collection)
        {
            try
            {
                Session["active_module"] = Module.ToString();
                Session["active_section"] = Section.ToString();
                Session["active_page"] = Home.ToString();

                ViewBag.Module = Module.ToString();
                ViewBag.Section = Section.ToString();
                ViewBag.Action = "Print";
                ViewBag.Home = Home.ToString();
                ViewBag.Title = Title.ToString();

                int system_user_id = Convert.ToInt32(collection["system_user_id"]);
                var date_from = collection["date_from"].ToString();
                var date_to = collection["date_to"].ToString();
                var in_charge = collection["in_charge"].ToString();

                var month = Convert.ToDateTime(date_from).ToString("MMMM dd");
                var day_to = Convert.ToDateTime(date_to).ToString("dd");
                var year = Convert.ToDateTime(date_from).ToString("yyyy");

                //string fullMonthName = new DateTime(month:(), i, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

                var sys_user_data = SystemUsers.GetBy_ID(system_user_id);
                ViewData["sys_user_data"] = sys_user_data;
                ViewData["dtr_range"] = month + "-" + day_to + ", " + year;
                ViewData["time_logs"] = SystemUserTimeLogs.PrintBy_Employee(sys_user_data.id, date_from, date_to);
                ViewData["in_charge"] = in_charge;

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
