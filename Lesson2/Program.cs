using System;
using System.Net;

namespace Lesson2
{
    /// <summary>
    /// The Best Program in the World
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">command line words</param>
        static void Main(string[] args)
        {
            OtherClass obj = (OtherClass)5;

            IDoing doing = new SomeClass();
            doing.DoIt(5);
            if (doing is SomeClass)
                Console.WriteLine("OK");
            SomeClass sc = (SomeClass)doing;

            int i1;
            A a = new();
            Console.WriteLine(a);
            //a.F = 11;
            Console.WriteLine(a.F);
            Console.WriteLine(10.Equals(8));

            S s;
            s.f1 = 10;
            s.f2 = 8;
            S s1 = new() { f1 = 6, f2 = 7 };
            Console.WriteLine("" + s + s1);

            object o = 10;
            Console.WriteLine(o.GetType().Name);
            A.sf = 0;

            int[] arr1;
            arr1 = new int[8];
            foreach (var i in arr1)
                Console.Write(" " + i);
            Console.WriteLine();

            int[] arr2 = { 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            //int[] arr3 = new int[10] { 1, 2, 3 };

            int[,] matrix1 = new int[2, 3];
            Console.WriteLine(matrix1.GetLength(0));

            int[][] matrix2;
            matrix2 = new int[5][];
            for (int i = 0; i < 5; ++i)
                matrix2[i] = new int[i + 1];

            int[,] matrix3 =
            {
                { 1, 2, 3},
                { 4, 5, 6}
            };

            int[][] matrix4 =
            {
                new int[] {1,2,3 },
                new int[] {5,6}
            };

            int[,][] superMatrix;
            //Console.WriteLine(sum(3));
            //Console.WriteLine(sum(2));
            //Console.WriteLine(sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
            namedParams(p3: 2, p2: "Tevuna", p1: 7);

            optionalParams(1, p3: 8);
            int n1 = 1, n2 = 2;

            switch ((n1, n2 + 1))
            {
                case (3, > 2 and <= 4) when n1*n2 > 8: break;
                default: break;
            }
        }

        static private void optionalParams(int p1, int p2 = 2, int p3 = 3) { }

        static private void sum(string str, params int[] numbers)
        {
            Console.Write(str + ": ");
            int s = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i];
            }
            Console.WriteLine(s);
        }

        static void namedParams(int p1, string p2, int p3) { }

    }

    class A
    {
        int f = 8;

        public int F
        {
            get => f;
            private set => f = value;
        }

        int g;
        public int G => g;

        public int H { get; set; }

        private int num;
        // public int Num => num;
        public int Num
        {
            //get { return num; }
            get => num; set => num = value;
            // set { num = value; }
        }

        public DateTime Today { get => DateTime.Now; }

        public int Num2 { get; private set; } = 8;

        public static int sf = 1;
        public override string ToString() => $"f={f}";
    }

    struct S
    {
        public int f1;
        public int f2;

    }

    interface IDoing
    {
        internal int DoIt(int num) => num;
    }

    class SomeClass : IDoing
    {
        int IDoing.DoIt(int num) => throw new NotImplementedException();
    }

    class OtherClass
    {
        private int field;
        private OtherClass(int p) => field = p;

        public static explicit operator OtherClass(int param)
            => new OtherClass(param);

        void printNumbers(params int[] numbers)
        {
            foreach (int n in numbers)
                Console.WriteLine(n);
        }

        void some(int num)
        {
            IDoing obj = new SomeClass();
            Console.WriteLine(obj.DoIt(0));

            printNumbers(1, 2, 3, 4);

            f2(6, n2: 5, s: "Yossi");
        }

        void f2(int n, string s, int n2) { }
    }
}
