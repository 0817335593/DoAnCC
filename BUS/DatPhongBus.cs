
using DAL;
using DTO;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class DatPhongBus
    {
        
public List<DatPhongObject> GetAll()
{
    return new DatPhongDao().GetAll();
}

        
public DatPhongObject GetByIDDatPhong(System.Int32 IDDatPhong)
{
    return new DatPhongDao().GetByIDDatPhong(IDDatPhong);
}

        
public bool Insert(DatPhongObject ob)
{
    return new DatPhongDao().Insert(ob);
}

        
public bool Delete(System.Int32 IDDatPhong)
{
    return new DatPhongDao().Delete(IDDatPhong);
}

        
public bool Update(DatPhongObject ob)
{
    return new DatPhongDao().Update(ob);
}

    }
}
