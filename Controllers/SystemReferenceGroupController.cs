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
    public class SystemReferenceGroupController : Controller
    {
        DBM_SystemReferenceGroups SystemReferenceGroups = new DBM_SystemReferenceGroups();
        DBM_SystemDepartments SystemDepartments = new DBM_SystemDepartments();
        DBM_SystemDivisions SystemDivisions = new DBM_SystemDivisions();
        public string Module = "General Setup";
        public string Section = "Reference Groups";
        public string Title = "DMS - Reference Groups";
        public string Home = "SystemReferenceGroup";

        // GET: SystemReferenceGroup
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
                new Scripts_path {path = "/dist/js/pages/system_reference_group/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var List = SystemReferenceGroups.ListAll();
            return View(List);
        }

        //// GET: SystemReferenceGroup/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SystemReferenceGroup/Create
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
                new Styles_path {path = "/plugins/select2/css/select2.min.css"}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/select2/js/select2.full.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_reference_group/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListAll();

            return View();
        }

        // POST: SystemReferenceGroup/Create
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
                var system_reference_groups = new System_reference_groups();
                system_reference_groups.department_id = Convert.ToInt32(collection["department_id"]);
                system_reference_groups.division_id = Convert.ToInt32(collection["division_id"]);
                system_reference_groups.code = collection["code"].ToString();
                system_reference_groups.name = collection["name"].ToString();
                system_reference_groups.description = collection["description"].ToString();
                system_reference_groups.ctr = Convert.ToInt32(collection["ctr"]);
                system_reference_groups.created_by = Session["username"].ToString();
                system_reference_groups.created_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemReferenceGroups.Insert(system_reference_groups);

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

        // GET: SystemReferenceGroup/Edit/5
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
                new Styles_path {path = "/plugins/select2/css/select2.min.css"}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/select2/js/select2.full.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_reference_group/edit.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var system_reference_group = SystemReferenceGroups.GetBy_ID(id);

            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListBy_SystemDepartmentID(system_reference_group.department_id);
            ViewData["system_reference_group"] = system_reference_group;
            return View();
        }

        // POST: SystemReferenceGroup/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["id"]);

                var system_reference_groups = new System_reference_groups();
                system_reference_groups.id = id;
                system_reference_groups.department_id = Convert.ToInt32(collection["department_id"]);
                system_reference_groups.division_id = Convert.ToInt32(collection["division_id"]);
                system_reference_groups.code = collection["code"].ToString();
                system_reference_groups.name = collection["name"].ToString();
                system_reference_groups.description = collection["description"].ToString();
                system_reference_groups.ctr = Convert.ToInt32(collection["ctr"]);
                system_reference_groups.updated_by = Session["username"].ToString();
                system_reference_groups.updated_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemReferenceGroups.Update(system_reference_groups);

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

        //// GET: SystemReferenceGroup/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: SystemReferenceGroup/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isDeleted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                // TODO: Add delete logic here
                var system_reference_groups = new System_reference_groups();
                system_reference_groups.id = id;
                system_reference_groups.deleted_by = Session["username"].ToString();
                system_reference_groups.deleted_at = DateTime.Now;


                id = SystemReferenceGroups.Delete(system_reference_groups);

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
