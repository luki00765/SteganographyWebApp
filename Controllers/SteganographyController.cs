using Microsoft.AspNetCore.Mvc;
using SteganographyWebApp.Factories;
using SteganographyWebApp.SteganographyMethods.Interfaces;
using SteganographyWebApp.Models;

namespace SteganographyWebApp.Controllers
{
	public class SteganographyController : Controller
	{
		private readonly ISteganographyMethod _steganography;

		public SteganographyController(ISteganographyMethod steganography)
		{
			_steganography = steganography;
		}

		[HttpPost]
		[Route("/stego/hide")]
		public IActionResult HideMessage(SteganographyModel steganography)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ErrorModelState.GetErrors(ModelState));
			}

			var file = steganography.FormFile.GetFileStructureFactory();
			var fileWithMessage = _steganography.HideMessage(file.DataBytes, steganography.Message);

			return File(file.OverrideNewDataBytes(fileWithMessage), steganography.FormFile.ContentType);
		}

		[HttpPost]
		[Route("/stego/extract")]
		public IActionResult ExtractMessage(IFormFile formFile)
		{
			if (formFile == null || formFile.Length == 0)
			{
				return BadRequest("Invalid file.");
			}

			var file = formFile.GetFileStructureFactory();
			var message = _steganography.ExtractMessage(file.DataBytes);

			return Content(message);
		}
	}
}
