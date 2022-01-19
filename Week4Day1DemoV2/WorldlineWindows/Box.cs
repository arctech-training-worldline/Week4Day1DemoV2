using System;

namespace Week4Day1DemoV2.WorldlineWindows
{
    public struct PositionChangedInfo
    {
        public int Left { get; set; }
        public int Top { get; set; }

        public PositionChangedInfo(int left, int top)
        {
            Left = left;
            Top = top;
        }
    }

    //Step1
    //public delegate void PositionChangedDelegate(PositionChangedInfo positionChangedInfo);

    public class Box
    {
        //Step2
        //public event PositionChangedDelegate PositionChanged;
        public event EventHandler<PositionChangedInfo> PositionChanged;

        public const char WindowBorderHorizontal = '-';
        public const char WindowBorderVertical = '|';
        public const char ClearCharacter = ' ';

        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Right => Left + Width - 1;
        public int Bottom => Top + Height - 1;

        public Box(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public virtual void Show()
        {
            DisplayTop(WindowBorderHorizontal);
            DisplayLeft(WindowBorderVertical);
            DisplayRight(WindowBorderVertical);
            DisplayBottom(WindowBorderHorizontal);
        }

        public virtual void Hide()
        {
            DisplayTop(ClearCharacter);
            DisplayLeft(ClearCharacter);
            DisplayRight(ClearCharacter);
            DisplayBottom(ClearCharacter);
        }

        public void MoveLeft()
        {
            Hide();
            Left--;
            Show();

            //Step3
            if (PositionChanged != null)
                //PositionChanged.Invoke(new PositionChangedInfo(Left, Top));
                PositionChanged.Invoke(this, new PositionChangedInfo(Left, Top));
        }

        public void MoveRight()
        {
            Hide();
            Left++;
            Show();

            //Step3
            if (PositionChanged != null)
                PositionChanged.Invoke(this, new PositionChangedInfo(Left, Top));
        }

        public void MoveUp()
        {
            Hide();
            Top--;
            Show();

            //Step3
            if (PositionChanged != null)
                PositionChanged.Invoke(this, new PositionChangedInfo(Left, Top));
        }

        public void MoveDown()
        {
            Hide();
            Top++;
            Show();

            //Step3
            if (PositionChanged != null)
                PositionChanged.Invoke(this, new PositionChangedInfo(Left, Top));
        }

        protected virtual void DisplayBottom(char horizontalCharacter)
        {
            var horizontalBar = new string(horizontalCharacter, Width);

            Console.SetCursorPosition(Left, Bottom);
            Console.Write(horizontalBar);
        }

        protected virtual void DisplayRight(char verticalCharacter)
        {
            for (var i = 1; i < Height - 1; i++)
            {
                Console.SetCursorPosition(Right, Top + i);
                Console.Write(verticalCharacter);
            }
        }

        protected virtual void DisplayLeft(char verticalCharacter)
        {
            for (var i = 1; i < Height - 1; i++)
            {
                Console.SetCursorPosition(Left, Top + i);
                Console.Write(verticalCharacter);
            }
        }

        protected virtual void DisplayTop(char horizontalCharacter)
        {
            var horizontalBar = new string(horizontalCharacter, Width);
            Console.SetCursorPosition(Left, Top);
            Console.Write(horizontalBar);
        }
    }
}
