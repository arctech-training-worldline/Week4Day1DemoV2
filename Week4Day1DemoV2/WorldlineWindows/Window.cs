using System;

namespace Week4Day1DemoV2.WorldlineWindows
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

            var row = 1;
            foreach (var item in Contents)
            {
                if (row >= Height - 1)
                    break;

                Console.SetCursorPosition(Left + 1, Top + row);
                Console.Write(item);
                row++;
            }
        }

        public override void Hide()
        {
            base.Hide();

            HideContents();
        }

        private void HideContents()
        {
            if (Contents == null) return;

            var blankLine = new string(' ', Width - 2);

            for (var row = Top + 1; row < Top + Height - 1; row++)
            {
                Console.SetCursorPosition(Left + 1, row);
                Console.Write(blankLine);
            }
        }
    }
}
