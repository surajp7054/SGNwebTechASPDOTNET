using SGNwebTech.Data;
using SGNwebTech.DataAccesLayer;

namespace SGNwebTech.ServiceLayer
{
    public class DataService
    {
        private readonly CustomerEnquiryService _dataAccess;
        public DataService(CustomerEnquiryService dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task AddCustomer(CustomerFormdata CustformData)
        {
            await _dataAccess.AddCustomer(CustformData);
        }
    }
}
