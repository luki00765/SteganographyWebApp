using System.ComponentModel.DataAnnotations;

namespace SteganographyWebApp.Models
{
	public class ComparisonModel
	{
		[Required(ErrorMessage = "Invalid oryginal file")]
		public IFormFile OryginalFile { get; set; }

		[Required(ErrorMessage = "Invalid file with hidden message")]
		public IFormFile StegoFile { get; set; }
	}
}
