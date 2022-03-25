using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQLKhachSan.Controllers
{
    public class CamNangDuLichController : Controller
    {
        // GET: CamNangDuLich
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChiTiet(int id = 1234)
        {
            return View();
        }
    }
}