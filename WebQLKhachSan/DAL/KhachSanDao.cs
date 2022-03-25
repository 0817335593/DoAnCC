
using System;
using System.Linq;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class KhachSanDao
    {

        public List<KhachSanObject> GetAll()
        {
            return (from o in new dbKhachSanEntities().KhachSans.ToList().Where(q => q.IsDelete != true).ToList()
                    select new KhachSanObject
                    {
                        IsDelete = o.IsDelete,
                        IDKhachSan = o.IDKhachSan,
                        IDHinhAnh = o.IDHinhAnh,
                        GhiChu = o.GhiChu,
                        DiaChi = o.DiaChi,
                        GioiThieu = o.GioiThieu,
                        IDTinhThanh = o.IDTinhThanh,
                        MaKhachSan = o.MaKhachSan,
                        TenKhachSan = o.TenKhachSan,
                        Star = o.Star,
                        TieuDe = o.TieuDe,
                        TinhThanh = new TinhThanhObject
                        {
                            TenTinh = o.TinhThanh.TenTinh
                        },
                        HinhAnh = new HinhAnhObject
                        {
                            IDHinhAnh = o.HinhAnh.IDHinhAnh,
                            ImageLink = o.HinhAnh.ImageLink,
                            IsDelete = o.HinhAnh.IsDelete ?? false,
                            Rank = o.HinhAnh.Rank,
                        }
                    }).ToList();
        }


        public KhachSanObject GetByIDKhachSan(System.Int32 IDKhachSan)
        {
            var o = new dbKhachSanEntities().KhachSans.ToList().FirstOrDefault(q => q.IDKhachSan == IDKhachSan);
            if (o == null) return null;
            return new KhachSanObject
            {
                IsDelete = o.IsDelete,
                IDKhachSan = o.IDKhachSan,
                IDHinhAnh = o.IDHinhAnh,
                GhiChu = o.GhiChu,
                DiaChi = o.DiaChi,
                GioiThieu = o.GioiThieu,
                IDTinhThanh = o.IDTinhThanh,
                MaKhachSan = o.MaKhachSan,
                TenKhachSan = o.TenKhachSan,
                Star = o.Star,
                TieuDe = o.TieuDe,
                TinhThanh = new TinhThanhObject
                {
                    TenTinh = o.TinhThanh.TenTinh
                },
                HinhAnh = new HinhAnhObject
                {
                    IDHinhAnh = o.HinhAnh.IDHinhAnh,
                    ImageLink = o.HinhAnh.ImageLink,
                    IsDelete = o.HinhAnh.IsDelete ?? false,
                    Rank = o.HinhAnh.Rank,
                }
            };
        }


        public bool Insert(KhachSanObject o)
        {
            var db = new dbKhachSanEntities();
            db.KhachSans.Add(new KhachSan
            {
                IsDelete = o.IsDelete,
                IDKhachSan = o.IDKhachSan,
                IDHinhAnh = o.IDHinhAnh,
                GhiChu = o.GhiChu,
                DiaChi = o.DiaChi,
                GioiThieu = o.GioiThieu,
                IDTinhThanh = o.IDTinhThanh,
                MaKhachSan = o.MaKhachSan,
                TenKhachSan = o.TenKhachSan,
                Star = o.Star,
                TieuDe = o.TieuDe,
            });
            return db.SaveChanges() > 0;
        }


        public bool Delete(System.Int32 IDKhachSan)
        {
            var db = new dbKhachSanEntities();
            var o = db.KhachSans.ToList().FirstOrDefault(q => q.IDKhachSan == IDKhachSan);
            if (o != null)
            {
                o.IsDelete = true;
            }
            return db.SaveChanges() > 0;
        }


        public bool Update(KhachSanObject o)
        {
            var ob = new KhachSan
            {
                IsDelete = o.IsDelete,
                IDKhachSan = o.IDKhachSan,
                IDHinhAnh = o.IDHinhAnh,
                GhiChu = o.GhiChu,
                DiaChi = o.DiaChi,
                GioiThieu = o.GioiThieu,
                IDTinhThanh = o.IDTinhThanh,
                MaKhachSan = o.MaKhachSan,
                TenKhachSan = o.TenKhachSan,
                TieuDe = o.TieuDe,
                Star = o.Star,
            };
            var db = new dbKhachSanEntities();
            db.Entry(ob).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

    }
}
