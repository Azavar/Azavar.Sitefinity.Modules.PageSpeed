namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public class PageStats
    {
        public int NumberResources { get; set; }
        public int NumberHosts { get; set; }
        public string TotalRequestBytes { get; set; }
        public int NumberStaticResources { get; set; }
        public string HtmlResponseBytes { get; set; }
        public string CssResponseBytes { get; set; }
        public string ImageResponseBytes { get; set; }
        public string JavascriptResponseBytes { get; set; }
        public string OtherResponseBytes { get; set; }
        public int NumberJsResources { get; set; }
        public int NumberCssResources { get; set; }
    }
}