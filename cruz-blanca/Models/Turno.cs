using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("turnos")]
    [Index(nameof(IdEmpleadoAsignado), Name = "IdEmpleadoAsignado")]
    [Index(nameof(IdEmpleadoCreador), Name = "IdEmpleadoCreador")]
    [Index(nameof(IdPaciente), Name = "IdPaciente")]
    [Index(nameof(IdTipoTurno), Name = "IdTipoTurno")]
    public partial class Turno
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public int IdPaciente { get; set; }
        public int IdEmpleadoCreador { get; set; }
        public int IdEmpleadoAsignado { get; set; }
        public int IdTipoTurno { get; set; }
        public bool Activo { get; set; }
        public bool Asistido { get; set; }
        [StringLength(255)]
        public string Observaciones { get; set; }
        [StringLength(100)]
        public string AdjuntosRuta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey(nameof(IdEmpleadoAsignado))]
        [InverseProperty(nameof(Empleado.TurnoIdEmpleadoAsignadoNavigations))]
        public virtual Empleado IdEmpleadoAsignadoNavigation { get; set; }
        [ForeignKey(nameof(IdEmpleadoCreador))]
        [InverseProperty(nameof(Empleado.TurnoIdEmpleadoCreadorNavigations))]
        public virtual Empleado IdEmpleadoCreadorNavigation { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        [InverseProperty(nameof(Paciente.Turnos))]
        public virtual Paciente IdPacienteNavigation { get; set; }
        [ForeignKey(nameof(IdTipoTurno))]
        [InverseProperty(nameof(TipoTurno.Turnos))]
        public virtual TipoTurno IdTipoTurnoNavigation { get; set; }
    }
}
