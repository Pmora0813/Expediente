namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistrarCita")]
    public partial class RegistrarCita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistrarCita()
        {
            ListaCita = new HashSet<ListaCita>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_PACIENTE { get; set; }

        public int ID_CONSULTA { get; set; }

        public int ID_HORARIO { get; set; }

        public int disponible { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        public virtual Consulta Consulta { get; set; }

        public virtual Horario Horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaCita> ListaCita { get; set; }
    }
}
