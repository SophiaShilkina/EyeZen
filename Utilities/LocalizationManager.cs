using System.Globalization;
using System.Resources;
using System.Windows;

namespace EyeZen.Utilities
{
    public static class LocalizationManager
    {
        private static ResourceManager _resourceManager = new ResourceManager("EyeZen.Resources.Strings", typeof(App).Assembly);

        public static string AppTitle => GetString("AppTitle");
        public static string StartButton => GetString("StartButton");
        public static string StopButton => GetString("StopButton");
        
        public static event EventHandler LanguageChanged = delegate { };

        public static string GetString(string key)
        {
            Console.WriteLine("Зашел в Utilities/LocalizationManager.GetString");
            return _resourceManager.GetString(key, CultureInfo.CurrentCulture) ?? key;
        }

        public static void SetLanguage(string languageCode)
        {
            Console.WriteLine("Зашел в Utilities/LocalizationManager.SetLanguage");
            var culture = new CultureInfo(languageCode);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            
            LanguageChanged.Invoke(null, EventArgs.Empty);

            // Обновляем все окна
            foreach (Window window in Application.Current.Windows)
            {
                window?.Resources.Clear();
                window?.Resources.MergedDictionaries.Clear();
            }
        }
    }
}