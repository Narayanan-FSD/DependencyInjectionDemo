using DependencyInjectionDemo.DataAccessLayer;

namespace DependencyInjectionDemo.BusinessLayer
{
    public class BusinessService : IBusinessService
    {
        //private readonly IDataAccessService _dataAccessService;
        //public BusinessService(IDataAccessService dataAccessService)
        //{
        //    _dataAccessService = dataAccessService;
        //}
        //public void DoBusinessWork()
        //{
        //    _dataAccessService.DoDataBaseWork();
        //}

        #region ServiceScopeFactory

        private readonly IServiceScopeFactory _scopeFactory;
        public BusinessService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void DoBusinessWork()
        {
            Console.WriteLine("Business Operation");
            using (var scope = _scopeFactory.CreateScope())
            {
                var dataAccessService = scope.ServiceProvider.GetRequiredService<IDataAccessService>();
                dataAccessService.DoDataBaseWork();
            }
        }

        #endregion ServiceScopeFactory


    }
}
