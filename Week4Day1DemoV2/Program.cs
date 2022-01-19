using Week4Day1DemoV2.WorldlineWindows;

namespace Week4Day1DemoV2
{
    /// <summary>
    /// Problem Statement: Create a windowing system in a console application
    /// Features:
    ///     1. Window should have a border and titlebar
    ///     2. Window should be able to move around left, right, up or down on the screen
    ///     3. Window should have option of setting the text contents within the window area
    ///     4. Ability to set the focus on specific window, and switch focus when required.
    /// Solution:
    ///     1. Box
    ///         Show
    ///         Hide
    ///         MoveLeft
    ///         MoveRight
    ///         MoveUp
    ///         MoveDown
    ///     2. Window
    ///         Title
    ///         TextContent
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowDemo.Demo();
            //ParametersDemo.Demo();
            //DelegateDemo.Demo2();
            //EventDemo.Demo();
            //EventDemoFinal.Demo();
            //EventDemoFinalFinal.Demo();
        }
    }
}
