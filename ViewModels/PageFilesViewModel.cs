using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DMS.Models;

namespace DMS.ViewModels
{
    public class PageFilesViewModel
    {
        public List<Styles_path> Styles { get; set; }
        public List<Scripts_path> Scripts { get; set; }
    }
}