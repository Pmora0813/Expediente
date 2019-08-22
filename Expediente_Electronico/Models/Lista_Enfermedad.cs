namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lista_Enfermedad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lista_Enfermedad()
        {
            Enfermedad_Expediente = new HashSet<Enfermedad_Expediente>();
            Enfermedad_Familiar = new HashSet<Enfermedad_Familiar>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        public int ID_CATEGORIA { get; set; }

        public int estado { get; set; }
        public string estado_String { get; set; }
        public int? ID_EXPEDIENTE { get; set; }

        [Required]
        [StringLength(50)]
        public string img { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enfermedad_Expediente> Enfermedad_Expediente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enfermedad_Familiar> Enfermedad_Familiar { get; set; }
    }
}
