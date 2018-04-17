namespace Forum.App.Contracts
{
    public interface IForumViewEngine
    {
		void RenderMenu(IMenu menu);

		void Mark(ILabel label, bool highlighted = true);

		void SetBufferHeight(int rows);

		void ResetBuffer();
    }
}
