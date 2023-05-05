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
    public class AuthController : Controller
    {
        DBM_SystemUsers SystemUsers = new DBM_SystemUsers();
        DBM_SystemUserRoleModuleAccess SystemUserRoleModuleAccess = new DBM_SystemUserRoleModuleAccess();
        DBM_SystemUserRoleSectionAccess SystemUserRoleSectionAccess = new DBM_SystemUserRoleSectionAccess();
        DBM_SystemUserRoles SystemUserRoles = new DBM_SystemUserRoles();
        public string Module = "Auth";
        public string Section = "";
        public string Title = "DMS - Login";
        public string Home = "Auth";
        // GET: Auth
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["logged_on"]))
            {
                return RedirectToAction("Index", Session["active_page"].ToString());
            }

            ViewBag.Module = Module.ToString();
            ViewBag.Section = Section.ToString();
            ViewBag.Action = "Login";
            ViewBag.Home = Home.ToString();
            ViewBag.Title = Title.ToString();


            return PartialView();
        }

        [HttpPost]
        public JsonResult Login(FormCollection collection)
        {
            bool isSuccess = false;
            var sMessage = "Incorrect Credentials! Please try again.";
            int user_id = 0;

            try
            {
                string username = collection["username"].ToString();
                string password = collection["password"].ToString();
                if (ModelState.IsValid)
                {
                    var sys_user = SystemUsers.GetBy_Username_Password(username, password);
                    var sys_role = SystemUserRoles.GetBy_UserID(sys_user.id);

                    user_id = Convert.ToInt32(sys_user.id);

                    if (user_id > 0 && sys_role.role_id > 0)
                    {
                        Session["logged_on"] = true;
                        Session["user_id"] = user_id;
                        Session["username"] = sys_user.username.ToString();
                        Session["role_id"] = Convert.ToInt32(sys_role.role_id);
                        Session["system_department_id"] = Convert.ToInt32(sys_user.department_id);
                        Session["system_division_id"] = Convert.ToInt32(sys_user.division_id);
                        Session["system_unit_id"] = Convert.ToInt32(sys_user.unit_id);
                        Session["first_name"] = sys_user.first_name.ToString();
                        Session["last_name"] = sys_user.last_name.ToString();
                        Session["pic_img_path"] = sys_user.pic_img_path.ToString();
                        Session["active_module"] = "Home";
                        Session["active_section"] = "";
                        Session["active_page"] = "Home";

                        isSuccess = true;
                        sMessage = "Login successful!";
                    }
                }

                var result = new { status = isSuccess, message = sMessage, user_id = user_id };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                var exError = ex.Message;
                var result = new { status = isSuccess, message = sMessage, user_id = user_id };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["logged_on"] = null;
            Session["user_id"] = null;
            Session["username"] = null;
            Session["role_id"] = null;
            Session["system_department_id"] = null;
            Session["system_division_id"] = null;
            Session["system_unit_id"] = null;
            Session["first_name"] = null;
            Session["last_name"] = null;
            Session["pic_img_path"] = null;
            Session["active_module"] = null;
            Session["active_section"] = null;
            Session["active_page"] = null;

            return RedirectToAction("Index", "Auth");
        }

        [HttpGet]
        public ActionResult ShowModules()
        {
            try
            {
                var sys_role = SystemUserRoles.GetBy_UserID(Convert.ToInt32(Session["user_id"]));
                var sys_user_role_module_access = SystemUserRoleModuleAccess.ListBy_SystemRoleID(Convert.ToInt32(Session["role_id"]));

                return PartialView(sys_user_role_module_access);
            }
            catch (Exception ex)
            {
                var exError = ex.Message;
                return RedirectToAction("Logout");
            }

        }

        [HttpGet]
        public ActionResult ShowSections(int web_module_id)
        {
            try
            {
                var sys_role = SystemUserRoles.GetBy_UserID(Convert.ToInt32(Session["user_id"]));
                var sys_user_role_section_access = SystemUserRoleSectionAccess.ListBy_SystemRoleID_And_SystemWebModuleID(Convert.ToInt32(Session["role_id"]), web_module_id);

                return PartialView(sys_user_role_section_access);
            }
            catch (Exception ex)
            {
                var exError = ex.Message;
                return RedirectToAction("Logout");
            }
        }
    }
}