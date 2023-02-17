using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SteganographyWebApp.Models
{
	public class Image : File
	{
		private int _width;
		private int _height;
		private PixelFormat _pixelFormat;

		public Image(IFormFile file) : base(file)
		{
			setPixelsToDataBytes();
		}
		public override byte[] OverrideNewDataBytes(byte[] newData)
		{
			return createImageFromPixels(DataBytes, _width, _height, _pixelFormat).Concat(newData).ToArray();
		}

		private void setPixelsToDataBytes()
		{
			var pixels = getPixelsFromImage(_formFile);
			DataBytes = pixels;
		}

		private byte[] getPixelsFromImage(IFormFile imageFile)
		{
			using (var memoryStream = new MemoryStream())
			{
				imageFile.CopyTo(memoryStream);
				using (var bitmap = new Bitmap(memoryStream))
				{
					_width = bitmap.Width;
					_height = bitmap.Height;
					_pixelFormat = bitmap.PixelFormat;
					var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
					var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

					var numberOfBytes = Math.Abs(bitmapData.Stride) * bitmap.Height;
					var pixels = new byte[numberOfBytes];

					Marshal.Copy(bitmapData.Scan0, pixels, 0, numberOfBytes);
					bitmap.UnlockBits(bitmapData);

					return pixels;
				}
			}
		}

		private byte[] createImageFromPixels(byte[] pixels, int width, int height, PixelFormat pixelFormat)
		{
			using (var bitmap = new Bitmap(width, height, pixelFormat))
			{
				var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
				var numberOfBytes = Math.Abs(bitmapData.Stride) * bitmap.Height;

				Marshal.Copy(pixels, 0, bitmapData.Scan0, numberOfBytes);
				bitmap.UnlockBits(bitmapData);

				using (var memoryStream = new MemoryStream())
				{
					bitmap.Save(memoryStream, ImageFormat.Bmp);
					return memoryStream.ToArray();
				}
			}
		}
	}
}
