using System.Windows;

namespace EyeZen.Utilities
{
    public partial class LanguageDialog 
    {
        public string SelectedLanguage { get; private set; } = "";

        public LanguageDialog()
        {
            InitializeComponent();
        }

        private void Russian_Click(object sender, RoutedEventArgs e)
        {
            SelectedLanguage = "ru";
            DialogResult = true;
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            SelectedLanguage = "en";
            DialogResult = true;
        }
    }
}