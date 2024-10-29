using System;

class RunningActivity : Activity
{
    private double _distance { get; set; }

    public RunningActivity(DateTime date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        _distance = distance;
    }

    protected override double GetDistance()
    {
        return _distance;
    }
}
