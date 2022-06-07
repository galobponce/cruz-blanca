using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("pacientes")]
    [Index(nameof(IdObraSocial), Name = "IdObraSocial")]
    public partial class Paciente
    {
        public Paciente()
        {
            Turnos = new HashSet<Turno>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Dni { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string NumeroContacto { get; set; }
        [Required]
        [StringLength(100)]
        public string MailContacto { get; set; }
        public bool EsCliente { get; set; }
        public int? IdObraSocial { get; set; }
        [StringLength(255)]
        public string Observaciones { get; set; }
        [StringLength(100)]
        public string AdjuntosRuta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey(nameof(IdObraSocial))]
        [InverseProperty(nameof(ObraSocial.Pacientes))]
        public virtual ObraSocial IdObraSocialNavigation { get; set; }
        [InverseProperty(nameof(Turno.IdPacienteNavigation))]
        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
