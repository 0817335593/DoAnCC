using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
using ClosedXML.Excel;
using System.IO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class DangKiDatPhongController : BaseController
    {
        // GET: Admin/DangKiDatPhong
        public ActionResult Index()
        {
            return View(new DangKiDatPhongBus().GetAll().OrderBy(q => q.Status));
        }

        public ActionResult ViewDetail(int id)
        {
            return View(new DangKiDatPhongBus().GetByID_DangKi(id));
        }

        [HttpPost]
        public ActionResult ViewDetail(DangKiDatPhongObject ob)
        {
            var obj = new DangKiDatPhongBus().GetByID_DangKi(ob.ID_DangKi);
            obj.Status = ob.Status;
            new DangKiDatPhongBus().Update(obj);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!AllowThemSuaXoa) return Json(false);
            return Json(new DangKiDatPhongBus().Delete(id));
        }

        public ActionResult Report(DateTime? timeStart, DateTime? timeEnd, string excel)
        {
            var data = new DangKiDatPhongBus().GetAll();
            if (timeStart.HasValue)
            {
                data = data.Where(q => q.NgayTao >= timeStart).ToList();
            }
            if (timeEnd.HasValue)
            {
                data = data.Where(q => q.NgayTao <= timeEnd).ToList();
            }
            ViewBag.stimeStart = timeStart.HasValue ? timeStart.Value.ToString("yyyy-MM-dd") : "none";
            ViewBag.stimeEnd = timeEnd.HasValue ? timeEnd.Value.ToString("yyyy-MM-dd") : "none";
            if (excel == "excel")
            {
                XLWorkbook wb = new XLWorkbook(Server.MapPath("/Areas/Admin/Report/email-kh.xlsx"));
                var ws = wb.Worksheet(1);

                int index = 3;
                ws.Cell(index++, 3).Value = ViewBag.stimeStart + " => " + ViewBag.stimeEnd;
                ws.Cell(index++, 3).Value = DateTime.Now;
                ws.Cell(index++, 3).Value = new Models.LoginHelper().GetTaiKhoan().HoTen;

                for (int i = 0; i < data.Count; i++)
                {
                    var item = data[i];
                    index = 1;
                    ws.Cell(8 + i, index++).Value = i + 1;
                    ws.Cell(8 + i, index++).Value = item.ID_DangKi;
                    ws.Cell(8 + i, index++).Value = item.HoTen;
                    ws.Cell(8 + i, index++).Value = item.Email;
                    ws.Cell(8 + i, index++).Value = item.NgayTao;
                    ws.Cell(8 + i, index++).Value = item.Phone;
                    ws.Cell(8 + i, index++).Value = item.PhongObjectJoin.TenPhong;
                    ws.Cell(8 + i, index++).Value = item.PhongObjectJoin.KhachSanObjectJoin.TenKhachSan;
                    ws.Cell(8 + i, index++).Value = item.PhongObjectJoin.TinhThanhObjectJoin.TenTinh;
                }

                using (var stream = new MemoryStream())
                {
                    //ws.Columns().AdjustToContents();
                    wb.SaveAs(stream);
                    string nameFile = string.Format("danh-sach-email.xlsx");
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nameFile);
                }
            }
            return View(data);
        }
    }
}