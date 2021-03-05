using System;
using System.Windows.Forms;
using FurryGoggles.Forms;

namespace FurryGoggles
{
	static class Program
	{
		public const string APPLICATION_NAME = "Furry Goggles";

		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static DialogResult ShowInfo(string message, MessageBoxButtons buttons = MessageBoxButtons.OK)
		{
			return MessageBox.Show(message, APPLICATION_NAME, buttons, MessageBoxIcon.Information);
		}

		public static DialogResult ShowQuestion(string message, MessageBoxButtons buttons = MessageBoxButtons.YesNo)
		{
			return MessageBox.Show(message, APPLICATION_NAME, buttons, MessageBoxIcon.Question);
		}

		public static DialogResult ShowError(string message, MessageBoxButtons buttons = MessageBoxButtons.OK)
		{
			return MessageBox.Show(message, APPLICATION_NAME, buttons, MessageBoxIcon.Error);
		}
	}
}
