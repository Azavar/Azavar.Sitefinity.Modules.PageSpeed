namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public class Result : IPageSpeedFormattable
    {
        public string Format { get; set; }
        public Arg[] Args { get; set; }
    }
}