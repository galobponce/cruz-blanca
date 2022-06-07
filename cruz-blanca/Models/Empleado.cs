using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("empleados")]
    [Index(nameof(IdRol), Name = "IdRol")]
    public partial class Empleado
    {
        public Empleado()
        {
            Horarios = new HashSet<Horario>();
            TurnoIdEmpleadoAsignadoNavigations = new HashSet<Turno>();
            TurnoIdEmpleadoCreadorNavigations = new HashSet<Turno>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Dni { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaInicio { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public int IdRol { get; set; }
        [Required]
        [StringLength(100)]
        public string NumeroContacto { get; set; }
        [Required]
        [StringLength(100)]
        public string MailContacto { get; set; }
        [Required]
        [Column("contraseña")]
        [StringLength(100)]
        public string Contraseña { get; set; }
        [Column("sueldo")]
        public decimal? Sueldo { get; set; }
        [Column("domicilio")]
        [StringLength(100)]
        public string Domicilio { get; set; }
        [StringLength(255)]
        public string Observaciones { get; set; }
        [StringLength(100)]
        public string AdjuntosRuta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey(nameof(IdRol))]
        [InverseProperty(nameof(Rol.Empleados))]
        public virtual Rol IdRolNavigation { get; set; }
        [InverseProperty(nameof(Horario.IdEmpleadoNavigation))]
        public virtual ICollection<Horario> Horarios { get; set; }
        [InverseProperty(nameof(Turno.IdEmpleadoAsignadoNavigation))]
        public virtual ICollection<Turno> TurnoIdEmpleadoAsignadoNavigations { get; set; }
        [InverseProperty(nameof(Turno.IdEmpleadoCreadorNavigation))]
        public virtual ICollection<Turno> TurnoIdEmpleadoCreadorNavigations { get; set; }
    }
}
