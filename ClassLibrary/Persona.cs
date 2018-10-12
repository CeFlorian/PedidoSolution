using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Persona
    {
        public Int64 CUI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombres} {Apellidos}";
            }
        }

        public int Edad
        {
            get
            {
                return DateTime.Now.Year - FechaNacimiento.Year;
            }
        }

        public Persona()
        {

        }
    }
}
