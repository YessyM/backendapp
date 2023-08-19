using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using savemeapi.Models;

namespace savemeapi.Data;

public partial class SavemeContext : DbContext
{
    public SavemeContext(DbContextOptions<SavemeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adopcion> Adopcions { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Donacion> Donacions { get; set; }

    public virtual DbSet<Rescate> Rescates { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Veterinario> Veterinarios { get; set; }

    public virtual DbSet<Visitasveterinario> Visitasveterinarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Adopcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adopcion");

            entity.HasIndex(e => e.AnimalId, "animal_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.ComentariosAdicionales)
                .HasColumnType("text")
                .HasColumnName("comentarios_adicionales");
            entity.Property(e => e.FechaAdopcion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_adopcion");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Adopcions)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("adopcion_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Adopcions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("adopcion_ibfk_1");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("animal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Especie)
                .HasMaxLength(255)
                .HasColumnName("especie");
            entity.Property(e => e.Sección)
                .HasMaxLength(45)
                .HasColumnName("sección");
        });

        modelBuilder.Entity<Donacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("donacion");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaDonacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_donacion");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Donacions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("donacion_ibfk_1");
        });

        modelBuilder.Entity<Rescate>(entity =>
        {
            entity.HasKey(e => e.Idrescate).HasName("PRIMARY");

            entity.ToTable("rescate");

            entity.HasIndex(e => e.Idanimal, "fk_id_animal_idx");

            entity.HasIndex(e => e.Idusuario, "fk_id_usuario_idx");

            entity.Property(e => e.Idrescate)
                .ValueGeneratedNever()
                .HasColumnName("idrescate");
            entity.Property(e => e.ApellidoDeRescatista)
                .HasMaxLength(45)
                .HasColumnName("apellido de rescatista");
            entity.Property(e => e.CelularDeRescatista)
                .HasMaxLength(45)
                .HasColumnName("celular de rescatista");
            entity.Property(e => e.CorreoDeRescatista)
                .HasMaxLength(45)
                .HasColumnName("correo de rescatista");
            entity.Property(e => e.DescripcionRescate).HasColumnName("descripcion rescate");
            entity.Property(e => e.Idanimal).HasColumnName("idanimal");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Imagen)
                .HasColumnType("blob")
                .HasColumnName("imagen");
            entity.Property(e => e.NombreDeRescatista)
                .HasMaxLength(45)
                .HasColumnName("nombre de rescatista");

            entity.HasOne(d => d.IdanimalNavigation).WithMany(p => p.Rescates)
                .HasForeignKey(d => d.Idanimal)
                .HasConstraintName("fk_id_animal");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Rescates)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("fk_id_usuario");
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipos usuarios");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ubicacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(255)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.TipoDeUsuario, "fk_tipo_usuario_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cedula)
                .HasMaxLength(45)
                .HasColumnName("cedula");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .HasColumnName("celular");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .HasColumnName("clave");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Nombres)
                .HasMaxLength(255)
                .HasColumnName("nombres");
            entity.Property(e => e.TipoDeUsuario).HasColumnName("tipo de usuario");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.TipoDeUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoDeUsuario)
                .HasConstraintName("fk_tipo_usuario");
        });

        modelBuilder.Entity<Veterinario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("veterinario");

            entity.HasIndex(e => e.UbicacionId, "ubicacion_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(255)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.Veterinarios)
                .HasForeignKey(d => d.UbicacionId)
                .HasConstraintName("veterinario_ibfk_1");
        });

        modelBuilder.Entity<Visitasveterinario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("visitasveterinario");

            entity.HasIndex(e => e.AnimalId, "animal_id");

            entity.HasIndex(e => e.VeterinarioId, "veterinario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.FechaVisita)
                .HasColumnType("datetime")
                .HasColumnName("fecha_visita");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Visitasveterinarios)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("visitasveterinario_ibfk_1");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Visitasveterinarios)
                .HasForeignKey(d => d.VeterinarioId)
                .HasConstraintName("visitasveterinario_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
