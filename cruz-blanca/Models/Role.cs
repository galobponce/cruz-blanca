using System;
using System.Collections.Generic;

#nullable disable

namespace cruz_blanca
{
    public partial class Role
    {
        public Role()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
