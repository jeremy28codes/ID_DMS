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
    public class HomeController : Controller
    {
        public string Module = "Home";
        public string Section = "";
        public string Title = "DMS - Home";
        public string Home = "Home";

        public ActionResult Index()
        {
            if(!Convert.ToBoolean(Session["logged_on"]))
            {
                return RedirectToAction("Index","Auth");
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
                //new Scripts_path {path = "/dist/js/pages/home/dashboard.js"}
            };

            ViewData["Styles"] = style_paths;
            ViewData["Scripts"] = script_paths;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}