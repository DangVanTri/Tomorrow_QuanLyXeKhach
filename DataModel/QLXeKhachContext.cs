
namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLXeKhachContext : DbContext
    {
        public QLXeKhachContext()
            : base("name=Model12")
        {
        }

        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<TuyenXe> TuyenXes { get; set; }
        public virtual DbSet<ChuyenXe> ChuyenXes { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TrangThaiNV> TrangThaiNVs { get; set; }
        public virtual DbSet<TaiKhoanNV> TaiKhhoanNVs { get; set; }
        public virtual DbSet<UngVien> UngViens { get; set; }
        public virtual DbSet<LichPhongVan> LichPhongVans { get; set; }

        public virtual DbSet<TrangThaiUV> TrangThaiUVs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
