namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paciente")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            Compartir_Expediente = new HashSet<Compartir_Expediente>();
            Expediente = new HashSet<Expediente>();
            Paciente_Dueño_Asociado = new HashSet<Paciente_Dueño_Asociado>();
        }

        [Key]
        [StringLength(50)]
        public string correo { get; set; }

        [Required]
        [StringLength(50)]
        public string cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string p_Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string s_Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string contrasenna { get; set; }

        [Required]
        [StringLength(50)]
        public string sexo { get; set; }

        public int estado { get; set; }
        public string estado_String { get; set; }

        public int ID_TIPO_USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compartir_Expediente> Compartir_Expediente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expediente> Expediente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente_Dueño_Asociado> Paciente_Dueño_Asociado { get; set; }

        public virtual Tipo_Usuario Tipo_Usuario { get; set; }
    }
}
