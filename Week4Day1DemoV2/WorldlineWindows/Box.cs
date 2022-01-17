using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Day1Demo.WorldlineWindows
{
    public class Box
    {
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
        }

        public void MoveRight()
        {
            Hide();
            Left++;
            Show();
        }

        public void MoveUp()
        {
            Hide();
            Top--;
            Show();
        }

        public void MoveDown()
        {
            Hide();
            Top++;
            Show();
        }

        protected virtual void DisplayBottom(char horizontalCharacter)
        {
            var horizontalBar = new string(horizontalCharacter, Width);

            Console.SetCursorPosition(Left, Bottom);
            Console.Write(horizontalBar);
        }

        protected virtual void DisplayRight(char verticalCharacter)
        {
            for (int i = 1; i < Height - 1; i++)
            {
                Console.SetCursorPosition(Right, Top + i);
                Console.Write(verticalCharacter);
            }
        }

        protected virtual void DisplayLeft(char verticalCharacter)
        {
            for (int i = 1; i < Height - 1; i++)
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
