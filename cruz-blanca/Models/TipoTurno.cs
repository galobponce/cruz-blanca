using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("tipos_turno")]
    public partial class TipoTurno
    {
        public TipoTurno()
        {
            Turnos = new HashSet<Turno>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Turno.IdTipoTurnoNavigation))]
        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
