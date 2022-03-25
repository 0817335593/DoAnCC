
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class ViTriDao
    {

        public List<ViTriObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_ViTri_GetAll();
            List<ViTriObject> lst = new List<ViTriObject>();
            foreach (var item in list)
            {
                var obj = new ViTriObject();

                obj.GhiChu = item.GhiChu;
                obj.ID_ViTri = item.ID_ViTri;
                obj.TenViTri = item.TenViTri;
                lst.Add(obj);
            }
            return lst;
        }


        public ViTriObject GetByID_ViTri(System.Int32 ID_ViTri)
        {
            var list = new dbKhachSanEntities().SP_ViTri_GetByID_ViTri(ID_ViTri);
            foreach (var item in list)
            {
                var obj = new ViTriObject();

                obj.GhiChu = item.GhiChu;
                obj.ID_ViTri = item.ID_ViTri;
                obj.TenViTri = item.TenViTri;
                return obj;
            }
            return null;
        }


        public bool Insert(ViTriObject ob)
        {
            return new dbKhachSanEntities().SP_ViTri_Insert(ob.GhiChu, ob.TenViTri) > 0;
        }


        public bool Delete(System.Int32 ID_ViTri)
        {
            var ob = GetByID_ViTri(ID_ViTri);
            if (ob == null) return false;
            ob.GhiChu = "DA XOA";
            return new dbKhachSanEntities().SP_ViTri_Update(ob.GhiChu, ob.ID_ViTri, ob.TenViTri) > 0;
        }


        public bool Update(ViTriObject ob)
        {
            return new dbKhachSanEntities().SP_ViTri_Update(ob.GhiChu, ob.ID_ViTri, ob.TenViTri) > 0;
        }

    }
}
