using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace krtrading.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Banner()
        {
            return View();
        }
        public PartialViewResult _Pagination( int TotalRecords, int PageSize)
        {
            ViewBag.TotalRecords = TotalRecords;
            ViewBag.PageSize = PageSize;

            return PartialView();
        }
    }
}