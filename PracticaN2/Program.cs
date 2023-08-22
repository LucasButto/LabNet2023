using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaN2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculadora calculadora = new Calculadora();

            Console.Write("Ingrese el dividendo: ");
            string dividendoStr = Console.ReadLine();

            Console.Write("Ingrese el divisor: ");
            string divisorStr = Console.ReadLine();

            Console.WriteLine("--- Ejercicio 2: División ---");
            calculadora.RealizarDivisionConValidacion(dividendoStr, divisorStr);
            Console.WriteLine("---------------------------");

            Logic logic = new Logic();

            try
            {
                logic.DispararExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("--- Ejercicio 3: Excepción Capturada ---");
                Console.WriteLine("Tipo de excepción: " + ex.GetType());
                Console.WriteLine("Mensaje de excepción: " + ex.Message);
                Console.WriteLine("---------------------------------------");
            }

            try
            {
                Exception excepcion = logic.ObtenerExcepcionPersonalizada();
                throw excepcion;
            }
            catch (MiExcepcion ex)
            {
                Console.WriteLine("--- Ejercicio 4: Excepción Personalizada ---");
                Console.WriteLine("Tipo de excepción: " + ex.GetType());
                Console.WriteLine("Mensaje de excepción: " + ex.Message);
                Console.WriteLine("------------------------------------------");
            }


            RealizarPruebasUnitarias(calculadora);

            Console.ReadLine();
        }

        static void RealizarPruebasUnitarias(Calculadora calculadora)
        {
            Console.WriteLine("Prueba 1: División con validación");
            calculadora.RealizarDivisionConValidacion("10", "2");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Prueba 2: División con valores inválidos");
            calculadora.RealizarDivisionConValidacion("10", "0");
            Console.WriteLine("---------------------------");
        }
    }
}
