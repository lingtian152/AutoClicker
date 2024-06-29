using SharpConfig;
using System;
using System.Collections.Generic;
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
            // 配置项字典
            var settings = new Dictionary<string, object>
            {
                { "ClickInterval", 100 }, // 点击间隔
                { "HotKey", "F1" },       // 热键
                { "Button", "LeftButton" }, // 点击鼠标按钮
                { "TopMost", false }      // 窗口顶置
            };

            // 使用循环初始化配置
            foreach (var setting in settings)
            {
                if (setting.Value is int intValue)
                {
                    config["Settings"][setting.Key].IntValue = intValue;
                }
                else if (setting.Value is string stringValue)
                {
                    config["Settings"][setting.Key].StringValue = stringValue;
                }
                else if (setting.Value is bool boolValue)
                {
                    config["Settings"][setting.Key].BoolValue = boolValue;
                }
            }
        }


        public static void SaveSettings(string fileName, string key, object value)
        {
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
