namespace Vheos.Interview.CobbleGames
{
	internal interface IGuid<T>
	{
		public T Guid { get; }
		public T GenerateNewGuid();
	}
}