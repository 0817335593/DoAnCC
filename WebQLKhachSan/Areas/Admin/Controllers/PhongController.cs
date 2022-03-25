using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
using WebQLKhachSan.Areas.Admin.Models;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class PhongController : BaseController
    {
        // GET: Admin/Phong
        public ActionResult Index(int IDKhachSan)
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            ViewBag.IDKhachSan = IDKhachSan;
            return View(new PhongBus().GetAll(IDKhachSan));
        }

        public ActionResult Edit(int? id, int? IDKhachSan = null)
        {
            if (!AllowThemSuaXoa) RedirectToAction("NotPermistion", "Redirect");
            var selectViTri = new SelectList(new ViTriBus().GetAll(), "ID_ViTri", "TenViTri");
            var selectLoaiPhong = new SelectList(new LoaiPhongBus().GetAll(), "ID_LoaiPhong", "TenLoai");
            PhongObject ob = new PhongObject()
            {
                IDPhong = 0,
                Active = true,
                IDKhachSan = IDKhachSan ?? 0,
                IsDelete = false
            };
            if (id.HasValue)
            {
                ob = new PhongBus().GetByIDPhong(id.Value);
                if (ob == null) return RedirectToAction("Index", new { IDKhachSan = IDKhachSan });
                selectViTri = new SelectList(new ViTriBus().GetAll(), "ID_ViTri", "TenViTri", ob.ID_ViTri);
                selectLoaiPhong = new SelectList(new LoaiPhongBus().GetAll(), "ID_LoaiPhong", "TenLoai", ob.ID_LoaiPhong);
            }
            ViewBag.selectViTri = selectViTri;
            ViewBag.selectLoaiPhong = selectLoaiPhong;
            return View(ob);
        }

        [HttpPost]
        public ActionResult Edit(PhongObject ob, FormCollection collection)
        {
            if (!AllowThemSuaXoa) RedirectToAction("NotPermistion", "Redirect");
            if (ob.IDPhong == 0) new PhongBus().Insert(ob);
            else new PhongBus().Update(ob);
            return RedirectToAction("Index", new { IDKhachSan = ob.IDKhachSan });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new PhongBus().Delete(id));
        }

        public ActionResult SetTrangThai(int id, string trangThai)
        {
            if (!AllowThemSuaXoa) RedirectToAction("NotPermistion", "Redirect");
            var ob = new PhongBus().GetByIDPhong(id);
            if (ob != null)
            {
                ob.TrangThai = trangThai;
                new PhongBus().Update(ob);
            }
            return RedirectToAction("Index", "Homes", new { IDKhachSan = ob.IDKhachSan });
        }

        public ActionResult ThemPhong(int id)
        {
            if (!AllowThemSuaXoa) RedirectToAction("NotPermistion", "Redirect");
            var datphong = new DatPhongBus().GetByIDDatPhong(id);
            if (datphong == null) return RedirectToAction("Index", "Homes", new { IDKhachSan = datphong.PhongObjectJoin.IDKhachSan });
            ViewBag.Khach = new KhachHangBus().GetByIDKhachHang(datphong.IDKhachHang.Value);
            ViewBag.IDKhachSan = datphong.PhongObjectJoin.IDKhachSan;
            return View(new PhongBus().GetAll(datphong.PhongObjectJoin.IDKhachSan.Value).Where(q => q.IDPhong != datphong.IDPhong && q.TrangThai == TrangThaiPhongHelper.eTrangThai.SanSang.ToString() && q.Active == true));
        }

        [HttpPost]
        public ActionResult ThemPhong(Guid IDKhachHang, int[] Selected, int IDKhachSan)
        {
            if (!AllowThemSuaXoa) RedirectToAction("NotPermistion", "Redirect");
            foreach (var item in Selected)
            {
                new DatPhongBus().Insert(new DatPhongObject()
                {
                    BatDau = DateTime.Now,
                    IDDatPhong = 0,
                    IDKhachHang = IDKhachHang,
                    IDPhong = item,
                    IDTaiKhoan = new LoginHelper().GetTaiKhoan().IDTaiKhoan,
                    KetThuc = null,
                    Status = false,
                    ThanhToan = 0,
                    TongTien = 0
                });
                var ob = new PhongBus().GetByIDPhong(item);
                ob.TrangThai = TrangThaiPhongHelper.eTrangThai.SuDung.ToString();
                new PhongBus().Update(ob);
            }
            return RedirectToAction("Index", "Homes", new { IDKhachSan = IDKhachSan });
        }
    }
}
