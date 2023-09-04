using ConsultasLinq.Data;
using ConsultasLinq.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasLinq.Logic
{
    public class QueriesLogic
    {
        private readonly NorthwindContext _context;

        public QueriesLogic()
        {
            _context = new NorthwindContext();
        }

        //1. Query para devolver objeto customer
        public Customers GetCustomerById(string id)
        {
            return _context.Customers.FirstOrDefault(x => x.CustomerID == id);
        }

        //2. Query para devolver todos los productos sin stock
        public List<Products> GetProductsOutOfStock()
        {
            return _context.Products.Where(x => x.UnitsInStock == 0).ToList();
        }

        //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad

        public List<Products> GetProductsInStockAndPriceGreaterThan3()
        {
            var query = from product in _context.Products
                        where product.UnitsInStock > 0 && product.UnitPrice > 3
                        select product;

            return query.ToList();
        }

        //4. Query para devolver todos los customers de la Región WA
        public List<Customers> GetCustomersByRegion(string region)
        {
            return _context.Customers.Where(x => x.Region == region).ToList();
        }

        //5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789
        public Products GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ProductID == id);
        }

        //6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.
        public List<string> GetCustomersNameLower()
        {
            var query = from customer in _context.Customers
                        select customer.CompanyName.ToLower();

            return query.ToList();
        }
        public List<string> GetCustomersNameUpper()
        {
            return _context.Customers.Select(x => x.CompanyName.ToUpper()).ToList();
        }

        //7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.
        public List<Customers> GetCustomersByRegionAndOrderDate(string region, DateTime date)
        {
            return _context.Customers
                .Where(c => c.Region == region)
                .Join(_context.Orders, c => c.CustomerID, o => o.CustomerID, (c, o) => new { c, o })
                .Where(x => x.o.OrderDate > date)
                .Select(x => x.c)
                .ToList();
        }

        //8. Query para devolver los primeros 3 Customers de la  Región WA
        public List<Customers> GetFirst3CustomersByRegion(string region)
        {
            return _context.Customers.Where(x => x.Region == region).Take(3).ToList();
        }

        //9. Query para devolver lista de productos ordenados por nombre
        public List<Products> GetProductsOrderByName()
        {
            return _context.Products.OrderBy(x => x.ProductName).ToList();
        }

        //10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.
        public List<Products> GetProductsOrderByUnitInStock()
        {
            return _context.Products.OrderByDescending(x => x.UnitsInStock).ToList();
        }

        //11. Query para devolver las distintas categorías asociadas a los productos. Mostrar nombre de la categoria y producto.

        public class ProductCategory
        {
            public string Product { get; set; }
            public string Category { get; set; }
        }

        public List<ProductCategory> GetProductsWithCategories()
        {
            return _context.Products
                .Join(_context.Categories, p => p.CategoryID, c => c.CategoryID, (p, c) => new { p, c })
                .Select(x => new ProductCategory
                {
                    Product = x.p.ProductName,
                    Category = x.c.CategoryName
                })
                .ToList();
        }


        //12. Query para devolver el primer elemento de una lista de productos
        public Products GetFirstProduct()
        {
            return _context.Products.FirstOrDefault();
        }

        //13. Query para devolver los customer con la cantidad de ordenes asociadas.
        public class CustomerOrders
        {
            public string Customer { get; set; }
            public int Orders { get; set; }
        }

        public List<CustomerOrders> GetCustomersWithOrders()
        {
            var query = from customer in _context.Customers
                        join order in _context.Orders
                        on customer.CustomerID equals order.CustomerID
                        group new { customer, order } by customer.CustomerID into g
                        select new CustomerOrders
                        {
                            Customer = g.FirstOrDefault().customer.ContactName,
                            Orders = g.Count()
                        };

            return query.ToList();
        }

    }
}
