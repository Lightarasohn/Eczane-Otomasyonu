using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EczaneAPI.Models;

public partial class EczaneContext : DbContext
{
    public EczaneContext()
    {
    }

    public EczaneContext(DbContextOptions<EczaneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ilac> Ilaclar { get; set; }

    public virtual DbSet<Satis> Satislar { get; set; }

    public virtual DbSet<SatisIlac> SatisIlacs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=EczaneConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ilac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ILAC__3214EC07DE7DE899");

            entity.ToTable("ILAC");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.StokDurumu).HasColumnName("Stok Durumu");
        });

        modelBuilder.Entity<Satis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SATIS__3214EC076DC4B8FD");

            entity.ToTable("SATIS");

            entity.Property(e => e.AliciEmail)
                .HasMaxLength(50)
                .HasColumnName("Alici Email");
            entity.Property(e => e.SatisTarihi).HasColumnName("Satis Tarihi");
        });

        modelBuilder.Entity<SatisIlac>(entity =>
        {
            entity.HasKey(e => new { e.SatisId, e.IlacId }).HasName("PK__SATIS_IL__E2EB4C0C126F3DA4");

            entity.ToTable("SATIS_ILAC");

            entity.HasOne(d => d.Ilac).WithMany(p => p.SatisIlacs)
                .HasForeignKey(d => d.IlacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SATIS_ILA__IlacI__5FB337D6");

            entity.HasOne(d => d.Satis).WithMany(p => p.SatisIlacs)
                .HasForeignKey(d => d.SatisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SATIS_ILA__Satis__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
