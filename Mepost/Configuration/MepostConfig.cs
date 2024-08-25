namespace Mepost.Configuration
{
    public class MepostConfig
    {
        public string ApiKey { get; set; }

        public MepostConfig(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}
