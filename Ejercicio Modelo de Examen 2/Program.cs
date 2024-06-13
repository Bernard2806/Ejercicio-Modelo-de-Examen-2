using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Modelo_de_Examen_2
{
    internal class Program
    {
        private static string[] MenuSeleccion = new string[] {
            "Registrar Producto",
            "Registrar Compra",
            "Registrar Venta",
            "Consultar Stock",
            "Total de Ventas",
            "Total de Compras",
            "Ganancias"
        };

        static void Main(string[] args)
        {
            MenuInicio();
            Tienda tienda = new Tienda();
            Console.WriteLine("Ingrese un Nombre para la Tienda");
            tienda.Nombre = Console.ReadLine();
            ProcesarMenu(tienda, MostrarMenu(MenuSeleccion));
        }
        static void ProcesarMenu(Tienda tienda, int Opt) {
            switch (Opt) {
                case 0:
                    RegistrarProducto(tienda);
                    break;
                case 1:
                    RegistrarComprobante(tienda, true);
                    break;
                case 2:
                    RegistrarComprobante(tienda, false);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el Codigo del Producto a Consultar:");
                    int Codigo = int.Parse(Console.ReadLine());
                    ReportarStock(tienda, Codigo);
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
        static void ReportarStock(Tienda tienda, int codigoProducto)
        {
            Producto actual = null;
            foreach (Producto p in tienda.productos)
            {
                if (p.Codigo == codigoProducto)
                {
                    actual = p;
                    break;
                }
            }
            if (actual == null)
            {
                Console.WriteLine("Producto no encontrado");
                return;
            }
            int total = actual.Stock;
            foreach (Comprobante c in tienda.comprobantes)
            {
                if (c.CodigoProducto == codigoProducto)
                    total += c.CantidadNeta;
            }
            Console.WriteLine("Producto encontrado");
            Console.WriteLine(actual.Descripcion);
            Console.WriteLine($"Stock actual: {total}");
        }
        static void RegistrarComprobante(Tienda tienda, bool esCompra)
        {
            Console.Clear();
            Comprobante c;
            if (esCompra)
                c = new Compra();
            else
                c = new Venta();
            Console.WriteLine("Ingrese el codigo ");
            c.CodigoProducto = int.Parse(Console.ReadLine());
            foreach (Producto p in tienda.productos)
            {
                if (p.Codigo == c.CodigoProducto)
                {
                    Console.WriteLine($"El producto encontrado - {p.Descripcion}");
                    Console.WriteLine("Ingrese la cantidad");
                    c.Cantidad = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el precio unitario ");
                    c.PrecioUnitario = float.Parse(Console.ReadLine());

                    if (esCompra)
                    {
                        Console.WriteLine("Ingrese el proveedor ");
                        (c as Compra).Proveedor = Console.ReadLine();

                    }
                    else
                    {
                        Console.WriteLine("Ingrese el Cliente ");
                        (c as Venta).Cliente = Console.ReadLine();
                    }
                    tienda.comprobantes.Add(c);
                    return;
                }
            }
            Console.WriteLine("Producto No encontrado");
            Console.ReadKey();
            Console.Clear();
        }

        static void RegistrarProducto(Tienda tienda)
        {
            Console.Clear();
            Producto producto = new Producto();
            Console.WriteLine("Ingrese el codigo para el nuevo producto");
            producto.Codigo = int.Parse(Console.ReadLine());
            foreach (Producto p in tienda.productos)
            {
                if (p.Codigo == producto.Codigo)
                {
                    Console.WriteLine($"El producto ya existe - {p.Descripcion}");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("Ingrese la descripcion para el nuevo producto");
            producto.Descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese el stock actual para el nuevo producto");
            producto.Stock = int.Parse(Console.ReadLine());
            tienda.productos.Add(producto);
            Console.Clear();
        }

        static void MenuInicio() {
            string PrintMenu = @".-.   .-. .----. .----. .----..-.    .----.    .----. .----.   .----..-.  .-.  .--.  .-.   .-..----..-. .-.   
|  `.'  |/  {}  \| {}  \| {_  | |   /  {}  \   | {}  \| {_     | {_   \ \/ /  / {} \ |  `.'  || {_  |  `| |   
| |\ /| |\      /|     /| {__ | `--.\      /   |     /| {__    | {__  / /\ \ /  /\  \| |\ /| || {__ | |\  |   
`-' ` `-' `----' `----' `----'`----' `----'    `----' `----'   `----'`-'  `-'`-'  `-'`-' ` `-'`----'`-' `-'   ";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(PrintMenu);
            Console.WriteLine("");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        static int MostrarMenu(string[] Opciones, string InitalText = "Seleccione una opción del menu:")
        {
            bool loop = true;
            int counter = 0;
            ConsoleKeyInfo Tecla;

            Console.CursorVisible = false;

            while (loop)
            {
                Console.Clear();
                Console.WriteLine(InitalText + System.Environment.NewLine);
                string SeleccionActual = string.Empty;
                int Destacado = 0;

                Array.ForEach(Opciones, element =>
                {
                    if (Destacado == counter)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(" > " + element + " < ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        SeleccionActual = element;
                    }
                    else
                    {
                        Console.WriteLine(element);
                    }
                    Destacado++;
                });

                Tecla = Console.ReadKey(true);
                if (Tecla.Key == ConsoleKey.Enter)
                {
                    loop = false;
                    break;
                }
                switch (Tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (counter < Opciones.Length - 1) counter++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (counter > 0) counter--;
                        break;
                    default:
                        break;
                }
            }
            return counter;
        }
    }
}
