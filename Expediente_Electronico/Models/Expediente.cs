namespace Expediente_Electronico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expediente")]
    public partial class Expediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expediente()
        {
            Alcohol = new HashSet<Alcohol>();
            Cirugia = new HashSet<Cirugia>();
            Enfermedad_Expediente = new HashSet<Enfermedad_Expediente>();
            Enfermedad_Familiar = new HashSet<Enfermedad_Familiar>();
            Expediente_Alergia = new HashSet<Expediente_Alergia>();
            Fumador = new HashSet<Fumador>();
            Lista_Actividad_Fisica = new HashSet<Lista_Actividad_Fisica>();
            Medicamento = new HashSet<Medicamento>();
            Otra_Actividad = new HashSet<Otra_Actividad>();
            Otra_Alergia = new HashSet<Otra_Alergia>();
            Otra_Enfermedad = new HashSet<Otra_Enfermedad>();
        }

        public int id { get; set; }


        [Display(Name = "Fecha")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser tipo Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
          ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        public int estado { get; set; }

      
        [StringLength(50)]
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Seleccione el Paciente")]
        public string ID_PACIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alcohol> Alcohol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cirugia> Cirugia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enfermedad_Expediente> Enfermedad_Expediente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enfermedad_Familiar> Enfermedad_Familiar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expediente_Alergia> Expediente_Alergia { get; set; }
        [Display(Name = "Paciente")]
        public virtual Paciente Paciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fumador> Fumador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lista_Actividad_Fisica> Lista_Actividad_Fisica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicamento> Medicamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otra_Actividad> Otra_Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otra_Alergia> Otra_Alergia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otra_Enfermedad> Otra_Enfermedad { get; set; }
    }
}
