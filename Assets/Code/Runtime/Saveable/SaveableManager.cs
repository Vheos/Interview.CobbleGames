namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Threading.Tasks;
	using UnityEngine;

	public class SaveableManager : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public SaveableCollector SaveableCollector { get; private set; }

		// Fields
		[field: SerializeField] public FileHandler<SaveableData> FileHandler { get; private set; }
		private bool isBusy;

		// Methods
		public Task<bool> Save()
			=> TryRun(Save_Internal());
		public Task<bool> Load()
			=> TryRun(Load_Internal());
		private async Task Save_Internal()
		{
			SaveableData data = new();
			SaveableCollector.Items.DoForEach(t => t.SaveData(data));
			await FileHandler.WriteAsync(data);
		}
		private async Task Load_Internal()
		{
			SaveableData data = await FileHandler.ReadAsync();
			SaveableCollector.Items.DoForEach(t => t.LoadData(data));
		}
		private async Task<bool> TryRun(Task task)
		{
			try
			{
				if (isBusy)
					throw new Exception($"{nameof(SaveableManager)} is busy!");

				isBusy = true;
				await task;
				return true;
			}
			catch (Exception exception)
			{
				Debug.LogWarning(exception);
				return false;
			}
			finally
			{
				isBusy = false;
			}
		}
#if DEBUG
		public void Save_Debug()
			=> Save();
		public void Load_Debug()
			=> Load();
#endif
	}
}