using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmpresaProyect.models;

public partial class EmpresaContext : DbContext
{
    public EmpresaContext()
    {
    }

    public EmpresaContext(DbContextOptions<EmpresaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<Secciones> Secciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=Empresa;user=localhost;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC07AD975918");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trActualizarNumeroEmpleados");
                    tb.HasTrigger("trEliminarEmpleado");
                    tb.HasTrigger("trInsertarEmpleado");
                });

            entity.Property(e => e.Eliminado).HasDefaultValue((byte)0);
            entity.Property(e => e.Nombre)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Sueldo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkEmpleados");
        });

        modelBuilder.Entity<Secciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seccione__3214EC07A3A850F7");

            entity.Property(e => e.Eliminado).HasDefaultValue((byte)0);
            entity.Property(e => e.Nombre)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.SueldoMaximo).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
