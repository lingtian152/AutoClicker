using SharpConfig;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoClicker
{
    class ConfigurationManager
    {
        private const string SectionName = "Settings";

        public static void CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var config = new Configuration();
                InitConfig(config);
                config.SaveToFile(fileName);
            }
        }

        private static void InitConfig(Configuration config)
        {
            var settings = new Dictionary<string, object>
            {
                { "ClickInterval", 100 },
                { "HotKey", "F1" },
                { "Button", "LeftButton" },
                { "TopMost", false }
            };

            foreach (var setting in settings)
            {
                SetConfigValue(config, setting.Key, setting.Value);
            }
        }

        public static void SaveSettings(string fileName, string key, object value)
        {
            CreateFile(fileName);

            var configFile = Configuration.LoadFromFile(fileName);
            SetConfigValue(configFile, key, value);
            configFile.SaveToFile(fileName);
        }

        public static object LoadSettings(string fileName, string key, Type valueType)
        {
            var configFile = Configuration.LoadFromFile(fileName);
            var section = configFile[SectionName];

            if (valueType == typeof(string))
            {
                return section[key].StringValue;
            }
            else if (valueType == typeof(int))
            {
                return section[key].IntValue;
            }
            else if (valueType == typeof(bool))
            {
                return section[key].BoolValue;
            }
            else
            {
                throw new ArgumentException("Unsupported value type", nameof(valueType));
            }
        }

        private static void SetConfigValue(Configuration config, string key, object value)
        {
            var section = config[SectionName];

            switch (value)
            {
                case string stringValue:
                    section[key].StringValue = stringValue;
                    break;
                case int intValue:
                    section[key].IntValue = intValue;
                    break;
                case bool boolValue:
                    section[key].BoolValue = boolValue;
                    break;
                default:
                    throw new ArgumentException("Unsupported value type", nameof(value));
            }
        }
    }
}