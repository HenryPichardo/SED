﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SED.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SEDEntities : DbContext
    {
        public SEDEntities()
            : base("name=SEDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<Asignatura_Alumno> Asignatura_Alumno { get; set; }
        public virtual DbSet<Asignatura_Docente> Asignatura_Docente { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Categoria_Pregunta> Categoria_Pregunta { get; set; }
        public virtual DbSet<Cuestionario> Cuestionario { get; set; }
        public virtual DbSet<Detalle_Evaluacion> Detalle_Evaluacion { get; set; }
        public virtual DbSet<Directores_Escuelas> Directores_Escuelas { get; set; }
        public virtual DbSet<Docente_Evaluacion> Docente_Evaluacion { get; set; }
        public virtual DbSet<Docentes> Docentes { get; set; }
        public virtual DbSet<Escuela> Escuela { get; set; }
        public virtual DbSet<Evaluacion> Evaluacion { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<Pregunta> Pregunta { get; set; }
        public virtual DbSet<Preguntas_Cuestionario> Preguntas_Cuestionario { get; set; }
        public virtual DbSet<Respuestas> Respuestas { get; set; }
        public virtual DbSet<Secion> Secion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tipo_Cuestionario> Tipo_Cuestionario { get; set; }
        public virtual DbSet<Tipo_Evaluador> Tipo_Evaluador { get; set; }
        public virtual DbSet<Tipo_Pregunta> Tipo_Pregunta { get; set; }
        public virtual DbSet<Detalle_Pregunta> Detalle_Pregunta { get; set; }
    }
}