







namespace PragueParking.DataAccess
{
    public static class ConfigManager
    {
        public static Config LoadConfig(string path)
        {
            // Implement the logic to load the configuration file here
            return DataManager.LoadData<Config>(path);
        }
    }
}
