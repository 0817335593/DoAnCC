
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class HinhAnhDao
    {

        public List<HinhAnhObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_HinhAnh_GetAll();
            List<HinhAnhObject> lst = new List<HinhAnhObject>();
            foreach (var item in list)
            {
                if (item.IsDelete == true) continue;
                var obj = new HinhAnhObject();
                obj.IDHinhAnh = item.IDHinhAnh;
                obj.ImageLink = item.ImageLink;
                obj.IsDelete = item.IsDelete == true;
                obj.Rank = item.Rank;
                lst.Add(obj);
            }
            return lst;
        }


        public HinhAnhObject GetByIDHinhAnh(System.Int32 IDHinhAnh)
        {
            var list = new dbKhachSanEntities().SP_HinhAnh_GetByIDHinhAnh(IDHinhAnh);
            foreach (var item in list)
            {
                var obj = new HinhAnhObject();

                obj.IDHinhAnh = item.IDHinhAnh;
                obj.ImageLink = item.ImageLink;
                obj.IsDelete = item.IsDelete == true;
                obj.Rank = item.Rank;
                return obj;
            }
            return null;
        }


        public bool Insert(HinhAnhObject ob)
        {
            return new dbKhachSanEntities().SP_HinhAnh_Insert(ob.ImageLink, ob.IsDelete, ob.Rank) > 0;
        }


        public bool Delete(System.Int32 IDHinhAnh)
        {
            return new dbKhachSanEntities().SP_HinhAnh_Delete(IDHinhAnh) > 0;
        }


        public bool Update(HinhAnhObject ob)
        {
            return new dbKhachSanEntities().SP_HinhAnh_Update(ob.IDHinhAnh, ob.ImageLink, ob.IsDelete, ob.Rank) > 0;
        }
    }
}
