
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class LoaiPhongBus
    {

        public List<LoaiPhongObject> GetAll()
        {
            return new LoaiPhongDao().GetAll();
        }


        public LoaiPhongObject GetByID_LoaiPhong(System.Int32 ID_LoaiPhong)
        {
            return new LoaiPhongDao().GetByID_LoaiPhong(ID_LoaiPhong);
        }


        public bool Insert(LoaiPhongObject ob)
        {
            return new LoaiPhongDao().Insert(ob);
        }


        public bool Delete(System.Int32 ID_LoaiPhong)
        {
            return new LoaiPhongDao().Delete(ID_LoaiPhong);
        }


        public bool Update(LoaiPhongObject ob)
        {
            return new LoaiPhongDao().Update(ob);
        }

    }
}
