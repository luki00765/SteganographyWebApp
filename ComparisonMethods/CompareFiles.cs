using File = SteganographyWebApp.Models.File;

namespace SteganographyWebApp.ComparisonMethods
{
    public static class CompareFiles
    {
        public static string GetDifferentDataBytes(File oryginalFile, File stegoFile)
        {
            var differentDataBytes = new List<int>();

            if (oryginalFile.DataBytes.Length != stegoFile.DataBytes.Length)
            {
                return "The length of the original file is different from the stego file.";
            }

            for (int i = 0; i < oryginalFile.DataBytes.Length; i++)
            {
                if (oryginalFile.DataBytes[i] != stegoFile.DataBytes[i])
                {
                    differentDataBytes.Add(i);
                }
            }

            return $"Different data bytes: {differentDataBytes.Count}.";
        }
    }
}
