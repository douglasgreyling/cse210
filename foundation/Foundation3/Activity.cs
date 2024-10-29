using System;

class Activity
{
    protected DateTime _date { get; set; }
    protected int _durationMinutes { get; set; }

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    protected virtual double GetDistance()
    {
        return 0;
    }

    private double GetSpeed()
    {
       return  (GetDistance() / _durationMinutes) * 60;
    }

    private double GetPace()
    {
        return _durationMinutes / GetDistance();
    }

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {this.GetType().Name} ({_durationMinutes} min) - Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}
