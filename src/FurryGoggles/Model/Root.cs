using System.Collections.Generic;

namespace FurryGoggles.Model
{
	public class Root
	{
		public Root(string name, List<Folder> folders)
		{
			Name = name;
			Folders = folders;
		}

		public string Name { get; set; }
		public bool Expanded { get; set; } = true;
		public List<Folder> Folders { get; set; }

		public override string ToString() => Name;
	}
}
