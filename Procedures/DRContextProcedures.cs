using Microsoft.EntityFrameworkCore;

namespace DRBAPI.Data
{
    public partial class DRContextProcedures : DbContext
    {
        public virtual DbSet<ProcCabang> ProcCabangs { get; set; } = null!;

        public DRContextProcedures() { }

        public DRContextProcedures(DbContextOptions<DRContextProcedures> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcCabang>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.KODE_WILAYAH);
                entity.Property(e => e.NAMA_WILAYAH);
                entity.Property(e => e.ALAMAT);
                entity.Property(e => e.WILAYAH);
            });
        }
    }
}
