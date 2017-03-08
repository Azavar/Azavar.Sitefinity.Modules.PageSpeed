using Azavar.Sitefinity.Modules.PageSpeed.Model;

namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public class RuleResults
    {
        public AvoidLandingPageRedirects AvoidLandingPageRedirects { get; set; }
        public EnableGzipCompression EnableGzipCompression { get; set; }
        public LeverageBrowserCaching LeverageBrowserCaching { get; set; }
        public MainResourceServerResponseTime MainResourceServerResponseTime { get; set; }
        public MinifyCss MinifyCss { get; set; }
        public MinifyHtml MinifyHtml { get; set; }
        public MinifyJavaScript MinifyJavaScript { get; set; }
        public MinimizeRenderBlockingResources MinimizeRenderBlockingResources { get; set; }
        public OptimizeImages OptimizeImages { get; set; }
        public PrioritizeVisibleContent PrioritizeVisibleContent { get; set; }
    }
}