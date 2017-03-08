using System;

namespace Azavar.Sitefinity.Modules.PageSpeed.ViewModels
{
    public class RuleSetViewModel
    {
        private double _impact;
        public string LocalizedName { get; set; }

        public double Impact
        {
            get { return Math.Round(_impact, 2); }
            set { _impact = value; }
        }

        public string Summary { get; set; }
        public string Severity { get; set; }
        public string Url { get; set; }
        public UrlblockViewModel[] Urlblocks { get; set; }
        public string RuleName { get; set; }
    }
}