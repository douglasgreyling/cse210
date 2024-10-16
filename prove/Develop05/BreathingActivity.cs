using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking through your breathing in and out slowly. Clear your mind and focus your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(1);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        Random random = new Random();

        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            int pauseSeconds = random.Next(3, 10);

            Console.Write("Breathe in...");

            for (int i = 0; i < pauseSeconds; i++)
            {
                ShowCountDown(pauseSeconds - i);
            }

            Console.WriteLine();

            pauseSeconds = random.Next(3, 10);

            Console.Write("Now breathe out...");

            for (int i = 0; i < pauseSeconds; i++)
            {
                ShowCountDown(pauseSeconds - i);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
