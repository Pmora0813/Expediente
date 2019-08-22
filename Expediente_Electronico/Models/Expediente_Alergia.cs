namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Expediente_Alergia
    {
        public int id { get; set; }

        public int ID_EXPEDIENTE { get; set; }

        public int ID_ALERGIA { get; set; }

        public virtual Expediente Expediente { get; set; }

        public virtual Lista_Alergia Lista_Alergia { get; set; }
    }
}
