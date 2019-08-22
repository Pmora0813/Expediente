namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Otra_Enfermedad
    {
        public int id { get; set; }

        [StringLength(50)]
        public string descripciom { get; set; }

        [StringLength(50)]
        public string categoria { get; set; }

        public int? estado { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        public int? ID_EXPEDIENTE { get; set; }

        public virtual Expediente Expediente { get; set; }
    }
}
