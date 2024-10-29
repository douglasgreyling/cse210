using System;

class SwimmingActivity : Activity
{
    private int _laps { get; set; }
    private const double LapLengthMeters = 50;

    public SwimmingActivity(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        _laps = laps;
    }

    protected override double GetDistance()
    {
        return (_laps * LapLengthMeters) / 1000;
    }
}
