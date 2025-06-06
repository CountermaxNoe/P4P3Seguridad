﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P4P3Seguridad.models;

public partial class SeguridadContext : DbContext
{
    public SeguridadContext()
    {
    }

    public SeguridadContext(DbContextOptions<SeguridadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=Seguridad;user=NOEGOMEZ/noego;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC077AED2469");

            entity.Property(e => e.Contrasena)
                .HasMaxLength(264)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
