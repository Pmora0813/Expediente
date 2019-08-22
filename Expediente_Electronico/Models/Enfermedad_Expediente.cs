namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Enfermedad_Expediente
    {
        public int id { get; set; }

        [Display(Name = "Enfermedad")]
        [Required(ErrorMessage = "Seleccione la enfermedad")]
        public int ID_EFERMEDAD { get; set; }

        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el expediente")]
        public int ID_EXPEDIENTE { get; set; }
        [Display(Name = "Expediente")]
        public virtual Expediente Expediente { get; set; }
        [Display(Name = "Enfermedad")]
        public virtual Lista_Enfermedad Lista_Enfermedad { get; set; }
    }
}
