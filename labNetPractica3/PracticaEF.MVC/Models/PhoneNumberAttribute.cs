using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PracticaEF.MVC.Models
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString();

                // Modifica la expresión regular para permitir dígitos y caracteres especiales
                if (!Regex.IsMatch(phoneNumber, @"^[\d,.\(\)\[\]\{\}\*/-]+$"))
                {
                    return new ValidationResult("El número de teléfono no es válido. Debe tener 10 dígitos.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
