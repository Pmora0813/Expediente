namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lista_Alergia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lista_Alergia()
        {
            Expediente_Alergia = new HashSet<Expediente_Alergia>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        public int ID_CATEGORIA { get; set; }

        public int estado { get; set; }
        public string estado_String { get; set; }
        [StringLength(50)]
        public string reaccion { get; set; }

        [StringLength(50)]
        public string observaciones { get; set; }

        public int? ID_EXPEDIENTE { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        public virtual Categoria_Alergia Categoria_Alergia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expediente_Alergia> Expediente_Alergia { get; set; }
    }
}
