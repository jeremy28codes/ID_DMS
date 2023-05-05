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
    public class SystemRoleController : Controller
    {
        DBM_SystemDepartments SystemDepartments = new DBM_SystemDepartments();
        DBM_SystemRoles SystemRoles = new DBM_SystemRoles();
        DBM_SystemUserRoleModuleAccess SystemUserRoleModuleAccess = new DBM_SystemUserRoleModuleAccess();
        DBM_SystemUserRoleSectionAccess SystemUserRoleSectionAccess = new DBM_SystemUserRoleSectionAccess();
        DBM_SystemWebModules SystemWebModules = new DBM_SystemWebModules();
        DBM_SystemWebSections SystemWebSections = new DBM_SystemWebSections();
        public string Module = "System Users";
        public string Section = "Roles";
        public string Title = "DMS - System Roles";
        public string Home = "SystemRole";

        // GET: SystemRole
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
                new Scripts_path {path = "/dist/js/pages/system_role/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var List = SystemRoles.ListAll();
            return View(List);
        }

        //// GET: SystemRole/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SystemRole/Create
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
                new Scripts_path {path = "/dist/js/pages/system_role/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            return View();
        }

        // POST: SystemRole/Create
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
                var system_roles = new System_roles();
                system_roles.code = collection["code"].ToString();
                system_roles.name = collection["name"].ToString();
                system_roles.description = collection["description"].ToString();
                system_roles.created_by = Session["username"].ToString();
                system_roles.created_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemRoles.Insert(system_roles);

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

        // GET: SystemRole/Edit/5
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
                new Styles_path {path = "/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"},
                new Styles_path {path = "/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"},
                new Styles_path {path = "/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"},
                new Styles_path {path = "/plugins/select2/css/select2.min.css"}
            };

            var script_paths = new List<Scripts_path>
            {
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
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
                new Scripts_path {path = "/plugins/select2/js/select2.full.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_role/edit.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var system_role = SystemRoles.GetBy_ID(id);

            ViewData["system_role"] = system_role;
            ViewData["ma_system_web_modules_not_exists"] = SystemWebModules.ListAll_NotExistsRole(system_role.id);
            ViewData["ma_system_web_modules_exists"] = SystemUserRoleModuleAccess.ListAll_SystemRoleID(system_role.id);

            ViewData["sa_system_web_modules_not_exists"] = SystemWebModules.ListBy_ModuleRoleIDNotExists(system_role.id,0);
            ViewData["sa_system_web_sections_not_exists"] = SystemWebSections.ListAll_NotExistsRole(system_role.id,0);
            ViewData["sa_system_web_sections_exists"] = SystemUserRoleSectionAccess.ListAll_SystemRoleID(system_role.id); 
            return View();
        }

        // POST: SystemRole/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["id"]);

                var system_roles = new System_roles();
                system_roles.id = id;
                system_roles.code = collection["code"].ToString();
                system_roles.name = collection["name"].ToString();
                system_roles.description = collection["description"].ToString();
                system_roles.updated_by = Session["username"].ToString();
                system_roles.updated_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemRoles.Update(system_roles);

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

        // GET: SystemRole/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: SystemRole/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isDeleted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                // TODO: Add delete logic here
                var system_roles = new System_roles();
                system_roles.id = id;
                system_roles.deleted_by = Session["username"].ToString();
                system_roles.deleted_at = DateTime.Now;


                id = SystemRoles.Delete(system_roles);

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
        public JsonResult AddModuleRole(FormCollection collection)
        {
            bool isInserted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            int id = 0;
            var system_role_id = Convert.ToInt32(collection["ma_id"]);

            try
            {
                // TODO: Add delete logic here
                var system_user_role_module_access = new System_user_role_module_access();
                system_user_role_module_access.system_role_id = system_role_id;
                system_user_role_module_access.system_web_module_id = Convert.ToInt32(collection["ma_system_web_module_id"]);
                system_user_role_module_access.can_access = Convert.ToInt32(collection["ma_can_access"]);
                system_user_role_module_access.can_view = Convert.ToInt32(collection["ma_can_view"]);
                system_user_role_module_access.can_create = Convert.ToInt32(collection["ma_can_create"]);
                system_user_role_module_access.can_edit = Convert.ToInt32(collection["ma_can_edit"]);
                system_user_role_module_access.can_delete = Convert.ToInt32(collection["ma_can_delete"]);
                system_user_role_module_access.created_by = Session["username"].ToString();
                system_user_role_module_access.created_at = DateTime.Now;


                id = SystemUserRoleModuleAccess.Insert(system_user_role_module_access);

                if (id > 0)
                {
                    isInserted = true;
                    errMessage = "Successfully Added!";
                }

                var result = new { status = isInserted, message = errMessage };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                errMessage = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult AddSectionRole(FormCollection collection)
        {
            bool isInserted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            int id = 0;
            var system_role_id = Convert.ToInt32(collection["sa_id"]);

            try
            {
                // TODO: Add delete logic here
                var system_user_role_section_access = new System_user_role_section_access();
                system_user_role_section_access.system_role_id = system_role_id;
                system_user_role_section_access.system_web_module_id = Convert.ToInt32(collection["sa_system_web_module_id"]);
                system_user_role_section_access.system_web_section_id = Convert.ToInt32(collection["sa_system_web_section_id"]);
                system_user_role_section_access.can_access = Convert.ToInt32(collection["sa_can_access"]);
                system_user_role_section_access.can_view = Convert.ToInt32(collection["sa_can_view"]);
                system_user_role_section_access.can_create = Convert.ToInt32(collection["sa_can_create"]);
                system_user_role_section_access.can_edit = Convert.ToInt32(collection["sa_can_edit"]);
                system_user_role_section_access.can_delete = Convert.ToInt32(collection["sa_can_delete"]);
                system_user_role_section_access.created_by = Session["username"].ToString();
                system_user_role_section_access.created_at = DateTime.Now;


                id = SystemUserRoleSectionAccess.Insert(system_user_role_section_access);

                if (id > 0)
                {
                    isInserted = true;
                    errMessage = "Successfully Added!";
                }

                var result = new { status = isInserted, message = errMessage };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                errMessage = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult UpdateSectionTable(int system_role_id = 0, int system_web_module_id = 0)
        {
            try
            {
                // TODO: Add delete logic here
                var result = SystemUserRoleSectionAccess.ListBy_RoleID(system_role_id, system_web_module_id);
                //return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
                return PartialView(result);

            }
            catch (Exception e)
            {
                var errMessage = e.Message;
                return PartialView();
            }
        }

        [HttpGet]
        public PartialViewResult UpdateModuleTable(int system_role_id = 0)
        {
            try
            {
                // TODO: Add delete logic here
                var result = SystemUserRoleModuleAccess.ListAll_SystemRoleID(system_role_id);
                //return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
                return PartialView(result);

            }
            catch (Exception e)
            {
                var errMessage = e.Message;
                return PartialView();
            }
        }
    }
}
