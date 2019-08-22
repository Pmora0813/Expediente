namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Enfermedad_Familiar
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string parentesco { get; set; }

        [Required]
        [StringLength(50)]
        public string observaciones { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        public int? ID_ENFERMEDAD { get; set; }

        public virtual Expediente Expediente { get; set; }

        public virtual Lista_Enfermedad Lista_Enfermedad { get; set; }
    }
}
