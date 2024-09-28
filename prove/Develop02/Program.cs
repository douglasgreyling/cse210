// For this assignment, I exceeded the expectations by making the program use
// JSON serialization to save and load journal entries instead of CSV files.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");

                    string response = Console.ReadLine();

                    string date = DateTime.Now.ToString("dd/MM/yyyy");
                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);

                    Console.WriteLine("Entry added successfully!\n");
                    break;

                case "2":
                    Console.WriteLine("Displaying all journal entries:\n");
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Entries loaded from file!\n");
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Entries saved to file!\n");
                    break;

                case "5":
                    quit = true;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}
