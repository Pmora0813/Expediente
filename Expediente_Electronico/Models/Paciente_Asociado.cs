namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Paciente_Asociado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente_Asociado()
        {
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

        [Column(TypeName = "date")]
        public DateTime fecha_nacimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_sangre { get; set; }

        [Required]
        [StringLength(50)]
        public string recidencia { get; set; }

        public int telefono { get; set; }

        public int contacto_emergencia { get; set; }

        [Required]
        [StringLength(50)]
        public string parentesco { get; set; }

        public int ID_TIPO_USUARIO { get; set; }

        public virtual Tipo_Usuario Tipo_Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente_Dueño_Asociado> Paciente_Dueño_Asociado { get; set; }
    }
}
