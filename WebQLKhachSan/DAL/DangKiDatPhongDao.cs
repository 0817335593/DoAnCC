
using System.Linq;
using System.Collections.Generic;
using DTO;
using DAL.Model;

namespace DAL
{
    public class DangKiDatPhongDao
    {

        public List<DangKiDatPhongObject> GetAll()
        {
            var list = new dbKhachSanEntities().DangKiDatPhongs.ToList();
            List<DangKiDatPhongObject> lst = new List<DangKiDatPhongObject>();
            foreach (var item in list)
            {
                var obj = new DangKiDatPhongObject();

                obj.Email = item.Email;
                obj.GhiChu = item.GhiChu;
                obj.HoTen = item.HoTen;
                obj.ID_DangKi = item.ID_DangKi;
                obj.ID_Phong = item.ID_Phong;
                obj.Message = item.Message;
                obj.NgayTao = item.NgayTao;
                obj.Phone = item.Phone;
                obj.Status = item.Status ?? 0;
                obj.TimeEnd = item.TimeEnd;
                obj.TimeStart = item.TimeStart;
                obj.PhongObjectJoin = new PhongObject()
                {

                    Active = item.Phong.Active == true,
                    GiaPhong = item.Phong.GiaPhong,
                    ID_LoaiPhong = item.Phong.ID_LoaiPhong,
                    ID_ViTri = item.Phong.ID_ViTri,
                    IDPhong = (System.Int32)item.ID_Phong,
                    IsDelete = item.Phong.IsDelete == true,
                    TenPhong = item.Phong.TenPhong,
                    TrangThai = item.Phong.TrangThai,
                    KhachSanObjectJoin = new KhachSanObject
                    {
                        TenKhachSan = item.Phong.KhachSan.TenKhachSan
                    },
                    TinhThanhObjectJoin = new TinhThanhObject
                    {
                        TenTinh = item.Phong.KhachSan.TinhThanh.TenTinh
                    }
                };

                lst.Add(obj);
            }
            return lst;
        }


        public DangKiDatPhongObject GetByID_DangKi(System.Int32 ID_DangKi)
        {
            var list = new dbKhachSanEntities().SP_DangKiDatPhong_GetByID_DangKi(ID_DangKi);
            foreach (var item in list)
            {
                var obj = new DangKiDatPhongObject();

                obj.Email = item.Email;
                obj.GhiChu = item.GhiChu;
                obj.HoTen = item.HoTen;
                obj.ID_DangKi = item.ID_DangKi;
                obj.ID_Phong = item.ID_Phong;
                obj.Message = item.Message;
                obj.NgayTao = item.NgayTao;
                obj.Phone = item.Phone;
                obj.Status = item.Status ?? 0;
                obj.TimeEnd = item.TimeEnd;
                obj.TimeStart = item.TimeStart;
                obj.PhongObjectJoin = new PhongObject()
                {

                    Active = item.Active_PhongJoin == true,
                    GiaPhong = item.GiaPhong_PhongJoin,
                    ID_LoaiPhong = item.ID_LoaiPhong_PhongJoin,
                    ID_ViTri = item.ID_ViTri_PhongJoin,
                    IDPhong = (System.Int32)item.ID_Phong,
                    IsDelete = item.IsDelete_PhongJoin == true,
                    TenPhong = item.TenPhong_PhongJoin,
                    TrangThai = item.TrangThai_PhongJoin
                };

                return obj;
            }
            return null;
        }


        public bool Insert(DangKiDatPhongObject ob)
        {
            return new dbKhachSanEntities().SP_DangKiDatPhong_Insert(ob.Email, ob.GhiChu, ob.HoTen, ob.ID_Phong, ob.Message, ob.NgayTao, ob.Phone, ob.Status, ob.TimeEnd, ob.TimeStart) > 0;
        }


        public bool Delete(System.Int32 ID_DangKi)
        {
            return new dbKhachSanEntities().SP_DangKiDatPhong_Delete(ID_DangKi) > 0;
        }


        public bool Update(DangKiDatPhongObject ob)
        {
            return new dbKhachSanEntities().SP_DangKiDatPhong_Update(ob.Email, ob.GhiChu, ob.HoTen, ob.ID_DangKi, ob.ID_Phong, ob.Message, ob.NgayTao, ob.Phone, ob.Status, ob.TimeEnd, ob.TimeStart) > 0;
        }

    }
}
