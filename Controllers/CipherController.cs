using Microsoft.AspNetCore.Mvc;
using SteganographyWebApp.CipherMethods.Interfaces;
using SteganographyWebApp.Models;

namespace SteganographyWebApp.Controllers
{
	public class CipherController : Controller
	{
		private readonly ICipherMethod _cipher;

		public CipherController(ICipherMethod cipher)
		{
			_cipher = cipher;
		}

		[HttpPost]
		[Route("/cipher/encrypt")]
		public IActionResult Encrypt(CipherModel cipher)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ErrorModelState.GetErrors(ModelState));
			}

			var encryptedMessage = _cipher.Encrypt(cipher.Message, cipher.Shift);
			return Content(encryptedMessage);
		}

		[HttpPost]
		[Route("/cipher/decrypt")]
		public IActionResult Decrypt(CipherModel cipher)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ErrorModelState.GetErrors(ModelState));
			}

			var decryptedMessage = _cipher.Decrypt(cipher.Message, cipher.Shift);

			return Content(decryptedMessage);
		}
	}
}
