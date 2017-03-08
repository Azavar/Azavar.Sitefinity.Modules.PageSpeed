using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azavar.Sitefinity.Modules.PageSpeed.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Kendo;

namespace Azavar.Sitefinity.Modules.PageSpeed.Web.UI.Views
{
    public class PageSpeedView : KendoView
    {        
        private static string layoutTemplatePath = string.Concat(PageSpeedModule.ModuleVirtualPath, "Azavar.Sitefinity.Modules.PageSpeed.Web.UI.Views.PageSpeedView.ascx");

        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    base.LayoutTemplatePath = PageSpeedView.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        protected override void InitializeControls(GenericContainer container)
        {
            var config = Config.Get<PageSpeedConfig>();

            hdnHasApiKey.Value = (!string.IsNullOrEmpty(config.ApiKey)).ToString().ToLower();

            var host = HttpContext.Current.Request.Url.Host;

            hdnIsLocalHost.Value = host.Contains("localhost").ToString().ToLower();

            var url = HttpContext.Current.Request.Url.Scheme + Uri.SchemeDelimiter + host +
                       (HttpContext.Current.Request.Url.IsDefaultPort ? "" : ":" + HttpContext.Current.Request.Url.Port);

            hdnServiceUrl.Value = string.Format("{0}/Sitefinity/Services/PageSpeed.svc/RunPageSpeedOnUrls", url);
            hdnServiceUrlRunPageSpeedOnPageIds.Value = string.Format("{0}/Sitefinity/Services/PageSpeed.svc/RunPageSpeedOnPageIds", url);

            hdnPagesServiceUrl.Value = string.Format("{0}/Sitefinity/Services/Pages/PagesService.svc", url);

            hdnBaseUrl.Value = url;
        }



        protected virtual HiddenField hdnBaseUrl
        {
            get
            {
                return Container.GetControl<HiddenField>("hdnBaseUrl", true);
            }
        }

        protected virtual HiddenField hdnServiceUrlRunPageSpeedOnPageIds
        {
            get
            {
                return Container.GetControl<HiddenField>("hdnServiceUrlRunPageSpeedOnPageIds", true);
            }
        }

        protected virtual HiddenField hdnServiceUrl
        {
            get
            {
                return Container.GetControl<HiddenField>("hdnServiceUrl", true);
            }
        }

        protected virtual HiddenField hdnIsLocalHost
        {
            get
            {
                return Container.GetControl<HiddenField>("hdnIsLocalHost", true);
            }
        }

        protected virtual HiddenField hdnPagesServiceUrl
        {
            get
            {
                return Container.GetControl<HiddenField>("hdnPagesServiceUrl", true);
            }
        }

        protected virtual HiddenField hdnHasApiKey
        {
            get
            {
                return Container.GetControl<HiddenField>("hdnHasApiKey", true);
            }
        }

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            var assemblyName = typeof(PageSpeedView).Assembly.FullName;

            scripts.Add(new ScriptReference(PageSpeedPageScript, assemblyName));

            return scripts;
        }

        public const string PageSpeedPageScript = "Azavar.Sitefinity.Modules.PageSpeed.Web.Scripts.PageSpeedView.js";

    }
}
