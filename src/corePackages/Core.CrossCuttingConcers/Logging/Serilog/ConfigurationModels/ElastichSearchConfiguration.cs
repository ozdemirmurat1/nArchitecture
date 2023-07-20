using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels
{
    public class ElastichSearchConfiguration
    {
        public string ConnectionString { get; set; }

        public ElastichSearchConfiguration()
        {
                ConnectionString=string.Empty;
        }
    }
}
