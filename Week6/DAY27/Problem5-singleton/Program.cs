using ConsoleApp12;
using System;
using System.Collections.Generic;
using System.Drawing;

// Entity
class Program
{
    static void Main()
    {
        var obj1 = ConfigurationManager.GetInstance();
        var obj2 = ConfigurationManager.GetInstance();

        Console.WriteLine(obj1.AppName);
        Console.WriteLine(object.ReferenceEquals(obj1, obj2)); // True
    }
}