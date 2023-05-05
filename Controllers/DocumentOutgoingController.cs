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
    public class DocumentOutgoingController : Controller
    {
        DBM_SystemReferenceGroupValues SystemReferenceGroupValues = new DBM_SystemReferenceGroupValues();
        DBM_SystemDepartments SystemDepartments = new DBM_SystemDepartments();
        DBM_SystemDivisions SystemDivisions = new DBM_SystemDivisions();
        DBM_Documents Documents = new DBM_Documents();
        DBM_DocumentRouteLogs DocumentRouteLogs = new DBM_DocumentRouteLogs();
        DBM_DocumentAttachments DocumentAttachments = new DBM_DocumentAttachments();
        public string Module = "Documents";
        public string Section = "Outgoing";
        public string Title = "DMS - Outgoing Documents";
        public string Home = "DocumentOutgoing";

        public int rgv_action_type_id_IN = 28; // IN
        public int rgv_action_type_id_OUT = 29; // OUT
        public int rgv_action_type_id_COMPLETED = 30; // COMPLETED
        public int rgv_document_particular_id_INCOMING = 3; // INCOMING
        public int rgv_document_particular_id_OUTGOING = 4; // OUTGOING
        public int rgv_document_particular_id_COMPLETED = 5; // COMPLETED

        // GET: DocumentOutgoing
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
                new Scripts_path {path = "/dist/js/pages/document_outgoing/index.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            var List = Documents.ListAll_Outgoing();
            return View(List);
        }

        //// GET: DocumentOutgoing/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: DocumentOutgoing/Create
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
                new Scripts_path {path = "/dist/js/pages/document_outgoing/create.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListAll();
            ViewData["document_types"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Document Types", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));
            ViewData["document_statuses"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Document Statuses", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));

            return View();
        }


        // POST: DocumentOutgoing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FormCollection collection)
        {
            bool isInserted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            var reference_number = "";
            try
            {

                int document_id = 0;
                var generate_ref_num = Documents.Generate_ReferenceNumber(Convert.ToInt32(Session["system_division_id"]), rgv_action_type_id_OUT);
                reference_number = generate_ref_num.reference_number;

                // TODO: Add insert logic here
                var documents = new Documents();
                documents.reference_number = reference_number;
                documents.routing_number = collection["routing_number"].ToString();
                documents.title = collection["title"].ToString();
                documents.rgv_document_particular_id = rgv_document_particular_id_OUTGOING;
                documents.rgv_document_type_id = Convert.ToInt32(collection["rgv_document_type_id"]);
                documents.created_by = Session["username"].ToString();
                documents.created_at = DateTime.Now;
                documents.remarks = collection["document_remarks"].ToString();

                if (ModelState.IsValid)
                {
                    document_id = Documents.Insert(documents);

                    if (document_id > 0)
                    {
                        var document_reference_numbers = new Document_reference_numbers();
                        document_reference_numbers.document_id = document_id;
                        document_reference_numbers.rgv_action_type_id = rgv_action_type_id_OUT;
                        document_reference_numbers.system_department_id = Convert.ToInt32(Session["system_department_id"]);
                        document_reference_numbers.system_division_id = Convert.ToInt32(Session["system_division_id"]);
                        Documents.Insert_ReferenceNumber(document_reference_numbers);

                        var document_route_logs = new Document_route_logs();
                        document_route_logs.document_id = document_id;
                        document_route_logs.route_date = Convert.ToDateTime(collection["route_date"]).ToString("MM-dd-yyyy");
                        document_route_logs.route_time = Convert.ToDateTime(collection["route_time"]).ToString("HH:mm");
                        document_route_logs.to_system_department_id = Convert.ToInt32(collection["to_system_department_id"]);
                        document_route_logs.to_system_division_id = Convert.ToInt32(collection["to_system_division_id"]);
                        document_route_logs.to_system_unit_id = 0;
                        document_route_logs.to_name = collection["to_name"].ToString();
                        document_route_logs.from_system_department_id = Convert.ToInt32(Session["system_department_id"]);
                        document_route_logs.from_system_division_id = Convert.ToInt32(Session["system_division_id"]);
                        document_route_logs.from_system_unit_id = Convert.ToInt32(Session["system_unit_id"]);
                        document_route_logs.from_name = Session["username"].ToString();
                        document_route_logs.rgv_document_status_id = Convert.ToInt32(collection["rgv_document_status_id"]);
                        document_route_logs.rgv_action_type_id = rgv_action_type_id_OUT;
                        document_route_logs.created_by = Session["username"].ToString();
                        document_route_logs.created_at = DateTime.Now;
                        document_route_logs.remarks = collection["route_remarks"].ToString();

                        int route_log_id = DocumentRouteLogs.Insert(document_route_logs);

                        if (route_log_id > 0)
                        {
                            if (Request.Files.Count > 0)
                            {
                                Random rand = new Random();
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
                                        attachment_name = Convert.ToInt32(Session["system_department_id"]).ToString() + "/" + Convert.ToInt32(Session["system_division_id"]).ToString() + "/" + document_id.ToString() + "_" + rand.Next().ToString();
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

                                        file_type = Path.GetExtension(fname);
                                        file_size = file.ContentLength;
                                        file_name = Path.GetFileName(fname).Replace(file_type, "");

                                        // Get the complete folder path and store the file inside it.  
                                        fname = Path.Combine(Server.MapPath("~/attachments"), attachment_name + file_type);
                                        file.SaveAs(fname);

                                        document_attachments.document_id = document_id;
                                        document_attachments.document_route_log_id = route_log_id;
                                        document_attachments.file_name = file_name;
                                        document_attachments.file_type = file_type;
                                        document_attachments.file_size = file_size.ToString();
                                        document_attachments.file_path = "attachments/" + attachment_name + file_type;
                                        document_attachments.created_by = Session["username"].ToString();
                                        document_attachments.created_at = DateTime.Now;

                                        DocumentAttachments.Insert(document_attachments);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errMessage = ex.Message;
                                }
                            }

                            isInserted = true;
                            errMessage = "Successfully saved!";
                        }
                    }
                }

                var result = new { status = isInserted, message = errMessage, reference_number = reference_number, document_id = document_id };
                return Json(result, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var error = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: DocumentOutgoing/Edit/5
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
                new Scripts_path {path = "/dist/js/pages/document_outgoing/edit.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["document_types"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Document Types", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));
            var document = Documents.GetBy_ID(id);
            ViewData["document"] = document;
            ViewData["attachments"] = DocumentAttachments.ListBy_DocumentID(document.id);
            ViewData["document_route_logs_dt"] = DocumentRouteLogs.ListAll_DatesBy_DocumentID(id);

            return View();
        }

        // POST: DocumentOutgoing/Edit/5
        [HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            bool isEdited = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                int id = Convert.ToInt32(collection["id"]);

                var documents = new Documents();
                documents.id = id;
                documents.reference_number = collection["reference_number"].ToString();
                documents.routing_number = collection["routing_number"].ToString();
                documents.title = collection["title"].ToString();
                documents.rgv_document_type_id = Convert.ToInt32(collection["rgv_document_type_id"]);
                documents.rgv_document_particular_id = rgv_document_particular_id_OUTGOING;
                documents.updated_by = Session["username"].ToString();
                documents.updated_at = DateTime.Now;
                documents.remarks = collection["document_remarks"].ToString();

                if (ModelState.IsValid)
                {
                    id = Documents.Update(documents);

                    if (id > 0)
                    {

                        if (Request.Files.Count > 0)
                        {
                            Random rand = new Random();
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
                                    attachment_name = Convert.ToInt32(Session["system_department_id"]).ToString() + "/" + Convert.ToInt32(Session["system_division_id"]).ToString() + "/" + id.ToString() + "_" + rand.Next().ToString();
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

                                    file_type = Path.GetExtension(fname);
                                    file_size = file.ContentLength;
                                    file_name = Path.GetFileName(fname).Replace(file_type, "");

                                    // Get the complete folder path and store the file inside it.  
                                    fname = Path.Combine(Server.MapPath("~/attachments"), attachment_name + file_type);
                                    file.SaveAs(fname);

                                    document_attachments.document_id = id;
                                    document_attachments.document_route_log_id = 0;
                                    document_attachments.file_name = file_name;
                                    document_attachments.file_type = file_type;
                                    document_attachments.file_size = file_size.ToString();
                                    document_attachments.file_path = "attachments/" + attachment_name + file_type;
                                    document_attachments.created_by = Session["username"].ToString();
                                    document_attachments.created_at = DateTime.Now;

                                    DocumentAttachments.Insert(document_attachments);
                                }
                            }
                            catch (Exception ex)
                            {
                                errMessage = ex.Message;
                            }
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

        //// GET: DocumentOutgoing/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: DocumentOutgoing/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isDeleted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {
                // TODO: Add delete logic here
                var documents = new Documents();
                documents.id = id;
                documents.deleted_by = Session["username"].ToString();
                documents.deleted_at = DateTime.Now;


                id = Documents.Delete(documents);

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

        [HttpGet]
        public ActionResult Incoming(int id)
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
            ViewBag.Action = "Incoming";
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
                new Scripts_path {path = "/dist/js/pages/document_outgoing/incoming.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["system_departments"] = SystemDepartments.ListAll();
            ViewData["system_divisions"] = SystemDivisions.ListAll();
            ViewData["document_types"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Document Types", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));
            ViewData["document_statuses"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Document Statuses", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));
            ViewData["document"] = Documents.GetBy_ID(id);
            ViewData["document_route_logs_dt"] = DocumentRouteLogs.ListAll_DatesBy_DocumentID(id);

            return View();
        }

        [HttpPost]
        public JsonResult Incoming(FormCollection collection)
        {
            bool isInserted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {

                int document_id = Convert.ToInt32(collection["id"]);

                // TODO: Add insert logic here
                var documents = new Documents();
                documents.id = document_id;
                documents.reference_number = collection["reference_number"].ToString();
                documents.routing_number = collection["routing_number"].ToString();
                documents.title = collection["title"].ToString();
                documents.rgv_document_particular_id = rgv_document_particular_id_INCOMING;
                documents.rgv_document_type_id = Convert.ToInt32(collection["rgv_document_type_id"]);
                documents.created_by = Session["username"].ToString();
                documents.created_at = DateTime.Now;
                documents.remarks = collection["document_remarks"].ToString();

                if (ModelState.IsValid)
                {
                    document_id = Documents.Update(documents);

                    if (document_id > 0)
                    {
                        var document_route_logs = new Document_route_logs();
                        document_route_logs.document_id = document_id;
                        document_route_logs.route_date = Convert.ToDateTime(collection["route_date"]).ToString("MM-dd-yyyy");
                        document_route_logs.route_time = Convert.ToDateTime(collection["route_time"]).ToString("HH:mm");
                        document_route_logs.from_system_department_id = Convert.ToInt32(collection["from_system_department_id"]);
                        document_route_logs.from_system_division_id = Convert.ToInt32(collection["from_system_division_id"]);
                        document_route_logs.from_system_division_id = 0;
                        document_route_logs.from_name = collection["from_name"].ToString();
                        document_route_logs.to_system_department_id = Convert.ToInt32(Session["system_department_id"]);
                        document_route_logs.to_system_division_id = Convert.ToInt32(Session["system_division_id"]);
                        document_route_logs.to_system_unit_id = Convert.ToInt32(Session["system_unit_id"]);
                        document_route_logs.to_name = Session["username"].ToString();
                        document_route_logs.rgv_document_status_id = Convert.ToInt32(collection["rgv_document_status_id"]);
                        document_route_logs.rgv_action_type_id = rgv_action_type_id_IN;
                        document_route_logs.created_by = Session["username"].ToString();
                        document_route_logs.created_at = DateTime.Now;
                        document_route_logs.remarks = collection["route_remarks"].ToString();

                        int route_log_id = DocumentRouteLogs.Insert(document_route_logs);

                        if (route_log_id > 0)
                        {
                            if (Request.Files.Count > 0)
                            {
                                Random rand = new Random();
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
                                        attachment_name = Convert.ToInt32(Session["system_department_id"]).ToString() + "/" + Convert.ToInt32(Session["system_division_id"]).ToString() + "/" + document_id.ToString() + "_" + rand.Next().ToString();
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

                                        file_type = Path.GetExtension(fname);
                                        file_size = file.ContentLength;
                                        file_name = Path.GetFileName(fname).Replace(file_type, "");

                                        // Get the complete folder path and store the file inside it.  
                                        fname = Path.Combine(Server.MapPath("~/attachments"), attachment_name + file_type);
                                        file.SaveAs(fname);

                                        document_attachments.document_id = document_id;
                                        document_attachments.document_route_log_id = route_log_id;
                                        document_attachments.file_name = file_name;
                                        document_attachments.file_type = file_type;
                                        document_attachments.file_size = file_size.ToString();
                                        document_attachments.file_path = "attachments/" + attachment_name + file_type;
                                        document_attachments.created_by = Session["username"].ToString();
                                        document_attachments.created_at = DateTime.Now;

                                        DocumentAttachments.Insert(document_attachments);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errMessage = ex.Message;
                                }
                            }

                            isInserted = true;
                            errMessage = "Successfully saved!";
                        }
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

        [HttpGet]
        public ActionResult Completed(int id)
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
            ViewBag.Action = "Outgoing";
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
                new Scripts_path {path = "/dist/js/pages/document_outgoing/completed.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            ViewData["document_types"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Document Types", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));
            ViewData["document_statuses"] = SystemReferenceGroupValues.ListBy_GroupCodeDepartmentDivisionID("Document Statuses", Convert.ToInt32(Session["system_department_id"]), Convert.ToInt32(Session["system_division_id"]));
            ViewData["document"] = Documents.GetBy_ID(id);

            return View();
        }

        [HttpPost]
        public JsonResult Completed(FormCollection collection)
        {
            bool isInserted = false;
            var errMessage = "Something went wrong! Please contact technical support.";

            try
            {

                int document_id = Convert.ToInt32(collection["id"]);

                // TODO: Add insert logic here
                var documents = new Documents();
                documents.id = document_id;
                documents.reference_number = collection["reference_number"].ToString();
                documents.routing_number = collection["routing_number"].ToString();
                documents.title = collection["title"].ToString();
                documents.rgv_document_particular_id = rgv_document_particular_id_COMPLETED;
                documents.rgv_document_type_id = Convert.ToInt32(collection["rgv_document_type_id"]);
                documents.completed_at = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                documents.updated_by = Session["username"].ToString();
                documents.updated_at = DateTime.Now;
                documents.remarks = collection["document_remarks"].ToString();

                if (ModelState.IsValid)
                {
                    document_id = Documents.Update(documents);

                    if (document_id > 0)
                    {
                        var document_route_logs = new Document_route_logs();
                        document_route_logs.document_id = document_id;
                        document_route_logs.route_date = Convert.ToDateTime(collection["route_date"]).ToString("MM-dd-yyyy");
                        document_route_logs.route_time = Convert.ToDateTime(collection["route_time"]).ToString("HH:mm");
                        document_route_logs.to_system_department_id = Convert.ToInt32(Session["system_department_id"]);
                        document_route_logs.to_system_division_id = Convert.ToInt32(Session["system_division_id"]);
                        document_route_logs.to_system_unit_id = Convert.ToInt32(Session["system_unit_id"]);
                        document_route_logs.to_name = Session["username"].ToString();
                        document_route_logs.from_system_department_id = Convert.ToInt32(Session["system_department_id"]);
                        document_route_logs.from_system_division_id = Convert.ToInt32(Session["system_division_id"]);
                        document_route_logs.from_system_unit_id = Convert.ToInt32(Session["system_unit_id"]);
                        document_route_logs.from_name = Session["username"].ToString();
                        document_route_logs.rgv_document_status_id = Convert.ToInt32(collection["rgv_document_status_id"]);
                        document_route_logs.rgv_action_type_id = rgv_action_type_id_COMPLETED;
                        document_route_logs.created_by = Session["username"].ToString();
                        document_route_logs.created_at = DateTime.Now;
                        document_route_logs.remarks = collection["route_remarks"].ToString();

                        int route_log_id = DocumentRouteLogs.Insert(document_route_logs);

                        if (route_log_id > 0)
                        {
                            if (Request.Files.Count > 0)
                            {
                                Random rand = new Random();
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
                                        attachment_name = Convert.ToInt32(Session["system_department_id"]).ToString() + "/" + Convert.ToInt32(Session["system_division_id"]).ToString() + "/" + document_id.ToString() + "_" + rand.Next().ToString();
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

                                        file_type = Path.GetExtension(fname);
                                        file_size = file.ContentLength;
                                        file_name = Path.GetFileName(fname).Replace(file_type, "");

                                        // Get the complete folder path and store the file inside it.  
                                        fname = Path.Combine(Server.MapPath("~/attachments"), attachment_name + file_type);
                                        file.SaveAs(fname);

                                        document_attachments.document_id = document_id;
                                        document_attachments.document_route_log_id = route_log_id;
                                        document_attachments.file_name = file_name;
                                        document_attachments.file_type = file_type;
                                        document_attachments.file_size = file_size.ToString();
                                        document_attachments.file_path = "attachments/" + attachment_name + file_type;
                                        document_attachments.created_by = Session["username"].ToString();
                                        document_attachments.created_at = DateTime.Now;

                                        DocumentAttachments.Insert(document_attachments);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errMessage = ex.Message;
                                }
                            }

                            isInserted = true;
                            errMessage = "Successfully saved!";
                        }
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

        [HttpGet]
        public ActionResult RouteHistoryByDate(int document_id, string dateTime)
        {
            try
            {
                var document_route_history = DocumentRouteLogs.ListBy_DocumentIDAndDate(document_id, dateTime);

                return PartialView(document_route_history);
            }
            catch (Exception ex)
            {
                var exError = ex.Message;

                return PartialView(null);
            }

        }
    }
}
