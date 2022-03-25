using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        const string BACK = "back";
        public TaiKhoanObject TaiKhoan { get; private set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            TaiKhoan = new Models.LoginHelper().GetTaiKhoan();
            if (TaiKhoan == null) filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            else
            {
                int back = 0;
                if (filterContext.RequestContext.HttpContext.Request[BACK] != null && int.TryParse(filterContext.RequestContext.HttpContext.Request[BACK], out back))
                {
                    switch (back)
                    {
                        case 1:
                            Session[BACK] = Request.UrlReferrer.AbsoluteUri;
                            break;
                        case 0:
                            var url = (Session[BACK] as string) ?? "/Admin";
                            filterContext.Result = new RedirectResult(url);
                            break;
                        default:
                            break;
                    }
                }
                var lstPhanQuyen = new PhanQuyenBus().GetByIDTaiKhoan(TaiKhoan.IDTaiKhoan);
                AllowXem = lstPhanQuyen.Any(q => q.IDQuyen == 1);
                AllowThemSuaXoa = lstPhanQuyen.Any(q => q.IDQuyen == 2);
            }
            base.OnActionExecuting(filterContext);
        }
        public bool AllowXem { get; set; }
        public bool AllowThemSuaXoa { get; set; }
    }
}