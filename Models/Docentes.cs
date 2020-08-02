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
    
    public partial class Docentes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docentes()
        {
            this.Asignatura_Docente = new HashSet<Asignatura_Docente>();
            this.Docente_Evaluacion = new HashSet<Docente_Evaluacion>();
            this.Secion = new HashSet<Secion>();
        }
    
        public int id_docente { get; set; }
        public string codigo_empleado { get; set; }
        public int fk_id_periodo { get; set; }
        public string nombre { get; set; }
        public int fk_id_escuela { get; set; }
        public System.DateTime fechaRegistro { get; set; }
        public string correo_universitario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asignatura_Docente> Asignatura_Docente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Docente_Evaluacion> Docente_Evaluacion { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual Periodo Periodo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Secion> Secion { get; set; }
    }
}