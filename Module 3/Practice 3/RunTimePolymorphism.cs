using System;

namespace Practice_3
{
    class Shape
    {
        public virtual double CalculateArea()
        {
            return 0;
        }
    }
    class Rectangle : Shape {
        
        public double Length {  get; set; }
        public double Breadth {  get; set; }
        public override double CalculateArea()
        {
           return Length * Breadth;
        }
    }
    class Circle : Shape
    {

        public double Radius { get; set; }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
