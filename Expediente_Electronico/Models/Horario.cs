namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Horario")]
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            AgendaCita = new HashSet<AgendaCita>();
            RegistrarCita = new HashSet<RegistrarCita>();
        }
        public string estado_String { get; set; }
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string hora { get; set; }

        [Required]
        [StringLength(50)]
        public string am_pm { get; set; }

        [Column(TypeName = "date")]
        public DateTime dia { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public int estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgendaCita> AgendaCita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrarCita> RegistrarCita { get; set; }
    }
}
