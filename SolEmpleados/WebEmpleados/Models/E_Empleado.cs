using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEmpleados.Models
{
    public class E_Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string NumeroEmpleado { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool TiempoCompleto { get; set; }

        //Propiedad de solo lectura o propiedades full

        public string TiempoCompletoDescripcion
        {
            get
            {
                if (TiempoCompleto == true)
                    return "si";
                else
                    return "no";
            }
        }

        public string Edad
        {
            get
            {
                //Obteniendo la fecha actual
                DateTime fechaActual = DateTime.Now;
                //Calculando
                return $"{fechaActual.Year - FechaNacimiento.Year} "+ "años";
            }
        }
    }
}