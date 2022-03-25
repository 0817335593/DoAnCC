using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLKhachSan.Areas.Admin.Models
{
    public class ExcelHelper<T>
    {
        public void ExportExcel(IEnumerable<T> data)
        {
            var grid = new GridView();
            grid.DataSource = data;
            grid.DataBind();

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xlsx");
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            HttpContext.Current.Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            HttpContext.Current.Response.Output.Write(sw.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }
    }
}