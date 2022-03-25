using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhThanhObject
    {
        public int IDTinhThanh { get; set; }
        public Nullable<int> IDHinhAnh { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public virtual HinhAnhObject mHinhAnh { get; set; }
        public virtual ICollection<KhachSanObject> mKhachSans { get; set; }
    }
}
