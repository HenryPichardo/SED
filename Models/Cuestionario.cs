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
    
    public partial class Cuestionario
    {
        public int id_cuestionario { get; set; }
        public int fk_id_periodo { get; set; }
        public int fk_id_tipo_cuestionario { get; set; }
        public int cantidad_categoria { get; set; }
        public System.DateTime fecha_registro { get; set; }
    
        public virtual Periodo Periodo { get; set; }
        public virtual Tipo_Cuestionario Tipo_Cuestionario { get; set; }
    }
}
