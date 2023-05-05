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
    public class SystemReferenceCityController : Controller
    {
        DBM_SystemReferenceCities SystemReferenceCities = new DBM_SystemReferenceCities();
        public string Module = "Default";
        public string Section = "Index";
        public string Title = "File A Complaint";
        public string Home = "Default";
        // GET: SystemReferenceCity
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemReferenceCity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemReferenceCity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemReferenceCity/Create
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

        // GET: SystemReferenceCity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemReferenceCity/Edit/5
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

        // GET: SystemReferenceCity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemReferenceCity/Delete/5
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
        public JsonResult ListBy_RegionIDProvinceID(int reference_region_id, int reference_province_id)
        {

            try
            {
                // TODO: Add delete logic here
                var result = SystemReferenceCities.ListBy_RegionIDProvinceID(reference_region_id, reference_province_id);
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
