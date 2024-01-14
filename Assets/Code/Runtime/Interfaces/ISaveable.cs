namespace Vheos.Interview.CobbleGames
{
	public interface ISaveable
	{
		public void SaveData(SaveableData data);
		public void LoadData(SaveableData data);
	}
}