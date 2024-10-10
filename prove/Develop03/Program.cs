// For this assignment, I exceeded the expectations by making the program ask
// the user do adjust the difficulty of the memorization by asking them for how
// many words they would like to hide on each attempt

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference refer = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(refer, "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        Console.WriteLine("Welcome to the scripture memorization program!");
        Console.WriteLine();
        Console.WriteLine("Please enter the number of words you would like to hide on each attempt:");

        int numWords = Convert.ToInt32(Console.ReadLine());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type 'quit' to exit...");

            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            } else {
                Console.Clear();
                scripture.HideRandomWords(numWords);
            }
        }
    }
}