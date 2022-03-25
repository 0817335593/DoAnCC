using System.Web.Mvc;

namespace WebQLKhachSan.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "TinhThanh", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebQLKhachSan.Areas.Admin.Controllers" }
            );
        }
    }
}