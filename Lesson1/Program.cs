using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            B a;
            Console.WriteLine("Hello World!");

            Console.WriteLine("");
            Console.WriteLine(@"
It is my
   verse!
");
            int b = 8;

            Console.WriteLine($"The number is {b+12:x3}");
        }
    }

    class B { }
}
