using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("obras_sociales")]
    public partial class ObraSocial
    {
        public ObraSocial()
        {
            Pacientes = new HashSet<Paciente>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public bool AsociadaConClinica { get; set; }
        [StringLength(255)]
        public string Observaciones { get; set; }
        [StringLength(100)]
        public string AdjuntosRuta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [InverseProperty(nameof(Paciente.IdObraSocialNavigation))]
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
