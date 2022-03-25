
using System;
using System.Linq;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class TinhThanhDao
    {

        public List<TinhThanhObject> GetAll()
        {
            return (from o in new dbKhachSanEntities().TinhThanhs.ToList().Where(q => q.IsDelete != true).ToList()
                    select new TinhThanhObject
                    {
                        TenTinh = o.TenTinh,
                        MaTinh = o.MaTinh,
                        IsDelete = o.IsDelete,
                        IDTinhThanh = o.IDTinhThanh,
                        IDHinhAnh = o.IDHinhAnh,
                        GhiChu = o.GhiChu,
                        mHinhAnh = new HinhAnhObject
                        {
                            IDHinhAnh = o.HinhAnh.IDHinhAnh,
                            ImageLink = o.HinhAnh.ImageLink,
                            IsDelete = o.HinhAnh.IsDelete ?? false,
                            Rank = o.HinhAnh.Rank,
                        }
                    }).ToList();
        }


        public TinhThanhObject GetByIDTinhThanh(System.Int32 IDTinhThanh)
        {
            var o = new dbKhachSanEntities().TinhThanhs.ToList().FirstOrDefault(q => q.IDTinhThanh == IDTinhThanh);
            if (o == null) return null;
            return new TinhThanhObject
            {
                TenTinh = o.TenTinh,
                MaTinh = o.MaTinh,
                IsDelete = o.IsDelete,
                IDTinhThanh = o.IDTinhThanh,
                IDHinhAnh = o.IDHinhAnh,
                GhiChu = o.GhiChu,
                mHinhAnh = new HinhAnhObject
                {
                    IDHinhAnh = o.HinhAnh.IDHinhAnh,
                    ImageLink = o.HinhAnh.ImageLink,
                    IsDelete = o.HinhAnh.IsDelete ?? false,
                    Rank = o.HinhAnh.Rank,
                }
            };
        }


        public bool Insert(TinhThanhObject o)
        {
            var db = new dbKhachSanEntities();
            db.TinhThanhs.Add(new TinhThanh
            {
                TenTinh = o.TenTinh,
                MaTinh = o.MaTinh,
                IsDelete = o.IsDelete,
                IDTinhThanh = o.IDTinhThanh,
                IDHinhAnh = o.IDHinhAnh,
                GhiChu = o.GhiChu,
            });
            return db.SaveChanges() > 0;
        }


        public bool Delete(System.Int32 IDTinhThanh)
        {
            var db = new dbKhachSanEntities();
            var o = db.TinhThanhs.ToList().FirstOrDefault(q => q.IDTinhThanh == IDTinhThanh);
            if (o != null)
            {
                o.IsDelete = true;
            }
            return db.SaveChanges() > 0;
        }


        public bool Update(TinhThanhObject o)
        {
            var ob = new TinhThanh
            {
                TenTinh = o.TenTinh,
                MaTinh = o.MaTinh,
                IsDelete = o.IsDelete,
                IDTinhThanh = o.IDTinhThanh,
                IDHinhAnh = o.IDHinhAnh,
                GhiChu = o.GhiChu,
            };
            var db = new dbKhachSanEntities();
            db.Entry(ob).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

    }
}
