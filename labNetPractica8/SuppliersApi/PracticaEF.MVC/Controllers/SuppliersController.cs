using PracticaEF.Entities;
using PracticaEF.Logic;
using System.Web.Mvc;
using PracticaEF.Entities.DTOs;
using System.Linq;

namespace PracticaEF.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SuppliersLogic _suppliersLogic = new SuppliersLogic();

        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = _suppliersLogic.GetAll();

            var suppliersDTOList = suppliers.Select(supplier => new SuppliersDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                Phone = supplier.Phone,
                PostalCode = supplier.PostalCode
            }).ToList();

            return View(suppliersDTOList);
        }

        public ActionResult Details(int id)
        {
            var supplier = _suppliersLogic.GetSupplierById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/CreateOrEdit
        public ActionResult CreateOrEdit(int? id)
        {
            if (id.HasValue)
            {
                var supplier = _suppliersLogic.GetSupplierById(id.Value);
                if (supplier == null)
                {
                    return HttpNotFound();
                }

                var supplierDTO = new SuppliersDTO
                {
                    SupplierID = supplier.SupplierID,
                    CompanyName = supplier.CompanyName,
                    ContactName = supplier.ContactName,
                    Phone = supplier.Phone,
                    PostalCode = supplier.PostalCode
                };

                return View(supplierDTO);
            }

            return View(new SuppliersDTO());
        }

        // POST: Suppliers/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(SuppliersDTO supplierDTO)
        {
            if (ModelState.IsValid)
            {
                if (supplierDTO.SupplierID > 0)
                {
                    var existingSupplier = _suppliersLogic.GetSupplierById(supplierDTO.SupplierID);
                    if (existingSupplier != null)
                    {
                        existingSupplier.CompanyName = supplierDTO.CompanyName;
                        existingSupplier.ContactName = supplierDTO.ContactName;
                        existingSupplier.Phone = supplierDTO.Phone;
                        existingSupplier.PostalCode = supplierDTO.PostalCode;
                        _suppliersLogic.UpdateSupplier(existingSupplier);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                else
                {
                    var newSupplier = new Suppliers
                    {
                        CompanyName = supplierDTO.CompanyName,
                        ContactName = supplierDTO.ContactName,
                        Phone = supplierDTO.Phone,
                        PostalCode = supplierDTO.PostalCode
                    };

                    _suppliersLogic.InsertSupplier(newSupplier);
                }

                return RedirectToAction("Index");
            }

            return View(supplierDTO);
        }

        // GET: Suppliers/Delete/{id}
        public ActionResult Delete(int id)
        {
            var supplier = _suppliersLogic.GetSupplierById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }

            var supplierDTO = new SuppliersDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                Phone = supplier.Phone,
                PostalCode = supplier.PostalCode
            };

            return View(supplierDTO);
        }

        // POST: Suppliers/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _suppliersLogic.DeleteSupplier(id);
            return RedirectToAction("Index");
        }
    }
}