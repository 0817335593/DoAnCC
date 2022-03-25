
using System;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class QuyenDao
    {
        
public List<QuyenObject> GetAll()
{
    var list = new dbKhachSanEntities().SP_Quyen_GetAll();
    List<QuyenObject> lst = new List<QuyenObject>();
    foreach (var item in list)
    {
        var obj = new QuyenObject();
        
obj.GhiChu = item.GhiChu  ;
obj.IDQuyen = item.IDQuyen  ;
obj.TenQuyen = item.TenQuyen  ;
        lst.Add(obj);
    }
    return lst;
}

        
public QuyenObject GetByIDQuyen(System.Int32 IDQuyen)
{
    var list =  new dbKhachSanEntities().SP_Quyen_GetByIDQuyen(IDQuyen);
    foreach (var item in list)
    {
        var obj = new QuyenObject();
        
obj.GhiChu = item.GhiChu  ;
obj.IDQuyen = item.IDQuyen  ;
obj.TenQuyen = item.TenQuyen  ;
        return obj;
    }
    return null;
}

        
public bool Insert(QuyenObject ob)
{
    return new dbKhachSanEntities().SP_Quyen_Insert( ob.GhiChu , ob.TenQuyen )>0;
}

        
public bool Delete( System.Int32 IDQuyen)
{
    return new dbKhachSanEntities().SP_Quyen_Delete( IDQuyen)>0;
}

        
public bool Update(QuyenObject ob)
{
    return new dbKhachSanEntities().SP_Quyen_Update( ob.GhiChu , ob.IDQuyen , ob.TenQuyen )>0;
}

    }
}
