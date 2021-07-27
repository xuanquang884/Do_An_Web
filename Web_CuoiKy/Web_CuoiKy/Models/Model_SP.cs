using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web_CuoiKy.Models
{
    public partial class Model_SP : DbContext
    {
        public Model_SP()
            : base("name=Model_SP")
        {
        }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Loai_SP> Loai_SP { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<San_Pham> San_Pham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CodeCus)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.EmailCus)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneCus)
                .IsFixedLength();

            modelBuilder.Entity<Loai_SP>()
                .HasMany(e => e.San_Pham)
                .WithOptional(e => e.Loai_SP)
                .HasForeignKey(e => e.MALOAISP);

            modelBuilder.Entity<Order>()
                .Property(e => e.CodeCus)
                .IsFixedLength();

            modelBuilder.Entity<San_Pham>()
                .HasMany(e => e.Orderdetails)
                .WithOptional(e => e.San_Pham)
                .HasForeignKey(e => e.IDMASP);
        }
    }
}
