namespace Azavar.Sitefinity.Modules.PageSpeed.Model
{
    public interface IPageSpeedFormattable
    {
        string Format { get; set; }
        Arg[] Args { get; set; }
    }
}