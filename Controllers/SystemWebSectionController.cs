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
    public class SystemWebSectionController : Controller
    {
        DBM_SystemWebModules SystemWebModules = new DBM_SystemWebModules();
        DBM_SystemWebSections SystemWebSections = new DBM_SystemWebSections();
        DBM_SystemUserRoleSectionAccess SystemUserRoleSectionAccess = new DBM_SystemUserRoleSectionAccess();
        public string Module = "General Setup";
        public string Section = "Web Sections";
        public string Title = "DMS - Login";
        public string Home = "SystemWebSection";

        // GET: SystemWebSection
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
                new Scripts_path {path = "/dist/js/pages/system_web_section/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var List = SystemWebSections.ListAll();
            return View(List);
        }

        //// GET: SystemWebSection/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SystemWebSection/Create
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
                new Scripts_path {path = "/dist/js/pages/system_web_section/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;
            ViewData["system_web_modules"] = SystemWebModules.ListAll();

            return View();
        }

        // POST: SystemWebSection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FormCollection collection)
        {
            bool isInserted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {

                int id = 0;
                var icon = collection["icon"].ToString();

                // TODO: Add insert logic here
                var system_Web_Sections = new System_web_sections();
                system_Web_Sections.system_web_module_id = Convert.ToInt32(collection["system_web_module_id"]);
                system_Web_Sections.code = collection["code"].ToString();
                system_Web_Sections.name = collection["name"].ToString();
                system_Web_Sections.description = collection["description"].ToString();
                system_Web_Sections.link = collection["link"].ToString();
                system_Web_Sections.icon = (icon != ""? icon : "far fa-circle");
                system_Web_Sections.ctr = Convert.ToInt32(collection["ctr"]);
                system_Web_Sections.created_by = Session["username"].ToString();
                system_Web_Sections.created_at = DateTime.Now;
                system_Web_Sections.is_active = Convert.ToInt32(collection["is_active"]);

                if (ModelState.IsValid)
                { 
                    id = SystemWebSections.Insert(system_Web_Sections);

                    if (id > 0)
                    {
                        if (Convert.ToInt32(Session["role_id"]) == 1)
                        {
                            var system_user_role_section_access = new System_user_role_section_access();
                            system_user_role_section_access.system_role_id = Convert.ToInt32(Session["role_id"]);
                            system_user_role_section_access.system_web_section_id = id;
                            system_user_role_section_access.can_access = 1;
                            system_user_role_section_access.can_view = 1;
                            system_user_role_section_access.can_create = 1;
                            system_user_role_section_access.can_edit = 1;
                            system_user_role_section_access.can_delete = 1;
                            system_user_role_section_access.created_by = Session["username"].ToString();
                            system_user_role_section_access.created_at = DateTime.Now;

                            SystemUserRoleSectionAccess.Insert(system_user_role_section_access);
                        }

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

        // GET: SystemWebSection/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (!Convert.ToBoolean(Session["logged_on"]))
            {
                return RedirectToAction("Index", "Auth");
            }

            if(id <= 0)
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
                new Scripts_path {path = "/dist/js/pages/system_web_section/edit.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;
            ViewData["system_web_modules"] = SystemWebModules.ListAll();

            ViewData["system_web_section"] = SystemWebSections.GetBy_ID(id);
            return View();
        }

        // POST: SystemWebSection/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["id"]);
                var icon = collection["icon"].ToString();

                var system_Web_Sections = new System_web_sections();
                system_Web_Sections.id = id;
                system_Web_Sections.system_web_module_id = Convert.ToInt32(collection["system_web_module_id"]);
                system_Web_Sections.code = collection["code"].ToString();
                system_Web_Sections.name = collection["name"].ToString();
                system_Web_Sections.description = collection["description"].ToString();
                system_Web_Sections.link = collection["link"].ToString();
                system_Web_Sections.icon = (icon != "" ? icon : "far fa-circle");
                system_Web_Sections.ctr = Convert.ToInt32(collection["ctr"]);
                system_Web_Sections.updated_by = Session["username"].ToString();
                system_Web_Sections.updated_at = DateTime.Now;
                system_Web_Sections.is_active = Convert.ToInt32(collection["is_active"]);

                if (ModelState.IsValid)
                {
                    id = SystemWebSections.Update(system_Web_Sections);

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

        //// GET: SystemWebSection/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: SystemWebSection/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isDeleted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                // TODO: Add delete logic here
                var system_Web_Modules = new System_web_modules();
                system_Web_Modules.id = id;
                system_Web_Modules.deleted_by = Session["username"].ToString();
                system_Web_Modules.deleted_at = DateTime.Now;


                id = SystemWebModules.Delete(system_Web_Modules);

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

        [HttpPost]
        public JsonResult ListByModuleRoleIDNotExists(int system_role_id, int system_web_module_id = 0)
        {
            try
            {
                // TODO: Add delete logic here
                var result = SystemWebSections.ListAll_NotExistsRole(system_role_id, system_web_module_id);
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                var errMessage = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
