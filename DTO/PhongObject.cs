
using System;
using System.Collections.Generic;

namespace DTO
{
    public class PhongObject
    {
        public Nullable<bool> Active { get; set; }
        public Nullable<long> GiaPhong { get; set; }
        public Nullable<int> ID_LoaiPhong { get; set; }
        public Nullable<int> ID_ViTri { get; set; }
        public Nullable<int> GiaKM { get; set; }
        public Nullable<int> Star { get; set; }
        public int IDPhong { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string TenPhong { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu_LoaiPhongJoin { get; set; }
        public string TenLoai_LoaiPhongJoin { get; set; }
        public string GhiChu_ViTriJoin { get; set; }
        public string TenViTri_ViTriJoin { get; set; }
        public Nullable<int> IDKhachSan { get; set; }
        public string LinkImage { get; set; }
        public ViTriObject ViTriObjectJoin { get; set; }
        public LoaiPhongObject LoaiPhongObjectJoin { get; set; }
        public TinhThanhObject TinhThanhObjectJoin { get; set; }
        public KhachSanObject KhachSanObjectJoin { get; set; }
    }
}
