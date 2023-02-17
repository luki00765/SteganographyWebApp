using System.ComponentModel.DataAnnotations;

namespace SteganographyWebApp.Models
{
	public class SteganographyModel
	{
		[Required(ErrorMessage = "The file cannot be null")]
		public IFormFile FormFile { get; set; }

		[Required(ErrorMessage = "The message cannot be null")]
		public string Message { get; set; }
	}
}
