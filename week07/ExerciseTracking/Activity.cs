using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    private string _activity;

    public Activity(DateTime date, int minutes, string activity)
    {
        _date = date;
        _minutes = minutes;
        _activity = activity;
    }

    public abstract double GetDistance();
    public abstract double GetPace();
    public abstract double GetSpeed();

    public virtual string GetSummary()
    {
        string formattedDate = _date.ToString("dd MMM yyyy");

        double distance = GetDistance();
        double pace = GetPace();
        double speed = GetSpeed();

        return  $"{formattedDate} {_activity} ({_minutes} min): " +
                $"Distance {distance:F1} miles, " +
                $"Speed {speed:F1} mph, " +
                $"Pace {pace:F1} min per mile.";
    }

    protected int GetMinutes()
    {
        return _minutes;
    }
}