namespace Discord_Bot.Module.Utilities;

public class TimeAndDate
{
    private DateTime  time;
    
    private DateTime DateAndTime()
    {
        time = DateTime.Now;
        return time;

    }

    public DateTime Time
    {
        get { return DateAndTime(); }
    }

}