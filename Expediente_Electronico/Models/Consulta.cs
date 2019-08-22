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

        public int ID_MEDICO { get; set; }

        public int ID_CONSULTORIO { get; set; }

        public decimal precio { get; set; }

        public int ID_ESPECIALIDAD { get; set; }

        public virtual Consultorio Consultorio { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        public virtual Medico Medico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrarCita> RegistrarCita { get; set; }
    }
}
