
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class TinhThanhBus
    {

        public List<TinhThanhObject> GetAll()
        {
            return new TinhThanhDao().GetAll();
        }


        public TinhThanhObject GetByIDTinhThanh(System.Int32 ID_TinhThanh)
        {
            return new TinhThanhDao().GetByIDTinhThanh(ID_TinhThanh);
        }


        public bool Insert(TinhThanhObject ob)
        {
            return new TinhThanhDao().Insert(ob);
        }


        public bool Delete(System.Int32 ID_TinhThanh)
        {
            return new TinhThanhDao().Delete(ID_TinhThanh);
        }


        public bool Update(TinhThanhObject ob)
        {
            return new TinhThanhDao().Update(ob);
        }

    }
}
