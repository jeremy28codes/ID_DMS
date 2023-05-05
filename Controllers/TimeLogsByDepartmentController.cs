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
    public class TimeLogsByDepartmentController : Controller
    {

        DBM_SystemReferenceGroupValues SystemReferenceGroupValues = new DBM_SystemReferenceGroupValues();
        DBM_SystemDepartments SystemDepartments = new DBM_SystemDepartments();
        DBM_SystemDivisions SystemDivisions = new DBM_SystemDivisions();
        DBM_SystemUsers SystemUsers = new DBM_SystemUsers();
        public string Module = "Time Logs";
        public string Section = "Print By Department";
        public string Title = "DMS - Print Logs by Department";
        public string Home = "PrintLogsByDepartment";

        // GET: PrintLogsByDepartment
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
                new Scripts_path {path = "/dist/js/pages/time_logs_by_department/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListAll();
            return View();

        }

        // GET: PrintLogsByDepartment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrintLogsByDepartment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrintLogsByDepartment/Create
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

        // GET: PrintLogsByDepartment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrintLogsByDepartment/Edit/5
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

        // GET: PrintLogsByDepartment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrintLogsByDepartment/Delete/5
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

        [HttpPost]
        public ActionResult Print(FormCollection collection)
        {
            try
            {
                int system_department_id = Convert.ToInt32(collection["system_department_id"]);
                int system_division_id = Convert.ToInt32(collection["system_division_id"]);
                var date_from = collection["date_from"].ToString();
                var date_to = collection["date_to"].ToString();

                var sys_users = SystemUsers.ListBy_DepartmentDivisionID(system_department_id, system_division_id);
                ViewData["sys_users"] = sys_users;

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
