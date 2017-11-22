namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    
    class StartUp
    {
        static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);
            }
        }
    }
}
