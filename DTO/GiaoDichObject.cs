
using System;
using System.Collections.Generic;

namespace DTO
{
    public class GiaoDichObject
    {

        public System.DateTime? BuyTime { get; set; }
        public System.Int32? IDDatPhong { get; set; }
        public System.Int32? IDDichVu { get; set; }
        public System.Int32 IDGiaoDich { get; set; }
        public System.Int32? IDTaiKhoan { get; set; }
        public System.Int32? SoLuong { get; set; }
        public DatPhongObject DatPhongObjectJoin { get; set; }
        public DichVuObject DichVuObjectJoin { get; set; }
        public TaiKhoanObject TaiKhoanObjectJoin { get; set; }
    }
}
