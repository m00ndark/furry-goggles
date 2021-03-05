using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurryGoggles.Model;
using IO = System.IO;

namespace FurryGoggles.Controls
{
	public partial class FolderEntry : UserControl
	{
		private const string MENU_ITEM_DELETE = "Delete";
		private const string MENU_ITEM_DELETE_ALL = "Delete All";

		public FolderEntry(Folder folder)
		{
			Folder = folder;
			InitializeComponent();
			UpdateInfo();
		}

		public Folder Folder { get; }

		private void ButtonMenu_Click(object sender, EventArgs e)
		{
			contextMenuStrip.Show(buttonMenu.Parent
				.PointToScreen(new Point(buttonMenu.Location.X, buttonMenu.Location.Y + buttonMenu.Size.Height)));
		}

		private void LinkLabelFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(Folder.Path);
			}
			catch (Exception ex1)
			{
				if (ex1.Message.Contains("access is denied", StringComparison.InvariantCultureIgnoreCase))
				{
					try
					{
						Process.Start("explorer", Folder.Path);
					}
					catch (Exception ex2)
					{
						Program.ShowError(ex2.ToString());
					}
				}
				else
				{
					Program.ShowError(ex1.ToString());
				}
			}
		}

		private void ButtonRemove_Click(object sender, EventArgs e)
		{
			DeleteAllFiles();
		}

		private void UpdateInfo()
		{
			linkLabelFolder.Text = Folder.Name;
			labelFiles.Text = string.Join(", ", Folder.Files
				.Select(file => IO.Path.GetExtension(file.Name))
				.GroupBy(ext => ext, (ext, exts) => (Name: ext, Count: exts.Count()))
				.Select(ext => $"{ext.Name} x {ext.Count}"));

			toolTip.SetToolTip(labelFiles, string.Join(Environment.NewLine, Folder.Files.Select(file => file.Name)));

			UpdateSize();

			Task.Run(ResetContextMenu);
		}

		private void UpdateSize()
		{
			labelFiles.Left = linkLabelFolder.Left + linkLabelFolder.Width + linkLabelFolder.Margin.Right;
			buttonRemove.Left = labelFiles.Left + labelFiles.Width + labelFiles.Margin.Right;

			labelFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left;
			buttonRemove.Anchor = AnchorStyles.Top | AnchorStyles.Left;

			Width = buttonRemove.Left + buttonRemove.Width + buttonRemove.Margin.Right;

			labelFiles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		}

		public void ResetContextMenu()
		{
			contextMenuStrip.InvokeIfRequired(() =>
			{
				contextMenuStrip.Items.DisposeItems();
				contextMenuStrip.Items.Clear();

				ToolStripMenuItem deleteMenuItem = contextMenuStrip.AddItem<ToolStripMenuItem>(MENU_ITEM_DELETE);

				foreach (File file in Folder.Files)
				{
					deleteMenuItem.AddItem<ToolStripMenuItem>(file.Name, DeleteMenuItem_Click, file);
				}

				contextMenuStrip.AddItem<ToolStripMenuItem>(MENU_ITEM_DELETE_ALL, DeleteAllMenuItem_Click);
			});
		}

		private void DeleteMenuItem_Click(object sender, EventArgs e)
		{
			File file = sender.GetTagValue<File>();

			if (file == null)
				return;

			DeleteFile(file);
		}

		private void DeleteAllMenuItem_Click(object sender, EventArgs e)
		{
			DeleteAllFiles();
		}

		private void DeleteAllFiles()
		{
			foreach (File file in Folder.Files)
			{
				DeleteFile(file);
			}
		}

		private static void DeleteFile(File file)
		{
			try
			{
				IO.File.Delete(file.FilePath);
				Debug.WriteLine($"DELETE: {file.FilePath}");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.ToString());
			}
		}
	}
}
