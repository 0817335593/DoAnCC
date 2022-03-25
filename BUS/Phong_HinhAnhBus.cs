
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class Phong_HinhAnhBus
    {

        public List<Phong_HinhAnhObject> GetAll()
        {
            return new Phong_HinhAnhDao().GetAll();
        }


        public Phong_HinhAnhObject GetByIDPhong_HinhAnh(System.Int32 IDPhong_HinhAnh)
        {
            return new Phong_HinhAnhDao().GetByIDPhong_HinhAnh(IDPhong_HinhAnh);
        }

        public List<Phong_HinhAnhObject> GetByIDPhong(System.Int32 IDPhong)
        {
            return new Phong_HinhAnhDao().GetByIDPhong(IDPhong);
        }


        public bool Insert(Phong_HinhAnhObject ob)
        {
            return new Phong_HinhAnhDao().Insert(ob);
        }


        public bool Delete(System.Int32 IDPhong_HinhAnh)
        {
            return new Phong_HinhAnhDao().Delete(IDPhong_HinhAnh);
        }


        public bool Update(Phong_HinhAnhObject ob)
        {
            return new Phong_HinhAnhDao().Update(ob);
        }

    }
}
