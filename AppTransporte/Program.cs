using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantOmnibus = 0;
            int cantTaxis = 0;
            int cantPasajeros;
            int tipoTransporte;

            List<TransportePublico> listaTransportes = new List<TransportePublico>();

            do
            {
                Console.WriteLine("Ingrese el tipo de transporte: (0 - Omnibus / 1 - Taxi)");
                while (!int.TryParse(Console.ReadLine(), out tipoTransporte))
                {
                    Console.WriteLine("Debe ingresar un número válido. Intente nuevamente: ");
                }

                switch (tipoTransporte)
                {
                    case 0:
                        if (cantOmnibus < 5)
                        {
                            cantPasajeros = ObtenerCantidadPasajeros(100, 0, "Omnibus");
                            Omnibus omnibus = new Omnibus(cantPasajeros);
                            ArrancarVehiculo(omnibus);
                            listaTransportes.Add(omnibus);
                            cantOmnibus++;
                            break;  
                        }
                        else
                        {
                            Console.WriteLine("Ya se ingresaron 5 omnibus");
                            break;
                        }
                    case 1:
                        if (cantTaxis < 5)
                        {
                            cantPasajeros = ObtenerCantidadPasajeros(4, 0, "taxi");
                            Taxi taxi = new Taxi(cantPasajeros);
                            ArrancarVehiculo(taxi);
                            listaTransportes.Add(taxi);
                            cantTaxis++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ya se ingresaron 5 taxis");
                            break;
                        }

                    default:
                        Console.WriteLine("El tipo de transporte ingresado no es correcto");
                        break;
                    }
            } while (cantOmnibus < 5 || cantTaxis < 5);

            ResultadoFinal(listaTransportes);
            Console.ReadKey();
        }

        static int ObtenerCantidadPasajeros(int maxPasajeros, int minPasajeros, string tipoVehiculo)
        {
            int cantPasajeros;
            Console.WriteLine($"Ingrese la cantidad de pasajeros del {tipoVehiculo}: ");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out cantPasajeros))
                {
                    Console.WriteLine("Debe ingresar un número válido. Intente nuevamente: ");
                }

                if (cantPasajeros > maxPasajeros)
                {
                    Console.WriteLine($"La cantidad de pasajeros no puede ser mayor a {maxPasajeros}. Intente nuevamente:");
                }
                if (cantPasajeros < minPasajeros)
                {
                    Console.WriteLine("La cantidad de pasajeros no puede ser menor a 0. Intente nuevamente:");
                }

            } while (cantPasajeros > maxPasajeros || cantPasajeros < minPasajeros);

            return cantPasajeros;
        }

        static void ArrancarVehiculo(TransportePublico transporte)
        {
            Console.WriteLine(transporte.Avanzar());
            Console.WriteLine(transporte.Detenerse());
        }

        static void ResultadoFinal(List<TransportePublico> transportes)
        {
            Console.WriteLine("============================================================================");
            Console.WriteLine("Lista de transportes: ");
            foreach (var transporte in transportes)
            {
                Console.WriteLine($"{transporte.GetType().Name}: {transporte.obtenerPasajeros} pasajeros");
            }
            Console.WriteLine("============================================================================");
        }
    }
}
