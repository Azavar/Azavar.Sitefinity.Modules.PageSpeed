using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace Azavar.Sitefinity.Modules.PageSpeed.Configuration
{
    /// <summary>
    /// Sitefinity configuration section.
    /// </summary>
    /// <remarks>
    /// If this is a Sitefinity module's configuration,
    /// you need to add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Configuration<PageSpeedConfig>();
    /// 
    /// You also need to add this to the module:
    /// protected override ConfigSection GetModuleConfig()
    /// {
    ///     return Config.Get<PageSpeedConfig>();
    /// }
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/deep-dive/configuration/creating-configuration-classes"/>
    [ObjectInfo(Title = "PageSpeedConfig Title", Description = "PageSpeedConfig Description")]
    public class PageSpeedConfig : ConfigSection
    {
        [ObjectInfo(Title = "ApiKey", Description = "API Key")]
        [ConfigurationProperty("ApiKey", DefaultValue = "")]
        public string ApiKey
        {
            get
            {
                return (string)this["ApiKey"];
            }
            set
            {
                this["ApiKey"] = value;
            }
        }

        [ObjectInfo(Title = "PageSpeedUrl", Description = "Page Speed Url")]
        [ConfigurationProperty("PageSpeedUrl", DefaultValue = "https://www.googleapis.com/pagespeedonline/v2/runPagespeed")]
        public string PageSpeedUrl
        {
            get
            {
                return (string)this["PageSpeedUrl"];
            }
            set
            {
                this["PageSpeedUrl"] = value;
            }
        }
    }
}