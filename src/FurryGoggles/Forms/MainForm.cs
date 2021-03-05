using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FurryGoggles.Controls;
using FurryGoggles.Model;
using IO = System.IO;

namespace FurryGoggles.Forms
{
	public partial class MainForm : Form
	{
		private List<Root> _roots;
		private DateTime _formClosedAt;
		private Point _lastShowPosition;
		private bool _isUpdatingContent;

		public MainForm()
		{
			InitializeComponent();
			_roots = new List<Root>();
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassStyle |= NativeMethods.CP_NOCLOSE_BUTTON;
				return createParams;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			toolStripMenuItemVersion.Text = Assembly.GetExecutingAssembly().GetBuildVersion();

			HideForm();
			UpdateContent();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.Save();
		}

		private void MainForm_Deactivate(object sender, EventArgs e)
		{
			if ((int)Opacity == 1)
				HideForm();
		}

		private void NotifyIcon_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				if (ModifierKeys == Keys.Control)
					Assembly.GetExecutingAssembly().GetBuildVersion().TrySetClipboardText();

				return;
			}

			if ((int)Opacity == 0 && _formClosedAt.AddMilliseconds(500) < DateTime.Now)
			{
				_lastShowPosition = MousePosition;
				ShowForm();
			}

			try { NativeMethods.SetForegroundWindow(Handle); } catch { ; }
		}

		private void toolStripMenuItemRefresh_Click(object sender, EventArgs e)
		{
			UpdateContent();
		}

		private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ShowForm()
		{
			if ((int)Opacity != 0)
				return;

			SetLocation();
			Opacity = 1;
			Show();
		}

		private void HideForm()
		{
			Hide();
			Opacity = 0;
			_formClosedAt = DateTime.Now;
		}

		private void SetLocation()
		{
			Location = new Point(
				Math.Min(_lastShowPosition.X - Size.Width / 2, Screen.PrimaryScreen.WorkingArea.Width - Size.Width - 8),
				Math.Max(Screen.PrimaryScreen.WorkingArea.Top, Screen.PrimaryScreen.WorkingArea.Height - Size.Height - 8));
		}

		private void UpdateContent()
		{
			try
			{
				_isUpdatingContent = true;

				foreach (RootEntry rootEntry in flowLayoutPanel.Controls.OfType<RootEntry>())
				{
					rootEntry.SizeChanged -= RootEntry_SizeChanged;
					rootEntry.Dispose();
				}

				flowLayoutPanel.Controls.Clear();

				Scan();

				labelInfo.Visible = !_roots.Any();

				List<RootEntry> rootEntries = _roots
					.OrderBy(root => root.Name)
					.Select(root => new RootEntry(root))
					.ToList();

				foreach (RootEntry rootEntry in rootEntries)
				{
					rootEntry.SizeChanged += RootEntry_SizeChanged;
				}

				rootEntries.ForEach(rootEntry => rootEntry.UpdateSize());
				UpdateSize(rootEntries);
				flowLayoutPanel.Controls.AddRange(rootEntries.ToArray<Control>());
				rootEntries.FirstOrDefault()?.Focus();
			}
			finally
			{
				_isUpdatingContent = false;
			}
		}

		private void RootEntry_SizeChanged(object sender, EventArgs e)
		{
			if (!(sender is RootEntry changedRootEntry))
				return;

			List<RootEntry> rootEntries = flowLayoutPanel.Controls.OfType<RootEntry>().ToList();

			if (!_isUpdatingContent)
			{
				try
				{
					_isUpdatingContent = true;

					foreach (RootEntry rootEntry in rootEntries)
					{
						if (rootEntry == changedRootEntry)
							continue;

						rootEntry.SizeChanged -= RootEntry_SizeChanged;
						rootEntry.UpdateSize();
						rootEntry.SizeChanged += RootEntry_SizeChanged;
					}
				}
				finally
				{
					_isUpdatingContent = false;
				}
			}

			UpdateSize(rootEntries);
		}

		private void UpdateSize(List<RootEntry> rootEntries)
		{
			UpdateSize(rootEntries.Select(x => (x.Size, x.Margin)).ToArray());
			SetLocation();

			foreach (RootEntry rootEntry in rootEntries)
			{
				if (rootEntry.Width == flowLayoutPanel.Width)
					continue;

				rootEntry.SizeChanged -= RootEntry_SizeChanged;
				rootEntry.Width = flowLayoutPanel.Width;
				rootEntry.UpdateWidth();
				rootEntry.SizeChanged += RootEntry_SizeChanged;
			}
		}

		private void UpdateSize(ICollection<(Size Size, Padding Margin)> controlDimensions)
		{
			const int MIN_WIDTH = 290, MIN_HEIGHT = 170;

			MinimumSize = MaximumSize = new Size(0, 0);

			Size newSize;
			int totalControlsHeight = controlDimensions?.Sum(x => x.Size.Height + x.Margin.Vertical) ?? 0;

			if (controlDimensions != null && controlDimensions.Count > 0)
			{
				int maxControlWidth = controlDimensions.Max(x => x.Size.Width + x.Margin.Horizontal);
				newSize = new Size(Math.Max(MIN_WIDTH, Width - panelScroll.Width + maxControlWidth),
					Math.Min(Height - panelScroll.Height + totalControlsHeight, Screen.PrimaryScreen.WorkingArea.Height));
			}
			else
			{
				newSize = new Size(MIN_WIDTH, MIN_HEIGHT);
			}

			if (newSize.Width != Size.Width || newSize.Height != Size.Height)
			{
				bool flowLayoutPanelHeightChanged = false;
				if (totalControlsHeight < flowLayoutPanel.Height)
				{
					flowLayoutPanel.Size = new Size(flowLayoutPanel.Width, totalControlsHeight);
					flowLayoutPanelHeightChanged = true;
				}

				Size = newSize;

				if (!flowLayoutPanelHeightChanged)
					flowLayoutPanel.Size = new Size(flowLayoutPanel.Width, totalControlsHeight);
			}

			MinimumSize = MaximumSize = Size;
			SetLocation();
		}

		private void Scan()
		{
			try
			{
				if (!Settings.Exist)
				{
					_roots = new List<Root>();
					return;
				}

				IO.EnumerationOptions options = new IO.EnumerationOptions
					{
						IgnoreInaccessible = true,
						RecurseSubdirectories = true,
						MatchCasing = IO.MatchCasing.CaseInsensitive,
						MatchType = IO.MatchType.Simple
					};

				_roots = IO.Directory.EnumerateFiles(Settings.Default.Path, Settings.Default.SearchPattern, options)
					.Select(filePath => Regex.Match(filePath, Settings.Default.VisualizationPattern, RegexOptions.IgnoreCase))
					.Where(match => match.Success)
					.Select(match => new
						{
							FilePath = match.Groups[0].Value,
							Root = match.Groups[1].Value,
							Folder = match.Groups[2].Value,
							File = match.Groups[3].Value
						})
					.GroupBy(x => x.Root)
					.Select(x => new Root(x.Key, x
						.GroupBy(y => y.Folder)
						.Select(y => new Folder(y.Key, y
							.Select(z => new File(z.FilePath))
							.ToList()))
						.ToList()))
					.ToList();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.ToString());
			}
		}
	}
}
