using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cruz_blanca.Models
{
    [Table("roles")]
    public partial class Rol
    {
        public Rol()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Empleado.IdRolNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
