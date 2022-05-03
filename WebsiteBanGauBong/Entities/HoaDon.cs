namespace WebsiteBanGauBong.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public long MaHoaDon { get; set; }

        [StringLength(50)]
        public string TenKhach { get; set; }

        [StringLength(15)]
        public string SoDT { get; set; }

        public long? MaHang { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        public DateTime? NgayLap { get; set; }

        public int? SoLuong { get; set; }

        public bool XuLy { get; set; }

        public virtual Product Product { get; set; }
    }
}
