namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fumador")]
    public partial class Fumador
    {
        public int id { get; set; }
        public string estado_String { get; set; }
        public int activo { get; set; }

        public int? cant_cigarrillos { get; set; }

        public int? tiempo { get; set; }

        [StringLength(50)]
        public string observaciones { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        public virtual Expediente Expediente { get; set; }
    }
}
