
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class Phong_HinhAnhDao
    {

        public List<Phong_HinhAnhObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_Phong_HinhAnh_GetAll();
            List<Phong_HinhAnhObject> lst = new List<Phong_HinhAnhObject>();
            foreach (var item in list)
            {
                var obj = new Phong_HinhAnhObject();

                obj.GhiChu = item.GhiChu;
                obj.IDHinhAnh = item.IDHinhAnh;
                obj.IDPhong = item.IDPhong;
                obj.IDPhong_HinhAnh = item.IDPhong_HinhAnh;
                obj.Rank = item.Rank;
                obj.HinhAnhObjectJoin = new HinhAnhObject()
                {

                    IDHinhAnh = (System.Int32)item.IDHinhAnh,
                    ImageLink = item.ImageLink_HinhAnhJoin,
                    IsDelete = item.IsDelete_HinhAnhJoin == true,
                    Rank = item.Rank_HinhAnhJoin
                };

                obj.PhongObjectJoin = new PhongObject()
                {

                    Active = item.Active_PhongJoin == true,
                    GiaPhong = item.GiaPhong_PhongJoin,
                    ID_LoaiPhong = item.ID_LoaiPhong_PhongJoin,
                    ID_ViTri = item.ID_ViTri_PhongJoin,
                    IDPhong = (System.Int32)item.IDPhong,
                    IsDelete = item.IsDelete_PhongJoin == true,
                    TenPhong = item.TenPhong_PhongJoin,
                    TrangThai = item.TrangThai_PhongJoin
                };

                lst.Add(obj);
            }
            return lst;
        }


        public Phong_HinhAnhObject GetByIDPhong_HinhAnh(System.Int32 IDPhong_HinhAnh)
        {
            var list = new dbKhachSanEntities().SP_Phong_HinhAnh_GetByIDPhong_HinhAnh(IDPhong_HinhAnh);
            foreach (var item in list)
            {
                var obj = new Phong_HinhAnhObject();

                obj.GhiChu = item.GhiChu;
                obj.IDHinhAnh = item.IDHinhAnh;
                obj.IDPhong = item.IDPhong;
                obj.IDPhong_HinhAnh = item.IDPhong_HinhAnh;
                obj.Rank = item.Rank;
                obj.HinhAnhObjectJoin = new HinhAnhObject()
                {

                    IDHinhAnh = (System.Int32)item.IDHinhAnh,
                    ImageLink = item.ImageLink_HinhAnhJoin,
                    IsDelete = item.IsDelete_HinhAnhJoin == true,
                    Rank = item.Rank_HinhAnhJoin
                };

                obj.PhongObjectJoin = new PhongObject()
                {

                    Active = item.Active_PhongJoin == true,
                    GiaPhong = item.GiaPhong_PhongJoin,
                    ID_LoaiPhong = item.ID_LoaiPhong_PhongJoin,
                    ID_ViTri = item.ID_ViTri_PhongJoin,
                    IDPhong = (System.Int32)item.IDPhong,
                    IsDelete = item.IsDelete_PhongJoin == true,
                    TenPhong = item.TenPhong_PhongJoin,
                    TrangThai = item.TrangThai_PhongJoin
                };

                return obj;
            }
            return null;
        }

        public List<Phong_HinhAnhObject> GetByIDPhong(System.Int32 IDPhong)
        {
            var list = new dbKhachSanEntities().SP_Phong_HinhAnh_GetByIDPhong(IDPhong);
            List<Phong_HinhAnhObject> lst = new List<Phong_HinhAnhObject>();
            foreach (var item in list)
            {
                var obj = new Phong_HinhAnhObject();

                obj.GhiChu = item.GhiChu;
                obj.IDHinhAnh = item.IDHinhAnh;
                obj.IDPhong = item.IDPhong;
                obj.IDPhong_HinhAnh = item.IDPhong_HinhAnh;
                obj.Rank = item.Rank;
                obj.HinhAnhObjectJoin = new HinhAnhObject()
                {

                    IDHinhAnh = (System.Int32)item.IDHinhAnh,
                    ImageLink = item.ImageLink_HinhAnhJoin,
                    IsDelete = item.IsDelete_HinhAnhJoin == true,
                    Rank = item.Rank_HinhAnhJoin
                };

                obj.PhongObjectJoin = new PhongObject()
                {

                    Active = item.Active_PhongJoin == true,
                    GiaPhong = item.GiaPhong_PhongJoin,
                    ID_LoaiPhong = item.ID_LoaiPhong_PhongJoin,
                    ID_ViTri = item.ID_ViTri_PhongJoin,
                    IDPhong = (System.Int32)item.IDPhong,
                    IsDelete = item.IsDelete_PhongJoin == true,
                    TenPhong = item.TenPhong_PhongJoin,
                    TrangThai = item.TrangThai_PhongJoin
                };

                lst.Add(obj);
            }
            return lst;
        }


        public bool Insert(Phong_HinhAnhObject ob)
        {
            return new dbKhachSanEntities().SP_Phong_HinhAnh_Insert(ob.GhiChu, ob.IDHinhAnh, ob.IDPhong, ob.Rank) > 0;
        }


        public bool Delete(System.Int32 IDPhong_HinhAnh)
        {
            return new dbKhachSanEntities().SP_Phong_HinhAnh_Delete(IDPhong_HinhAnh) > 0;
        }


        public bool Update(Phong_HinhAnhObject ob)
        {
            return new dbKhachSanEntities().SP_Phong_HinhAnh_Update(ob.GhiChu, ob.IDHinhAnh, ob.IDPhong, ob.IDPhong_HinhAnh, ob.Rank) > 0;
        }

    }
}
