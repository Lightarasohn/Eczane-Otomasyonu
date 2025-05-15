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

    public virtual DbSet<Rapor> Raporlar { get; set; }

    public virtual DbSet<RaporSatis> RaporSatislar { get; set; }

    public virtual DbSet<Satis> Satislar { get; set; }

    public virtual DbSet<SatisIlac> SatisIlacs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=EczaneConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ilac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ILAC__3214EC07CD9AA972");

            entity.ToTable("ILAC");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.StokDurumu).HasColumnName("Stok Durumu");
        });

        modelBuilder.Entity<Rapor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RAPOR__3214EC07A64AD37D");

            entity.ToTable("RAPOR");
        });

        modelBuilder.Entity<RaporSatis>(entity =>
        {
            entity.HasKey(e => new { e.RaporId, e.SatisId }).HasName("PK__RAPOR_SA__27B35040BD9A6A0E");

            entity.ToTable("RAPOR_SATIS");

            entity.HasOne(d => d.Rapor).WithMany(p => p.RaporSatis)
                .HasForeignKey(d => d.RaporId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RAPOR_SAT__Rapor__4F7CD00D");

            entity.HasOne(d => d.Satis).WithMany(p => p.RaporSatis)
                .HasForeignKey(d => d.SatisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RAPOR_SAT__Satis__5070F446");
        });

        modelBuilder.Entity<Satis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SATIS__3214EC0770B179C3");

            entity.ToTable("SATIS");

            entity.Property(e => e.AliciEmail)
                .HasMaxLength(50)
                .HasColumnName("Alici Email");
            entity.Property(e => e.SatisTarihi).HasColumnName("Satis Tarihi");
        });

        modelBuilder.Entity<SatisIlac>(entity =>
        {
            entity.HasKey(e => new { e.SatisId, e.IlacId }).HasName("PK__SATIS_IL__E2EB4C0CF882D43D");

            entity.ToTable("SATIS_ILAC");

            entity.HasOne(d => d.Ilac).WithMany(p => p.SatisIlac)
                .HasForeignKey(d => d.IlacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SATIS_ILA__IlacI__3B75D760");

            entity.HasOne(d => d.Satis).WithMany(p => p.SatisIlac)
                .HasForeignKey(d => d.SatisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SATIS_ILA__Satis__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
