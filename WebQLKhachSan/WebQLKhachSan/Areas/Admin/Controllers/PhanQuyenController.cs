using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class PhanQuyenController : BaseController
    {
        // GET: Admin/PhanQuyen
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            List<TaiKhoanObject> lst = new TaiKhoanBus().GetAll();
            var phanquyen = new PhanQuyenBus().GetAll();
            foreach (var item in lst)
            {
                item.lstPhanQuyen = new List<PhanQuyenObject>();
                item.lstPhanQuyen.Add(phanquyen.FirstOrDefault(q => q.IDTaiKhoan == item.IDTaiKhoan && q.IDQuyen == 1));
                item.lstPhanQuyen.Add(phanquyen.FirstOrDefault(q => q.IDTaiKhoan == item.IDTaiKhoan && q.IDQuyen == 2));
            }
            return View(lst);
        }

        [HttpPost]
        public JsonResult Change(int idTaiKhoan, int value, bool isDelete)
        {
            if (!AllowThemSuaXoa) return Json(isDelete);
            if (idTaiKhoan == new Models.LoginHelper().GetTaiKhoan().IDTaiKhoan) return Json(false); // không cho phép sửa quyền của chính mình
            if (isDelete ? new PhanQuyenBus().Delete(value, idTaiKhoan) : new PhanQuyenBus().Insert(new PhanQuyenObject() { IDQuyen = value, IDTaiKhoan = idTaiKhoan }))
            {
                return Json(!isDelete);
            } 
            return Json(isDelete);
        }
    }
}