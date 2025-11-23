namespace DependencyInjectionDemo.DataAccessLayer
{
    public class DataAccessService : IDataAccessService
    {
        public void DoDataBaseWork()
        {
            Console.WriteLine("Database Operation");
        }
    }
}
