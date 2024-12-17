using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1ExamenFinalOscar.Models
{
    public class Empleado
    {
        public int Carnet { get; set; } // Primary Key
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = "San José"; // Default value
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; } // Unique
        public decimal Salario { get; set; } = 250000; // Default value, constraint <= 500000
        public string Categoria { get; set; } // Foreign Key to CategoriaLaboral
    }
}