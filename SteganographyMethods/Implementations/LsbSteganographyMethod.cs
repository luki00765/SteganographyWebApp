using SteganographyWebApp.SteganographyMethods.Interfaces;
using System.Text;

namespace SteganographyWebApp.Steganography.Implementation
{
	public class LsbSteganographyMethod : ISteganographyMethod
	{
		public byte[] HideMessage(byte[] file, string message)
		{
			byte[] messageBytes = Encoding.UTF8.GetBytes(message + "\0");
			byte expectedCharLength = 8;
			int messageIndex = 0;

			for (int i = 0; i < messageBytes.Length * expectedCharLength; i++)
			{
				if (messageBytes.Length > file.Length || messageIndex >= file.Length) break;

				bool bitMessage = (messageBytes[messageIndex / expectedCharLength] & (128 >> (messageIndex % expectedCharLength))) != 0;
				file[i] = (byte)(file[i] & (~1));
				file[i] |= (bitMessage) ? (byte)1 : (byte)0;
				messageIndex++;
			}

			return file;
		}

		public string ExtractMessage(byte[] file)
		{
			byte letter = 0;
			int findChar = 1;
			byte expectedCharLength = 8;

			byte[] letterArray = new byte[file.Length];
			int indexArray = 0;

			for (int i = 0; i < file.Length; i++)
			{
				letter = (byte)((byte)(letter << 1) | (byte)(file[i] & 1));

				if ((findChar % expectedCharLength) == 0)
				{
					letterArray[indexArray] = letter;

					if (letterArray[indexArray] == 0)
						return Encoding.UTF8.GetString(letterArray.Take(indexArray).ToArray());

					indexArray++;
					letter = 0;
				}

				findChar++;
			}

			return "The message not found.";
		}
	}
}
