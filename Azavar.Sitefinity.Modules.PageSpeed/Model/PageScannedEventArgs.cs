using System;

namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public class PageScannedEventArgs : EventArgs
    {
        public int TotalPages { get; set; }
        public int PagesComplete { get; set; }
    }
}