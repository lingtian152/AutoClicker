using System;
using System.Dynamic;
using System.IO;
using SharpConfig;

namespace AutoClicker
{
    class ConfigurationManager
    {
        private static void initConfig(string FileName)
        {
            Configuration config = new Configuration();
            config["Settings"]["ClickInterval"].IntValue = 100;
            config["Settings"]["HotKey"].StringValue = "F1";
            config.SaveToFile(FileName);
        }

        private static void CreateFile(string FileName)
        {
            if (!File.Exists(FileName))
            {
                using (File.Create(FileName))
                {
                    initConfig(FileName);
                }
            }
        }

        public static void SaveSettings(string fileName, string key, object value)
        {
            CreateFile(fileName);

            var configFile = Configuration.LoadFromFile(fileName);
            var section = configFile["Settings"];

            if (value is string stringValue)
            {
                section[key].StringValue = stringValue;
            }
            else if (value is int intValue)
            {
                section[key].IntValue = intValue;
            }
            else if (value is bool boolValue)
            {
                section[key].BoolValue = boolValue;
            }

            configFile.SaveToFile(fileName);
        }

        public static object LoadSettings(string fileName, string key, Type valueType)
        {
            CreateFile(fileName);

            var configFile = Configuration.LoadFromFile(fileName);
            var section = configFile["Settings"];

            if (valueType == typeof(string))
            {
                return section[key].StringValue;
            }
            else if (valueType == typeof(int))
            {
                return section[key].IntValue;
            }
            else
            {
                throw new ArgumentException("Unsupported value type", nameof(valueType));
            }
        }


    }
}