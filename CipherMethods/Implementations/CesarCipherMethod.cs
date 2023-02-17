using SteganographyWebApp.CipherMethods.Interfaces;

namespace SteganographyWebApp.CipherMethods.Implementations
{
	public class CesarCipherMethod : ICipherMethod
	{
		public string Encrypt(string message, string shift)
		{
			int shiftKey = Convert.ToInt32(shift);
			char[] chars = message.ToCharArray();

			for (int i = 0; i < chars.Length; i++)
			{
				char letter = chars[i];
				letter = (char)(letter + shiftKey);
				chars[i] = letter;
			}

			return new string(chars);
		}

		public string Decrypt(string message, string shift)
		{
			int shiftKey = Convert.ToInt32(shift);
			char[] chars = message.ToCharArray();

			for (int i = 0; i < chars.Length; i++)
			{
				char letter = chars[i];
				letter = (char)(letter - shiftKey);
				chars[i] = letter;
			}

			return new string(chars);
		}
	}
}
