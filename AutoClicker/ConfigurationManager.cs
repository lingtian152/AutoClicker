using SharpConfig;
using System;
using System.IO;

namespace AutoClicker
{
    class ConfigurationManager
    {
        private static void CreateFile(string fileName)
        {
            // 创建文件
            if (!File.Exists(fileName))
            {
                var config = new Configuration();
                InitConfig(config);
                config.SaveToFile(fileName);
            }
        }

        private static void InitConfig(Configuration config)
        {
            config["Settings"]["ClickInterval"].IntValue = 100;
            config["Settings"]["HotKey"].StringValue = "F1";
            config["Settings"]["Button"].StringValue = "LeftButton";
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
            else if (valueType == typeof(bool))
            {
                return section[key].BoolValue;
            }
            else
            {
                return null;
            }
        }
    }
}
