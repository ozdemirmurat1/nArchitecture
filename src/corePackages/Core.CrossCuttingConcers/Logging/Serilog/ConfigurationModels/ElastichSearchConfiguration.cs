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
