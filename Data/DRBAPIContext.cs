using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DRBAPI.Models;

namespace DRBAPI.Data
{
    public partial class DRBAPIContext : DbContext
    {
        public DRBAPIContext()
        {
        }

        public DRBAPIContext(DbContextOptions<DRBAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabang> Cabangs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cabang>(entity =>
            {
                entity.HasKey(e => e.KodeCabang)
                    .HasName("PRIMARY");

                entity.ToTable("cabang");

                entity.Property(e => e.KodeCabang)
                    .HasMaxLength(10)
                    .HasColumnName("kode_cabang");

                entity.Property(e => e.Alamat)
                    .HasColumnType("text")
                    .HasColumnName("alamat");

                entity.Property(e => e.NamaCabang)
                    .HasMaxLength(50)
                    .HasColumnName("nama_cabang");

                entity.Property(e => e.Wilayah)
                    .HasMaxLength(50)
                    .HasColumnName("wilayah");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
