using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachSanObject
    {
        public int IDKhachSan { get; set; }
        public Nullable<int> IDTinhThanh { get; set; }
        public Nullable<int> IDHinhAnh { get; set; }
        public Nullable<int> Star { get; set; }
        public string MaKhachSan { get; set; }
        public string TenKhachSan { get; set; }
        public string DiaChi { get; set; }
        public string GioiThieu { get; set; }
        public string TieuDe { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        public virtual HinhAnhObject HinhAnh { get; set; }
        public virtual TinhThanhObject TinhThanh { get; set; }
    }
}
