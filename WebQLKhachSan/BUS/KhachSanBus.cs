
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class KhachSanBus
    {

        public List<KhachSanObject> GetAll()
        {
            return new KhachSanDao().GetAll();
        }


        public KhachSanObject GetByIDKhachSan(System.Int32 ID_KhachSan)
        {
            return new KhachSanDao().GetByIDKhachSan(ID_KhachSan);
        }


        public bool Insert(KhachSanObject ob)
        {
            return new KhachSanDao().Insert(ob);
        }


        public bool Delete(System.Int32 ID_KhachSan)
        {
            return new KhachSanDao().Delete(ID_KhachSan);
        }


        public bool Update(KhachSanObject ob)
        {
            return new KhachSanDao().Update(ob);
        }

    }
}
