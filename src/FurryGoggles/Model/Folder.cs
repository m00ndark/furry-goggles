using System.Collections.Generic;
using System.Linq;
using IO = System.IO;

namespace FurryGoggles.Model
{
	public class Folder
	{
		public Folder(string name, List<File> files)
		{
			Name = name;
			Path = IO.Path.GetDirectoryName(files.First().FilePath);
			Files = files;
		}

		public string Name { get; set; }
		public string Path { get; set; }
		public List<File> Files { get; set; }

		public override string ToString() => Name;
	}
}
