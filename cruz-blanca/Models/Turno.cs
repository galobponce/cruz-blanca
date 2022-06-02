using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
    public partial class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPaciente { get; set; }
        public int IdEmpleadoCreador { get; set; }
        public int IdEmpleadoAsignado { get; set; }
        public int IdTipoTurno { get; set; }
        public bool Activo { get; set; }
        public bool Asistido { get; set; }
        public string Observaciones { get; set; }
        public string AdjuntosRuta { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Empleado IdEmpleadoAsignadoNavigation { get; set; }
        public virtual Empleado IdEmpleadoCreadorNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual TiposTurno IdTipoTurnoNavigation { get; set; }
    }
}
