using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using krtrading.AdminModel;
using krtrading.BL;

namespace krtrading.Controllers
{
    public class AdminController : Controller
    {
        AdminBl objBl = new AdminBl();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Banner()
        {
            try
            {
                BannerData obj = new BannerData();
                obj = objBl.BannerData();
                return View(obj);
            }
            catch(Exception exp)
            {
                return View();
            }
        }
        public PartialViewResult _Pagination( int TotalRecords, int PageSize)
        {
            ViewBag.TotalRecords = TotalRecords;
            ViewBag.PageSize = PageSize;

            return PartialView();
        }
    }
}