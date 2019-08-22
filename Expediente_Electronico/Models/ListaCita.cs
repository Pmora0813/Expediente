namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListaCita")]
    public partial class ListaCita
    {
        public int id { get; set; }

        public int idRegistrarCita { get; set; }

        public virtual RegistrarCita RegistrarCita { get; set; }
    }
}
