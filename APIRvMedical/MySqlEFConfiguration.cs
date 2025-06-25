using System.Data.Entity;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;

namespace APIRvMedical
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))] // Important
    public class MySqlEFConfiguration : DbConfiguration
    {
        public MySqlEFConfiguration()
        {
            SetDefaultConnectionFactory(new MySqlConnectionFactory());
        }
    }
}
