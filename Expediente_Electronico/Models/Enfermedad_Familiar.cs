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

      
        [StringLength(50)]
        [Display(Name = "Parentesco")]
        [Required(ErrorMessage = "Debe seleccionar el parentesco")]
        public string parentesco { get; set; }

        [StringLength(50)]

        [Display(Name = "Enfermedad")]
        [Required(ErrorMessage = "Seleccione la enfermedad")]
        public string observaciones { get; set; }
        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el expediente")]
        public int ID_EXPEDIENTE { get; set; }
        [Display(Name = "Expediente")]
        public int? ID_ENFERMEDAD { get; set; }

        public virtual Expediente Expediente { get; set; }
        [Display(Name = "Enfermedad")]
        public virtual Lista_Enfermedad Lista_Enfermedad { get; set; }
    }
}
