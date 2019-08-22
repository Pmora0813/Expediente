namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Otra_Alergia
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        public int? estado { get; set; }

        [StringLength(50)]
        public string reaccion { get; set; }

        [StringLength(50)]
        public string observaciones { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        public int? ID_EXPEDIENTE { get; set; }

        public int? ID_CATEGORIA { get; set; }

        public virtual Expediente Expediente { get; set; }
    }
}
