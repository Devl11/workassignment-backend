using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WorkAssignment.Shared
{
    public class AppSettings
    {
        public IConfigurationSection AppSettingsSection { get; set; }
        public const string SectionName = "AppSettings";
        public OpenChangeSettings OpenChange { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection(SectionName);
            appSettingsSection.Bind(this);
            AppSettingsSection = appSettingsSection;
        }
    }
    
    public class OpenChangeSettings
    {
        public string BaseUri { get; set; }
        public string ApiKey { get; set; }
    }
}