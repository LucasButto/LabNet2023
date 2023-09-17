using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace PracticaEF.Entities.DTOs
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString();

                string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());


                if (digitsOnly.Length < 10)
                {
                    return new ValidationResult("El número de teléfono no es válido. Debe tener al menos 10 dígitos.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

