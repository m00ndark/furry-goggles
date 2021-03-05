using IO = System.IO;

namespace FurryGoggles.Model
{
	public class File
	{
		public File(string filePath)
		{
			Name = IO.Path.GetFileName(filePath);
			FilePath = filePath;
		}

		public string Name { get; set; }
		public string FilePath { get; }

		public override string ToString() => Name;
	}
}
