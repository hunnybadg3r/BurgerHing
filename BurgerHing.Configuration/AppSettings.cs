using Microsoft.Extensions.Configuration;

namespace BurgerHing.Configuration
{
    public class AppSettings
    {
        private static AppSettings _instance;

        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSettings();
                    _instance.Initialize();
                }
                return _instance;
            }
        }

        public IConfiguration Configuration { get; private set; }

        private void Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
