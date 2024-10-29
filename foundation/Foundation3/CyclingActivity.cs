using System;

class CyclingActivity : Activity
{
    private double _averageSpeed { get; set; }

    public CyclingActivity(DateTime date, int durationMinutes, double averageSpeedKph) : base(date, durationMinutes)
    {
        _averageSpeed = averageSpeedKph;
    }

    protected override double GetDistance()
    {
        return (_averageSpeed * _durationMinutes) / 60;
    }
}