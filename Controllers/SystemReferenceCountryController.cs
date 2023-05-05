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
    public class SystemReferenceCountryController : Controller
    {
        DBM_SystemReferenceCountries SystemReferenceCountries = new DBM_SystemReferenceCountries();

        // GET: SystemReferenceCountry
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemReferenceCountry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemReferenceCountry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemReferenceCountry/Create
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

        // GET: SystemReferenceCountry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemReferenceCountry/Edit/5
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

        // GET: SystemReferenceCountry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemReferenceCountry/Delete/5
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
                var result = SystemReferenceCountries.ListAll();
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
