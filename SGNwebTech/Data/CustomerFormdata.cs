namespace SGNwebTech.Data
{
    public class CustomerFormdata
    {
        public string? CUST_FIRST_NAME { get; set; } = string.Empty;

        public string? CUST_LAST_NAME { get; set; } = string.Empty;
        public string? CUST_MOBILE_NO { get; set; } = string.Empty;

        public string? CUST_EMAIL_ID { get; set; } = string.Empty;
        public string? CUST_MESSAGE { get; set; } = string.Empty;
        public DateTime CUST_ENQUERY_DATE { get; set; }
        public string? CUST_IP_ADDRESS { get; set; } = string.Empty;

    }
}
