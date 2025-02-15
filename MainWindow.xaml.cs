using System.Windows;
using EyeZen.Services;
using EyeZen.Utilities;

namespace EyeZen
{
    public partial class MainWindow 
    {
        private readonly NotificationService _notificationService;

        public MainWindow()
        {
            InitializeComponent();
            
            LocalizationManager.LanguageChanged += OnLanguageChanged;
            
            if (Properties.Settings.Default.Language == "")
            {
                var languageDialog = new LanguageDialog();
                if (languageDialog.ShowDialog() == true)
                {
                    LocalizationManager.SetLanguage(languageDialog.SelectedLanguage);
                    Properties.Settings.Default.Language = languageDialog.SelectedLanguage;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                LocalizationManager.SetLanguage(Properties.Settings.Default.Language);
            }

            _notificationService = new NotificationService();
        }
        
        private void OnLanguageChanged(object? sender, EventArgs e)
        {
            // Обновляем привязки данных
            Title = LocalizationManager.AppTitle;
            StartButton.Content = LocalizationManager.StartButton;
            StopButton.Content = LocalizationManager.StopButton;
        }

        private void StartReminders_Click(object sender, RoutedEventArgs e)
        {
            _notificationService.Start();
        }

        private void StopReminders_Click(object sender, RoutedEventArgs e)
        {
            _notificationService.Stop();
        }
    }
}