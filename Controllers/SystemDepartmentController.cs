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
    public class SystemDepartmentController : Controller
    {
        DBM_SystemDepartments SystemDepartments = new DBM_SystemDepartments();
        public string Module = "General Setup";
        public string Section = "Departments";
        public string Title = "DMS - Login";
        public string Home = "SystemDepartment";

        // GET: SystemDepartment
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
                new Scripts_path {path = "/dist/js/pages/system_department/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var List = SystemDepartments.ListAll();
            return View(List);
        }

        //// GET: SystemDepartment/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SystemDepartment/Create
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
            ViewBag.Action = "Create";
            ViewBag.Home = Home.ToString();
            ViewBag.Title = Title.ToString();


            var style_paths = new List<Styles_path>
            {
                new Styles_path {}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_department/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            return View();
        }

        // POST: SystemDepartment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FormCollection collection)
        {
            bool isInserted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {

                int id = 0;

                // TODO: Add insert logic here
                var system_departments = new System_departments();
                system_departments.code = collection["code"].ToString();
                system_departments.name = collection["name"].ToString();
                system_departments.description = collection["description"].ToString();
                system_departments.ctr = Convert.ToInt32(collection["ctr"]);
                system_departments.created_by = Session["username"].ToString();
                system_departments.created_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemDepartments.Insert(system_departments);

                    if (id > 0)
                    {
                        isInserted = true;
                        errMessage = "Successfully saved!";
                    }
                }

                var result = new { status = isInserted, message = errMessage };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var error = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: SystemDepartment/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
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
            ViewBag.Action = "Edit";
            ViewBag.Home = Home.ToString();
            ViewBag.Title = Title.ToString();

            var style_paths = new List<Styles_path>
            {
                new Styles_path {}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_department/edit.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["system_department"] = SystemDepartments.GetBy_ID(id);
            return View();
        }

        // POST: SystemDepartment/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["id"]);

                var system_departments = new System_departments();
                system_departments.id = id;
                system_departments.code = collection["code"].ToString();
                system_departments.name = collection["name"].ToString();
                system_departments.description = collection["description"].ToString();
                system_departments.ctr = Convert.ToInt32(collection["ctr"]);
                system_departments.updated_by = Session["username"].ToString();
                system_departments.updated_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemDepartments.Update(system_departments);

                    if (id > 0)
                    {
                        isEdited = true;
                        errMessage = "Successfully saved!";
                    }
                }

                var result = new { status = isEdited, message = errMessage };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                errMessage = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //// GET: SystemDepartment/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: SystemDepartment/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isDeleted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                // TODO: Add delete logic here
                var system_departments = new System_departments();
                system_departments.id = id;
                system_departments.deleted_by = Session["username"].ToString();
                system_departments.deleted_at = DateTime.Now;


                id = SystemDepartments.Delete(system_departments);

                if (id > 0)
                {
                    isDeleted = true;
                    errMessage = "Successfully deleted!";
                }

                var result = new { status = isDeleted, message = errMessage };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                errMessage = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
