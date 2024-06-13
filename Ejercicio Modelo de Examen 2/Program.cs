using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Modelo_de_Examen_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuInicio();
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
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
