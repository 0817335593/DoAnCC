
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class ChucVuBus
    {
        
public List<ChucVuObject> GetAll()
{
    return new ChucVuDao().GetAll();
}

        
public ChucVuObject GetByIDChucVu(System.Int32 IDChucVu)
{
    return new ChucVuDao().GetByIDChucVu(IDChucVu);
}

        
public bool Insert(ChucVuObject ob)
{
    return new ChucVuDao().Insert(ob);
}

        
public bool Delete(System.Int32 IDChucVu)
{
    return new ChucVuDao().Delete(IDChucVu);
}

        
public bool Update(ChucVuObject ob)
{
    return new ChucVuDao().Update(ob);
}

    }
}
