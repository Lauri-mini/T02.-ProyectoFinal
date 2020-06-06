using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto1.Models
{
    public class biodiversity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        [MaxLength(50)]
        public string Tipo { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Especie")]
        [MaxLength(50)]
        public string Especie { get; set; }
        public string ImgUrl { get; set; }
        public int SantuarioId { get; set; }
        [ForeignKey("SantuarioId")]
        public sanctuary santuario { get; set; }
        
    }
}