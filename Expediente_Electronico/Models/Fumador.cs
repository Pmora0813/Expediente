namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fumador")]
    public partial class Fumador
    {
        public int id { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }
        public int activo { get; set; }
        [Display(Name = "Cantidad de cigerros")]
        [Required(ErrorMessage = "Digite la cantidad de cigarros")]
        public int? cant_cigarrillos { get; set; }

        [Display(Name = "Cantidad de tiempo")]
        [Required(ErrorMessage = "Digite la cantidad de tiempo de fumado")]
        public int? tiempo { get; set; }

        [StringLength(50)]
        [Column(TypeName = "text")]
        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string observaciones { get; set; }
        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el Expediente")]
        public int ID_EXPEDIENTE { get; set; }
        [Display(Name = "Expediente")]
        public virtual Expediente Expediente { get; set; }
    }
}
