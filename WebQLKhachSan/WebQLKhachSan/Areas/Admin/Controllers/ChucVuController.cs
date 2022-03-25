using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class ChucVuController : BaseController
    {
        // GET: Admin/ChucVu
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new ChucVuBus().GetAll());
        }

        public ActionResult Edit(int? id = null)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            ChucVuObject ob = new ChucVuObject()
            {
                IDChucVu = 0
            };
            if (id.HasValue)
            {
                ob = new ChucVuBus().GetByIDChucVu(id.Value);
                if (ob == null) return RedirectToAction("Index");
                return View(ob);
            }
            else
            {
                return View(ob);
            }
        }

        [HttpPost]
        public ActionResult Edit(ChucVuObject ob, FormCollection collection)
        {
            if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            if (ob.IDChucVu == 0) new ChucVuBus().Insert(ob);
            else new ChucVuBus().Update(ob);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new ChucVuBus().Delete(id));
        }

        public ActionResult ExportExcel()
        {
            new Models.ExcelHelper<ChucVuObject>().ExportExcel(new ChucVuBus().GetAll());
            return RedirectToAction("Index");
        }

    }
}
