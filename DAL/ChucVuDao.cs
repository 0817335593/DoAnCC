
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class ChucVuDao
    {

        public List<ChucVuObject> GetAll()
        {
            var list = new dbKhachSanEntities().SP_ChucVu_GetAll();
            List<ChucVuObject> lst = new List<ChucVuObject>();
            foreach (var item in list)
            {
                var obj = new ChucVuObject();

                obj.GhiChu = item.GhiChu;
                obj.IDChucVu = item.IDChucVu;
                obj.IsDelete = item.IsDelete == true;
                obj.TenCV = item.TenCV;
                lst.Add(obj);
            }
            return lst;
        }


        public ChucVuObject GetByIDChucVu(System.Int32 IDChucVu)
        {
            var list = new dbKhachSanEntities().SP_ChucVu_GetByIDChucVu(IDChucVu);
            foreach (var item in list)
            {
                var obj = new ChucVuObject();

                obj.GhiChu = item.GhiChu;
                obj.IDChucVu = item.IDChucVu;
                obj.IsDelete = item.IsDelete == true;
                obj.TenCV = item.TenCV;
                return obj;
            }
            return null;
        }


        public bool Insert(ChucVuObject ob)
        {
            return new dbKhachSanEntities().SP_ChucVu_Insert(ob.GhiChu, ob.IsDelete, ob.TenCV) > 0;
        }


        public bool Delete(System.Int32 IDChucVu)
        {
            return new dbKhachSanEntities().SP_ChucVu_Delete(IDChucVu) > 0;
        }


        public bool Update(ChucVuObject ob)
        {
            return new dbKhachSanEntities().SP_ChucVu_Update(ob.GhiChu, ob.IDChucVu, ob.IsDelete, ob.TenCV) > 0;
        }

    }
}
