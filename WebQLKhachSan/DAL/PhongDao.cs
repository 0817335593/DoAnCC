
using System.Linq;
using System.Collections.Generic;
using DTO;
using DAL.Model;
using System;

namespace DAL
{
    public class PhongDao
    {

        public List<PhongObject> GetAll(int IDKhachSan)
        {
            return (from o in new dbKhachSanEntities().Phongs.ToList().Where(q => q.IsDelete != true && q.IDKhachSan == IDKhachSan)
                    select new PhongObject
                    {
                        Active = o.Active,
                        GiaPhong = o.GiaPhong,
                        IDKhachSan = o.IDKhachSan,
                        IDPhong = o.IDPhong,
                        ID_ViTri = o.ID_ViTri,
                        IsDelete = o.IsDelete,
                        LinkImage = o.Phong_HinhAnh.FirstOrDefault() + "",
                        GiaKM = o.GiaKM,
                        Star = o.Star,
                        LoaiPhongObjectJoin = new LoaiPhongObject
                        {
                            GhiChu = o.LoaiPhong.GhiChu,
                            ID_LoaiPhong = o.LoaiPhong.ID_LoaiPhong,
                            TenLoai = o.LoaiPhong.TenLoai
                        },
                        TenPhong = o.TenPhong,
                        TrangThai = o.TrangThai,
                        ViTriObjectJoin = new ViTriObject
                        {
                            GhiChu = o.ViTri.GhiChu,
                            ID_ViTri = (System.Int32)o.ID_ViTri,
                            TenViTri = o.ViTri.TenViTri
                        },
                        KhachSanObjectJoin = new KhachSanObject
                        {
                            TenKhachSan = o.KhachSan.TenKhachSan
                        },
                        TinhThanhObjectJoin = new TinhThanhObject
                        {
                            IDTinhThanh = o.KhachSan.TinhThanh.IDTinhThanh,
                            TenTinh = o.KhachSan.TinhThanh.TenTinh
                        }
                    }
                    ).ToList();
        }

        public List<PhongObject> GetAll()
        {
            return (from o in new dbKhachSanEntities().Phongs.ToList().Where(q => q.IsDelete != true)
                    select new PhongObject
                    {
                        Active = o.Active,
                        GiaPhong = o.GiaPhong,
                        IDKhachSan = o.IDKhachSan,
                        IDPhong = o.IDPhong,
                        ID_ViTri = o.ID_ViTri,
                        IsDelete = o.IsDelete,
                        LinkImage = o.Phong_HinhAnh.FirstOrDefault() + "",
                        GiaKM = o.GiaKM,
                        Star = o.Star,
                        LoaiPhongObjectJoin = new LoaiPhongObject
                        {
                            GhiChu = o.LoaiPhong.GhiChu,
                            ID_LoaiPhong = o.LoaiPhong.ID_LoaiPhong,
                            TenLoai = o.LoaiPhong.TenLoai
                        },
                        TenPhong = o.TenPhong,
                        TrangThai = o.TrangThai,
                        ViTriObjectJoin = new ViTriObject
                        {
                            GhiChu = o.ViTri.GhiChu,
                            ID_ViTri = (System.Int32)o.ID_ViTri,
                            TenViTri = o.ViTri.TenViTri
                        },
                        KhachSanObjectJoin = new KhachSanObject
                        {
                            TenKhachSan = o.KhachSan.TenKhachSan
                        },
                        TinhThanhObjectJoin = new TinhThanhObject
                        {
                            IDTinhThanh = o.KhachSan.TinhThanh.IDTinhThanh,
                            TenTinh = o.KhachSan.TinhThanh.TenTinh
                        }
                    }
                    ).ToList();
        }

        public PhongObject GetByIDPhong(System.Int32 IDPhong)
        {
            var list = new dbKhachSanEntities().SP_Phong_GetByIDPhong(IDPhong);
            foreach (var item in list)
            {
                var obj = new PhongObject();

                obj.Active = item.Active == true;
                obj.GiaPhong = item.GiaPhong;
                obj.ID_LoaiPhong = item.ID_LoaiPhong;
                obj.ID_ViTri = item.ID_ViTri;
                obj.IDPhong = item.IDPhong;
                obj.IsDelete = item.IsDelete == true;
                obj.TenPhong = item.TenPhong;
                obj.TrangThai = item.TrangThai;
                obj.IDKhachSan = item.IDKhachSan;
                obj.GiaKM = item.GiaKM;
                obj.Star = item.Star;
                obj.LoaiPhongObjectJoin = new LoaiPhongObject()
                {
                    GhiChu = item.GhiChu_LoaiPhongJoin,
                    ID_LoaiPhong = (System.Int32)item.ID_LoaiPhong,
                    TenLoai = item.TenLoai_LoaiPhongJoin
                };

                obj.ViTriObjectJoin = new ViTriObject()
                {

                    GhiChu = item.GhiChu_ViTriJoin,
                    ID_ViTri = (System.Int32)item.ID_ViTri,
                    TenViTri = item.TenViTri_ViTriJoin
                };
                obj.KhachSanObjectJoin = new KhachSanObject
                {
                    TenKhachSan = item.TenKhachSan
                };
                obj.TinhThanhObjectJoin = new TinhThanhObject
                {
                    TenTinh = item.TenTinh
                };
                return obj;
            }
            return null;
        }


        public bool Insert(PhongObject ob)
        {
            return new dbKhachSanEntities().SP_Phong_Insert(ob.Active, ob.GiaPhong, ob.ID_LoaiPhong, ob.ID_ViTri, ob.IDKhachSan, ob.IsDelete, ob.TenPhong, ob.TrangThai, ob.GiaKM, ob.Star) > 0;
        }


        public bool Delete(System.Int32 IDPhong)
        {
            return new dbKhachSanEntities().SP_Phong_Delete(IDPhong) > 0;
        }


        public bool Update(PhongObject ob)
        {
            return new dbKhachSanEntities().SP_Phong_Update(ob.Active, ob.GiaPhong, ob.ID_LoaiPhong, ob.IDKhachSan, ob.ID_ViTri, ob.IDPhong, ob.IsDelete, ob.TenPhong, ob.TrangThai, ob.GiaKM, ob.Star) > 0;
        }

    }
}
