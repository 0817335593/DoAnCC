
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class TaiKhoanDao
    {

        public List<TaiKhoanObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_TaiKhoan_GetAll();
            List<TaiKhoanObject> lst = new List<TaiKhoanObject>();
            foreach (var item in list)
            {
                var obj = new TaiKhoanObject();

                obj.HoTen = item.HoTen;
                obj.IDChucVu = item.IDChucVu;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.IsDelete = item.IsDelete == true;
                obj.NgaySinh = item.NgaySinh;
                obj.SDT = item.SDT;
                obj.TenDangNhap = item.TenDangNhap;
                obj.ChucVuObjectJoin = new ChucVuObject()
                {

                    GhiChu = item.GhiChu_ChucVuJoin,
                    IDChucVu = (System.Int32)item.IDChucVu,
                    IsDelete = item.IsDelete_ChucVuJoin == true,
                    TenCV = item.TenCV_ChucVuJoin
                };

                lst.Add(obj);
            }
            return lst;
        }


        public TaiKhoanObject GetByIDTaiKhoan(System.Int32 IDTaiKhoan)
        {
            var list = new dbKhachSanEntities().SP_TaiKhoan_GetByIDTaiKhoan(IDTaiKhoan);
            foreach (var item in list)
            {
                var obj = new TaiKhoanObject();

                obj.HoTen = item.HoTen;
                obj.IDChucVu = item.IDChucVu;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.IsDelete = item.IsDelete == true;
                obj.NgaySinh = item.NgaySinh;
                obj.SDT = item.SDT;
                obj.TenDangNhap = item.TenDangNhap;
                obj.ChucVuObjectJoin = new ChucVuObject()
                {

                    GhiChu = item.GhiChu_ChucVuJoin,
                    IDChucVu = (System.Int32)item.IDChucVu,
                    IsDelete = item.IsDelete_ChucVuJoin == true,
                    TenCV = item.TenCV_ChucVuJoin
                };

                return obj;
            }
            return null;
        }


        public bool Insert(TaiKhoanObject ob)
        {
            return new dbKhachSanEntities().SP_TaiKhoan_Insert(ob.HoTen, ob.IDChucVu, ob.IsDelete, ob.MatKhau, ob.NgaySinh, ob.SDT, ob.TenDangNhap) > 0;
        }


        public bool Delete(System.Int32 IDTaiKhoan)
        {
            return new dbKhachSanEntities().SP_TaiKhoan_Delete(IDTaiKhoan) > 0;
        }


        public bool Update(TaiKhoanObject ob)
        {
            return new dbKhachSanEntities().SP_TaiKhoan_Update(ob.HoTen, ob.IDChucVu, ob.IDTaiKhoan, ob.MatKhau, ob.NgaySinh, ob.SDT, ob.TenDangNhap) > 0;
        }


        public TaiKhoanObject CheckLogin(TaiKhoanObject taiKhoanObject)
        {
            var list = new dbKhachSanEntities().SP_TaiKhoan_CheckLogin(taiKhoanObject.TenDangNhap, taiKhoanObject.MatKhau);
            foreach (var item in list)
            {
                var obj = new TaiKhoanObject();

                obj.HoTen = item.HoTen;
                obj.IDChucVu = item.IDChucVu;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.IsDelete = item.IsDelete == true;
                obj.NgaySinh = item.NgaySinh;
                obj.SDT = item.SDT;
                obj.TenDangNhap = item.TenDangNhap;
                obj.ChucVuObjectJoin = new ChucVuObject()
                {
                    IDChucVu = (System.Int32)item.IDChucVu,
                    TenCV = item.TenCV,
                    GhiChu = item.GhiChu,
                    IsDelete = item.IsDelete ?? false
                };

                return obj;
            }
            return null;
        }

        public TaiKhoanObject DoiMatKhau(int IDTaiKhoan, string curent, string newpass)
        {
            var list = new dbKhachSanEntities().SP_TaiKhoan_DoiMatKhau(IDTaiKhoan, curent, newpass);
            foreach (var item in list)
            {
                var obj = new TaiKhoanObject();

                obj.HoTen = item.HoTen;
                obj.IDChucVu = item.IDChucVu;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.IsDelete = item.IsDelete == true;
                obj.NgaySinh = item.NgaySinh;
                obj.SDT = item.SDT;
                obj.TenDangNhap = item.TenDangNhap;
                obj.ChucVuObjectJoin = new ChucVuObject()
                {
                    GhiChu = item.GhiChu_ChucVuJoin,
                    IDChucVu = (System.Int32)item.IDChucVu,
                    IsDelete = item.IsDelete_ChucVuJoin == true,
                    TenCV = item.TenCV_ChucVuJoin
                };

                return obj;
            }
            return null;
        }
    }
}
