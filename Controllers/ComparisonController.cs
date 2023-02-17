using Microsoft.AspNetCore.Mvc;
using SteganographyWebApp.ComparisonMethods;
using SteganographyWebApp.Factories;
using SteganographyWebApp.Models;

namespace SteganographyWebApp.Controllers
{
    public class ComparisonController : Controller
	{
		[HttpPost]
		[Route("/stego/analyze")]
		public IActionResult Analyze(ComparisonModel comparisonModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ErrorModelState.GetErrors(ModelState));
			}

			var comparisonResult = CompareFiles.GetDifferentDataBytes(
				comparisonModel.OryginalFile.GetFileStructureFactory(),
				comparisonModel.StegoFile.GetFileStructureFactory());

			return Content(comparisonResult);
		}
	}
}
