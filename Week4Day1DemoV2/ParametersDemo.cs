using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Day1Demo
{
    internal class ParametersDemo
    {
        /// <summary>
        /// 1. Value Parameters => Before Demo x:10, y:20 | Before SwapNumbers x:10, y:20 | After SwapNumber x:20, y:10 | After Demo x:10, y:20
        /// 2. Ref Parameters => Before Demo x:10, y:20 | Before SwapNumbers x:10, y:20 | After SwapNumber x:20, y:10 | After Demo x:20, y:10
        /// 3. Out Parameters => Before Demo x:10, y:20 | Before SwapNumbers x:10, y:20 | After SwapNumber x:20, y:10 | After Demo x:20, y:10
        /// </summary>
        internal static void Demo()
        {
            //int x = 10, y = 20;

            //Console.WriteLine($"Before Demo => x:{x}, y:{y}");
            //SwapNumbers(ref x, ref y);
            //Console.WriteLine($"After Demo => x:{x}, y:{y}");

            float average;
            int sum = 10, count;
            FindAverageSumAndCount(out average, out sum, out count, 10, 20, 30, 40, 50);
            FindAverageSumAndCount(out average, out sum, out count, 10, 20, 30);
            FindAverageSumAndCount(out average, out sum, out count, 10, 20, 30, 40, 50, 60, 100);

            Console.WriteLine($"Avg:{average} Sum:{sum} Count:{count}");

            int ans1 = Add(10, 20);
            int ans2 = Add(10, 20, 30);
        }

        internal static void SwapNumbers(ref int xxx, ref int yyy)
        {
            Console.WriteLine($"Before SwapNumbers=> x:{xxx}, y:{yyy}");

            int z = xxx;
            xxx = yyy;
            yyy = z;

            Console.WriteLine($"After SwapNumbers=> x:{xxx}, y:{yyy}");
        }

        internal static void FindAverageSumAndCount(out float average, out int sum, out int count,
            params int[] values)
        {
            sum = 0;
            foreach (int item in values)
            {
                sum += item;
            }

            count = values.Length;
            average = sum / count;
        }

        internal static int Add(int x, int y, int z = 0)
        {
            return x + y + z;
        }

        //internal static int Add(int x, int y, int z)
        //{
        //    return x + y + z;
        //}
    }
}
