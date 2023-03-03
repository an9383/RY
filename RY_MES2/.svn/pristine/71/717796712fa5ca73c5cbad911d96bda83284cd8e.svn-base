using System.Configuration;

namespace nsCommon
{
    public enum AppConfig
    {
        USER_ID
    }

    internal class clsAppConfiguration
    {
        public static string GetAppConfig(AppConfig key)
        {
            return ConfigurationManager.AppSettings[key.ToString()];
        }

        public static string GetAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;
            cfgCollection.Remove(key);
            cfgCollection.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void SetAppConfig(AppConfig key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;
            cfgCollection.Remove(key.ToString());
            cfgCollection.Add(key.ToString(), value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void AddAppConfig(AppConfig key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;
            cfgCollection.Add(key.ToString(), value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void RemoveAppConfig(AppConfig key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;
            try
            {
                cfgCollection.Remove(key.ToString());
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch { }
        }
    }
}