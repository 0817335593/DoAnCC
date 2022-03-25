
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class GiaoDichDao
    {

        public List<GiaoDichObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_GiaoDich_GetAll();
            List<GiaoDichObject> lst = new List<GiaoDichObject>();
            foreach (var item in list)
            {
                var obj = new GiaoDichObject();

                obj.BuyTime = item.BuyTime;
                obj.IDDatPhong = item.IDDatPhong;
                obj.IDDichVu = item.IDDichVu;
                obj.IDGiaoDich = item.IDGiaoDich;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.SoLuong = item.SoLuong;
                obj.DatPhongObjectJoin = new DatPhongObject()
                {

                    BatDau = item.BatDau_DatPhongJoin,
                    IDDatPhong = (System.Int32)item.IDDatPhong,
                    IDKhachHang = item.IDKhachHang_DatPhongJoin,
                    IDPhong = item.IDPhong_DatPhongJoin,
                    IDTaiKhoan = item.IDTaiKhoan_DatPhongJoin,
                    KetThuc = item.KetThuc_DatPhongJoin,
                    Status = item.Status_DatPhongJoin == true,
                    ThanhToan = item.ThanhToan_DatPhongJoin ?? 0,
                    TongTien = item.TongTien_DatPhongJoin ?? 0
                };

                obj.DichVuObjectJoin = new DichVuObject()
                {

                    Active = item.Active_DichVuJoin == true,
                    DonVi = item.DonVi_DichVuJoin,
                    GhiChu = item.GhiChu_DichVuJoin,
                    GiaTien = item.GiaTien_DichVuJoin,
                    IDDichVu = (System.Int32)item.IDDichVu,
                    IsDelete = item.IsDelete_DichVuJoin == true,
                    TenDichVu = item.TenDichVu_DichVuJoin
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


        public GiaoDichObject GetByIDGiaoDich(System.Int32 IDGiaoDich)
        {
            var list = new dbKhachSanEntities().SP_GiaoDich_GetByIDGiaoDich(IDGiaoDich);
            foreach (var item in list)
            {
                var obj = new GiaoDichObject();

                obj.BuyTime = item.BuyTime;
                obj.IDDatPhong = item.IDDatPhong;
                obj.IDDichVu = item.IDDichVu;
                obj.IDGiaoDich = item.IDGiaoDich;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.SoLuong = item.SoLuong;
                obj.DatPhongObjectJoin = new DatPhongObject()
                {

                    BatDau = item.BatDau_DatPhongJoin,
                    IDDatPhong = (System.Int32)item.IDDatPhong,
                    IDKhachHang = item.IDKhachHang_DatPhongJoin,
                    IDPhong = item.IDPhong_DatPhongJoin,
                    IDTaiKhoan = item.IDTaiKhoan_DatPhongJoin,
                    KetThuc = item.KetThuc_DatPhongJoin,
                    Status = item.Status_DatPhongJoin == true,
                    ThanhToan = item.ThanhToan_DatPhongJoin ?? 0,
                    TongTien = item.TongTien_DatPhongJoin ?? 0
                };

                obj.DichVuObjectJoin = new DichVuObject()
                {

                    Active = item.Active_DichVuJoin == true,
                    DonVi = item.DonVi_DichVuJoin,
                    GhiChu = item.GhiChu_DichVuJoin,
                    GiaTien = item.GiaTien_DichVuJoin,
                    IDDichVu = (System.Int32)item.IDDichVu,
                    IsDelete = item.IsDelete_DichVuJoin == true,
                    TenDichVu = item.TenDichVu_DichVuJoin
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


        public bool Insert(GiaoDichObject ob)
        {
            return new dbKhachSanEntities().SP_GiaoDich_Insert(ob.BuyTime, ob.IDDatPhong, ob.IDDichVu, ob.IDTaiKhoan, ob.SoLuong) > 0;
        }


        public bool Delete(System.Int32 IDGiaoDich)
        {
            return new dbKhachSanEntities().SP_GiaoDich_Delete(IDGiaoDich) > 0;
        }


        public bool Update(GiaoDichObject ob)
        {
            return new dbKhachSanEntities().SP_GiaoDich_Update(ob.BuyTime, ob.IDDatPhong, ob.IDDichVu, ob.IDGiaoDich, ob.IDTaiKhoan, ob.SoLuong) > 0;
        }

        public List<GiaoDichObject> GetByIDDatPhong(int id)
        {
            var list = new dbKhachSanEntities().SP_GiaoDich_GetBy_IDDatPhong(id);
            List<GiaoDichObject> lst = new List<GiaoDichObject>();
            foreach (var item in list)
            {
                var obj = new GiaoDichObject();

                obj.BuyTime = item.BuyTime;
                obj.IDDatPhong = item.IDDatPhong;
                obj.IDDichVu = item.IDDichVu;
                obj.IDGiaoDich = item.IDGiaoDich;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.SoLuong = item.SoLuong;
                obj.DatPhongObjectJoin = new DatPhongObject()
                {

                    BatDau = item.BatDau_DatPhongJoin,
                    IDDatPhong = (System.Int32)item.IDDatPhong,
                    IDKhachHang = item.IDKhachHang_DatPhongJoin,
                    IDPhong = item.IDPhong_DatPhongJoin,
                    IDTaiKhoan = item.IDTaiKhoan_DatPhongJoin,
                    KetThuc = item.KetThuc_DatPhongJoin,
                    Status = item.Status_DatPhongJoin == true,
                    ThanhToan = item.ThanhToan_DatPhongJoin ?? 0,
                    TongTien = item.TongTien_DatPhongJoin ?? 0
                };

                obj.DichVuObjectJoin = new DichVuObject()
                {

                    Active = item.Active_DichVuJoin == true,
                    DonVi = item.DonVi_DichVuJoin,
                    GhiChu = item.GhiChu_DichVuJoin,
                    GiaTien = item.GiaTien_DichVuJoin,
                    IDDichVu = (System.Int32)item.IDDichVu,
                    IsDelete = item.IsDelete_DichVuJoin == true,
                    TenDichVu = item.TenDichVu_DichVuJoin
                };

                obj.TaiKhoanObjectJoin = new TaiKhoanObject()
                {

                    HoTen = item.HoTen_TaiKhoanJoin,
                    IDChucVu = item.IDChucVu_TaiKhoanJoin,
                    IDTaiKhoan = (System.Int32)item.IDTaiKhoan,
                    IsDelete = item.IsDelete_TaiKhoanJoin == true,
                    NgaySinh = item.NgaySinh_TaiKhoanJoin,
                    SDT = item.SDT_TaiKhoanJoin,
                    TenDangNhap = item.TenDangNhap_TaiKhoanJoin
                };

                lst.Add(obj);
            }
            return lst;
        }

    }
}
