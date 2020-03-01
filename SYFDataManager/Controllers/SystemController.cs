using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SYFDataManager.Controllers
{
    public class SystemController : Controller
    {
        // GET: System/Version
        public ActionResult Version()
        {
            return Content(JsonConvert.SerializeObject("0.1.2020.03.01"));
        }

    }
}
