
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class PhanQuyenBus
    {

        public List<PhanQuyenObject> GetAll()
        {
            return new PhanQuyenDao().GetAll();
        }


        public PhanQuyenObject GetByIDQuyen(System.Int32 IDQuyen)
        {
            return new PhanQuyenDao().GetByIDQuyen(IDQuyen);
        }

        public List<PhanQuyenObject> GetByIDTaiKhoan(System.Int32 IDTaiKhoan)
        {
            return new PhanQuyenDao().GetByIDTaiKhoan(IDTaiKhoan);
        }


        public bool Insert(PhanQuyenObject ob)
        {
            return new PhanQuyenDao().Insert(ob);
        }


        public bool Delete(System.Int32 IDQuyen, System.Int32 IDTaiKhoan)
        {
            return new PhanQuyenDao().Delete(IDQuyen, IDTaiKhoan);
        }


    }
}
