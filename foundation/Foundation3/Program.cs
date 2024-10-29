using System;

class Program
{
    static void Main(string[] args)
    {
        var activites = new List<Activity> {
            new RunningActivity(new DateTime(2022, 11, 3), 30, 4.8),
            new CyclingActivity(new DateTime(2022, 11, 3), 30, 20.0),
            new SwimmingActivity(new DateTime(2022, 11, 3), 30, 20),
        };

        foreach (var activity in activites)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
