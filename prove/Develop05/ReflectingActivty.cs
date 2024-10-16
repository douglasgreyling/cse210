using System;

class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _prompts = new List<string>{
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };
        _questions = new List<string>{
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(1);

        Console.WriteLine();

        DisplayPrompt();
        DisplayQuestions();

        Console.WriteLine();

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();

        return _prompts[random.Next(0, _prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();

        return _questions[random.Next(0, _questions.Count)];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("When you have something in mind, press any key to continue.");
        Console.ReadKey();
    }

    private void DisplayQuestions()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");

        Console.Write("You may begin in: ");

        for (int i = 0; i < 4; i++)
        {
            ShowCountDown(4 - i);
        }

        Console.WriteLine("");

        Random random = new Random();
        var shuffledQuestions = _questions.OrderBy(x => random.Next()).ToList();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        foreach (var question in shuffledQuestions)
        {
            Console.Write($"> {question} ");

            ShowSpinner(5);

            Console.WriteLine();

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }
    }
}
