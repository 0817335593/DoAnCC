using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class GiaoDichController : BaseController
    {
        public JsonResult GoiDichVu(int idDatPhong, int[] lstDichVu, int[] lstSoLuong)
        {
            if (lstDichVu == null || lstSoLuong == null) return Json(false);
            for (int i = 0; i < lstDichVu.Length; i++)
            {
                new GiaoDichBus().Insert(new DTO.GiaoDichObject()
                {
                    BuyTime = DateTime.Now,
                    IDDatPhong = idDatPhong,
                    IDDichVu = lstDichVu[i],
                    IDGiaoDich = 0,
                    IDTaiKhoan = new Models.LoginHelper().GetTaiKhoan().IDTaiKhoan,
                    SoLuong = lstSoLuong[i]
                });
            }
            return Json(true);
        }
    }
}