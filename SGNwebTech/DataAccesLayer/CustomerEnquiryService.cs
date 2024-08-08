using SGNwebTech.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
namespace SGNwebTech.DataAccesLayer
{
    public class CustomerEnquiryService
    {
        private string Strallmsg;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CustomerEnquiryService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("cnnstr");
        }

        public async Task AddCustomer(CustomerFormdata customer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO SGN_CUSTENQUIRY (CUST_FIRST_NAME, CUST_LAST_NAME, CUST_MOBILE_NO, CUST_EMAIL_ID, CUST_MESSAGE, CUST_ENQUERY_DATE, CUST_IP_ADDRESS)" +
                        " VALUES (@CUST_FIRST_NAME, @CUST_LAST_NAME, @CUST_MOBILE_NO, @CUST_EMAIL_ID, @CUST_MESSAGE, @CUST_ENQUERY_DATE, @CUST_IP_ADDRESS)", conn))
                    {
                        customer.CUST_ENQUERY_DATE = DateTime.Now;
                        // customer.CUST_IP_ADDRESS = HttpContext.Connection.RemoteIpAddress?.ToString();
                        cmd.Parameters.AddWithValue("@CUST_FIRST_NAME", customer.CUST_FIRST_NAME ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CUST_LAST_NAME", customer.CUST_LAST_NAME ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CUST_MOBILE_NO", customer.CUST_MOBILE_NO ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CUST_EMAIL_ID", customer.CUST_EMAIL_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CUST_MESSAGE", customer.CUST_MESSAGE ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CUST_ENQUERY_DATE", customer.CUST_ENQUERY_DATE);
                        cmd.Parameters.AddWithValue("@CUST_IP_ADDRESS", customer.CUST_IP_ADDRESS ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Strallmsg = ex.Message;
            }

        }
    }
}
