using Newtonsoft.Json;

namespace AppEnvironment;
public class AppSettings
{
    public _ConnectionString ConnectionStrings { get; set; }
    public _Logging Logging { get; set; }

    public string AllowedHosts { get; set; }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class _ConnectionString
    {
        public string DefaultConnection { get; set; }
    }
    public class _LogLevel
    {
        public string Default { get; set; }

        [JsonProperty("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; }
    }

    public class _Logging
    {
        public _LogLevel LogLevel { get; set; }
    }

}