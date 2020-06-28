using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace DataAccess.Models
{
    public partial class eTicaretDBContext : DbContext
    {
        public eTicaretDBContext()
        {
        }
        public eTicaretDBContext(DbContextOptions<eTicaretDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<UrunSiparis> UrunSiparis { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=eTicaretDB;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Code).HasMaxLength(50);
            });
            modelBuilder.Entity<Urun>(entity =>
            {
                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InsertedDate).HasColumnType("datetime");
                entity.Property(e => e.UrunTarihi).HasColumnType("datetime");
            });
            modelBuilder.Entity<UrunSiparis>(entity =>
            {
                entity.Property(e => e.SiparisBirimFiyat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SiparisToplamFiyat).HasColumnType("decimal(18, 2)");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
