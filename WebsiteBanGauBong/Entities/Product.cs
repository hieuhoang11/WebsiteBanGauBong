namespace WebsiteBanGauBong.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public long ProductId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        public int? Price { get; set; }

        public int? PromotionPrice { get; set; }

        public int? Amounts { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public long? ProductCategoryID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
