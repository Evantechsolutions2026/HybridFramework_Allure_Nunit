using Framework.POJO;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Framework.Utils
{
    public static class ConfigReader
    {
        private static readonly JObject config;

        // Static constructor to load configuration from config.json 
        static ConfigReader()
        {
            string configPath = Path.Combine(Directory.GetCurrentDirectory(), "Config", "config.json");
            config = JObject.Parse(File.ReadAllText(configPath));
        }

        public static string Get(string key)
        {
            return config[key].ToString();
        }

        public static string GetNested(string parent, string child)
        {
            return config[parent][child].ToString();
        }

        public static int GetInt(string parent, string child)
        {
            return config[parent][child].ToObject<int>();
        }
        public static DbUser GetDbUser(string userType)
        {
            return new DbUser
            {
                Username = config["users"][userType]["username"].ToString(),
                Password = config["users"][userType]["password"].ToString()
            };
        }

    }
}