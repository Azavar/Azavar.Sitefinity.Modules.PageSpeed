namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public class PageSpeedResult
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public int ResponseCode { get; set; }
        public string Title { get; set; }
        public Rulegroups RuleGroups { get; set; }
        public PageStats PageStats { get; set; }
        public FormattedResults FormattedResults { get; set; }
        public Version Version { get; set; }
    }
}