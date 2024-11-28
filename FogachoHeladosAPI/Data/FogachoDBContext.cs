using System;
using System.Collections.Generic;
using FogachoHeladosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FogachoHeladosAPI.Data;

public partial class FogachoDBContext : DbContext
{
    public FogachoDBContext()
    {
    }

    public FogachoDBContext(DbContextOptions<FogachoDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AF_Helado> AfHelados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FogachoHeladeriaDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AF_Helado>(entity =>
        {
            entity.HasKey(e => e.AF_IdHeladeria);

            entity.ToTable("AF_Helado");

            entity.Property(e => e.AF_IdHeladeria).HasColumnName("AF_IdHeladeria");
            entity.Property(e => e.AF_Categorias).HasColumnName("AF_Categorias");
            entity.Property(e => e.AF_Nombre).HasColumnName("AF_Nombre");
            entity.Property(e => e.AF_Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AF_Precio");
            entity.Property(e => e.AF_Queso).HasColumnName("AF_Queso");
            entity.Property(e => e.AF_Sabor).HasColumnName("AF_Sabor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
