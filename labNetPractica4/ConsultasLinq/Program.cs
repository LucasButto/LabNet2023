using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasLinq.Logic;
using ConsultasLinq.Entities;
using static ConsultasLinq.Logic.QueriesLogic;

namespace ConsultasLinq
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Mostrar resultado Ejercicio 1");
                Console.WriteLine("2. Mostrar resultado Ejercicio 2");
                Console.WriteLine("3. Mostrar resultado Ejercicio 3");
                Console.WriteLine("4. Mostrar resultado Ejercicio 4");
                Console.WriteLine("5. Mostrar resultado Ejercicio 5");
                Console.WriteLine("6. Mostrar resultado Ejercicio 6");
                Console.WriteLine("7. Mostrar resultado Ejercicio 7");
                Console.WriteLine("8. Mostrar resultado Ejercicio 8");
                Console.WriteLine("9. Mostrar resultado Ejercicio 9");
                Console.WriteLine("10. Mostrar resultado Ejercicio 10");
                Console.WriteLine("11. Mostrar resultado Ejercicio 11");
                Console.WriteLine("12. Mostrar resultado Ejercicio 12");
                Console.WriteLine("13. Mostrar resultado Ejercicio 13");
                Console.WriteLine("14. Salir");

                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        EjecutarSubMenu(Ejercicio1);
                        break;
                    case "2":
                        EjecutarSubMenu(Ejercicio2);
                        break;
                    case "3":
                        EjecutarSubMenu(Ejercicio3);
                        break;
                    case "4":
                        EjecutarSubMenu(Ejercicio4);
                        break;
                    case "5":
                        EjecutarSubMenu(Ejercicio5);
                        break;
                    case "6":
                        EjecutarSubMenu(Ejercicio6);
                        break;
                    case "7":
                        EjecutarSubMenu(Ejercicio7);
                        break;
                    case "8":
                        EjecutarSubMenu(Ejercicio8);
                        break;
                    case "9":
                        EjecutarSubMenu(Ejercicio9);
                        break;
                    case "10":
                        EjecutarSubMenu(Ejercicio10);
                        break;
                    case "11":
                        EjecutarSubMenu(Ejercicio11);
                        break;
                    case "12":
                        EjecutarSubMenu(Ejercicio12);
                        break;
                    case "13":
                        EjecutarSubMenu(Ejercicio13);
                        break;
                    case "14":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        private static void Ejercicio1()
        {
            //1. Query para devolver objeto customer
            var queries = new QueriesLogic();
            var customer = queries.GetCustomerById("ALFKI");

            if (customer != null)
            {
                Console.WriteLine($"Customer: {customer.CompanyName}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
        private static void Ejercicio2()
        {
            //2. Query para devolver todos los productos sin stock
            var queries = new QueriesLogic();
            var productsOutOfStock = queries.GetProductsOutOfStock();
            Console.WriteLine($"Products out of stock: {productsOutOfStock.Count}");
        }

        private static void Ejercicio3() 
        {
            //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad
            var queries = new QueriesLogic();
            var productsInStockAndPriceGreaterThan3 = queries.GetProductsInStockAndPriceGreaterThan3();
            Console.WriteLine($"Products in stock and price greater than 3: {productsInStockAndPriceGreaterThan3.Count}");
        }

        private static void Ejercicio4()
        {
            //4. Query para devolver todos los customers de la Región WA
            var queries = new QueriesLogic();
            var customersByRegion = queries.GetCustomersByRegion("WA");
            Console.WriteLine($"Customers in region WA: {customersByRegion.Count}");
        }

        private static void Ejercicio5()
        {
            //5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789
            var queries = new QueriesLogic();
            var productById = queries.GetProductById(789);
            if (productById != null)
            {
                Console.WriteLine($"Product: {productById.ProductName}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        private static void Ejercicio6()
        {
            //6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.
            var queries = new QueriesLogic();
            
            Console.WriteLine("Selecciona una opción: ");
            Console.WriteLine("1. Mostrar nombre en Minuscula");
            Console.WriteLine("2. Mostrar nombre en Mayuscula");
            Console.WriteLine("3. Volver");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    var customersNameLower = queries.GetCustomersNameLower();
                    foreach (var name in customersNameLower)
                    {
                        Console.WriteLine($"Customer name Lowercase: {name}");
                    }
                    break;
                case "2":
                    var customersNameUpper = queries.GetCustomersNameUpper();
                    foreach (var name in customersNameUpper)
                    {
                        Console.WriteLine($"Customer name Uppercase: {name}");
                    }
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

        private static void Ejercicio7()
        {
            //7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.
            var queries = new QueriesLogic();
            var customersByRegionAndOrderDate = queries.GetCustomersByRegionAndOrderDate("WA", new DateTime(1997, 1, 1));
            Console.WriteLine($"Customers in region WA and order date greater than 1/1/1997: {customersByRegionAndOrderDate.Count}");
        }

        private static void Ejercicio8()
        {
            //8. Query para devolver los primeros 3 Customers de la  Región WA
            var queries = new QueriesLogic();
            var first3CustomersByRegion = queries.GetFirst3CustomersByRegion("WA");
            foreach (var customerByRegion in first3CustomersByRegion)
            {
                Console.WriteLine($"Customer: {customerByRegion.CompanyName}");
            }
        }

        private static void Ejercicio9()
        {
            //9. Query para devolver lista de productos ordenados por nombre
            var queries = new QueriesLogic();
            var productsOrderedByName = queries.GetProductsOrderByName();
            foreach (var product in productsOrderedByName)
            {
                Console.WriteLine($"Product: {product.ProductName}");
            }
        }

        private static void Ejercicio10()
        {
            //10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.
            var queries = new QueriesLogic();
            var productsOrderedByStock = queries.GetProductsOrderByUnitInStock();
            foreach (var product in productsOrderedByStock)
            {
                Console.WriteLine($"Product: {product.ProductName} - Stock: {product.UnitsInStock}");
            }
        }

        private static void Ejercicio11()
        {
            //11. Query para devolver las distintas categorías asociadas a los productos, hacer un join de productos y categorias.
            var queries = new QueriesLogic();
            var productsWithCategories = queries.GetProductsWithCategories();

            foreach (var item in productsWithCategories)
            {
                Console.WriteLine($"Product: {item.Product} - Category: {item.Category}");
            }
        }

        private static void Ejercicio12()
        {
            //12. Query para devolver el primer elemento de una lista de productos.
            var queries = new QueriesLogic();
            var firstProduct = queries.GetFirstProduct();
            Console.WriteLine($"First product: {firstProduct.ProductName}");
        }

        private static void Ejercicio13()
        {
            //13. Query para devolver los customer con la cantidad de ordenes asociadas
            var queries = new QueriesLogic();
            var customersWithOrders = queries.GetCustomersWithOrders();
            foreach (var customerWithOrder in customersWithOrders)
            {
                Console.WriteLine($"Customer: {customerWithOrder.Customer} - Orders: {customerWithOrder.Orders}");
            }
        }

        private static void EjecutarSubMenu(Action subMenuFunc)
        {
            Console.Clear();
            Console.WriteLine("============================================================");
            subMenuFunc();
            Console.WriteLine("============================================================");
            while (true)
            {
                Console.WriteLine("\n1. Volver al menú principal");
                Console.WriteLine("2. Salir del programa");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.Clear();
                    return;
                }
                else if (opcion == "2")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }
        }
    }
}
