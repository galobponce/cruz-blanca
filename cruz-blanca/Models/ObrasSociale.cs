using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
    public partial class ObrasSociale
    {
        public ObrasSociale()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool AsociadaConClinica { get; set; }
        public string Observaciones { get; set; }
        public string AdjuntosRuta { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
