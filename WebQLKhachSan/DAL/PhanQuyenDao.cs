using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class PhanQuyenDao
    {

        public List<PhanQuyenObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_PhanQuyen_GetAll();
            List<PhanQuyenObject> lst = new List<PhanQuyenObject>();
            foreach (var item in list)
            {
                var obj = new PhanQuyenObject();

                obj.IDQuyen = item.IDQuyen;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.QuyenObjectJoin = new QuyenObject()
                {

                    GhiChu = item.GhiChu_QuyenJoin,
                    IDQuyen = (System.Int32)item.IDQuyen,
                    TenQuyen = item.TenQuyen_QuyenJoin
                };

                obj.TaiKhoanObjectJoin = new TaiKhoanObject()
                {

                    HoTen = item.HoTen_TaiKhoanJoin,
                    IDChucVu = item.IDChucVu_TaiKhoanJoin,
                    IDTaiKhoan = (System.Int32)item.IDTaiKhoan,
                    IsDelete = item.IsDelete_TaiKhoanJoin == true,
                    MatKhau = item.MatKhau_TaiKhoanJoin,
                    NgaySinh = item.NgaySinh_TaiKhoanJoin,
                    SDT = item.SDT_TaiKhoanJoin,
                    TenDangNhap = item.TenDangNhap_TaiKhoanJoin
                };

                lst.Add(obj);
            }
            return lst;
        }


        public PhanQuyenObject GetByIDQuyen(System.Int32 IDQuyen)
        {
            var list = new dbKhachSanEntities().SP_PhanQuyen_GetByIDQuyen(IDQuyen);
            foreach (var item in list)
            {
                var obj = new PhanQuyenObject();

                obj.IDQuyen = item.IDQuyen;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.QuyenObjectJoin = new QuyenObject()
                {

                    GhiChu = item.GhiChu_QuyenJoin,
                    IDQuyen = (System.Int32)item.IDQuyen,
                    TenQuyen = item.TenQuyen_QuyenJoin
                };

                obj.TaiKhoanObjectJoin = new TaiKhoanObject()
                {

                    HoTen = item.HoTen_TaiKhoanJoin,
                    IDChucVu = item.IDChucVu_TaiKhoanJoin,
                    IDTaiKhoan = (System.Int32)item.IDTaiKhoan,
                    IsDelete = item.IsDelete_TaiKhoanJoin == true,
                    MatKhau = item.MatKhau_TaiKhoanJoin,
                    NgaySinh = item.NgaySinh_TaiKhoanJoin,
                    SDT = item.SDT_TaiKhoanJoin,
                    TenDangNhap = item.TenDangNhap_TaiKhoanJoin
                };

                return obj;
            }
            return null;
        }

        public List<PhanQuyenObject> GetByIDTaiKhoan(System.Int32 IDTaiKhoan)
        {
            var list = new dbKhachSanEntities().SP_PhanQuyen_GetByIDTaiKhoan(IDTaiKhoan);
            List<PhanQuyenObject> lst = new List<PhanQuyenObject>();
            foreach (var item in list)
            {
                var obj = new PhanQuyenObject();

                obj.IDQuyen = item.IDQuyen;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.QuyenObjectJoin = new QuyenObject()
                {

                    GhiChu = item.GhiChu_QuyenJoin,
                    IDQuyen = (System.Int32)item.IDQuyen,
                    TenQuyen = item.TenQuyen_QuyenJoin
                };

                obj.TaiKhoanObjectJoin = new TaiKhoanObject()
                {

                    HoTen = item.HoTen_TaiKhoanJoin,
                    IDChucVu = item.IDChucVu_TaiKhoanJoin,
                    IDTaiKhoan = (System.Int32)item.IDTaiKhoan,
                    IsDelete = item.IsDelete_TaiKhoanJoin == true,
                    MatKhau = item.MatKhau_TaiKhoanJoin,
                    NgaySinh = item.NgaySinh_TaiKhoanJoin,
                    SDT = item.SDT_TaiKhoanJoin,
                    TenDangNhap = item.TenDangNhap_TaiKhoanJoin
                };

                lst.Add(obj);
            }
            return lst;
        }


        public bool Insert(PhanQuyenObject ob)
        {
            return new dbKhachSanEntities().SP_PhanQuyen_Insert(ob.IDQuyen, ob.IDTaiKhoan) > 0;
        }


        public bool Delete(System.Int32 IDQuyen, System.Int32 IDTaiKhoan)
        {
            return new dbKhachSanEntities().SP_PhanQuyen_Delete(IDQuyen, IDTaiKhoan) > 0;
        }


    }
}
