using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class RedirectController : Controller
    {
        const string BACK = "BACK";
        // GET: Admin/Redirect
        public ActionResult Back()
        {
            return Redirect((Session[BACK] as string) ?? "/Admin");
        }

        public ActionResult RedirectToAction(string NameAction,string NameController,object routeValues)
        {
            Session[BACK] = Request.Url;
            return RedirectToAction(NameAction, NameController, routeValues);
        }

        public ActionResult NotPermistion()
        {
            return View();
        }
    }
}