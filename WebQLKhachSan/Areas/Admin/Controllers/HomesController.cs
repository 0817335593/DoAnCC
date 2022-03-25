using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class HomesController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index(int IDKhachSan)
        {
            //if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            var listPhong = new PhongBus().GetAll(IDKhachSan);
            var listDatPhong = new DatPhongBus().GetAll().Where(q => q.Status == false);
            var data = new List<DatPhongObject>();
            var listImage = new Phong_HinhAnhBus().GetAll();
            foreach (var item in listPhong)
            {
                var ob = listDatPhong.FirstOrDefault(q => q.IDPhong == item.IDPhong);
                if (ob == null)
                {
                    ob = new DatPhongObject() { PhongObjectJoin = item };
                }
                else
                {
                    ob.PhongObjectJoin.LoaiPhongObjectJoin = listPhong.FirstOrDefault(q => q.IDPhong == ob.IDPhong).LoaiPhongObjectJoin;
                }
                var hinhanh = listImage.FirstOrDefault(q => q.IDPhong == item.IDPhong);
                if (hinhanh != null) ob.PhongObjectJoin.LinkImage = hinhanh.HinhAnhObjectJoin.ImageLink;
                data.Add(ob);
            }
            ViewBag.IDKhachSan = IDKhachSan;
            return View(data);
        }


        public ActionResult DichVu()
        {
            //if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new DichVuBus().GetAll());
        }

        public ActionResult Filter(string trangThai, int IDKhachSan)
        {
            var listPhong = new PhongBus().GetAll(IDKhachSan);
            var listDatPhong = new DatPhongBus().GetAll().Where(q => q.Status == false);
            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                listPhong = listPhong.Where(q => q.TrangThai.Trim().ToLower().Equals(trangThai.Trim().ToLower())).ToList();
            }
            var data = new List<DatPhongObject>();
            var listImage = new Phong_HinhAnhBus().GetAll();
            foreach (var item in listPhong)
            {
                var ob = listDatPhong.FirstOrDefault(q => q.IDPhong == item.IDPhong);
                if (ob == null)
                {
                    ob = new DatPhongObject() { PhongObjectJoin = item };
                }
                var hinhanh = listImage.FirstOrDefault(q => q.IDPhong == item.IDPhong);
                if (hinhanh != null) ob.PhongObjectJoin.LinkImage = hinhanh.HinhAnhObjectJoin.ImageLink;
                data.Add(ob);
            }
            return PartialView("DSPhong", data);
        }
    }
}