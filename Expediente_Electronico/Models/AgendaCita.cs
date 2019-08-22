namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgendaCita")]
    public partial class AgendaCita
    {
        public int id { get; set; }


        public int idHora { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string detalle { get; set; }

        public virtual Horario Horario { get; set; }
    }
}
