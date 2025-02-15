using System.Configuration;
using System.Diagnostics;

namespace EyeZen.Properties
{
    using System.Configuration;

    public sealed partial class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = new Settings();

        public static Settings Default => defaultInstance;

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string Language
        {
            get => (string)this["Language"];
            set => this["Language"] = value;
        }
    }
}