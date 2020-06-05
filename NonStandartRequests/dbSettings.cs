using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonStandartRequests
{
    internal sealed partial class dbSettings : global::System.Configuration.ApplicationSettingsBase
    {

        private static dbSettings defaultInstance = ((dbSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new dbSettings())));

        public static dbSettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("outpost")]
        public string DatabaseName
        {
            get
            {
                return ((string)(this["DatabaseName"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.88.101")]
        public string Host
        {
            get
            {
                return ((string)(this["Host"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5432")]
        public int Port
        {
            get
            {
                return ((int)(this["Port"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("postgres")]
        public string User
        {
            get
            {
                return ((string)(this["User"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("kovila77")]
        public string Password
        {
            get
            {
                return ((string)(this["Password"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\transcription.sqlite")]
        public string TranslationPath
        {
            get
            {
                return ((string)(this["TranslationPath"]));
            }
        }
    }
}
