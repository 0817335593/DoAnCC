using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
using System.IO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class HinhAnhController : BaseController
    {
        // GET: Admin/HinhAnh
        public ActionResult Index(int id_phong)
        {
            var phong = new PhongBus().GetByIDPhong(id_phong);
            if (phong == null) return RedirectToAction("Index", "Phong");
            ViewBag.Phong = phong;
            return View(new HinhAnhBus().GetAll());
        }

        public ActionResult UploadFile()
        {
            var Files = Request.Files;
            List<HinhAnhObject> lst = new List<HinhAnhObject>();
            for (int i = 0; i < Files.Count; i++)
            {
                var item = Files[i];
                string folder = "/Content/images/phong";
                string fileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss_") + item.FileName;
                item.SaveAs(Path.Combine(Server.MapPath(folder), fileName));
                var ob = new HinhAnhObject()
                {
                    IDHinhAnh = 0,
                    ImageLink = folder + "/" + fileName,
                    IsDelete = false,
                    Rank = i
                };
                new HinhAnhBus().Insert(ob);
                lst.Add(ob);
            }
            return View("LoadImage", new HinhAnhBus().GetAll());
        }

        public ActionResult LoadImage()
        {
            return View(new HinhAnhBus().GetAll());
        }

        [HttpPost]
        public ActionResult Delete(int[] delete, string[] link, int IDPhong)
        {
            for (int i = 0; i < delete.Length; i++)
            {
                if (new HinhAnhBus().Delete(delete[i]))
                {
                    System.IO.File.Delete(Server.MapPath(link[i]));
                }
            }
            return RedirectToAction("Index", new { id_phong = IDPhong });
        }

        public ActionResult ImagePhong(int IDPhong)
        {
            return View(new Phong_HinhAnhBus().GetByIDPhong(IDPhong));
        }

        [HttpPost]
        public ActionResult Insert(int IDPhong, int[] ID_HinhAnh)
        {
            if (ID_HinhAnh != null)
            {
                var bus = new Phong_HinhAnhBus();
                foreach (var item in ID_HinhAnh)
                {
                    bus.Insert(new Phong_HinhAnhObject()
                    {
                        GhiChu = "",
                        IDHinhAnh = item,
                        IDPhong = IDPhong,
                        IDPhong_HinhAnh = 0,
                        Rank = 1
                    });
                }
            }
            return View("ImagePhong", new Phong_HinhAnhBus().GetByIDPhong(IDPhong));
        }

        [HttpPost]
        public JsonResult Delete_PHA(int[] ID_PHA)
        {
            var bus = new Phong_HinhAnhBus();
            List<int> lst = new List<int>();
            foreach (var item in ID_PHA)
            {
                if (bus.Delete(item)) lst.Add(item);
            }
            return Json(lst);
        }
    }

}