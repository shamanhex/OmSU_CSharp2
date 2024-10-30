using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab
{
    public class Cfg
    {
        public static readonly string APP_SETTINGS_PATH = "appsettings.json";

        private static IConfiguration config = null;

        static Cfg() {
            try
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(APP_SETTINGS_PATH, false);
                config = builder.Build();
            }
            catch (TypeInitializationException ex)
            {
                Console.WriteLine("ERROR: "+ex.Message);
                throw new TypeInitializationException("Configuration load error: "+ex.Message, ex);
            }
        }

        public static string ReadString(string paramName)
        {
            return config.GetSection(paramName).Value;
        }
    }
}
