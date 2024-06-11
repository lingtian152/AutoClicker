using System;
using System.IO;
using SharpConfig;

namespace AutoClicker
{
    class ConfigurationManager
    {
        public static void SaveSettings(string fileName, string key, object value)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }

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
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"The file {fileName} does not exist.");
            }

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