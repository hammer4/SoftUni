namespace Forum.App.Contracts
{
	using DataModels;

	public interface ISession
    {
		string Username { get; }

		int UserId { get; }

		bool IsLoggedIn { get; }

		IMenu CurrentMenu { get; }

		void LogIn(User user);

		void LogOut();

		IMenu Back();

		bool PushView(IMenu view);

		void Reset();
	}
}
