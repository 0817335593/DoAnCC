//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phong_HinhAnh
    {
        public int IDPhong_HinhAnh { get; set; }
        public Nullable<int> IDHinhAnh { get; set; }
        public Nullable<int> IDPhong { get; set; }
        public Nullable<int> Rank { get; set; }
        public string GhiChu { get; set; }
    
        public virtual HinhAnh HinhAnh { get; set; }
        public virtual Phong Phong { get; set; }
    }
}
