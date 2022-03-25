
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class ViTriBus
    {

        public List<ViTriObject> GetAll()
        {
            return new ViTriDao().GetAll();
        }


        public ViTriObject GetByID_ViTri(System.Int32 ID_ViTri)
        {
            return new ViTriDao().GetByID_ViTri(ID_ViTri);
        }


        public bool Insert(ViTriObject ob)
        {
            return new ViTriDao().Insert(ob);
        }


        public bool Delete(System.Int32 ID_ViTri)
        {
            return new ViTriDao().Delete(ID_ViTri);
        }


        public bool Update(ViTriObject ob)
        {
            return new ViTriDao().Update(ob);
        }

    }
}
