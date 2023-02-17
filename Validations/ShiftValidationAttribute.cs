using SteganographyWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SteganographyWebApp.Validations
{
	public class ShiftValidationAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var cipherModel = (CipherModel)validationContext.ObjectInstance;

			string strategy = validationContext.GetService<IHttpContextAccessor>().HttpContext.Request.Query.Keys.FirstOrDefault();

			if (!string.IsNullOrEmpty(strategy) && strategy.ToLower() == "vigenere")
			{
				if (string.IsNullOrEmpty(cipherModel.Shift) || cipherModel.Shift.Any(c => !char.IsLetter(c)))
				{
					return new ValidationResult("Shift should contain only letters for Vigenere Cipher");
				}
			}
			else
			{
				if (string.IsNullOrEmpty(cipherModel.Shift) || cipherModel.Shift.Any(c => !char.IsDigit(c)))
				{
					return new ValidationResult("Shift should contain only numbers for Cesar Cipher");
				}
			}

			return ValidationResult.Success;
		}
	}
}
