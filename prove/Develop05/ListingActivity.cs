using System;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompts = new List<string>{
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        GetRandomPrompt();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        var list = GetListFromUser();

        _count = list.Count;

        Console.WriteLine($"You listed {_count} items!");

        Console.WriteLine();

        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        Random random = new Random();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[random.Next(0, _prompts.Count)]} ---");
    }

    private List<string> GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        List<string> list = new List<string>();

        do
        {
            Console.Write("> ");
            list.Add(Console.ReadLine());
        } while (DateTime.Now < endTime);

        return list;
    }
}
