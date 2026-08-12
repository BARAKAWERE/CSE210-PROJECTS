using System;

// Base class - holds everything that's the same across all workout types
public class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date
    {
        get { return _date; }
    }

    public int Minutes
    {
        get { return _minutes; }
    }

    // Not implemented here on purpose - each activity type calculates
    // these completely differently so it doesn't make sense to guess
    // at a default in the base class.
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        string activityType = GetType().Name;

        return $"{_date:dd MMM yyyy} {activityType} ({_minutes} min) - " +
            $"Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, " +
            $"Pace: {GetPace():F2} min per mile";
    }
}