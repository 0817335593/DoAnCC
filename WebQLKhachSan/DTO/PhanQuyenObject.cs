
using System;
using System.Collections.Generic;

namespace DTO
{
    public class PhanQuyenObject
    {

        public System.Int32 IDQuyen { get; set; }
        public System.Int32 IDTaiKhoan { get; set; }
        public QuyenObject QuyenObjectJoin { get; set; }
        public TaiKhoanObject TaiKhoanObjectJoin { get; set; }
    }
}
