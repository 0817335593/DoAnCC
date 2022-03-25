
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class TaiKhoanBus
    {

        public List<TaiKhoanObject> GetAll()
        {
            return new TaiKhoanDao().GetAll();
        }


        public TaiKhoanObject GetByIDTaiKhoan(System.Int32 IDTaiKhoan)
        {
            return new TaiKhoanDao().GetByIDTaiKhoan(IDTaiKhoan);
        }


        public bool Insert(TaiKhoanObject ob)
        {
            return new TaiKhoanDao().Insert(ob);
        }


        public bool Delete(System.Int32 IDTaiKhoan)
        {
            return new TaiKhoanDao().Delete(IDTaiKhoan);
        }


        public bool Update(TaiKhoanObject ob)
        {
            return new TaiKhoanDao().Update(ob);
        }


        public TaiKhoanObject CheckLogin(string TenDangNhap, string MatKhau)
        {
            return new TaiKhoanDao().CheckLogin(new TaiKhoanObject() { TenDangNhap = TenDangNhap, MatKhau = MatKhau });
        }

        public TaiKhoanObject DoiMatKhau(int IDTaiKhoan, string curent, string newpass)
        {
            return new TaiKhoanDao().DoiMatKhau(IDTaiKhoan, curent, newpass);
        }
    }
}
