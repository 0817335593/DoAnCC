using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new TaiKhoanBus().GetAll().Where(q => q.IDTaiKhoan != TaiKhoan.IDTaiKhoan));
        }

        public ActionResult Edit(int? id = null)
        {
            var my = new Models.LoginHelper().GetTaiKhoan();
            if (id.HasValue && my.IDTaiKhoan == id)
            {
                ViewBag.ChucVu = new SelectList(new ChucVuBus().GetAll(), "IDChucVu", "TenCV", my.IDChucVu);
                return View(my);
            }
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            SelectList ChucVu = null;
            TaiKhoanObject ob = new TaiKhoanObject()
            {
                IDTaiKhoan = 0
            };
            if (id.HasValue)
            {
                ob = new TaiKhoanBus().GetByIDTaiKhoan(id.Value);
                if (ob == null) return RedirectToAction("Index");
                ChucVu = new SelectList(new ChucVuBus().GetAll(), "IDChucVu", "TenCV", ob.IDChucVu);
            }
            else
            {
                ChucVu = new SelectList(new ChucVuBus().GetAll(), "IDChucVu", "TenCV");
            }
            ViewBag.ChucVu = ChucVu;
            return View(ob);
        }

        [HttpPost]
        public ActionResult Edit(TaiKhoanObject ob, FormCollection collection)
        {
            var my = new Models.LoginHelper().GetTaiKhoan();
            if (my.IDTaiKhoan != ob.IDTaiKhoan && !AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            if (ob.IDTaiKhoan == 0)
            {
                ob.MatKhau = "12345678";
                new TaiKhoanBus().Insert(ob);
            }
            else new TaiKhoanBus().Update(ob);
            return RedirectToAction("Index");
        }

        public ActionResult EditInfo()
        {
            return RedirectToAction("Edit", new { id = new Models.LoginHelper().GetTaiKhoan().IDTaiKhoan });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new TaiKhoanBus().Delete(id));
        }

        public ActionResult ResetPasswork(int id)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            var ob = new TaiKhoanBus().GetByIDTaiKhoan(id);
            if (ob == null) return RedirectToAction("Index");
            return View(ob);
        }

        [HttpPost]
        public ActionResult ResetPasswork(TaiKhoanObject ob, string curentPass)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            var my = new Models.LoginHelper().GetTaiKhoan();
            if (!new Models.LoginHelper().CheckLogin(new TaiKhoanObject()
            {
                IDTaiKhoan = my.IDTaiKhoan,
                MatKhau = curentPass
            })) ModelState.AddModelError("", "Mật khẩu xác nhận không chính xác.");
            else
            {
                var acc = new TaiKhoanBus().GetByIDTaiKhoan(ob.IDTaiKhoan);
                acc.MatKhau = "12345678";
                new TaiKhoanBus().Update(acc);
            }
            return View();
        }

        public ActionResult DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhau(string curent, string newpass, string repass)
        {
            bool ok = true;
            ok = ok && newpass.Equals(repass);
            if (!ok) ModelState.AddModelError("", "Vui lòng nhập xác nhận mật khẩu và mật khẩu mới trùng khớp.");
            ok = ok && newpass.Length >= 8;
            if (!ok) ModelState.AddModelError("", "Vui lòng nhập mật khẩu mới ít nhất 8 kí tự.");
            var my = new Models.LoginHelper().GetTaiKhoan();
            ok = ok && new TaiKhoanBus().CheckLogin(my.TenDangNhap, curent) != null;
            if (ok)
            {
                if (new TaiKhoanBus().DoiMatKhau(my.IDTaiKhoan, curent, newpass) != null) return RedirectToAction("Index", "Login");
                else ModelState.AddModelError("", "Đổi mật khẩu thất bại.");
            }
            else ModelState.AddModelError("", "Mật khẩu cũ không chính xác.");
            return View();
        }
    }
}
