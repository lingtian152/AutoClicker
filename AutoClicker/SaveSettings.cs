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
    }

}