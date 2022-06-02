using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
    public partial class Horario
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public int? IdDomingo { get; set; }
        public int? IdLunes { get; set; }
        public int? IdMartes { get; set; }
        public int? IdMiercoles { get; set; }
        public int? IdJueves { get; set; }
        public int? IdViernes { get; set; }
        public int? IdSabado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Dia IdDomingoNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Dia IdJuevesNavigation { get; set; }
        public virtual Dia IdLunesNavigation { get; set; }
        public virtual Dia IdMartesNavigation { get; set; }
        public virtual Dia IdMiercolesNavigation { get; set; }
        public virtual Dia IdSabadoNavigation { get; set; }
        public virtual Dia IdViernesNavigation { get; set; }
    }
}
