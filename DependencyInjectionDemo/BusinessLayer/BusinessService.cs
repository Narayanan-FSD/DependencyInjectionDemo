using DependencyInjectionDemo.DataAccessLayer;

namespace DependencyInjectionDemo.BusinessLayer
{
    public class BusinessService : IBusinessService
    {
        private readonly IDataAccessService _dataAccessService;
        public BusinessService(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        public void DoBusinessWork()
        {
            _dataAccessService.DoDataBaseWork();
        }
    }
}
