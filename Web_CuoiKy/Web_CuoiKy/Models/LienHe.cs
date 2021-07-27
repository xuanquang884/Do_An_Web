namespace Web_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
public partial class LienHe
{
    [Key]
    public int MaLH { get; set; }

    [StringLength(100)]
    public string HoTen { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    public string NoiDung { get; set; }

    [StringLength(20)]
    public string SoDienThoai { get; set; }

    public int? MaKH { get; set; }
}
}
