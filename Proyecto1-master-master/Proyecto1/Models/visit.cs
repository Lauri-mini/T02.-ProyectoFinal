using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1.Models
{
    public class visit
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Cantidad de Personas")]
        [MaxLength(50)]
        public string Cantidad { get; set; }
        [Required]
        [Display(Name = "Fecha (Mes/Día/Año) y Hora")]
        public DateTime FechaHora { get; set; }

    }
}