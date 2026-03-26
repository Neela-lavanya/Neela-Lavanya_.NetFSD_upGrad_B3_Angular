using ConsoleApp12;
using System;
using System.Collections.Generic;
using System.Drawing;

// Entity
abstract class Shape
{
    public abstract double CalculateArea();
}

// Rectangle
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// Circle
class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// Main Class
class Program
{
    static void PrintArea(Shape shape)
    {
        Console.WriteLine("Area: " + shape.CalculateArea());
    }

    static void Main()
    {
        PrintArea(new Rectangle { Width = 5, Height = 4 });
        PrintArea(new Circle { Radius = 3 });
    }
}