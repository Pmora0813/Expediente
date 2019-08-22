namespace Expediente_Electronico.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EMEPDB : DbContext
    {
        public EMEPDB()
            : base("name=EMEPDB")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<AgendaCita> AgendaCita { get; set; }
        public virtual DbSet<Alcohol> Alcohol { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Categoria_Alergia> Categoria_Alergia { get; set; }
        public virtual DbSet<Cirugia> Cirugia { get; set; }
        public virtual DbSet<Compartir_Expediente> Compartir_Expediente { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Consultorio> Consultorio { get; set; }
        public virtual DbSet<Enfermedad_Expediente> Enfermedad_Expediente { get; set; }
        public virtual DbSet<Enfermedad_Familiar> Enfermedad_Familiar { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Expediente> Expediente { get; set; }
        public virtual DbSet<Expediente_Alergia> Expediente_Alergia { get; set; }
        public virtual DbSet<Fumador> Fumador { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Lista_Actividad_Fisica> Lista_Actividad_Fisica { get; set; }
        public virtual DbSet<Lista_Alergia> Lista_Alergia { get; set; }
        public virtual DbSet<Lista_Enfermedad> Lista_Enfermedad { get; set; }
        public virtual DbSet<ListaCita> ListaCita { get; set; }
        public virtual DbSet<Medicamento> Medicamento { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Otra_Actividad> Otra_Actividad { get; set; }
        public virtual DbSet<Otra_Alergia> Otra_Alergia { get; set; }
        public virtual DbSet<Otra_Enfermedad> Otra_Enfermedad { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Paciente_Asociado> Paciente_Asociado { get; set; }
        public virtual DbSet<Paciente_Dueño_Asociado> Paciente_Dueño_Asociado { get; set; }
        public virtual DbSet<RegistrarCita> RegistrarCita { get; set; }
        public virtual DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaCita>()
                .Property(e => e.detalle)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Lista_Enfermedad)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.ID_CATEGORIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria_Alergia>()
                .HasMany(e => e.Lista_Alergia)
                .WithRequired(e => e.Categoria_Alergia)
                .HasForeignKey(e => e.ID_CATEGORIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Consulta>()
                .Property(e => e.precio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Consulta>()
                .HasMany(e => e.RegistrarCita)
                .WithRequired(e => e.Consulta)
                .HasForeignKey(e => e.ID_CONSULTA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Consultorio>()
                .HasMany(e => e.Consulta)
                .WithRequired(e => e.Consultorio)
                .HasForeignKey(e => e.ID_CONSULTORIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.Consulta)
                .WithRequired(e => e.Especialidad)
                .HasForeignKey(e => e.ID_ESPECIALIDAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Alcohol)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Cirugia)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Enfermedad_Expediente)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Enfermedad_Familiar)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Expediente_Alergia)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Fumador)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Lista_Actividad_Fisica)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Medicamento)
                .WithRequired(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Otra_Actividad)
                .WithOptional(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Otra_Alergia)
                .WithOptional(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Otra_Enfermedad)
                .WithOptional(e => e.Expediente)
                .HasForeignKey(e => e.ID_EXPEDIENTE);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.AgendaCita)
                .WithRequired(e => e.Horario)
                .HasForeignKey(e => e.idHora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.RegistrarCita)
                .WithRequired(e => e.Horario)
                .HasForeignKey(e => e.ID_HORARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lista_Alergia>()
                .HasMany(e => e.Expediente_Alergia)
                .WithRequired(e => e.Lista_Alergia)
                .HasForeignKey(e => e.ID_ALERGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lista_Enfermedad>()
                .HasMany(e => e.Enfermedad_Expediente)
                .WithRequired(e => e.Lista_Enfermedad)
                .HasForeignKey(e => e.ID_EFERMEDAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lista_Enfermedad>()
                .HasMany(e => e.Enfermedad_Familiar)
                .WithOptional(e => e.Lista_Enfermedad)
                .HasForeignKey(e => e.ID_ENFERMEDAD);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.Consulta)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.ID_MEDICO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Compartir_Expediente)
                .WithRequired(e => e.Paciente)
                .HasForeignKey(e => e.ID_PACIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Expediente)
                .WithRequired(e => e.Paciente)
                .HasForeignKey(e => e.ID_PACIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Paciente_Dueño_Asociado)
                .WithRequired(e => e.Paciente)
                .HasForeignKey(e => e.ID_PACIENTE_DUE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente_Asociado>()
                .HasMany(e => e.Paciente_Dueño_Asociado)
                .WithRequired(e => e.Paciente_Asociado)
                .HasForeignKey(e => e.ID_PACIENTE_ASO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegistrarCita>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<RegistrarCita>()
                .HasMany(e => e.ListaCita)
                .WithRequired(e => e.RegistrarCita)
                .HasForeignKey(e => e.idRegistrarCita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Administrador)
                .WithRequired(e => e.Tipo_Usuario)
                .HasForeignKey(e => e.ID_TIPO_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Medico)
                .WithRequired(e => e.Tipo_Usuario)
                .HasForeignKey(e => e.ID_TIPO_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Paciente)
                .WithRequired(e => e.Tipo_Usuario)
                .HasForeignKey(e => e.ID_TIPO_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Paciente_Asociado)
                .WithRequired(e => e.Tipo_Usuario)
                .HasForeignKey(e => e.ID_TIPO_USUARIO)
                .WillCascadeOnDelete(false);
        }
    }
}
