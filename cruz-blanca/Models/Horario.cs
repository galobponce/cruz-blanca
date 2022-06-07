using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("horarios")]
    [Index(nameof(IdDomingo), Name = "IdDomingo")]
    [Index(nameof(IdEmpleado), Name = "IdEmpleado")]
    [Index(nameof(IdJueves), Name = "IdJueves")]
    [Index(nameof(IdLunes), Name = "IdLunes")]
    [Index(nameof(IdMartes), Name = "IdMartes")]
    [Index(nameof(IdMiercoles), Name = "IdMiercoles")]
    [Index(nameof(IdSabado), Name = "IdSabado")]
    [Index(nameof(IdViernes), Name = "IdViernes")]
    public partial class Horario
    {
        [Key]
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public int? IdDomingo { get; set; }
        public int? IdLunes { get; set; }
        public int? IdMartes { get; set; }
        public int? IdMiercoles { get; set; }
        public int? IdJueves { get; set; }
        public int? IdViernes { get; set; }
        public int? IdSabado { get; set; }
        [StringLength(255)]
        public string Observaciones { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey(nameof(IdDomingo))]
        [InverseProperty(nameof(Dia.HorarioIdDomingoNavigations))]
        public virtual Dia IdDomingoNavigation { get; set; }
        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(Empleado.Horarios))]
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        [ForeignKey(nameof(IdJueves))]
        [InverseProperty(nameof(Dia.HorarioIdJuevesNavigations))]
        public virtual Dia IdJuevesNavigation { get; set; }
        [ForeignKey(nameof(IdLunes))]
        [InverseProperty(nameof(Dia.HorarioIdLunesNavigations))]
        public virtual Dia IdLunesNavigation { get; set; }
        [ForeignKey(nameof(IdMartes))]
        [InverseProperty(nameof(Dia.HorarioIdMartesNavigations))]
        public virtual Dia IdMartesNavigation { get; set; }
        [ForeignKey(nameof(IdMiercoles))]
        [InverseProperty(nameof(Dia.HorarioIdMiercolesNavigations))]
        public virtual Dia IdMiercolesNavigation { get; set; }
        [ForeignKey(nameof(IdSabado))]
        [InverseProperty(nameof(Dia.HorarioIdSabadoNavigations))]
        public virtual Dia IdSabadoNavigation { get; set; }
        [ForeignKey(nameof(IdViernes))]
        [InverseProperty(nameof(Dia.HorarioIdViernesNavigations))]
        public virtual Dia IdViernesNavigation { get; set; }
    }
}
