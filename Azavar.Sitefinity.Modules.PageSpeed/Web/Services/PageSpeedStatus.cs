using System.Collections.Generic;

namespace Azavar.Sitefinity.Modules.PageSpeed.Web.Services
{
    public class PageSpeedStatus
    {
        public int CurrentProgress
        {
            get;
            set;
        }

        public IEnumerable<string> Links
        {
            get;
            set;
        }

        public string StatusMessage
        {
            get;
            set;
        }
    }
}