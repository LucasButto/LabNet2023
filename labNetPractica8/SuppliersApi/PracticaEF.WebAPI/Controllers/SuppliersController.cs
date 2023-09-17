using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PracticaEF.Entities;
using PracticaEF.Entities.DTOs;
using PracticaEF.Logic;

namespace PracticaEF.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SuppliersController : ApiController
    {
        private readonly SuppliersLogic _logic = new SuppliersLogic();

        // GET: api/Suppliers
        public IEnumerable<SuppliersDTO> GetSuppliers()
        {
            var suppliers = _logic.GetAll();
            var supplierDTOs = suppliers.Select(s => new SuppliersDTO
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                Phone = s.Phone,
                PostalCode = s.PostalCode
            });
            return supplierDTOs;
        }

        // GET: api/Suppliers/{id}
        [ResponseType(typeof(SuppliersDTO))]
        public IHttpActionResult GetSuppliers(int id)
        {
            var supplier = _logic.GetSupplierById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            var supplierDTO = new SuppliersDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                Phone = supplier.Phone,
                PostalCode = supplier.PostalCode
            };

            return Ok(supplierDTO);
        }

        // POST: api/Suppliers
        [ResponseType(typeof(SuppliersDTO))]
        public IHttpActionResult PostSuppliers(SuppliersDTO supplierDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = new Suppliers
            {
                CompanyName = supplierDTO.CompanyName,
                ContactName = supplierDTO.ContactName,
                Phone = supplierDTO.Phone,
                PostalCode = supplierDTO.PostalCode
            };

            _logic.InsertSupplier(supplier);

            return CreatedAtRoute("DefaultApi", new { id = supplier.SupplierID }, supplierDTO);
        }

        // PUT: api/Suppliers/{id}
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuppliers(int id, SuppliersDTO supplierDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = new Suppliers
            {
                SupplierID = id,
                CompanyName = supplierDTO.CompanyName,
                ContactName = supplierDTO.ContactName,
                Phone = supplierDTO.Phone,
                PostalCode = supplierDTO.PostalCode
            };

            _logic.UpdateSupplier(supplier);

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/Suppliers/{id}
        [ResponseType(typeof(SuppliersDTO))]
        public IHttpActionResult DeleteSuppliers(int id)
        {
            var supplier = _logic.GetSupplierById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _logic.DeleteSupplier(id);

            var supplierDTO = new SuppliersDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                Phone = supplier.Phone,
                PostalCode = supplier.PostalCode
            };

            return Ok(supplierDTO);
        }
    }
}
