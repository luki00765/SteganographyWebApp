namespace SteganographyWebApp.CipherMethods.Interfaces
{
	public interface ICipherMethod
	{
		string Encrypt(string message, string shift);
		string Decrypt(string message, string shift);
	}
}
