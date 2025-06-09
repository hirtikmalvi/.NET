using System;

namespace Abstraction
{

    interface ITestInterface
    {
        void GetName(string name);
    }
    abstract class TestAbstractClass: ITestInterface
    {
        public abstract void GetName(string name);
    }

    public abstract class AbstractClass
    {
        public static int temp = 1;
        public abstract void GetName(string name);
        public void GetName(string name, int age)
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }
    public class NonAbstractClass: AbstractClass
    {
        public override void GetName(string name)
        {
            Console.WriteLine("Hirtik Malvi");
        }
        //public abstract void GetName(string name);
    }

    public abstract class A
    {
        public static int GetNumber()
        {
            return 0;
        }
        public abstract void GetName(string name);
    }

    public abstract class B: A
    {
        public override void GetName(string name)
        {
            
        }
    }

    class AbstractClassDemo
    {
        NonAbstractClass nac = new NonAbstractClass();
    }
}
