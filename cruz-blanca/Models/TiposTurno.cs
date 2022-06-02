using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
    public partial class TiposTurno
    {
        public TiposTurno()
        {
            Turnos = new HashSet<Turno>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
