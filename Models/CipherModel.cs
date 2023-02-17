using SteganographyWebApp.Validations;
using System.ComponentModel.DataAnnotations;

namespace SteganographyWebApp.Models
{
	public class CipherModel
	{
		[Required(ErrorMessage = "The message cannot be null")]
		public string Message { get; set; }

		[ShiftValidation]
		[Required(ErrorMessage = "The Shift field is required")]
		public string Shift { get; set; }
	}
}
