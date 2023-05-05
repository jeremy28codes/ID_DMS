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
    public class SystemReferenceProvinceController : Controller
    {
        DBM_SystemReferenceProvinces SystemReferenceProvinces = new DBM_SystemReferenceProvinces();

        // GET: SystemReferenceProvince
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemReferenceProvince/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemReferenceProvince/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemReferenceProvince/Create
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

        // GET: SystemReferenceProvince/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemReferenceProvince/Edit/5
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

        // GET: SystemReferenceProvince/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemReferenceProvince/Delete/5
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
        public JsonResult List_All()
        {
            try
            {
                // TODO: Add delete logic here
                var result = SystemReferenceProvinces.ListAll();
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
