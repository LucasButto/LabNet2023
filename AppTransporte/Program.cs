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
                            Console.WriteLine("Ingrese la cantidad de pasajeros: ");
                            do
                            {
                                while (!int.TryParse(Console.ReadLine(), out cantPasajeros))
                                {
                                    Console.WriteLine("Debe ingresar un número válido. Intente nuevamente: ");
                                }

                                if (cantPasajeros > 100)
                                {
                                    Console.WriteLine("La cantidad de pasajeros no puede ser mayor a 100. Intente nuevamente:");
                                }
                                if (cantPasajeros < 0)
                                {
                                    Console.WriteLine("La cantidad de pasajeros no puede ser menor a 0. Intente nuevamente:");
                                }

                            } while (cantPasajeros > 100 || cantPasajeros < 0);

                            Omnibus omnibus = new Omnibus(cantPasajeros);
                            Console.WriteLine(omnibus.Avanzar());
                            Console.WriteLine(omnibus.Detenerse());
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
                            Console.WriteLine("Ingrese la cantidad de pasajeros: ");
                            do
                            {
                                while (!int.TryParse(Console.ReadLine(), out cantPasajeros))
                                {
                                    Console.WriteLine("Debe ingresar un número válido. Intente nuevamente: ");
                                }

                                if (cantPasajeros > 4)
                                {
                                    Console.WriteLine("La cantidad de pasajeros no puede ser mayor a 4. Intente nuevamente:");
                                }
                                if (cantPasajeros < 0)
                                {
                                    Console.WriteLine("La cantidad de pasajeros no puede ser menor a 0. Intente nuevamente:");
                                }

                            } while (cantPasajeros > 4 || cantPasajeros < 0);
                            Taxi taxi = new Taxi(cantPasajeros);
                            Console.WriteLine(taxi.Avanzar());
                            Console.WriteLine(taxi.Detenerse());
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

            Console.WriteLine("============================================================================");
            Console.WriteLine("Lista de transportes: ");
            foreach (var transporte in listaTransportes)
            {
                Console.WriteLine(transporte.GetType().Name + ": " + transporte.getPasajeros + " pasajeros");
            }
            Console.WriteLine("============================================================================");
            Console.ReadKey();
        }
    }
}
