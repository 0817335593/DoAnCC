using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class KhachSanController : BaseController
    {
        // GET: Admin/KhachSan
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new KhachSanBus().GetAll().Where(q => q.IsDelete != true));
        }

        public ActionResult Edit(int? id = null)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            KhachSanObject ob = new KhachSanObject()
            {
                IDKhachSan = 0,
                IsDelete = false,
                HinhAnh = new HinhAnhObject
                {
                    ImageLink = ""
                }
            };
            if (id.HasValue)
            {
                ob = new KhachSanBus().GetByIDKhachSan(id.Value);
                if (ob == null) return RedirectToAction("Index");
                ViewBag.selectTinhThanh = new SelectList(new TinhThanhBus().GetAll(), "IDTinhThanh", "TenTinh", ob.IDTinhThanh);
            }
            else
            {
                ViewBag.selectTinhThanh = new SelectList(new TinhThanhBus().GetAll(), "IDTinhThanh", "TenTinh");
            }
            return View(ob);
        }

        [HttpPost]
        public ActionResult Edit(KhachSanObject ob, FormCollection collection, int[] delete)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            if ((ob.IDKhachSan == 0 && (delete == null || delete.Length != 1)) || (ob.IDKhachSan > 0 && delete != null && delete.Length != 1))
            {
                ModelState.AddModelError("", "Khách sạn cần 01 hình ảnh đại diện");
                ViewBag.selectTinhThanh = new SelectList(new TinhThanhBus().GetAll(), "IDTinhThanh", "TenTinh", ob.IDTinhThanh);
                return View(ob);
            }
            else if (delete != null)
            {
                ob.IDHinhAnh = delete[0];
            }

            if (ob.IDKhachSan == 0) new KhachSanBus().Insert(ob);
            else new KhachSanBus().Update(ob);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new KhachSanBus().Delete(id));
        }

    }
}
