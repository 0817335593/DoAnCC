using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class TinhThanhController : BaseController
    {
        // GET: Admin/TinhThanh
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new TinhThanhBus().GetAll().Where(q => q.IsDelete != true));
        }

        public ActionResult Edit(int? id = null)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            TinhThanhObject ob = new TinhThanhObject()
            {
                IDTinhThanh = 0,
                IsDelete = false,
                mHinhAnh = new HinhAnhObject
                {
                    ImageLink = ""
                }
            };
            if (id.HasValue)
            {
                ob = new TinhThanhBus().GetByIDTinhThanh(id.Value);
                if (ob == null) return RedirectToAction("Index");
                return View(ob);
            }
            else
            {
                return View(ob);
            }
        }

        [HttpPost]
        public ActionResult Edit(TinhThanhObject ob, FormCollection collection, int[] delete)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            if ((ob.IDTinhThanh == 0 && (delete == null || delete.Length != 1)) || (ob.IDTinhThanh > 0 && delete != null && delete.Length != 1))
            {
                ModelState.AddModelError("", "Tỉnh thành cần 01 hình ảnh đại diện");
                return View(ob);
            }
            else if(delete != null)
            {
                ob.IDHinhAnh = delete[0];
            }
            if (ob.IDTinhThanh == 0) new TinhThanhBus().Insert(ob);
            else new TinhThanhBus().Update(ob);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new TinhThanhBus().Delete(id));
        }

    }
}
