namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consulta")]
    public partial class Consulta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consulta()
        {
            RegistrarCita = new HashSet<RegistrarCita>();
        }

        public int id { get; set; }

        [Display(Name = "Médico")]
        [Required(ErrorMessage = "Seleccione el Médico")]
        public int ID_MEDICO { get; set; }

        [Display(Name = "Consultorio")]
        [Required(ErrorMessage = "Seleccione el Consultorio")]
        public int ID_CONSULTORIO { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:N2}",
    ApplyFormatInEditMode = true)]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo números sin decimales")]
        public decimal precio { get; set; }

        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = "Seleccione la especialidad")]
        public int ID_ESPECIALIDAD { get; set; }

        [Display(Name = "Consultorio")]
        public virtual Consultorio Consultorio { get; set; }

        [Display(Name = "Especialidad")]
        public virtual Especialidad Especialidad { get; set; }
        [Display(Name = "Médico")]
        public virtual Medico Medico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrarCita> RegistrarCita { get; set; }
    }
}
