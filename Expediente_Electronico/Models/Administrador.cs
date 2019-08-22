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

        [Required]
        [StringLength(50)]
        public string correo { get; set; }

        [Required]
        [StringLength(50)]
        public string contraseña { get; set; }

        public int estado { get; set; }

        public int ID_TIPO_USUARIO { get; set; }

        public string estado_String { get; set; }
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }
    }
}
