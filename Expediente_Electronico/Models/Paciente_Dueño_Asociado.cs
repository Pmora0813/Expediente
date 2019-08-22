namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Paciente_Dueño_Asociado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_PACIENTE_DUE { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_PACIENTE_ASO { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Paciente_Asociado Paciente_Asociado { get; set; }
    }
}
