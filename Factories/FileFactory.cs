using Image = SteganographyWebApp.Models.Image;
using File = SteganographyWebApp.Models.File;

namespace SteganographyWebApp.Factories
{
	public static class FileFactory
	{
		public static File GetFileStructureFactory(this IFormFile file)
		{
			string extension = Path.GetExtension(file.FileName).TrimStart('.').ToLower();

			switch (extension)
			{
				case "bmp":
				case "jpg":
				case "jpeg":
				case "png":
				case "gif":
					return new Image(file);

				default:
					return new File(file);
			}
		}
	}
}
