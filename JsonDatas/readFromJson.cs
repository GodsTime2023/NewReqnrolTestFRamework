namespace NewReqnrolTestFRamework.JsonDatas
{
    public class readFromJson
    {
        private IConfigurationRoot _config;

        public readFromJson()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("settings.json")
               .Build();

            _config = builder;
        }

        public string geturlValue(string key) => _config[key]!;
        public string? GetUrl() =>
            _config.GetSection("url")?.GetValue<string>("suacedemoUrl");
    }
}
