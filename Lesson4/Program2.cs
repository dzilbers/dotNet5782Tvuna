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
            Printer pr1 = new("HP Color Floor 3");
            Printer pr2 = new("Brother B/W Floor 2 Room 9211");
            //pr1.PageOver();
            User1 u1 = new(pr1);
            User1 u2 = new(pr2);
            User1 u3 = new(pr1);
            User1 u4 = new(pr1);
            User2 u5 = new(pr1);

            int pages;
            do
            {
                Console.Write("How many pages to print: ");
                bool success = int.TryParse(Console.ReadLine(), out pages);
                if (success)
                {
                    if (pages > 0)
                        pr1.Print(pages);
                }
            } while (pages > 0);
        }
    }

    class PrinterEventArgs : EventArgs
    {
        public int PagesNotPrinted { get; init; }
        public PrinterEventArgs(int pages) => PagesNotPrinted = pages;
    }

    class Printer
    {
        internal string Name { get; set; }

        public Printer(string name) => Name = name;

        public event EventHandler<PrinterEventArgs> PageOver = null;
        private void handlePageOver(int pages) => PageOver?.Invoke(this, new PrinterEventArgs(pages));

        private int pageCount = 20;

        public void Print(int pages)
        {
            if (pages <= pageCount)
                pageCount -= pages;
            else
            {
                int missing = pages - pageCount;
                pageCount = 0;
                handlePageOver(missing);
            }
        }

        public void AddPaper(int pages) => pageCount += pages;
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

        private void myPageOver(object sender, EventArgs args)
        {
            Console.WriteLine("Can't bring it - I am in the lunch break!!!");
        }
    }

    class User2
    {
        static Random rand = new Random();
        Printer printer;
        public User2(Printer printer)
        {
            this.printer = printer;
            printer.PageOver += myPageOver;
        }

        private void myPageOver(object sender, PrinterEventArgs pArgs)
        {
            //PrinterEventArgs pArgs = args as PrinterEventArgs ?? throw new ArgumentNullException("Not printer args");
            Printer prt = (Printer)sender;
            Console.WriteLine("Just a moment - I am bringing more paper for " + prt.Name);
            prt.AddPaper(pArgs.PagesNotPrinted + rand.Next(10, 100));
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

        private void PrinterPageOver(object sender, EventArgs args)
        {
            Console.WriteLine("I am tired, find somebody else to bring the paper");
        }
    }
}
