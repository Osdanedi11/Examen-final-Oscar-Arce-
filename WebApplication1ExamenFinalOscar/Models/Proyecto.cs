using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1ExamenFinalOscar.Models
{
    public class Proyecto
    {
        public int CodigoProyecto { get; set; } // Primary Key
        public string NombreProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; } // Nullable
    }
}