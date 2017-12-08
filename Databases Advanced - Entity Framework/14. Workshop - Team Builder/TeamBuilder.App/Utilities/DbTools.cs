namespace TeamBuilder.App.Utilities
{
    using TeamBuilder.Data;

    internal class DbTools
    {
        internal static void ResetDb()
        {
            using (var context = new TeamBuilderContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}