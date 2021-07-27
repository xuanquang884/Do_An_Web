namespace Web_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class San_Pham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public San_Pham()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        [Key]
        public int MASP { get; set; }

        [StringLength(50)]
        public string MALOAISP { get; set; }

        [StringLength(255)]
        public string TENSP { get; set; }

        public string MOTA { get; set; }

        public int? GIA { get; set; }

        public int? SOLUONG { get; set; }

        public int? TINHTRANG { get; set; }

        public int? LUOTVIEW { get; set; }

        [StringLength(255)]
        public string HINH { get; set; }

        [StringLength(255)]
        public string HINH1 { get; set; }

        [StringLength(255)]
        public string HINH2 { get; set; }

        [StringLength(255)]
        public string HINH3 { get; set; }

        [StringLength(255)]
        public string HINH4 { get; set; }

        public virtual Loai_SP Loai_SP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
