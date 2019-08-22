namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Expediente_Alergia
    {
        public int id { get; set; }
        public string estado_String { get; set; }
        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el Expediente")]
        public int ID_EXPEDIENTE { get; set; }
        [Display(Name = "Alergia")]
        [Required(ErrorMessage = "Seleccione la Alergia")]
        public int ID_ALERGIA { get; set; }

        [Display(Name = "Expediente")]
        public virtual Expediente Expediente { get; set; }
        [Display(Name = "Alergia")]
        public virtual Lista_Alergia Lista_Alergia { get; set; }
    }
}
