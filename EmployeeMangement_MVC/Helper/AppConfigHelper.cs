namespace EmployeeMangement_MVC.Helper
{
    public static class AppConfigHelper
    {
        private static IConfiguration _configuration;

        static AppConfigHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set base path
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Load config

            _configuration = builder.Build();
        }
        public static async Task<AppConfigModel> GetConfigValue()
        {
            return new AppConfigModel()
            {
                SecretKey = _configuration["Jwt:Key"]
            };
        }
    }
}
