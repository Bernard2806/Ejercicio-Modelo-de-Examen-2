using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Modelo_de_Examen_2
{
    public class Tienda
    {
        public string Nombre { get; set; }
        public List<Producto> productos { get; set; }
        public List<Comprobante> comprobantes { get; set; }
    }
}
