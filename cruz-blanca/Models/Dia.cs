using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("dias")]
    public partial class Dia
    {
        public Dia()
        {
            HorarioIdDomingoNavigations = new HashSet<Horario>();
            HorarioIdJuevesNavigations = new HashSet<Horario>();
            HorarioIdLunesNavigations = new HashSet<Horario>();
            HorarioIdMartesNavigations = new HashSet<Horario>();
            HorarioIdMiercolesNavigations = new HashSet<Horario>();
            HorarioIdSabadoNavigations = new HashSet<Horario>();
            HorarioIdViernesNavigations = new HashSet<Horario>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(100)]
        public string Desde { get; set; }
        [Required]
        [StringLength(100)]
        public string Hasta { get; set; }

        [InverseProperty(nameof(Horario.IdDomingoNavigation))]
        public virtual ICollection<Horario> HorarioIdDomingoNavigations { get; set; }
        [InverseProperty(nameof(Horario.IdJuevesNavigation))]
        public virtual ICollection<Horario> HorarioIdJuevesNavigations { get; set; }
        [InverseProperty(nameof(Horario.IdLunesNavigation))]
        public virtual ICollection<Horario> HorarioIdLunesNavigations { get; set; }
        [InverseProperty(nameof(Horario.IdMartesNavigation))]
        public virtual ICollection<Horario> HorarioIdMartesNavigations { get; set; }
        [InverseProperty(nameof(Horario.IdMiercolesNavigation))]
        public virtual ICollection<Horario> HorarioIdMiercolesNavigations { get; set; }
        [InverseProperty(nameof(Horario.IdSabadoNavigation))]
        public virtual ICollection<Horario> HorarioIdSabadoNavigations { get; set; }
        [InverseProperty(nameof(Horario.IdViernesNavigation))]
        public virtual ICollection<Horario> HorarioIdViernesNavigations { get; set; }
    }
}
