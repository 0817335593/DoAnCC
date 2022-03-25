
using System;
using System.Collections.Generic;

namespace DTO
{
    public class Phong_HinhAnhObject
    {
        
public string GhiChu { get; set; }
public System.Int32? IDHinhAnh { get; set; }
public System.Int32? IDPhong { get; set; }
public System.Int32 IDPhong_HinhAnh { get; set; }
public System.Int32? Rank { get; set; }
public HinhAnhObject HinhAnhObjectJoin { get; set; }
public PhongObject PhongObjectJoin { get; set; }
    }
}
