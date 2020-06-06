using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto1.Models
{
    public class visit_shrine
    {
        public int Id { get; set; }
        public int SantuarioId { get; set; }
        [ForeignKey("SantuarioId")]
        public sanctuary santuario { get; set; }

        public int VisitaId { get; set; }
        [ForeignKey("VisitaId")]
        public visit visita { get; set; }
    }
}