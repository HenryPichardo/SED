//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Secion
    {
        public int id_secion { get; set; }
        public int fk_id_docente { get; set; }
        public int fk_id_alumno { get; set; }
        public int fk_id_asignatura { get; set; }
        public string correo_universitario { get; set; }
    
        public virtual Alumnos Alumnos { get; set; }
        public virtual Asignatura Asignatura { get; set; }
        public virtual Docentes Docentes { get; set; }
    }
}