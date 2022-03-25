
using System;
using System.Collections.Generic;

namespace DTO
{
    public class DatPhongObject
    {
        
public System.DateTime? BatDau { get; set; }
public System.Int32 IDDatPhong { get; set; }
public System.Guid? IDKhachHang { get; set; }
public System.Int32? IDPhong { get; set; }
public System.Int32? IDTaiKhoan { get; set; }
public System.DateTime? KetThuc { get; set; }
public System.Boolean Status { get; set; }
public System.Int64? ThanhToan { get; set; }
public System.Int64? TongTien { get; set; }
public KhachHangObject KhachHangObjectJoin { get; set; }
public PhongObject PhongObjectJoin { get; set; }
public TaiKhoanObject TaiKhoanObjectJoin { get; set; }
    }
}
