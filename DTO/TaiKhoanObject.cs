
using System;
using System.Collections.Generic;

namespace DTO
{
    public class TaiKhoanObject
    {

        public string HoTen { get; set; }
        public System.Int32? IDChucVu { get; set; }
        public System.Int32 IDTaiKhoan { get; set; }
        public System.Boolean IsDelete { get; set; }
        public string MatKhau { get; set; }
        public System.DateTime? NgaySinh { get; set; }
        public string SDT { get; set; }
        public string TenDangNhap { get; set; }
        public ChucVuObject ChucVuObjectJoin { get; set; }
        public List<PhanQuyenObject> lstPhanQuyen { get; set; }

    }
}
