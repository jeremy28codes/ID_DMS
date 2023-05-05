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
    public class SystemWebModuleController : Controller
    {
        DBM_SystemWebModules SystemWebModules = new DBM_SystemWebModules();
        DBM_SystemUserRoleModuleAccess SystemUserRoleModuleAccess = new DBM_SystemUserRoleModuleAccess();
        public string Module = "General Setup";
        public string Section = "Web Modules";
        public string Title = "DMS - Login";
        public string Home = "SystemWebModule";

        // GET: SystemWebModule
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
                new Scripts_path {path = "/dist/js/pages/system_web_module/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var List = SystemWebModules.ListAll();
            return View(List);
        }

        //// GET: SystemWebModule/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SystemWebModule/Create
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
                new Scripts_path {path = "/dist/js/pages/system_web_module/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            return View();
        }

        // POST: SystemWebModule/Create
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
                var system_Web_Modules = new System_web_modules();
                system_Web_Modules.code = collection["code"].ToString();
                system_Web_Modules.name = collection["name"].ToString();
                system_Web_Modules.description = collection["description"].ToString();
                system_Web_Modules.link = collection["link"].ToString();
                system_Web_Modules.icon = collection["icon"].ToString();
                system_Web_Modules.ctr = Convert.ToInt32(collection["ctr"]);
                system_Web_Modules.created_by = Session["username"].ToString();
                system_Web_Modules.created_at = DateTime.Now;
                system_Web_Modules.is_active = Convert.ToInt32(collection["is_active"]);

                if (ModelState.IsValid)
                {
                    id = SystemWebModules.Insert(system_Web_Modules);

                    if (id > 0)
                    {
                        if(Convert.ToInt32(Session["role_id"]) == 1)
                        {
                            var system_user_role_module_access = new System_user_role_module_access();
                            system_user_role_module_access.system_role_id = Convert.ToInt32(Session["role_id"]);
                            system_user_role_module_access.system_web_module_id = id;
                            system_user_role_module_access.can_access = 1;
                            system_user_role_module_access.can_view = 1;
                            system_user_role_module_access.can_create = 1;
                            system_user_role_module_access.can_edit = 1;
                            system_user_role_module_access.can_delete = 1;
                            system_user_role_module_access.created_by = Session["username"].ToString();
                            system_user_role_module_access.created_at = DateTime.Now;

                            SystemUserRoleModuleAccess.Insert(system_user_role_module_access);
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

        // GET: SystemWebModule/Edit/5
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
                new Scripts_path {path = "/dist/js/pages/system_web_module/edit.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["system_web_module"] = SystemWebModules.GetBy_ID(id);
            return View();
        }

        // POST: SystemWebModule/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["id"]);

                var system_Web_Modules = new System_web_modules();
                system_Web_Modules.id = id;
                system_Web_Modules.code = collection["code"].ToString();
                system_Web_Modules.name = collection["name"].ToString();
                system_Web_Modules.description = collection["description"].ToString();
                system_Web_Modules.link = collection["link"].ToString();
                system_Web_Modules.icon = collection["icon"].ToString();
                system_Web_Modules.ctr = Convert.ToInt32(collection["ctr"]);
                system_Web_Modules.updated_by = Session["username"].ToString();
                system_Web_Modules.updated_at = DateTime.Now;
                system_Web_Modules.is_active = Convert.ToInt32(collection["is_active"]);

                if (ModelState.IsValid)
                {
                    id = SystemWebModules.Update(system_Web_Modules);

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

        //// GET: SystemWebModule/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: SystemWebModule/Delete/5
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
    }
}
