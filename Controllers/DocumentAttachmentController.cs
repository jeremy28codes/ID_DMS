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


namespace DMS.Controllers
{
    public class DocumentAttachmentController : Controller
    {
        DBM_DocumentAttachments DocumentAttachments = new DBM_DocumentAttachments();
        public string Module = "Documents";
        public string Section = "Attachments";
        public string Title = "DMS - Attachments";
        public string Home = "DocumentAttachment";

        // GET: DocumentAttachment
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentAttachment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentAttachment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentAttachment/Create
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

        // GET: DocumentAttachment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentAttachment/Edit/5
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

        //// GET: DocumentAttachment/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: DocumentAttachment/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isDeleted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                // TODO: Add delete logic here
                var document_attachments = new Document_attachments();
                document_attachments.id = id;
                document_attachments.deleted_by = Session["username"].ToString();
                document_attachments.deleted_at = DateTime.Now;


                id = DocumentAttachments.Delete(document_attachments);

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
