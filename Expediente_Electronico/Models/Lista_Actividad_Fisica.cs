namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lista_Actividad_Fisica
    {
        public int id { get; set; }

        public int activo { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        public int? minutos { get; set; }

        public int? cant_veces { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        public virtual Expediente Expediente { get; set; }
    }
}
