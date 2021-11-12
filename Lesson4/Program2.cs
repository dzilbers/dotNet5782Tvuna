using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    partial class Program
    {
        partial void Main2()
        {
            Printer pr1 = new();
            //pr1.PageOver();
            User1 u1 = new(pr1);
            User1 u2 = new(pr1);
            User1 u3 = new(pr1);
            User1 u4 = new(pr1);
            User2 u5 = new(pr1);
            pr1.Print(30);
        }
    }

    public delegate void PrintEventHandler();
    class Printer
    {
        public event PrintEventHandler PageOver = null;
        private void handlePageOver() => PageOver?.Invoke();

        private int pageCount = 20;

        public void Print(int pages)
        {
            if (pages <= pageCount)
                pageCount -= pages;
            else
            {
                pageCount = 0;
                handlePageOver();
            }
        }
    }

    class User1
    {
        Printer printer;
        public User1(Printer printer)
        {
            this.printer = printer;
            //printer.PageOver = myPageOver;
            printer.PageOver += myPageOver;
        }

        private void myPageOver()
        {
            Console.WriteLine("Can't bring it - I am in the lunch break!!!");
        }
    }

    class User2
    {
        Printer printer;
        public User2(Printer printer)
        {
            this.printer = printer;
            printer.PageOver += myPageOver;
        }

        private void myPageOver()
        {
            Console.WriteLine("Just a moment - I am bringing more paper");
        }
    }

    class User3
    {
        Printer printer;
        public User3(Printer printer)
        {
            this.printer = printer;
            printer.PageOver += PrinterPageOver;
        }

        private void PrinterPageOver()
        {
            Console.WriteLine("I am tired, find somebody else to bring the paper");
        }
    }
}
