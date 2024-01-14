namespace Vheos.Interview.CobbleGames
{
	using Newtonsoft.Json;

	public class JsonSerializer : ISerializer<string>
	{
		// Fields
		private readonly JsonSerializerSettings settings;

		// Constuctors
		public JsonSerializer(JsonSerializerSettings settings)
		{
			this.settings = settings;
		}
		public JsonSerializer() : this(new())
		{ }

		// Methods
		public string Serialize<T>(T toSerialize)
			=> JsonConvert.SerializeObject(toSerialize, settings);
		public T Deserialize<T>(string json)
			=> JsonConvert.DeserializeObject<T>(json, settings);
	}
}