using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.DBManagement;
using DMS.Models;
using DMS.ViewModels;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace DMS.Controllers
{
    public class SystemUserController : Controller
    {
        DBM_SystemReferenceGroupValues SystemReferenceGroupValues = new DBM_SystemReferenceGroupValues();
        DBM_SystemDepartments SystemDepartments = new DBM_SystemDepartments();
        DBM_SystemDivisions SystemDivisions = new DBM_SystemDivisions();
        DBM_SystemUnits SystemUnits = new DBM_SystemUnits();
        DBM_SystemUsers SystemUsers = new DBM_SystemUsers();
        DBM_SystemRoles SystemRoles = new DBM_SystemRoles();
        DBM_SystemUserRoles SystemUserRoles = new DBM_SystemUserRoles();
        public string Module = "System Users";
        public string Section = "List";
        public string Title = "DMS - Users";
        public string Home = "SystemUser";

        // GET: SystemUser
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
                new Styles_path {path = "/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"},
                new Styles_path {path = "/plugins/select2/css/select2.min.css"}
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
                new Scripts_path {path = "/plugins/select2/js/select2.full.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_user/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListAll();

            var List = SystemUsers.ListAll();
            return View(List);
        }

        // GET: SystemUser/Details/5
        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            if (!Convert.ToBoolean(Session["logged_on"]))
            {
                return RedirectToAction("Index", "Auth");
            }

            Session["active_module"] = "";
            Session["active_section"] = "";
            Session["active_page"] = "";


            ViewBag.Module = "";
            ViewBag.Section = "";
            ViewBag.Action = "Details";
            ViewBag.Home = "#";
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
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_user/details.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;
            var system_user_data = SystemUsers.GetBy_ID(id);
            ViewData["system_user_data"] = system_user_data;
            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListBy_SystemDepartmentID(system_user_data.department_id);
            ViewData["system_units"] = SystemUnits.ListBy_SystemDepartmentDivisionID(system_user_data.department_id, system_user_data.division_id);

            ViewData["system_roles"] = SystemRoles.ListAll();
            ViewData["system_user_role"] = SystemUserRoles.GetBy_UserID(system_user_data.id);
            ViewData["sex"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Sex", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));


            return View();
        }

        // GET: SystemUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemUser/Create
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

        // GET: SystemUser/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
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
                new Scripts_path {path = "/plugins/jquery-validation/jquery.validate.min.js"},
                new Scripts_path {path = "/plugins/jquery-validation/additional-methods.min.js"},
                new Scripts_path {path = "/dist/js/pages/system_user/edit.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;
            var system_user_data = SystemUsers.GetBy_ID(id);
            ViewData["system_user_data"] = system_user_data;
            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListBy_SystemDepartmentID(system_user_data.department_id);
            ViewData["system_units"] = SystemUnits.ListBy_SystemDepartmentDivisionID(system_user_data.department_id, system_user_data.division_id);

            ViewData["system_roles"] = SystemRoles.ListAll();
            ViewData["system_user_role"] = SystemUserRoles.GetBy_UserID(system_user_data.id);
            ViewData["sex"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Sex", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));


            return View();
        }

        // POST: SystemUser/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["id"]);
                int system_role_id = Convert.ToInt32(collection["system_role_id"]);
                var sys_role = SystemUserRoles.GetBy_UserID(id);

                var system_users = new System_users();
                system_users.id = id;
                system_users.reference_number = collection["reference_number"].ToString();
                system_users.prefix = collection["prefix"].ToString();
                system_users.first_name = collection["first_name"].ToString();
                system_users.middle_name = collection["middle_name"].ToString();
                system_users.last_name = collection["last_name"].ToString();
                system_users.suffix = collection["suffix"].ToString();
                system_users.rgv_sex_id = Convert.ToInt32(collection["rgv_sex_id"]);
                system_users.about = collection["about"].ToString();
                system_users.department_id = Convert.ToInt32(collection["system_department_id"]);
                system_users.division_id = Convert.ToInt32(collection["system_division_id"]);
                system_users.unit_id = Convert.ToInt32(collection["system_unit_id"]);
                system_users.job_title = collection["job_title"].ToString();
                system_users.updated_by = Session["username"].ToString();
                system_users.updated_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemUsers.Update_Profile(system_users);

                    if (id > 0)
                    {
                        if (Request.Files.Count > 0)
                        {
                            var file_type = "";
                            var file_name = "";
                            long file_size = 0;
                            var attachment_name = "";
                            var document_attachments = new Document_attachments();
                            try
                            {
                                //  Get all files from Request object  
                                HttpFileCollectionBase files = Request.Files;
                                for (int i = 0; i < (files.Count / 2); i++)
                                {
                                    var middle_name = (collection["middle_name"].ToString() == "" ? "" : collection["middle_name"].ToString().Substring(0, 1).ToLower());
                                    attachment_name = collection["first_name"].ToString().Substring(0, 1).ToLower() + middle_name + collection["last_name"].ToString().Replace(".", "").Replace(",", "").Replace(" ", "").Trim().ToLower();
                                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                                    HttpPostedFileBase file = files[i];
                                    string fname = "";

                                    // Checking for Internet Explorer  
                                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                    {
                                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                        fname = testfiles[testfiles.Length - 1];
                                    }
                                    else
                                    {
                                        fname = file.FileName;
                                    }

                                    var old_pic_path = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~/") + "/" +collection["pic_img_path"].ToString();
                                    if (Directory.Exists(Path.GetDirectoryName(old_pic_path)))
                                    {
                                        System.IO.File.Delete(old_pic_path);
                                    }

                                    file_type = Path.GetExtension(fname);
                                    file_size = file.ContentLength;
                                    file_name = Path.GetFileName(fname).Replace(file_type, "");

                                    // Get the complete folder path and store the file inside it.  
                                    fname = Path.Combine(Server.MapPath("~/dist/img/user_pics/"), attachment_name + file_type);
                                    file.SaveAs(fname);

                                    system_users.pic_img_path = "dist/img/user_pics/" + attachment_name + file_type;
                                    SystemUsers.Update_Photo(system_users);
                                }
                            }
                            catch (Exception ex)
                            {
                                errMessage = ex.Message;
                            }
                        }

                        if(system_role_id > 0)
                        {
                            var system_user_roles = new System_user_roles();
                            system_user_roles.id = sys_role.id;
                            system_user_roles.user_id = id;
                            system_user_roles.role_id = system_role_id;
                            system_user_roles.updated_by = Session["username"].ToString();
                            system_user_roles.updated_at = DateTime.Now; 

                            SystemUserRoles.Update(system_user_roles);

                        }

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

        // GET: SystemUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemUser/Delete/5
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
        public JsonResult UpdatePassword(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["user_id"]);
                var new_password = (collection["new_password"].ToString() == null ? "" : collection["new_password"].ToString());

                var password = (new_password == "" ? collection["password"].ToString() : new_password);
                var system_users = new System_users();
                system_users.id = id;
                system_users.username = collection["username"].ToString();
                system_users.password = password;
                system_users.updated_by = Session["username"].ToString();
                system_users.updated_at = DateTime.Now;

                if (ModelState.IsValid)
                {
                    id = SystemUsers.Update_UsernamePassword(system_users);

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

        //[HttpGet]
        //public PartialViewResult UpdateTableList(int system_department_id = 0, int system_division_id = 0)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        var result = SystemUsers.ListBy_DepartmentDivisionID(system_department_id, system_division_id);
        //        //return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
        //        return PartialView(result);

        //    }
        //    catch (Exception e)
        //    {
        //        var errMessage = e.Message;
        //        return PartialView();
        //    }
        //}
        [HttpGet]
        public ActionResult UpdateTableList(int system_department_id = 0, int system_division_id = 0)   
        {

            try
            {
                var result = SystemUsers.ListBy_DepartmentDivisionID(system_department_id, system_division_id);
                return Json(new { data = result }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                var errMessage = e.Message;
                return View();
            }

            
        }
    }
}
