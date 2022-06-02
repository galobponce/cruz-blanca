using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
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

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }

        public virtual ICollection<Horario> HorarioIdDomingoNavigations { get; set; }
        public virtual ICollection<Horario> HorarioIdJuevesNavigations { get; set; }
        public virtual ICollection<Horario> HorarioIdLunesNavigations { get; set; }
        public virtual ICollection<Horario> HorarioIdMartesNavigations { get; set; }
        public virtual ICollection<Horario> HorarioIdMiercolesNavigations { get; set; }
        public virtual ICollection<Horario> HorarioIdSabadoNavigations { get; set; }
        public virtual ICollection<Horario> HorarioIdViernesNavigations { get; set; }
    }
}
