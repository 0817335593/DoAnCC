using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using DTO;

namespace WebQLKhachSan.Areas.Admin.Models
{
    public class LoginHelper
    {
        const string LOGIN = "LOGIN";

        public LoginHelper()
        {
            
        }
        public bool CheckLogin(TaiKhoanObject taiKhoan)
        {
            var ob = new TaiKhoanBus().CheckLogin(taiKhoan.TenDangNhap, taiKhoan.MatKhau);
            if (ob == null) return false;
            HttpContext.Current.Session[LOGIN] = ob;
            return true;
        }

        public void Logout()
        {
            HttpContext.Current.Session[LOGIN] = null;
            HttpContext.Current.Session.Clear();
        }

        public TaiKhoanObject GetTaiKhoan()
        {
            return HttpContext.Current.Session[LOGIN] as TaiKhoanObject;
        }

        public bool AllowXem()
        {
            var acc = GetTaiKhoan();
            if (acc == null) return false;
            var lstPhanQuyen = new PhanQuyenBus().GetByIDTaiKhoan(acc.IDTaiKhoan);
            return lstPhanQuyen.Any(q => q.IDQuyen == 1);
        }

        public bool AllowThemSuaXoa()
        {
            var acc = GetTaiKhoan();
            if (acc == null) return false;
            var lstPhanQuyen = new PhanQuyenBus().GetByIDTaiKhoan(acc.IDTaiKhoan);
            return lstPhanQuyen.Any(q => q.IDQuyen == 2);
        }
    }
}