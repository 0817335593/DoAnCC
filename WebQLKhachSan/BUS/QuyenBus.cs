
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class QuyenBus
    {
        
public List<QuyenObject> GetAll()
{
    return new QuyenDao().GetAll();
}

        
public QuyenObject GetByIDQuyen(System.Int32 IDQuyen)
{
    return new QuyenDao().GetByIDQuyen(IDQuyen);
}

        
public bool Insert(QuyenObject ob)
{
    return new QuyenDao().Insert(ob);
}

        
public bool Delete(System.Int32 IDQuyen)
{
    return new QuyenDao().Delete(IDQuyen);
}

        
public bool Update(QuyenObject ob)
{
    return new QuyenDao().Update(ob);
}

    }
}
