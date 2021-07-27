namespace Web_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orderdetail")]
    public partial class Orderdetail
    {
        public int Id { get; set; }

        public int? IdOrder { get; set; }

        public int? IDMASP { get; set; }

        public int? GIASALE { get; set; }

        public int? SOLUONGSALE { get; set; }

        public virtual Order Order { get; set; }

        public virtual San_Pham San_Pham { get; set; }
    }
}
