
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class DichVuDao
    {
        
public List<DichVuObject> GetAll()
{
    var list = new dbKhachSanEntities().SP_DichVu_GetAll();
    List<DichVuObject> lst = new List<DichVuObject>();
    foreach (var item in list)
    {
        var obj = new DichVuObject();
        
obj.Active = item.Active == true ;
obj.DonVi = item.DonVi  ;
obj.GhiChu = item.GhiChu  ;
obj.GiaTien = item.GiaTien  ;
obj.IDDichVu = item.IDDichVu  ;
obj.IsDelete = item.IsDelete == true ;
obj.TenDichVu = item.TenDichVu  ;
        lst.Add(obj);
    }
    return lst;
}

        
public DichVuObject GetByIDDichVu(System.Int32 IDDichVu)
{
    var list =  new dbKhachSanEntities().SP_DichVu_GetByIDDichVu(IDDichVu);
    foreach (var item in list)
    {
        var obj = new DichVuObject();
        
obj.Active = item.Active == true ;
obj.DonVi = item.DonVi  ;
obj.GhiChu = item.GhiChu  ;
obj.GiaTien = item.GiaTien  ;
obj.IDDichVu = item.IDDichVu  ;
obj.IsDelete = item.IsDelete == true ;
obj.TenDichVu = item.TenDichVu  ;
        return obj;
    }
    return null;
}

        
public bool Insert(DichVuObject ob)
{
    return new dbKhachSanEntities().SP_DichVu_Insert( ob.Active , ob.DonVi , ob.GhiChu , ob.GiaTien , ob.IsDelete , ob.TenDichVu )>0;
}

        
public bool Delete( System.Int32 IDDichVu)
{
    return new dbKhachSanEntities().SP_DichVu_Delete( IDDichVu)>0;
}

        
public bool Update(DichVuObject ob)
{
    return new dbKhachSanEntities().SP_DichVu_Update( ob.Active , ob.DonVi , ob.GhiChu , ob.GiaTien , ob.IDDichVu , ob.IsDelete , ob.TenDichVu )>0;
}

    }
}
