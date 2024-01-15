namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[CreateAssetMenu(fileName = nameof(ScriptableUtils), menuName = AssetMenuPaths.Root + nameof(ScriptableUtils))]
	public class ScriptableUtils : ScriptableObject
	{
		public void ReloadScene()
			=> SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}