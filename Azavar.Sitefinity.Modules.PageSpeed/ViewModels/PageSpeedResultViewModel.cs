using System.Collections.Generic;

namespace Azavar.Sitefinity.Modules.PageSpeed.ViewModels
{
    public class PageSpeedResultViewModel
    {
        public string Title { get; set; }
        public int Score { get; set; }
        public string Url { get; set; }
        public List<RuleSetViewModel> RuleSets { get; set; }
        public int ResponseCode { get; set; }
        public string ContextClass { get; set; }

        public PageSpeedResultViewModel()
        {
            RuleSets = new List<RuleSetViewModel>();
        }
    }
}