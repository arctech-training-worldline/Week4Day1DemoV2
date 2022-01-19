using System;

namespace Week4Day1DemoV2
{
    internal interface BaseInterface
    {
        void Add();
        void Show();
    }

    internal abstract class BaseDemo
    {
        public int RollNo { get; set; }
        public int Age { get; set; }

        public void Add()
        {
            Console.WriteLine("BaseDemo::Add!!");
        }

        public abstract void Show();
    }

    internal class Derived1Demo : BaseDemo
    {
        public sealed override void Show()
        {
            Console.WriteLine("Derived1Demo Show!!");
        }
    }
    internal interface SomeOtherInterface
    { }

    internal sealed class Derived2Demo : BaseDemo, BaseInterface, SomeOtherInterface
    {
        public sealed override void Show()
        {
            Console.WriteLine("Derived2Demo Show!!");
        }

        public void Jump()
        {

        }
    }

    /*
    // Not allowed as class is sealed
    internal class Derived3Demo : Derived2Demo
    {
        
    }

    internal class Derived4Demo : Derived1Demo
    {
        // Not allowed as Show is sealed in base class
        public override void Show()
        {
            base.Show();
        }
    }
    */

    internal class AbstractDemo
    {
        internal static void Demo()
        {
            BaseDemo baseDemo;

            //baseDemo = new BaseDemo();
            //baseDemo.Show();
            baseDemo = new Derived1Demo();
            baseDemo.Show();
            baseDemo = new Derived2Demo();
            baseDemo.Show();
        }
    }
}
