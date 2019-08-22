namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrador")]
    public partial class Administrador
    {
        public int id { get; set; }


        [StringLength(50)]
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Digite el correo electrónico")]
        public string correo { get; set; }

        [StringLength(50)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Digite la contraseña")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",
            ErrorMessage = "Formato invalido: La contraseña debe tener al menos 4 " + "\n" +
            "caracteres, no más de 8 caracteres y debe" + "\n" +
            "incluir al menos una letra mayúscula, una" + "\n" +
            "letra minúscula y un dígito numérico.")]
        public string contraseña { get; set; }


        public int estado { get; set; }

        public int ID_TIPO_USUARIO { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione el estado")]
        public string estado_String { get; set; }
        [Display(Name = "Tipo de usuario")]
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }
    }
}
