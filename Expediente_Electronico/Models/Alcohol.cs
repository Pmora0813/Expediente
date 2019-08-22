namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alcohol")]
    public partial class Alcohol
    {
        [Key]
        public int id { get; set; }

        public int activo { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }

        [Display(Name = "Inicio")]
        [Required(ErrorMessage = "Digite la edad  de inicio")]
        public int? inicio { get; set; }

        [Display(Name = "Frecuencia")]
        [Required(ErrorMessage = "Digite la frecuencia de tomado")]
        public int? frecuencia { get; set; }

        [StringLength(50)]
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Seleccione el tipo de bebida")]
        public string tipo { get; set; }

        public int? cant_tipo { get; set; }

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
