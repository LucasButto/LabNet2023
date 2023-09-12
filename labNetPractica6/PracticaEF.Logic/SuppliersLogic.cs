using PracticaEF.Data;
using PracticaEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEF.Logic
{
    public class SuppliersLogic
    {
        private readonly NorthwindContext _context;

        public SuppliersLogic()
        {
            _context = new NorthwindContext();
        }
        
        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Suppliers GetSupplierById(int supplierID)
        {
            return _context.Suppliers.FirstOrDefault(s => s.SupplierID == supplierID);
        }


        public void InsertSupplier(Suppliers supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(Suppliers supplier)
        {
            var existingSupplier = _context.Suppliers.Find(supplier.SupplierID);
            if (existingSupplier != null)
            {
                _context.Entry(existingSupplier).CurrentValues.SetValues(supplier);
                _context.SaveChanges();
            }
        }

        public void DeleteSupplier(int supplierID)
        {
            var supplier = _context.Suppliers.Find(supplierID);
            if (supplier != null)
            {
                var productsToUpdate = _context.Products.Where(p => p.SupplierID == supplierID);

                foreach (var product in productsToUpdate)
                {
                    product.SupplierID = null;
                }

                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }

    }
}
