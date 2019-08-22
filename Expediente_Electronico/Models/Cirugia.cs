namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cirugia")]
    public partial class Cirugia
    {
        public int id { get; set; }

       
        [StringLength(50)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Digite el nombre de la cirugía")]
        public string nombre { get; set; }

        [Display(Name = "Fecha")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser tipo Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
                 ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        [Display(Name = "Lugar")]
        [Required(ErrorMessage = "Digite el nombre del lugar")]
        public string donde { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        [Display(Name = "Expediente")]
        public virtual Expediente Expediente { get; set; }
    }
}
