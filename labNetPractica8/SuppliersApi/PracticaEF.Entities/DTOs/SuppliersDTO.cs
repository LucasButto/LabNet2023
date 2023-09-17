using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticaEF.Entities.DTOs;
using System.ComponentModel.DataAnnotations;


namespace PracticaEF.Entities.DTOs
{
    public class SuppliersDTO
    {
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "El campo Nombre de la compañía es obligatorio.")]
        [StringLength(40, ErrorMessage = "La longitud máxima es 40 caracteres.")]
        [Display(Name = "Nombre de la compañía")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "El campo Nombre de contacto es obligatorio.")]
        [StringLength(30, ErrorMessage = "La longitud máxima es 30 caracteres.")]
        [Display(Name = "Nombre de contacto")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [StringLength(24, ErrorMessage = "La longitud máxima es 24 caracteres.")]
        [PhoneNumber(ErrorMessage = "El número de teléfono no es válido. Debe tener al menos 10 dígitos.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo Código Postal es obligatorio.")]
        [StringLength(10, ErrorMessage = "La longitud máxima es 10 caracteres.")]
        [Display(Name = "Código Postal")]
        public string PostalCode { get; set; }
    }
}

