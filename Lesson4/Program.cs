using System;
using System.Reflection;

namespace Lesson4
{
    partial class Program
    {
        static void Main()
        {
            //PrintInfo("", typeof(MyClass));
            //Console.WriteLine("-----------------------------------");
            var anonymousObject = new { Id = 2222, Name = "Yossi" };
            //var anonymousObject2 = new { Id = 2222, Name = "Yossi" };
            //Console.WriteLine(anonymousObject.GetType().Name + ":" + anonymousObject);
            //Console.WriteLine(anonymousObject2.GetType().Name + ":" + anonymousObject2);
            //Console.WriteLine("== " + (anonymousObject == anonymousObject2));
            //Console.WriteLine("Equals " + (anonymousObject.Equals(anonymousObject2)));
            //PrintInfo("", anonymousObject.GetType());
            //Console.WriteLine("-----------------------------------");
            //string str = "3456";
            //int num = str.ToInt();
            //num = "34567".ToInt();

            object o = new object();
            Console.WriteLine("An Object:");
            o.ToStringProperty();
            Console.WriteLine("\nMyClass object:");
            new MyClass().ToStringProperty();
            Console.WriteLine("\nAnonymous object:");
            anonymousObject.ToStringProperty();
            Console.WriteLine("\nDateTime.Now:");
            DateTime.Now.ToStringProperty();

            //int? num1 = null;
            ////num1 = 8;
            //int num2 = num1 ?? -1; //(int)num1;
            //num2 = num1 != null ? (int)num1 : -1;
            //if (num1 == null)
            //    throw new NotImplementedException("null nullable object");

            //SomeDelegate someDel = null;
            //Console.WriteLine(someDel(3, "abc"));

            //MyDelegate myDel = MyFunc1;
            //myDel += MyFunc2;
            //myDel += MyFunc3;
            //Console.WriteLine("========================");
            //Console.WriteLine(myDel());
            //Console.WriteLine("========================");
            //foreach (MyDelegate d in myDel.GetInvocationList())
            //    Console.WriteLine(d());
            //new Program().Main2();
        }

        partial void Main2();

        static int MyFunc1() { Console.WriteLine("Func1"); return 1; }
        static int MyFunc2() { Console.WriteLine("Func2"); return 2; }
        static int MyFunc3() { Console.WriteLine("Func3"); return 3; }

        /// <summary>
        /// Print detailed infor about all the members of a type
        /// </summary>
        /// <param name="suffix">indentation spare characters</param>
        /// <param name="type">Type ob ject</param>
        static void PrintInfo(string suffix, Type type)
        {
            Console.WriteLine(suffix + "Type Name: " + type.Name);
            Console.WriteLine(suffix + "Base Type: ");
            if (type.BaseType == null)
                Console.WriteLine(suffix + suffix + "None");
            else
                PrintInfo(suffix + "  ", type.BaseType);
            Console.WriteLine(suffix + "Member Info:");
            MemberInfo[] members = type.GetMembers(BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static|BindingFlags.Public);
            foreach (var item in members)
                Console.WriteLine(suffix + "name: {0,-15} type: {2,-11} in: {1}",
                                  item.Name, item.DeclaringType.Name, item.MemberType);
        }
    }

    class MyClass
    {
        public int Id;
        public string Name;
    }

    static class MyTools
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        public static void ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            Console.WriteLine(str);
        }
    }

    public delegate int SomeDelegate(int p1, string p2);
    public delegate int MyDelegate();
}
