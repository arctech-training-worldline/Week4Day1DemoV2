using System;

namespace Week4Day1DemoV2.WorldlineWindows
{
    internal class WindowDemo
    {
        public static void Demo()
        {
            string[] contents1 = { "Dummy Text to display", "in my window.", "Just to see how", "It works" };

            Window window1 = new Window(10, 5, 30, 7, "My 1st Window");
            window1.PositionChanged += Window1_PositionChanged;

            Window window2 = new Window(20, 13, 50, 5, "My 2nd Window", contents1);

            window1.Show();
            window2.Show();

            Window selectedWindow = window1;
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        selectedWindow.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        selectedWindow.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        selectedWindow.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        selectedWindow.MoveDown();
                        break;
                    case ConsoleKey.H:
                        selectedWindow.Hide();
                        break;
                    case ConsoleKey.S:
                        selectedWindow.Show();
                        break;
                    case ConsoleKey.D1:
                        selectedWindow = window1;
                        break;
                    case ConsoleKey.D2:
                        selectedWindow = window2;
                        break;
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        private static void Window1_PositionChanged(object sender, PositionChangedInfo positionChangedInfo)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Window 1 has moved to Left:{positionChangedInfo.Left}, Top:{positionChangedInfo.Top}");
        }
    }
}
