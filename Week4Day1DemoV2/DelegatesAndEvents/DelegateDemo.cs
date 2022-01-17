using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Day1Demo.DelegatesAndEvents
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // delegate
    internal delegate void ShowDelegate(string message);

    internal delegate void MyDelegate(string s, int a);

    internal class DelegateDemo
    {
        #region Delegate Demo1
        /// <summary>
        /// Custom delegates
        /// </summary>
        internal static void Demo1()
        {
            int i;  // Stack
            Department dept = new Department(); // Heap;

            // Example Delegate 1
            MyDelegate myDelegate = Jump;

            Jump("aa", 10);
            myDelegate.Invoke("bb", 20);
            myDelegate("bb", 20);

            // Example Delegate 2
            Console.Write("Do you want (W)hite, (R)ed or (G)reen: ");
            string answer = Console.ReadLine();

            ShowDelegate showFunction = Show;

            if (answer == "R")
                showFunction = ShowRed;
            else if (answer == "G")
                showFunction = ShowGreen;


            showFunction("Hello World 1");
            //or
            showFunction.Invoke("Hello World 2");
        }        

        internal static void Jump(string name, int age)
        {

        }

        internal static void Show(string s)
        {
            Console.WriteLine(s);
        }

        internal static void ShowRed(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void ShowGreen(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #endregion

        internal delegate void MyDelegate1(int aa, int bb);
        internal delegate int MyDelegate2(int aa, int bb);
        internal delegate string MyDelegate3(string s1, string s2, int n1);

        /// <summary>
        /// Inbuilt delegates
        /// </summary>
        internal static void Demo2()
        {
            // Manual Delegate
            MyDelegate1 del1; 
            del1 = Show;

            // InBuilt Delegate
            Action<int, int> del11;
            del11 = Show;

            // Manual Delegate
            MyDelegate2 del2 = Add;
            // InBuilt Delegate
            Func<int, int, int> del22 = Add;

            del1(10, 20);
            int ans = del2(10, 20);
            Console.WriteLine($"Answer={ans}");

            // Manual Delegate
            MyDelegate3 del3 = Concatenate;
            Console.WriteLine(del3("aaa", "bbbb", 10));

            // InBuilt Delegate
            Func<string, string, int, string> del4 = Concatenate;
            Console.WriteLine(del4("xxx", "yyy", 20));

            See(Concatenate);
        }

        internal static void See(MyDelegate3 del)
        {
            del("ggg", "jjj", 50);
        }

        internal static void Show(int x, int y)
        {
            Console.WriteLine($"x:{x}, y:{y}");
        }

        internal static string Concatenate(string s1, string s2, int n1)
        {
            return $"s1:{s1}, s2:{s2}, n1:{n1}";
        }

        internal static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
