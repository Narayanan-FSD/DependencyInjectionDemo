namespace DependencyInjectionDemo.DataAccessLayer
{
    public class DataAccessService : IDataAccessService
    {
        private readonly IConfiguration _configuration;
        public DataAccessService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void DoDataBaseWork()
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connString);
            Console.WriteLine("Database Operation");
        }
    }
}
