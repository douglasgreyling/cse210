using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        double average = sum / (double)numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int maxNumber = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > maxNumber)
            {
                maxNumber = num;
            }
        }
        Console.WriteLine($"The largest number is: {maxNumber}");

        int minPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < minPositive)
            {
                minPositive = num;
            }
        }

        if (minPositive == int.MaxValue)
        {
            Console.WriteLine("There are no positive numbers.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {minPositive}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
