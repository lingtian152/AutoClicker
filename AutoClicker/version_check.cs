using System;
using System.Net;
using AutoClicker.Properties;
using Newtonsoft.Json;

namespace AutoClicker
{
    class version_check
    {

       private string version;

        public void GetLastVersion()
        {
            string url = "https://autoclick.lingtian.workers.dev";
            try
            {
                
                Form_Alert.ShowNotice("Checking for updates...", MsgType.Info);

                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(url);
                    dynamic jsonObject = JsonConvert.DeserializeObject(json);

                    version = jsonObject["version"].ToString();

                    if (Resources.version != version)
                    {
                        Form_Alert.ShowNotice("New version available", MsgType.Info);

                        Updater updater = new Updater();
                        updater.Show();
                    }
                }
            }
            catch (Exception)
            {
                Form_Alert.ShowNotice("Failed to check for updates", MsgType.Error);
            }
        }
    }
}
