
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class GiaoDichBus
    {

        public List<GiaoDichObject> GetAll()
        {
            return new GiaoDichDao().GetAll();
        }


        public GiaoDichObject GetByIDGiaoDich(System.Int32 IDGiaoDich)
        {
            return new GiaoDichDao().GetByIDGiaoDich(IDGiaoDich);
        }


        public bool Insert(GiaoDichObject ob)
        {
            return new GiaoDichDao().Insert(ob);
        }


        public bool Delete(System.Int32 IDGiaoDich)
        {
            return new GiaoDichDao().Delete(IDGiaoDich);
        }


        public bool Update(GiaoDichObject ob)
        {
            return new GiaoDichDao().Update(ob);
        }


        public List<GiaoDichObject> GetByIDDatPhong(int id)
        {
            return new GiaoDichDao().GetByIDDatPhong(id);
        }
    }
}
