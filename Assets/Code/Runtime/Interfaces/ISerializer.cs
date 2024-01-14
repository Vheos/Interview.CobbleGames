namespace Vheos.Interview.CobbleGames
{
	public interface ISerializer<TIn>
	{
		public TIn Serialize<TOut>(TOut toSerialize);
		public TOut Deserialize<TOut>(TIn json);
	}
}