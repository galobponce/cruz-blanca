using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
    public partial class Empleado
    {
        public Empleado()
        {
            Horarios = new HashSet<Horario>();
            TurnoIdEmpleadoAsignadoNavigations = new HashSet<Turno>();
            TurnoIdEmpleadoCreadorNavigations = new HashSet<Turno>();
        }

        public int Id { get; set; }
        public string Dni { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Nombre { get; set; }
        public int IdRol { get; set; }
        public string NumeroContacto { get; set; }
        public string MailContacto { get; set; }
        public string Contraseña { get; set; }
        public decimal? Sueldo { get; set; }
        public string Domicilio { get; set; }
        public string Observaciones { get; set; }
        public string AdjuntosRuta { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
        public virtual ICollection<Turno> TurnoIdEmpleadoAsignadoNavigations { get; set; }
        public virtual ICollection<Turno> TurnoIdEmpleadoCreadorNavigations { get; set; }
    }
}
