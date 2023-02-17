using SteganographyWebApp.CipherMethods.Interfaces;

namespace SteganographyWebApp.CipherMethods.Implementations
{
	public class VigenereCipherMethod : ICipherMethod
	{
		public string Encrypt(string message, string shift)
		{
			return cipher(message, shift, true);
		}

		public string Decrypt(string message, string shift)
		{
			return cipher(message, shift, false);
		}

		private static int mod(int a, int b)
		{
			return (a % b + b) % b;
		}

		private static string cipher(string input, string key, bool encipher)
		{
			string output = string.Empty;
			int nonAlphaCharCount = 0;

			for (int i = 0; i < input.Length; ++i)
			{
				if (char.IsLetter(input[i]))
				{
					bool cIsUpper = char.IsUpper(input[i]);
					char offset = cIsUpper ? 'A' : 'a';
					int keyIndex = (i - nonAlphaCharCount) % key.Length;
					int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
					k = encipher ? k : -k;
					char ch = (char)((mod(((input[i] + k) - offset), 26)) + offset);
					output += ch;
				}
				else
				{
					output += input[i];
					++nonAlphaCharCount;
				}
			}

			return output;
		}
	}
}
