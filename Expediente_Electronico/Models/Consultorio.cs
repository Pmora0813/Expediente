namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consultorio")]
    public partial class Consultorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consultorio()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int id { get; set; }


        [StringLength(50)]
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe escribir la descripción de consultorio")]
        public string descripcion { get; set; }

        [StringLength(50)]
        [Display(Name = "Número")]
        [Required(ErrorMessage = "Debe escribir el numero de consultorio")]
        public string numero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
