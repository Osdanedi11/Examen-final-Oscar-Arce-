//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1ExamenFinalOscar.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asignacion
    {
        public int Carnet { get; set; }
        public int CodigoProyecto { get; set; }
        public Nullable<System.DateTime> FechaAsignacion { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
