using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb03
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Sueldo { get; set; }
        public DateTime Fecha_nac { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Sueldo: {Sueldo}, Fecha de Nacimiento: {Fecha_nac}";
        }
    }
}
