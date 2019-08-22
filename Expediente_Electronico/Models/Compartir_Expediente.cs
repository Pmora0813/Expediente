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

        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el Expediente")]
        public int ID_EXPEDIENTE { get; set; }

 
        [StringLength(50)]
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Seleccione el Paciente")]
        public string ID_PACIENTE { get; set; }

        public int estado { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }
        [Required]
        [StringLength(50)]
        public string ID_PACIENTE_COMPARTE { get; set; }

        [Display(Name = "Paciente")]
        public virtual Paciente Paciente { get; set; }
    }
}
