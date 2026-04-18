using Framework.Model;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Framework.Utils
{
    public static class ConfigReader
    {
        private static readonly JObject config;

        // Static constructor to load configuration from config.json 
        static ConfigReader()
        {
                try
                {
                    string configPath = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Config",
                        "config.json"
                    );

                    Console.WriteLine("PATH: " + configPath);

                    if (!File.Exists(configPath))
                        throw new FileNotFoundException("Config not found!");

                    string json = File.ReadAllText(configPath);

                    Console.WriteLine("JSON: " + json);

                    config = JObject.Parse(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    throw;
                }
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