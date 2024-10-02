using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Fraction wholeNumber = new Fraction(6);
        Fraction sixSevenths = new Fraction(6, 7);

        int top = sixSevenths.GetTop();
        sixSevenths.SetTop(top + 1);

        int bottom = sixSevenths.GetBottom();
        sixSevenths.SetBottom(bottom + 1);

        Console.WriteLine(one.GetFractionString());
        Console.WriteLine(one.GetDecimalValue());

        Fraction five = new Fraction(5);

        Console.WriteLine(five.GetFractionString());
        Console.WriteLine(five.GetDecimalValue());

        Fraction threeQuarters = new Fraction(3, 4);

        Console.WriteLine(threeQuarters.GetFractionString());
        Console.WriteLine(threeQuarters.GetDecimalValue());

        Fraction oneThird = new Fraction(1, 3);

        Console.WriteLine(oneThird.GetFractionString());
        Console.WriteLine(oneThird.GetDecimalValue());
    }
}
