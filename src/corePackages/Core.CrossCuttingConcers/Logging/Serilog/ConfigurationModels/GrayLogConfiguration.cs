namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels
{
    public class GrayLogConfiguration
    {
        public string? HostnameOrAddress { get; set; }
        public int Port { get; set; }
    }
}
