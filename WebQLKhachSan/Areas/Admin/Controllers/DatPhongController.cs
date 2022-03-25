using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.IO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class DatPhongController : BaseController
    {
        // GET: Admin/DatPhong
        public ActionResult Index()
        {
            if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            return View(new DatPhongBus().GetAll());
        }

        public ActionResult TraPhong(int id)
        {
            //if (!AllowXem) return RedirectToAction("NotPermistion", "Redirect");
            var datphong = new DatPhongBus().GetByIDDatPhong(id);
            var lstGiaoDich = new GiaoDichBus().GetByIDDatPhong(id);
            if (datphong.KetThuc == null) datphong.KetThuc = DateTime.Now;
            datphong.TongTien = (long)(((TimeSpan)(datphong.KetThuc - datphong.BatDau)).TotalHours * datphong.PhongObjectJoin.GiaPhong.Value);
            foreach (var item in lstGiaoDich)
            {
                datphong.TongTien += item.DichVuObjectJoin.GiaTien.Value * item.SoLuong.Value;
            }
            ViewBag.DatPhong = datphong;
            new DatPhongBus().Update(datphong);
            var phong = new PhongBus().GetByIDPhong(datphong.IDPhong.Value);
            var khachsan = new KhachSanBus().GetByIDKhachSan(phong.IDKhachSan.Value);
            ViewBag.khachsan = khachsan;
            return View(lstGiaoDich);
        }

        [HttpPost]
        public ActionResult TraPhong(DatPhongObject ob)
        {
            //if (!AllowThemSuaXoa) return RedirectToAction("NotPermistion", "Redirect");
            var obj = new DatPhongBus().GetByIDDatPhong(ob.IDDatPhong);
            if (ob.ThanhToan == obj.TongTien)
            {
                obj.ThanhToan = ob.ThanhToan;
                obj.Status = true;
                new DatPhongBus().Update(obj);
                var phong = new PhongBus().GetByIDPhong(obj.IDPhong.Value);
                phong.TrangThai = Models.TrangThaiPhongHelper.eTrangThai.DonDep.ToString();
                new PhongBus().Update(phong);
                return RedirectToAction("Index", "Homes", new { IDKhachSan = phong.IDKhachSan });
            }
            var sub = obj.TongTien - ob.ThanhToan;
            ModelState.AddModelError("", string.Format("Thanh toán không thành công, số tiền cần thanh toán là {0}, hiện tại khách hàng đã thanh toán {1}, {2}", obj.TongTien, ob.ThanhToan, sub > 0 ? "thiếu " + sub : "thừa " + (sub * -1)));
            ViewBag.DatPhong = obj;
            var phong2 = new PhongBus().GetByIDPhong(ob.IDPhong.Value);
            var khachsan = new KhachSanBus().GetByIDKhachSan(phong2.IDKhachSan.Value);
            ViewBag.khachsan = khachsan;
            return View(new GiaoDichBus().GetByIDDatPhong(ob.IDDatPhong));
        }

        public ActionResult ExpertReport(int IDDatPhong)
        {
            var datphong = new DatPhongBus().GetByIDDatPhong(IDDatPhong);
            if (datphong == null) return RedirectToAction("Index");

            XLWorkbook wb = new XLWorkbook(Server.MapPath("/Areas/Admin/Report/Hoa-don-khach-hang.xlsx"));
            var ws = wb.Worksheet(1);

            ws.Cell("C5").Value = datphong.KhachHangObjectJoin.HoTen;
            ws.Cell("C6").Value = datphong.KhachHangObjectJoin.CMT;
            ws.Cell("C7").Value = datphong.KhachHangObjectJoin.SDT;
            ws.Cell("C8").Value = datphong.KhachHangObjectJoin.DiaChi;
            ws.Cell("C9").Value = datphong.KhachHangObjectJoin.NgaySinh;
            ws.Cell("C10").Value = datphong.KhachHangObjectJoin.IsMale ? "Nam" : "Nữ";

            var phong = new PhongBus().GetByIDPhong(datphong.PhongObjectJoin.IDPhong);
            var khachsan = new KhachSanBus().GetByIDKhachSan(phong.IDKhachSan.Value);
            ws.Cell("C13").Value = khachsan.TinhThanh.TenTinh;
            ws.Cell("C14").Value = khachsan.TenKhachSan;
            ws.Cell("C15").Value = phong.TenPhong;
            ws.Cell("C16").Value = phong.ViTriObjectJoin.TenViTri;
            ws.Cell("C17").Value = phong.GiaPhong + " đ/h";
            ws.Cell("C18").Value = phong.LoaiPhongObjectJoin.TenLoai;
            ws.Cell("C19").Value = datphong.BatDau;
            ws.Cell("C20").Value = datphong.KetThuc;
            ws.Cell("C21").Value = ((TimeSpan)(datphong.KetThuc - datphong.BatDau)).ToString("hh\\:mm") + " phút";
            ws.Cell("C22").Value = datphong.TaiKhoanObjectJoin.HoTen;

            ws.Cell("C34").Value = DateTime.Now;
            ws.Cell("C36").Value = TaiKhoan.HoTen;

            long total = ((int)(datphong.PhongObjectJoin.GiaPhong.Value * ((TimeSpan)(datphong.KetThuc.Value - datphong.BatDau.Value)).TotalMinutes) / 60);
            ws.Cell("A27").Value = "Phòng";
            ws.Cell("B27").Value = phong.GiaPhong + " đ/h";
            ws.Cell("C27").Value = ((TimeSpan)(datphong.KetThuc - datphong.BatDau)).ToString("hh\\:mm") + " phút";
            ws.Cell("D27").Value = total;

            var giaodich = new GiaoDichBus().GetByIDDatPhong(datphong.IDDatPhong);
            foreach (var item in giaodich)
            {
                ws.Row(28).InsertRowsBelow(1);
                ws.Cell(28, 1).Value = item.DichVuObjectJoin.TenDichVu;
                ws.Cell(28, 2).Value = item.DichVuObjectJoin.GiaTien + " đ/" + item.DichVuObjectJoin.DonVi;
                ws.Cell(28, 3).Value = item.SoLuong + " " + item.DichVuObjectJoin.DonVi;
                ws.Cell(28, 4).Value = item.SoLuong * item.DichVuObjectJoin.GiaTien + " đ";
                total += item.SoLuong.Value * item.DichVuObjectJoin.GiaTien.Value;
            }
            ws.Cell(29 + giaodich.Count, 4).Value = total + " đ";

            using (var stream = new MemoryStream())
            {
                ws.Columns().AdjustToContents();
                wb.SaveAs(stream);
                string nameFile = string.Format("Hoa-don-khach-hang-{0}.xlsx", datphong.KhachHangObjectJoin.HoTen);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nameFile);
            }
        }

        public ActionResult Report(DateTime? timeStart, DateTime? timeEnd, string excel)
        {
            var data = new DatPhongBus().GetAll();
            if (timeStart.HasValue)
            {
                data = data.Where(q => q.KetThuc >= timeStart).ToList();
            }
            if (timeEnd.HasValue)
            {
                data = data.Where(q => q.KetThuc <= timeEnd).ToList();
            }
            ViewBag.stimeStart = timeStart.HasValue ? timeStart.Value.ToString("yyyy-MM-dd") : "none";
            ViewBag.stimeEnd = timeEnd.HasValue ? timeEnd.Value.ToString("yyyy-MM-dd") : "none";
            ViewBag.Total = data.Sum(q => q.TongTien).Value.ToString("#,###");
            if (excel == "excel")
            {
                XLWorkbook wb = new XLWorkbook(Server.MapPath("/Areas/Admin/Report/doanh-thu.xlsx"));
                var ws = wb.Worksheet(1);

                int index = 3;
                ws.Cell(index++, 3).Value = ViewBag.stimeStart + " => " + ViewBag.stimeEnd;
                ws.Cell(index++, 3).Value = DateTime.Now;
                ws.Cell(index++, 3).Value = new Models.LoginHelper().GetTaiKhoan().HoTen;
                ws.Cell(index++, 3).Value = ViewBag.Total;

                for (int i = 0; i < data.Count; i++)
                {
                    var item = data[i];
                    index = 1;
                    ws.Cell(9 + i, index++).Value = i + 1;
                    ws.Cell(9 + i, index++).Value = item.KetThuc;
                    ws.Cell(9 + i, index++).Value = item.KhachHangObjectJoin.HoTen;
                    ws.Cell(9 + i, index++).Value = item.PhongObjectJoin.TenPhong;
                    ws.Cell(9 + i, index++).Value = item.PhongObjectJoin.KhachSanObjectJoin.TenKhachSan;
                    ws.Cell(9 + i, index++).Value = item.PhongObjectJoin.TinhThanhObjectJoin.TenTinh;
                    ws.Cell(9 + i, index++).Value = item.TongTien.Value.ToString("#,###");
                }


                using (var stream = new MemoryStream())
                {
                    //ws.Columns().AdjustToContents();
                    wb.SaveAs(stream);
                    string nameFile = string.Format("doanh-thu-khach-san.xlsx");
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nameFile);
                }
            }
            return View(data);
        }
    }
}