
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class DichVuBus
    {
        
public List<DichVuObject> GetAll()
{
    return new DichVuDao().GetAll();
}

        
public DichVuObject GetByIDDichVu(System.Int32 IDDichVu)
{
    return new DichVuDao().GetByIDDichVu(IDDichVu);
}

        
public bool Insert(DichVuObject ob)
{
    return new DichVuDao().Insert(ob);
}

        
public bool Delete(System.Int32 IDDichVu)
{
    return new DichVuDao().Delete(IDDichVu);
}

        
public bool Update(DichVuObject ob)
{
    return new DichVuDao().Update(ob);
}

    }
}
