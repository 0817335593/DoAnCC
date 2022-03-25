
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class DangKiDatPhongBus
    {

        public List<DangKiDatPhongObject> GetAll()
        {
            return new DangKiDatPhongDao().GetAll();
        }


        public DangKiDatPhongObject GetByID_DangKi(System.Int32 ID_DangKi)
        {
            return new DangKiDatPhongDao().GetByID_DangKi(ID_DangKi);
        }


        public bool Insert(DangKiDatPhongObject ob)
        {
            return new DangKiDatPhongDao().Insert(ob);
        }


        public bool Delete(System.Int32 ID_DangKi)
        {
            return new DangKiDatPhongDao().Delete(ID_DangKi);
        }


        public bool Update(DangKiDatPhongObject ob)
        {
            return new DangKiDatPhongDao().Update(ob);
        }

    }
}
