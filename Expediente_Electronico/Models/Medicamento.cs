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
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }
        public int id { get; set; }

    
        [StringLength(50)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe de escribir el nombre")]
        public string nombre { get; set; }

        [Required]
               [Column(TypeName = "text")]
        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }

        [Display(Name = "Expediente")]
        [Required(ErrorMessage = "Seleccione el expediente")]
        public int ID_EXPEDIENTE { get; set; }
        [Display(Name = "Expediente")]
        public virtual Expediente Expediente { get; set; }
    }
}
