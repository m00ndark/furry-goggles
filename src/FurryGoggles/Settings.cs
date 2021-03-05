using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IOPath = System.IO.Path;

namespace FurryGoggles
{
	public class Settings
	{
		public string Path { get; set; }
		public string SearchPattern { get; set; }
		public string VisualizationPattern { get; set; }

		// ---------------------------------------------------------------------

		private const string SETTINGS_FOLDER_NAME = "FurryGoggles";
		private const string SETTINGS_FILE_NAME = "config.json";

		private static Settings _settings;
		private static readonly object _lock = new object();
		private static readonly string _path = IOPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), SETTINGS_FOLDER_NAME);
		private static readonly string _filePath = IOPath.Combine(_path, SETTINGS_FILE_NAME);

		private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
			{
				DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
				Converters = new JsonConverter[] { new StringEnumConverter() }
			};

		public static Settings Default
		{
			get
			{
				if (_settings == null)
				{
					lock (_lock)
					{
						_settings ??= Load();
					}
				}
				return _settings;
			}
		}

		public static bool Exist => File.Exists(_filePath);

		private static Settings Load()
		{
			string json = null;

			if (Exist)
			{
				json = File.ReadAllText(_filePath, Encoding.UTF8);
			}

			return Deserialize(string.IsNullOrWhiteSpace(json) ? "{}" : json);
		}

		public void Save()
		{
			Directory.CreateDirectory(_path);

			if (Exist && !Backup()) return;

			try
			{
				File.WriteAllText(_filePath, Serialize(this), Encoding.UTF8);
			}
			catch
			{
				Restore();
			}
		}

		private static bool Backup()
		{
			try
			{
				File.Copy(_filePath, _filePath + ".bak", true);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private static bool Restore()
		{
			try
			{
				File.Copy(_filePath + ".bak", _filePath, true);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private static Settings Deserialize(string json) => JsonConvert.DeserializeObject<Settings>(json, _serializerSettings);

		private static string Serialize(Settings settings) => JsonConvert.SerializeObject(settings, Formatting.Indented, _serializerSettings);
	}
}
