
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class LoaiPhongDao
    {

        public List<LoaiPhongObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_LoaiPhong_GetAll();
            List<LoaiPhongObject> lst = new List<LoaiPhongObject>();
            foreach (var item in list)
            {
                var obj = new LoaiPhongObject();

                obj.GhiChu = item.GhiChu;
                obj.ID_LoaiPhong = item.ID_LoaiPhong;
                obj.TenLoai = item.TenLoai;
                lst.Add(obj);
            }
            return lst;
        }


        public LoaiPhongObject GetByID_LoaiPhong(System.Int32 ID_LoaiPhong)
        {
            var list = new dbKhachSanEntities().SP_LoaiPhong_GetByID_LoaiPhong(ID_LoaiPhong);
            foreach (var item in list)
            {
                var obj = new LoaiPhongObject();

                obj.GhiChu = item.GhiChu;
                obj.ID_LoaiPhong = item.ID_LoaiPhong;
                obj.TenLoai = item.TenLoai;
                return obj;
            }
            return null;
        }


        public bool Insert(LoaiPhongObject ob)
        {
            return new dbKhachSanEntities().SP_LoaiPhong_Insert(ob.GhiChu, ob.TenLoai) > 0;
        }


        public bool Delete(System.Int32 ID_LoaiPhong)
        {
            var ob = GetByID_LoaiPhong(ID_LoaiPhong);
            if (ob == null) return false;
            ob.GhiChu = "DA XOA";
            return new dbKhachSanEntities().SP_LoaiPhong_Update(ob.GhiChu, ob.ID_LoaiPhong, ob.TenLoai) > 0;
        }


        public bool Update(LoaiPhongObject ob)
        {
            return new dbKhachSanEntities().SP_LoaiPhong_Update(ob.GhiChu, ob.ID_LoaiPhong, ob.TenLoai) > 0;
        }

    }
}
