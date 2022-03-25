using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TaiKhoanObject ob)
        {
            if (new Models.LoginHelper().CheckLogin(ob)) return RedirectToAction("Index", "TinhThanh");
            ModelState.AddModelError("", "Đăng nhập thất bại, vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu.");
            return View();
        }

        public ActionResult Logout()
        {
            new Models.LoginHelper().Logout();
            return RedirectToAction("Index");
        }
    }
}