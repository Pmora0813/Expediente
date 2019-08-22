namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cirugia")]
    public partial class Cirugia
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [Required]
        [StringLength(50)]
        public string donde { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        public virtual Expediente Expediente { get; set; }
    }
}
