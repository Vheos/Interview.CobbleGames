namespace Vheos.Interview.CobbleGames
{
	using Newtonsoft.Json;
	using System;
	using System.IO;
	using System.Threading.Tasks;
	using UnityEngine;

	[Serializable]
	public class FileHandler<T>
	{
		// Fields
		[field: SerializeField] public string FileName { get; private set; }
		[field: SerializeField] public string FileExtension { get; private set; }
		[field: SerializeField] public string FolderPathOverride { get; private set; }
		private static readonly JsonSerializerSettings serializerSettings = new()
		{
			TypeNameHandling = TypeNameHandling.Auto,
			Formatting = Formatting.Indented
		};
		private readonly ISerializer<string> serializer = new JsonSerializer(serializerSettings);

		// Methods
		private string FolderPath
			=> string.IsNullOrEmpty(FolderPathOverride) ? Application.persistentDataPath : FolderPathOverride;
		private string FullPath
			=> Path.Combine(FolderPath, Path.ChangeExtension(FileName, FileExtension));
		public async Task WriteAsync(T data)
		{
			string dataJson = serializer.Serialize(data);
			await File.WriteAllTextAsync(FullPath, dataJson);
		}
		public async Task<T> ReadAsync()
		{
			string dataJson = await File.ReadAllTextAsync(FullPath);
			return serializer.Deserialize<T>(dataJson);
		}
	}
}