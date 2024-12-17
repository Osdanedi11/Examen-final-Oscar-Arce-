using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1ExamenFinalOscar.Models
{
    public class Asignacion
    {
        public int Carnet { get; set; } // Foreign Key to Empleado
        public int CodigoProyecto { get; set; } // Foreign Key to Proyecto
        public DateTime FechaAsignacion { get; set; } = DateTime.Now; // Default value
    }
}