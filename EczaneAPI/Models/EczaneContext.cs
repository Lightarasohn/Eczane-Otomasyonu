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
            entity.HasKey(e => e.Id).HasName("PK__Satis__3214EC078B664D20");

            entity.ToTable("Satis");

            entity.Property(e => e.AliciEmail)
                .HasMaxLength(50)
                .HasColumnName("Alici Email");
            entity.Property(e => e.IlacId).HasColumnName("Ilac Id");
            entity.Property(e => e.SatisTarihi).HasColumnName("Satis Tarihi");

            entity.HasOne(d => d.Ilac).WithMany(p => p.Satislar)
                .HasForeignKey(d => d.IlacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Satis__Ilac Id__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
