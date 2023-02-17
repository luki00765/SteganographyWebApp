namespace SteganographyWebApp.Models
{
	public class File
	{
		protected IFormFile _formFile;
		public byte[] DataBytes { get; protected set; }

		public File(IFormFile file)
		{
			_formFile = file;
			SetDataBytes();
		}

		protected virtual void SetDataBytes()
		{
			using (var ms = new MemoryStream())
			{
				_formFile.CopyTo(ms);
				DataBytes = ms.ToArray();
			}
		}

		public virtual byte[] OverrideNewDataBytes(byte[] newData)
		{
			return newData;
		}
	}
}
