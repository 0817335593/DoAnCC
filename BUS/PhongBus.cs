
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class PhongBus
    {

        public List<PhongObject> GetAll(int IDKhachSan)
        {
            return new PhongDao().GetAll(IDKhachSan);
        }

        public List<PhongObject> GetAll()
        {
            return new PhongDao().GetAll();
        }


        public PhongObject GetByIDPhong(System.Int32 IDPhong)
        {
            return new PhongDao().GetByIDPhong(IDPhong);
        }


        public bool Insert(PhongObject ob)
        {
            return new PhongDao().Insert(ob);
        }


        public bool Delete(System.Int32 IDPhong)
        {
            return new PhongDao().Delete(IDPhong);
        }


        public bool Update(PhongObject ob)
        {
            return new PhongDao().Update(ob);
        }

    }
}
