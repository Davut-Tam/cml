using System.Configuration;
using System.Data.SqlClient;

namespace OgrenciTakipMuh.Data.Tools
{
    public static class Connections
    {
        // SQL Server Bağlantı
        public static SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
    }
}