using System;

class Program
{
    static void Main(string[] args)
    {
        Square s = new Square("red", 5);
        Console.WriteLine("Square Area: " + s.GetArea());
        Console.WriteLine("Square Color: " + s.GetColor());

        Rectangle r = new Rectangle("blue", 5, 10);
        Console.WriteLine("Rectangle Area: " + r.GetArea());
        Console.WriteLine("Rectangle Color: " + r.GetColor());

        Circle c = new Circle("green", 5);
        Console.WriteLine("Circle Area: " + c.GetArea());
        Console.WriteLine("Circle Color: " + c.GetColor());

        var shapes = new Shape[] { s, r, c };

        foreach (var shape in shapes)
        {
            Console.WriteLine("Area: " + shape.GetArea());
            Console.WriteLine("Color: " + shape.GetColor());
        }
    }
}