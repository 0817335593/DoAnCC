using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class LoaiPhongController : BaseController
    {
        // GET: Admin/LoaiPhong
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new LoaiPhongBus().GetAll().Where(q => string.IsNullOrWhiteSpace(q.GhiChu)));
        }

        public ActionResult Edit(int? id = null)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            LoaiPhongObject ob = new LoaiPhongObject()
            {
                ID_LoaiPhong = 0
            };
            if (id.HasValue)
            {
                ob = new LoaiPhongBus().GetByID_LoaiPhong(id.Value);
                if (ob == null) return RedirectToAction("Index");
                return View(ob);
            }
            else
            {
                return View(ob);
            }
        }

        [HttpPost]
        public ActionResult Edit(LoaiPhongObject ob, FormCollection collection)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            if (ob.ID_LoaiPhong == 0) new LoaiPhongBus().Insert(ob);
            else new LoaiPhongBus().Update(ob);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new LoaiPhongBus().Delete(id));
        }

    }
}
