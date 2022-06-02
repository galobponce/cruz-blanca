using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cruz_blanca
{
    public partial class CruzBlancaDbContext : DbContext
    {
        public CruzBlancaDbContext()
        {
        }

        public CruzBlancaDbContext(DbContextOptions<CruzBlancaDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Dia> Dias { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<ObrasSociale> ObrasSociales { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TiposTurno> TiposTurnos { get; set; }
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

            modelBuilder.Entity<Dia>(entity =>
            {
                entity.ToTable("dias");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Desde)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Hasta)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleados");

                entity.HasIndex(e => e.IdRol, "IdRol");

                entity.Property(e => e.AdjuntosRuta).HasMaxLength(100);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .HasColumnName("domicilio");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.MailContacto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroContacto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Observaciones).HasMaxLength(255);

                entity.Property(e => e.Sueldo)
                    .HasPrecision(15, 2)
                    .HasColumnName("sueldo");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleados_ibfk_1");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.ToTable("horarios");

                entity.HasIndex(e => e.IdDomingo, "IdDomingo");

                entity.HasIndex(e => e.IdEmpleado, "IdEmpleado");

                entity.HasIndex(e => e.IdJueves, "IdJueves");

                entity.HasIndex(e => e.IdLunes, "IdLunes");

                entity.HasIndex(e => e.IdMartes, "IdMartes");

                entity.HasIndex(e => e.IdMiercoles, "IdMiercoles");

                entity.HasIndex(e => e.IdSabado, "IdSabado");

                entity.HasIndex(e => e.IdViernes, "IdViernes");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Observaciones).HasMaxLength(255);

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

            modelBuilder.Entity<ObrasSociale>(entity =>
            {
                entity.ToTable("obras_sociales");

                entity.Property(e => e.AdjuntosRuta).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Observaciones).HasMaxLength(255);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("pacientes");

                entity.HasIndex(e => e.IdObraSocial, "IdObraSocial");

                entity.Property(e => e.AdjuntosRuta).HasMaxLength(100);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.MailContacto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroContacto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Observaciones).HasMaxLength(255);

                entity.HasOne(d => d.IdObraSocialNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdObraSocial)
                    .HasConstraintName("pacientes_ibfk_1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TiposTurno>(entity =>
            {
                entity.ToTable("tipos_turno");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.ToTable("turnos");

                entity.HasIndex(e => e.IdEmpleadoAsignado, "IdEmpleadoAsignado");

                entity.HasIndex(e => e.IdEmpleadoCreador, "IdEmpleadoCreador");

                entity.HasIndex(e => e.IdPaciente, "IdPaciente");

                entity.HasIndex(e => e.IdTipoTurno, "IdTipoTurno");

                entity.Property(e => e.AdjuntosRuta).HasMaxLength(100);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Observaciones).HasMaxLength(255);

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
