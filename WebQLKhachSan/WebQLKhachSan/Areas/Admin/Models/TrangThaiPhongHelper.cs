using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLKhachSan.Areas.Admin.Models
{
    public class TrangThaiPhongHelper
    {
        public enum eTrangThai
        {
            NULL,
            SanSang,
            SuDung,
            DonDep,
            SuaChua,
            Khac
        }

        public string GetName(string trangThai)
        {
            string result = "";
            switch (trangThai)
            {
                case "NULL":
                    result = "";
                    break;
                case "SanSang":
                    result = "Sẵn sàng";
                    break;
                case "DonDep":
                    result = "Đang dọn dẹp";
                    break;
                case "SuaChua":
                    result = "Đang sửa chữa";
                    break;
                case "Khac":
                    result = "Khác";
                    break;
                case "SuDung":
                    result = "Đang sử dụng";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
    }
}