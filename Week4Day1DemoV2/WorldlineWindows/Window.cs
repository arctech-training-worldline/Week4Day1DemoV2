using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Day1Demo.WorldlineWindows
{
    /// <summary>
    /// 1. Inherit from Box
    /// </summary>
    public class Window : Box
    {
        public string Title { get; set; }
        public string[] Contents { get; set; }

        public Window(int left, int top, int width, int height, string title) : base(left, top, width, height)
        {
            Title = title;
        }

        public Window(int left, int top, int width, int height, string title, string[] contents) : base(left, top, width, height)
        {
            Title = title;
            Contents = contents;
        }

        protected override void DisplayTop(char horizontalCharacter)
        {
            if(horizontalCharacter == ClearCharacter)
                base.DisplayTop(horizontalCharacter);
            else
                DisplayTitleBar(horizontalCharacter);
        }

        private void DisplayTitleBar(char horizontalCharacter)
        {
            var line = new string(horizontalCharacter, Width - Title.Length - 1);
            var horizontalBar = $"{horizontalCharacter}{Title}{line}";

            Console.SetCursorPosition(Left, Top);
            Console.Write(horizontalBar);
        }

        public override void Show()
        {
            base.Show();

            ShowContents();
        }

        private void ShowContents()
        {
            if (Contents == null) return;

            int row = 1;
            foreach (string item in Contents)
            {
                if (row >= Height - 1)
                    break;

                Console.SetCursorPosition(Left + 1, Top + row);
                Console.Write(item);
                row++;
            }
        }
    }
}
