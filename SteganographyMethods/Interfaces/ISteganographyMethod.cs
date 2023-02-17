namespace SteganographyWebApp.SteganographyMethods.Interfaces
{
	public interface ISteganographyMethod
	{
		public byte[] HideMessage(byte[] file, string message);
		public string ExtractMessage(byte[] file);
	}
}
