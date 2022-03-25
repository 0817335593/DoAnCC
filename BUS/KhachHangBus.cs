
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class KhachHangBus
    {
        
public List<KhachHangObject> GetAll()
{
    return new KhachHangDao().GetAll();
}

        
public KhachHangObject GetByIDKhachHang(System.Guid IDKhachHang)
{
    return new KhachHangDao().GetByIDKhachHang(IDKhachHang);
}

        
public bool Insert(KhachHangObject ob)
{
    return new KhachHangDao().Insert(ob);
}

        
public bool Delete(System.Guid IDKhachHang)
{
    return new KhachHangDao().Delete(IDKhachHang);
}

        
public bool Update(KhachHangObject ob)
{
    return new KhachHangDao().Update(ob);
}

    }
}
