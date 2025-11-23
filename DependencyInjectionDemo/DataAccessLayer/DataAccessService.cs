using DependencyInjectionDemo.Models;
using Microsoft.Extensions.Options;

namespace DependencyInjectionDemo.DataAccessLayer
{
    public class DataAccessService : IDataAccessService
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<Constants> _constants;
        public DataAccessService(IConfiguration configuration, IOptions<Constants> constants)
        {
            _configuration = configuration;
            _constants = constants;
            //_constants.OnChange(value =>
            //{
            //    Console.WriteLine("Configuration changed!");
            //});
        }
        public void DoDataBaseWork()
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connString);
            //Console.WriteLine(_constants.CurrentValue.TimeOut);
            Console.WriteLine(_constants.Value.TimeOut);
            Console.WriteLine("Database Operation");
        }
    }
}
