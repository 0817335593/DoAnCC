
using System;
using System.Collections.Generic;

namespace DTO
{
    public class DangKiDatPhongObject
    {
        
public string Email { get; set; }
public string GhiChu { get; set; }
public string HoTen { get; set; }
public System.Int32 ID_DangKi { get; set; }
public System.Int32? ID_Phong { get; set; }
public string Message { get; set; }
public System.DateTime? NgayTao { get; set; }
public string Phone { get; set; }
public byte Status { get; set; }
public System.DateTime? TimeEnd { get; set; }
public System.DateTime? TimeStart { get; set; }
public PhongObject PhongObjectJoin { get; set; }
    }
}
