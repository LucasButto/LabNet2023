using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaN2
{
    public class Calculadora
    {
        public void RealizarDivision(int numerador, int denominador)
        {
            try
            {
                int resultado = numerador / denominador;
                Console.WriteLine("La división se realizó exitosamente. Resultado: " + resultado);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operación completada.");
            }
        }

        public void RealizarDivisionConValidacion(string dividendoStr, string divisorStr)
        {
            if (!int.TryParse(dividendoStr, out int dividendo) || !int.TryParse(divisorStr, out int divisor))
            {
                Console.WriteLine("¡Seguro ingresó una letra o no ingresó nada!");
                return;
            }

            try
            {
                int resultado = dividendo / divisor;
                Console.WriteLine("La división se realizó exitosamente. Resultado: " + resultado);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operación completada.");
            }
        }

    }
}
