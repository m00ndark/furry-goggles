using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurryGoggles.Model;

namespace FurryGoggles.Controls
{
	public partial class RootEntry : UserControl
	{
		public RootEntry(Root root)
		{
			Root = root;
			InitializeComponent();
			UpdateContent();
		}

		public Root Root { get; }

		private void PictureBoxExpandCollapse_MouseDown(object sender, MouseEventArgs e)
		{
			Root.Expanded = !Root.Expanded;
			pictureBoxExpandCollapse.Image = Root.Expanded ? Resources.expanded : Resources.collapsed;
			UpdateSize();
		}

		public void UpdateSize()
		{
			List<FolderEntry> folderEntries = flowLayoutPanel.Controls.OfType<FolderEntry>().ToList();
			UpdateSize(folderEntries);
		}

		private void UpdateSize(List<FolderEntry> folderEntries)
		{
			int headingWidth = labelRoot.Left + labelRoot.Width + labelRoot.Margin.Horizontal;
			UpdateSize(folderEntries.Select(x => (x.Size, x.Margin)).ToArray(), headingWidth);
			UpdateWidth(folderEntries);
		}

		private void UpdateSize(ICollection<(Size Size, Padding Margin)> controlDimensions, int headingWidth)
		{
			const int MIN_WIDTH = 270, MIN_HEIGHT = 50;

			if (controlDimensions != null && controlDimensions.Count > 0)
			{
				int totalControlsHeight = controlDimensions.Sum(x => x.Size.Height + x.Margin.Vertical);
				int maxControlWidth = Math.Max(headingWidth, controlDimensions.Max(x => x.Size.Width + x.Margin.Horizontal));
				Size newSize = new Size(maxControlWidth, (Root.Expanded ? flowLayoutPanel.Top + totalControlsHeight : flowLayoutPanel.Top) + 1);
				if (newSize.Width != Size.Width || newSize.Height != Size.Height)
					Size = newSize;
			}
			else
				Size = new Size(Math.Max(MIN_WIDTH, headingWidth), MIN_HEIGHT);
		}

		public void UpdateWidth()
		{
			List<FolderEntry> folderEntries = flowLayoutPanel.Controls.OfType<FolderEntry>().ToList();
			UpdateWidth(folderEntries);
		}

		private void UpdateWidth(List<FolderEntry> folderEntries)
		{
			folderEntries.ForEach(folderEntry =>
				{
					if (folderEntry.Width != flowLayoutPanel.Width)
						folderEntry.Width = flowLayoutPanel.Width;
				});
		}

		private void UpdateContent()
		{
			pictureBoxExpandCollapse.Image = Root.Expanded ? Resources.expanded : Resources.collapsed;
			labelRoot.Text = Root.Name;

			List<FolderEntry> folderEntries = Root.Folders
				.OrderBy(folder => folder.Name)
				.Select(folder => new FolderEntry(folder))
				.ToList();

			//folderEntries.ForEach(folderEntry => folderEntry.WidthChanged += FolderEntry_WidthChanged);

			flowLayoutPanel.Controls.AddRange(folderEntries.ToArray<Control>());
			UpdateSize(folderEntries);
		}
	}
}
