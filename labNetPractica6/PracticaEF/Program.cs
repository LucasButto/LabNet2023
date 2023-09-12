using PracticaEF.Logic;
using PracticaEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEF
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Listar Categorías");
                Console.WriteLine("2. Listar Proveedores");
                Console.WriteLine("3. Insertar Proveedor");
                Console.WriteLine("4. Actualizar Proveedor");
                Console.WriteLine("5. Eliminar Proveedor");
                Console.WriteLine("6. Salir");

                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        EjecutarSubMenu(ListarCategorias);
                        break;
                    case "2":
                        EjecutarSubMenu(ListarProveedores);
                        break;
                    case "3":
                        EjecutarSubMenu(InsertarProveedor);
                        break;
                    case "4":
                        EjecutarSubMenu(ActualizarProveedor);
                        break;
                    case "5":
                        EjecutarSubMenu(EliminarProveedor);
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }


        }

        private static void ListarProveedores()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            var proveedores = suppliersLogic.GetAll();

            Console.WriteLine("Listado de Proveedores:");
            foreach (var proveedor in proveedores)
            {
                Console.WriteLine($"ID: {proveedor.SupplierID}, Nombre: {proveedor.ContactName}, Empresa: {proveedor.CompanyName}");
            }
        }

        private static void ListarCategorias()
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            var categorias = categoriesLogic.GetAll();

            Console.WriteLine("Listado de Categorías:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.CategoryID}, Nombre: {categoria.CategoryName}");
            }
        }

        private static void InsertarProveedor()
        {
            Console.WriteLine("Insertar nuevo proveedor:");

            Suppliers nuevoProveedor = new Suppliers();

            Console.Write("Nombre de la empresa: ");
            nuevoProveedor.CompanyName = Console.ReadLine();

            Console.Write("Nombre del contacto: ");
            nuevoProveedor.ContactName = Console.ReadLine();

            Console.Write("Teléfono: ");
            nuevoProveedor.Phone = Console.ReadLine();

            Console.Write("Código Postal: ");
            nuevoProveedor.PostalCode = Console.ReadLine();

            SuppliersLogic suppliersLogic = new SuppliersLogic();
            suppliersLogic.InsertSupplier(nuevoProveedor);

            Console.WriteLine("Proveedor insertado con éxito.");
        }

        private static void ActualizarProveedor()
        {
            Console.WriteLine("Actualizar proveedor:");

            Console.Write("ID del proveedor a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int supplierID))
            {
                SuppliersLogic suppliersLogic = new SuppliersLogic();
                var proveedor = suppliersLogic.GetSupplierById(supplierID);

                if (proveedor != null)
                {
                    Console.WriteLine($"\nID: {proveedor.SupplierID}");
                    Console.WriteLine($"Nombre de la empresa: {proveedor.CompanyName}");
                    Console.WriteLine($"Nombre del contacto: {proveedor.ContactName}");
                    Console.WriteLine($"Teléfono: {proveedor.Phone}");
                    Console.WriteLine($"Código Postal: {proveedor.PostalCode}");

                    string confirmacion;
                    while (true)
                    {
                        Console.Write("\n¿Desea actualizar este proveedor? (S/N): ");
                        confirmacion = Console.ReadLine().Trim().ToUpper();

                        if (confirmacion == "S")
                        {
                            Console.Write("\nNuevo nombre de la empresa: ");
                            proveedor.CompanyName = Console.ReadLine();

                            Console.Write("Nuevo nombre del contacto: ");
                            proveedor.ContactName = Console.ReadLine();

                            Console.Write("Nuevo teléfono: ");
                            proveedor.Phone = Console.ReadLine();

                            Console.Write("Nuevo código postal: ");
                            proveedor.PostalCode = Console.ReadLine();

                            suppliersLogic.UpdateSupplier(proveedor);

                            Console.WriteLine("Proveedor actualizado con éxito.");
                            break;
                        }
                        else if (confirmacion == "N")
                        {
                            Console.WriteLine("Actualización cancelada.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Proveedor no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }


        private static void EliminarProveedor()
        {
            Console.WriteLine("Eliminar proveedor:");

            Console.Write("ID del proveedor a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int supplierID))
            {
                SuppliersLogic suppliersLogic = new SuppliersLogic();
                var proveedor = suppliersLogic.GetSupplierById(supplierID);

                if (proveedor != null)
                {
                    Console.WriteLine($"\nID: {proveedor.SupplierID}");
                    Console.WriteLine($"Nombre de la empresa: {proveedor.CompanyName}");
                    Console.WriteLine($"Nombre del contacto: {proveedor.ContactName}");
                    Console.WriteLine($"Teléfono: {proveedor.Phone}");
                    Console.WriteLine($"Código Postal: {proveedor.PostalCode}");

                    string confirmacion;
                    while (true)
                    {
                        Console.WriteLine("\n¿Desea eliminar este proveedor? (S/N): ");
                        Console.WriteLine("*Los IDs de proveedor en los productos se estableceran en null.");
                        confirmacion = Console.ReadLine().Trim().ToUpper();

                        if (confirmacion == "S")
                        {
                            suppliersLogic.DeleteSupplier(supplierID);

                            Console.WriteLine("Proveedor eliminado con éxito.");
                            break;
                        }
                        else if (confirmacion == "N")
                        {
                            Console.WriteLine("Eliminación cancelada.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Proveedor no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        private static void EjecutarSubMenu(Action subMenuFunc)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            subMenuFunc();
            Console.WriteLine("==========================================");
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
