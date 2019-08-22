namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Compartir_Expediente
    {
        public int id { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_PACIENTE { get; set; }

        public int estado { get; set; }
        public string estado_String { get; set; }
        [Required]
        [StringLength(50)]
        public string ID_PACIENTE_COMPARTE { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
