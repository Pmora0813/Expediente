namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicamento")]
    public partial class Medicamento
    {
        public string estado_String { get; set; }
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        public virtual Expediente Expediente { get; set; }
    }
}
