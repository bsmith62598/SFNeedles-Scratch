using NeedlesAndScratch.UI.Secured.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeedlesAndScratch.UI.Secured.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Throw404()
        {
            return HttpNotFound();
        }

        public ActionResult Unresolved()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        
        public ActionResult DBOffline()
        {
            return View();
        }
    }
}