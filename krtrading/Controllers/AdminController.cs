using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using krtrading.AdminModel;
using krtrading.BL;
using System.IO;
using krtrading.AccountModel;

namespace krtrading.Controllers
{
    public class AdminController : Controller
    {
        Encript enc = new Encript();
        AdminBl objAdminBl = new AdminBl();
        CommonBL objBL = new CommonBL();
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
                obj = objAdminBl.BannerData();
                return View(obj);
            }
            catch(Exception exp)
            {
                objBL.CaptureError("Banner Get", "Admin", Convert.ToString(exp));
                return View("Error");
            }
        }
        public ActionResult _AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult _AddBanner(HttpPostedFileBase[] image)
        {
            try
            {
                foreach(var img in image)
                {
                    string FilePath = "/Upload/Banner/";
                    //if (!Directory.Exists(Server.MapPath(FilePath)))
                    //{
                    //    Directory.CreateDirectory(Server.MapPath(FilePath));
                    //}
                    string path = "";
                    string FileNameF = Guid.NewGuid() + img.FileName;
                    path = Server.MapPath(FilePath + FileNameF);
                    img.SaveAs(path);
                    objAdminBl.AddBanner(FilePath + FileNameF);
                }
                TempData["ErorrMessage"] = "Insert";
                return RedirectToAction("Banner");
            }
            catch (Exception exp)
            {
                objBL.CaptureError("_AddBanner Post", "Admin", Convert.ToString(exp));
                return View("Error");
            }
        }
        public ActionResult DeleteBanner(string q)
        {
            try
            {
                int id = Convert.ToInt32(enc.Decrypt(q));
                objAdminBl.DeleteUpDownBanner(id,"Delete");
                TempData["ErorrMessage"] = "FalseDelete";
                return RedirectToAction("Banner");
            }
            catch (Exception exp)
            {
                objBL.CaptureError("DeleteBanner", "Admin", Convert.ToString(exp));
                return View("Error");
            }
        }
        public ActionResult UpDownBanner(string q,string ActionUpDown)
        {
            try
            {
                int id = Convert.ToInt32(enc.Decrypt(q));
                objAdminBl.DeleteUpDownBanner(id, ActionUpDown);
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exp)
            {
                objBL.CaptureError("DeleteBanner", "Admin", Convert.ToString(exp));
                return Json("Error",JsonRequestBehavior.AllowGet);
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