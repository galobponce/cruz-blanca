using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using cruz_blanca.Models;

#nullable disable

namespace cruz_blanca.Data
{
    public partial class CruzBlancaDBContext : DbContext
    {
        public CruzBlancaDBContext()
        {
        }

        public CruzBlancaDBContext(DbContextOptions<CruzBlancaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dia> Dias { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<ObraSocial> ObrasSociales { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<TipoTurno> TiposTurnos { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=root123**;database=cruz_blanca;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FechaInicio).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Sueldo).HasPrecision(15, 2);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleados_ibfk_1");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.IdDomingoNavigation)
                    .WithMany(p => p.HorarioIdDomingoNavigations)
                    .HasForeignKey(d => d.IdDomingo)
                    .HasConstraintName("horarios_ibfk_2");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("horarios_ibfk_1");

                entity.HasOne(d => d.IdJuevesNavigation)
                    .WithMany(p => p.HorarioIdJuevesNavigations)
                    .HasForeignKey(d => d.IdJueves)
                    .HasConstraintName("horarios_ibfk_6");

                entity.HasOne(d => d.IdLunesNavigation)
                    .WithMany(p => p.HorarioIdLunesNavigations)
                    .HasForeignKey(d => d.IdLunes)
                    .HasConstraintName("horarios_ibfk_3");

                entity.HasOne(d => d.IdMartesNavigation)
                    .WithMany(p => p.HorarioIdMartesNavigations)
                    .HasForeignKey(d => d.IdMartes)
                    .HasConstraintName("horarios_ibfk_4");

                entity.HasOne(d => d.IdMiercolesNavigation)
                    .WithMany(p => p.HorarioIdMiercolesNavigations)
                    .HasForeignKey(d => d.IdMiercoles)
                    .HasConstraintName("horarios_ibfk_5");

                entity.HasOne(d => d.IdSabadoNavigation)
                    .WithMany(p => p.HorarioIdSabadoNavigations)
                    .HasForeignKey(d => d.IdSabado)
                    .HasConstraintName("horarios_ibfk_8");

                entity.HasOne(d => d.IdViernesNavigation)
                    .WithMany(p => p.HorarioIdViernesNavigations)
                    .HasForeignKey(d => d.IdViernes)
                    .HasConstraintName("horarios_ibfk_7");
            });

            modelBuilder.Entity<ObraSocial>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.IdObraSocialNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdObraSocial)
                    .HasConstraintName("pacientes_ibfk_1");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.Property(e => e.Fecha).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.IdEmpleadoAsignadoNavigation)
                    .WithMany(p => p.TurnoIdEmpleadoAsignadoNavigations)
                    .HasForeignKey(d => d.IdEmpleadoAsignado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turnos_ibfk_3");

                entity.HasOne(d => d.IdEmpleadoCreadorNavigation)
                    .WithMany(p => p.TurnoIdEmpleadoCreadorNavigations)
                    .HasForeignKey(d => d.IdEmpleadoCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turnos_ibfk_2");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turnos_ibfk_1");

                entity.HasOne(d => d.IdTipoTurnoNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.IdTipoTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turnos_ibfk_4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
