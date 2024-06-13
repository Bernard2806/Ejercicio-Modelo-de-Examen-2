using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Modelo_de_Examen_2
{
    public class Venta : Comprobante
    {
        public string Cliente { get; set; }
        public override int CantidadNeta => -this.Cantidad;
    }
}
