using System;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write($"How long, in seconds, would you like for your session? ");

        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...");
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(1);
        Console.WriteLine("");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity");
        ShowSpinner(1);
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("|");
            Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(300);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountDown(int seconds)
    {
        Console.Write(seconds);
        Thread.Sleep(1000);
        Console.Write("\b \b");
    }
}
