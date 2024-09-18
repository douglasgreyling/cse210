using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your course grade (0-100): ");
        int grade = int.Parse(Console.ReadLine());

        string letterGrade = "";
        string sign = "";

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        if (letterGrade != "A" && letterGrade != "F")
        {
            int lastDigit = grade % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        if (letterGrade == "A" && grade < 93)
        {
            sign = "-"; // Only A- exists
        }
        if (letterGrade == "F")
        {
            sign = ""; // No F+ or F-
        }

        Console.WriteLine($"Your final grade is {letterGrade}{sign}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You'll get it next time.");
        }
    }
}
