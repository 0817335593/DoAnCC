using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace WebQLKhachSan.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(int? TinhThanh, int? priceStart, int? priceEnd, int[] Star)
        {
            ViewBag.selectTinhThanh = new SelectList(new TinhThanhBus().GetAll(), "IDTinhThanh", "TenTinh");
            if (TinhThanh.HasValue == false && priceStart.HasValue == false && priceEnd.HasValue == false && Star == null)
            {
                return View(new TinhThanhBus().GetAll());
            }
            else if (TinhThanh.HasValue && priceStart.HasValue == false && priceEnd.HasValue == false && Star == null)
            {
                return RedirectToAction("KhachSan", new { id = TinhThanh.Value });
            }
            var data = new PhongBus().GetAll();
            if (TinhThanh.HasValue)
            {
                data = data.Where(q => q.TinhThanhObjectJoin.IDTinhThanh == TinhThanh).ToList();
            }
            if (priceStart.HasValue)
            {
                data = data.Where(q =>  q.GiaKM >= priceStart).ToList();
            }
            if (priceEnd.HasValue)
            {
                data = data.Where(q =>  q.GiaKM <= priceEnd).ToList();
            }
            if (Star != null)
            {
                data = data.Where(q => Star.Any(a => a == q.Star)).ToList();
            }
            var listImage = new Phong_HinhAnhBus().GetAll();
            foreach (var item in data)
            {
                var hinhanh = listImage.FirstOrDefault(q => q.IDPhong == item.IDPhong);
                item.LinkImage = hinhanh == null ? "/Content/images/khach-san-riverside-quang-binh-8.jpg" : hinhanh.HinhAnhObjectJoin.ImageLink;
            }
            return View("Phong", data);
        }

        public ActionResult KhachSan(int id)
        {
            ViewBag.tinhThanh = new TinhThanhBus().GetByIDTinhThanh(id);
            ViewBag.selectTinhThanh = new SelectList(new TinhThanhBus().GetAll(), "IDTinhThanh", "TenTinh");
            return View(new KhachSanBus().GetAll().Where(q => q.IsDelete != true && q.IDTinhThanh == id).ToList());
        }

        public ActionResult Phong(int IDKhachSan)
        {
            ViewBag.selectTinhThanh = new SelectList(new TinhThanhBus().GetAll(), "IDTinhThanh", "TenTinh");
            IEnumerable<PhongObject> data = new PhongBus().GetAll(IDKhachSan)
                .Where(q => q.Active != false && q.IDKhachSan == IDKhachSan)
                .OrderByDescending(q => q.TrangThai);
            var listImage = new Phong_HinhAnhBus().GetAll();
            foreach (var item in data)
            {
                var hinhanh = listImage.FirstOrDefault(q => q.IDPhong == item.IDPhong);
                item.LinkImage = hinhanh == null ? "/Content/images/khach-san-riverside-quang-binh-8.jpg" : hinhanh.HinhAnhObjectJoin.ImageLink;
            }
            return View(data);
        }

        public ActionResult ChiTiet(int id)
        {
            var phong = new PhongBus().GetByIDPhong(id);
            if (phong == null) return RedirectToAction("Index");
            ViewBag.Phong = phong;
            return View(new Phong_HinhAnhBus().GetByIDPhong(phong.IDPhong));
        }
    }
}