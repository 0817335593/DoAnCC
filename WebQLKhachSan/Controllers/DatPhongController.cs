using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
using System.Threading.Tasks;
using System.Globalization;

namespace WebQLKhachSan.Controllers
{
    public class DatPhongController : Controller
    {
        // GET: DatPhong
        public ActionResult Index(int id)
        {
            var ob = new PhongBus().GetByIDPhong(id);
            if (ob == null) return RedirectToAction("Index", "Home");
            return View(ob);
        }

        [HttpPost]
        public ActionResult DatPhongTruoc(DangKiDatPhongObject ob, string sTimeStart, string sTimeEnd)
        {
            var phong = new PhongBus().GetByIDPhong(ob.ID_Phong.Value);
            if (phong == null) return RedirectToAction("Index");
            ob.NgayTao = DateTime.Now;
            ob.Status = 0;
            ob.TimeStart = DateTime.ParseExact(sTimeStart, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ob.TimeEnd = DateTime.ParseExact(sTimeEnd, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            new DangKiDatPhongBus().Insert(ob);
            string contentEmail = string.Format(@"
<p>Xin chào <b>{0}</b></p>
<p>Công Ty khách sạn xin kính chào quý khách!<p>
<p>Cảm ơn bạn đã đặt phòng khách sạn của chúng tôi!</p>
<p>Thông tin đặt phòng:</p>
    <ul>
        <li> Phòng: <b>{1}</b></li>
        <li> Loại Phòng: <b>{2}</b></li>
        <li> Giá phòng khuyến mãi: <b>{3}</b></li>
        <li> Thời gian nhận phòng: <b>{4}</b></li>
        <li> Thời gian trả phòng: <b>{5}</b></li>
        <li> Hình thức thanh toán: <b>Thanh toán trực tiếp</b></li>
    </ul>
<p>Chúng tôi sẽ liên hệ với bạn để xác nhận các thông tin qua <b>{6}</b>.</p>
<p>Cảm ơn bạn đã tin dùng hệ thống của chúng tôi!</p>
<p><i>Phòng tiếp tân Khách sạn.</i></p>
", ob.HoTen, phong.TenPhong, phong.LoaiPhongObjectJoin.TenLoai, phong.GiaKM.Value.ToString("#,###"), ob.TimeStart, ob.TimeEnd, ob.Phone);
            new Task(() => { Models.SMTPHelper.SenMail(ob.Email, contentEmail, "Đăng kí đặt phòng"); }).Start();
            return RedirectToAction("thong_bao", new { code = 1 });
        }

        public ActionResult thong_bao(int code = 1)
        {
            ViewBag._ = code;
            return View(code);
        }
    }
}