
using System;
using System.Linq;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class KhachHangDao
    {

        public List<KhachHangObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_KhachHang_GetAll();
            List<KhachHangObject> lst = new List<KhachHangObject>();
            foreach (var item in list)
            {
                var obj = new KhachHangObject();

                obj.CMT = item.CMT;
                obj.DiaChi = item.DiaChi;
                obj.GhiChu = item.GhiChu;
                obj.HoTen = item.HoTen;
                obj.IDKhachHang = item.IDKhachHang;
                obj.IsDelete = item.IsDelete == true;
                obj.IsMale = item.IsMale == true;
                obj.NgaySinh = item.NgaySinh;
                obj.SDT = item.SDT;
                lst.Add(obj);
            }
            return lst;
        }

        public KhachHangObject GetByIDKhachHang(System.Guid IDKhachHang)
        {
            var list = new dbKhachSanEntities().SP_KhachHang_GetByIDKhachHang(IDKhachHang);
            foreach (var item in list)
            {
                var obj = new KhachHangObject();

                obj.CMT = item.CMT;
                obj.DiaChi = item.DiaChi;
                obj.GhiChu = item.GhiChu;
                obj.HoTen = item.HoTen;
                obj.IDKhachHang = item.IDKhachHang;
                obj.IsDelete = item.IsDelete == true;
                obj.IsMale = item.IsMale == true;
                obj.NgaySinh = item.NgaySinh;
                obj.SDT = item.SDT;
                return obj;
            }
            return null;
        }


        public bool Insert(KhachHangObject ob)
        {
            return new dbKhachSanEntities().SP_KhachHang_Insert(ob.CMT, ob.DiaChi, ob.GhiChu, ob.HoTen, ob.IDKhachHang, ob.IsDelete, ob.IsMale, ob.NgaySinh, ob.SDT) > 0;
        }


        public bool Delete(System.Guid IDKhachHang)
        {
            return new dbKhachSanEntities().SP_KhachHang_Delete(IDKhachHang) > 0;
        }


        public bool Update(KhachHangObject ob)
        {
            return new dbKhachSanEntities().SP_KhachHang_Update(ob.CMT, ob.DiaChi, ob.GhiChu, ob.HoTen, ob.IDKhachHang, ob.IsDelete, ob.IsMale, ob.NgaySinh, ob.SDT) > 0;
        }

    }
}
