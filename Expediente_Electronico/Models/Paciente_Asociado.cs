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
        [Required(ErrorMessage = "Seleccione el sexo")]
        public string sexo { get; set; }

        public int estado { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser tipo Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
          ApplyFormatInEditMode = true)]
        public DateTime fecha_nacimiento { get; set; }

        [Display(Name = "Tipo de sangre")]
        [Required(ErrorMessage = "Seleccione el tipo de sangre")]
        public string tipo_sangre { get; set; }

  
        [StringLength(50)]
        [Display(Name = "Resedencia")]
        [Required(ErrorMessage = "Debe escribir la residencia")]
        public string recidencia { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Debe escribir el numero de teléfono")]
        public int telefono { get; set; }

     
        [Display(Name = "Contacto de emergencia")]
        [Required(ErrorMessage = "Debe escribir el contacto de emergencia")]
        public int contacto_emergencia { get; set; }

        [StringLength(50)]
    
        [Display(Name = "Parentesco")]
        [Required(ErrorMessage = "Seleccione el parentesco")]
        public string parentesco { get; set; }
        [Display(Name = "Tipo de usuario")]
        [Required(ErrorMessage = "Seleccione el tipo de usuario")]
        public int ID_TIPO_USUARIO { get; set; }

        [Display(Name = "Tipo de usuario")]
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente_Dueño_Asociado> Paciente_Dueño_Asociado { get; set; }
    }
}
