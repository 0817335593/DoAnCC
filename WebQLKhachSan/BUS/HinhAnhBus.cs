
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class HinhAnhBus
    {

        public List<HinhAnhObject> GetAll()
        {
            return new HinhAnhDao().GetAll();
        }


        public HinhAnhObject GetByIDHinhAnh(System.Int32 IDHinhAnh)
        {
            return new HinhAnhDao().GetByIDHinhAnh(IDHinhAnh);
        }


        public bool Insert(HinhAnhObject ob)
        {
            return new HinhAnhDao().Insert(ob);
        }


        public bool Delete(System.Int32 IDHinhAnh)
        {
            return new HinhAnhDao().Delete(IDHinhAnh);
        }


        public bool Update(HinhAnhObject ob)
        {
            return new HinhAnhDao().Update(ob);
        }

    }
}
