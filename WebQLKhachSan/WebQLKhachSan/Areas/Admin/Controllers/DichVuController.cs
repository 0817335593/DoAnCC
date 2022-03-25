using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class DichVuController : BaseController
    {
        // GET: Admin/DichVu
        public ActionResult Index()
        {
            //if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new DichVuBus().GetAll());
        }

        public ActionResult Edit(int? id = null)
        {
            //if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            DichVuObject ob = new DichVuObject()
            {
                IDDichVu = 0
            };
            if (id.HasValue)
            {
                ob = new DichVuBus().GetByIDDichVu(id.Value);
                if (ob == null) return RedirectToAction("Index");
                return View(ob);
            }
            else
            {
                return View(ob);
            }
        }

        [HttpPost]
        public ActionResult Edit(DichVuObject ob, FormCollection collection)
        {
            //if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            if (ob.IDDichVu == 0) new DichVuBus().Insert(ob);
            else new DichVuBus().Update(ob);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new DichVuBus().Delete(id));
        }

    }
}
