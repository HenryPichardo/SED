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
    
    public partial class Carrera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carrera()
        {
            this.Alumnos = new HashSet<Alumnos>();
        }
    
        public int id_carrera { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public int fk_id_escuela { get; set; }
        public System.DateTime fecha_registro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public virtual Escuela Escuela { get; set; }
    }
}
