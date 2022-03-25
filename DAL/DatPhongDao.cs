
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class DatPhongDao
    {

        public List<DatPhongObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_DatPhong_GetAll();
            List<DatPhongObject> lst = new List<DatPhongObject>();
            foreach (var item in list)
            {
                var obj = new DatPhongObject();

                obj.BatDau = item.BatDau;
                obj.IDDatPhong = item.IDDatPhong;
                obj.IDKhachHang = item.IDKhachHang;
                obj.IDPhong = item.IDPhong;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.KetThuc = item.KetThuc;
                obj.Status = item.Status == true;
                obj.ThanhToan = item.ThanhToan;
                obj.TongTien = item.TongTien;
                obj.KhachHangObjectJoin = new KhachHangObject()
                {

                    CMT = item.CMT_KhachHangJoin,
                    DiaChi = item.DiaChi_KhachHangJoin,
                    GhiChu = item.GhiChu_KhachHangJoin,
                    HoTen = item.HoTen_KhachHangJoin,
                    IDKhachHang = (System.Guid)item.IDKhachHang,
                    IsDelete = item.IsDelete_KhachHangJoin == true,
                    IsMale = item.IsMale_KhachHangJoin == true,
                    NgaySinh = item.NgaySinh_KhachHangJoin,
                    SDT = item.SDT_KhachHangJoin
                };

                obj.PhongObjectJoin = new PhongObject()
                {
                    IDKhachSan = item.IDKhachSan_PhongJoin,
                    Active = item.Active_PhongJoin == true,
                    GiaPhong = item.GiaPhong_PhongJoin,
                    ID_LoaiPhong = item.ID_LoaiPhong_PhongJoin,
                    ID_ViTri = item.ID_ViTri_PhongJoin,
                    IDPhong = (System.Int32)item.IDPhong,
                    IsDelete = item.IsDelete_PhongJoin == true,
                    TenPhong = item.TenPhong_PhongJoin,
                    TrangThai = item.TrangThai_PhongJoin,
                    ViTriObjectJoin = new ViTriObject()
                    {
                        ID_ViTri = item.ID_ViTri_PhongJoin.Value,
                        TenViTri = item.TenViTri
                    },
                    KhachSanObjectJoin = new KhachSanObject
                    {
                        TenKhachSan = item.TenKhachSan
                    },
                    TinhThanhObjectJoin = new TinhThanhObject
                    {
                        TenTinh = item.TenTinh
                    }
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


        public DatPhongObject GetByIDDatPhong(System.Int32 IDDatPhong)
        {
            var list = new dbKhachSanEntities().SP_DatPhong_GetByIDDatPhong(IDDatPhong);
            foreach (var item in list)
            {
                var obj = new DatPhongObject();

                obj.BatDau = item.BatDau;
                obj.IDDatPhong = item.IDDatPhong;
                obj.IDKhachHang = item.IDKhachHang;
                obj.IDPhong = item.IDPhong;
                obj.IDTaiKhoan = item.IDTaiKhoan;
                obj.KetThuc = item.KetThuc;
                obj.Status = item.Status == true;
                obj.ThanhToan = item.ThanhToan;
                obj.TongTien = item.TongTien;
                obj.KhachHangObjectJoin = new KhachHangObject()
                {

                    CMT = item.CMT_KhachHangJoin,
                    DiaChi = item.DiaChi_KhachHangJoin,
                    GhiChu = item.GhiChu_KhachHangJoin,
                    HoTen = item.HoTen_KhachHangJoin,
                    IDKhachHang = (System.Guid)item.IDKhachHang,
                    IsDelete = item.IsDelete_KhachHangJoin == true,
                    IsMale = item.IsMale_KhachHangJoin == true,
                    NgaySinh = item.NgaySinh_KhachHangJoin,
                    SDT = item.SDT_KhachHangJoin
                };

                obj.PhongObjectJoin = new PhongObject()
                {
                    IDKhachSan = item.IDKhachSan_PhongJoin,
                    Active = item.Active_PhongJoin == true,
                    GiaPhong = item.GiaPhong_PhongJoin,
                    ID_LoaiPhong = item.ID_LoaiPhong_PhongJoin,
                    ID_ViTri = item.ID_ViTri_PhongJoin,
                    IDPhong = (System.Int32)item.IDPhong,
                    IsDelete = item.IsDelete_PhongJoin == true,
                    TenPhong = item.TenPhong_PhongJoin,
                    TrangThai = item.TrangThai_PhongJoin,
                    ViTriObjectJoin = new ViTriObject()
                    {
                        ID_ViTri = item.ID_ViTri_PhongJoin.Value,
                        TenViTri = item.TenViTri
                    }
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


        public bool Insert(DatPhongObject ob)
        {
            return new dbKhachSanEntities().SP_DatPhong_Insert(ob.BatDau, ob.IDKhachHang, ob.IDPhong, ob.IDTaiKhoan, ob.KetThuc, ob.Status, ob.ThanhToan, ob.TongTien) > 0;
        }


        public bool Delete(System.Int32 IDDatPhong)
        {
            return new dbKhachSanEntities().SP_DatPhong_Delete(IDDatPhong) > 0;
        }


        public bool Update(DatPhongObject ob)
        {
            return new dbKhachSanEntities().SP_DatPhong_Update(ob.BatDau, ob.IDDatPhong, ob.IDKhachHang, ob.IDPhong, ob.IDTaiKhoan, ob.KetThuc, ob.Status, ob.ThanhToan, ob.TongTien) > 0;
        }

    }
}
