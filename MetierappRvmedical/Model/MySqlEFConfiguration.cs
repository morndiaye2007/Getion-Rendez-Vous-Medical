using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System.Data.Entity;

namespace MetierappRvmedical.Model
{
    public class MySqlEFConfiguration : DbConfiguration
    {
        public MySqlEFConfiguration()
        {
            SetProviderServices("MySql.Data.MySqlClient", new MySqlProviderServices());
            SetDefaultConnectionFactory(new MySqlConnectionFactory());
        }
    }
}
