using System;

public class Cycling : Activity
{
    // opposite of running - on a bike you usually know your speed
    // (bike computer/app) more than exact distance, so store that instead
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed / 60) * Minutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}