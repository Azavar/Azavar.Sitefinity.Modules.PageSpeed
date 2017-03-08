namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public class MainResourceServerResponseTime
    {
        public string LocalizedRuleName { get; set; }
        public double RuleImpact { get; set; }
        public string[] Groups { get; set; }
        public Summary Summary { get; set; }
        public Urlblock[] UrlBlocks { get; set; }
    }
}