using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class KhachHangController : BaseController
    {
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("Index", "Home");
            return View(new KhachHangBus().GetAll());
        }

        public ActionResult Edit(Guid? id = null, int? idPhong = null)
        {
            //if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            KhachHangObject ob = new KhachHangObject()
            {
                IDKhachHang = Guid.Empty
            };
            if (idPhong.HasValue)
            {
                ViewBag.Phong = new PhongBus().GetByIDPhong(idPhong.Value);
                if (ViewBag.Phong == null) return RedirectToAction("Index", "Home");
            }
            else idPhong = 0;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                ob = new KhachHangBus().GetByIDKhachHang(id.Value);
                if (ob == null) return RedirectToAction("Index");
                return View(ob);
            }
            else
            {
                return View(ob);
            }
        }

        [HttpPost]
        public ActionResult Edit(KhachHangObject ob, int? idPhong)
        {
            //if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            bool datPhong = ob.IDKhachHang == Guid.Empty;
            if (ob.IDKhachHang == Guid.Empty)
            {
                ob.IDKhachHang = Guid.NewGuid();
                new KhachHangBus().Insert(ob);
            }
            else new KhachHangBus().Update(ob);
            if (idPhong.HasValue && idPhong != 0)
            {
                //đặt phòng cho khách
                if (datPhong)
                {
                    new DatPhongBus().Insert(new DatPhongObject()
                    {
                        BatDau = DateTime.Now,
                        IDDatPhong = 0,
                        IDKhachHang = ob.IDKhachHang,
                        IDPhong = idPhong,
                        IDTaiKhoan = new Models.LoginHelper().GetTaiKhoan().IDTaiKhoan,
                        KetThuc = null,
                        Status = false,
                        ThanhToan = 0,
                        TongTien = 0
                    });
                    var phong = new PhongBus().GetByIDPhong(idPhong.Value);
                    phong.TrangThai = Models.TrangThaiPhongHelper.eTrangThai.SuDung.ToString();
                    new PhongBus().Update(phong);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new KhachHangBus().Delete(id));
        }

    }
}
