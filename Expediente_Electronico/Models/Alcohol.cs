namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alcohol")]
    public partial class Alcohol
    {
        public int id { get; set; }

        public int activo { get; set; }

        public int? inicio { get; set; }

        public int? frecuencia { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        public int? cant_tipo { get; set; }

        [StringLength(50)]
        public string observaciones { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        public string estado_String { get; set; }
        public virtual Expediente Expediente { get; set; }
    }
}
