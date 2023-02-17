using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SteganographyWebApp.Models
{
	public static class ErrorModelState
	{
		public static string GetErrors(ModelStateDictionary ModelState)
		{
			return string.Join(".\n", ModelState.Values.Reverse().SelectMany(x => x.Errors).Select(err => err.ErrorMessage)) + ".";
		}
	}
}
