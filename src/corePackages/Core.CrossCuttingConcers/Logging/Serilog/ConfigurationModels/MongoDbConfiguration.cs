using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string Collection { get; set; }

        public MongoDbConfiguration()
        {
            ConnectionString = string.Empty;
            Collection = string.Empty;
        }

        public MongoDbConfiguration(string connectionString, string collection)
        {
            ConnectionString = connectionString;
            Collection = collection;
        }
    }
}
