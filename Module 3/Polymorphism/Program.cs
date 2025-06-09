internal class Program
{
    class ParentClass
    {
        public virtual void Method()
        {
            Console.WriteLine("Parent Class Method...");
        }
    }
    class ChildClass: ParentClass 
    {
        public override void Method()
        {
            Console.WriteLine("Child Class Method...");
        }
        private static void Main(string[] args)
        {
            ParentClass parentClass = new ParentClass();
            ChildClass childClass = new ChildClass();
            ParentClass parentClass1 = new ChildClass();

            parentClass1.Method();
            //parentClass.Method();
            //childClass.Method();
        }
    }
}