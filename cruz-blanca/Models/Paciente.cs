using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
    public partial class Paciente
    {
        public Paciente()
        {
            Turnos = new HashSet<Turno>();
        }

        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string NumeroContacto { get; set; }
        public string MailContacto { get; set; }
        public bool EsCliente { get; set; }
        public int? IdObraSocial { get; set; }
        public string Observaciones { get; set; }
        public string AdjuntosRuta { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ObrasSociale IdObraSocialNavigation { get; set; }
        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
