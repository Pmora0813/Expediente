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
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Digite el correo electrónico")]
        public string correo { get; set; }


        [StringLength(50)]
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "Digite numero de cédula")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Numero de cédula debe ser numérica")]
        public string cedula { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Digite nombre")]
        public string nombre { get; set; }

        [StringLength(50)]
        [Display(Name = "Primer apellido")]
        [Required(ErrorMessage = "Digite el primer apellido")]
        public string p_Apellido { get; set; }


        [StringLength(50)]
        [Display(Name = "Segundo apellido")]
        [Required(ErrorMessage = "Digite el segundo apellido")]
        public string s_Apellido { get; set; }


        [StringLength(50)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Digite la contraseña")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",
           ErrorMessage = "Formato invalido: La contraseña debe tener al menos 4 " + "\n" +
           "caracteres, no más de 8 caracteres y debe" + "\n" +
           "incluir al menos una letra mayúscula, una" + "\n" +
           "letra minúscula y un dígito numérico.")]
        public string contrasenna { get; set; }


        [StringLength(50)]
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Seleccione eñ sexo")]
        public string sexo { get; set; }

        public int estado { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }
        [Display(Name = "Tipo de usuario")]
        [Required(ErrorMessage = "Seleccione el tipo de usuario")]
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
