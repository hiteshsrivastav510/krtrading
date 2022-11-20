using System.Configuration;

namespace krtrading.DataLayer
{
    public class ConnectionProvider
    {
        public static readonly string ModelConnection = ConfigurationManager.ConnectionStrings["krtradingconn"].ToString();
    }
}