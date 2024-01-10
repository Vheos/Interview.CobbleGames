namespace Vheos.Interview.CobbleGames
{
	using System;

	public interface IClicker
	{
		// Events
		public event Action OnClick;

		// Methods
		public void Click();
	}
}