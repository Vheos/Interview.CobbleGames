namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class SaveableManager : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public SaveableCollector SaveableCollector { get; private set; }

		// Fields
		[field: SerializeField] public FileHandler<SaveableData> FileHandler { get; private set; }
		private readonly bool isBusy;

		// Methods
		[ContextMenu(nameof(Save))]
		public async void Save()
		{
			SaveableData data = new();
			SaveableCollector.Items.DoForEach(t => t.SaveData(data));
			await FileHandler.WriteAsync(data);

			Debug.Log("Save successful");
		}
		[ContextMenu(nameof(Load))]
		public async void Load()
		{
			SaveableData data = await FileHandler.ReadAsync();
			SaveableCollector.Items.DoForEach(t => t.LoadData(data));

			Debug.Log("Load successful");
		}
	}
}