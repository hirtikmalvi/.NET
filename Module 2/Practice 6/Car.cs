using System;

namespace Practice_6
{
    internal class Car
    {
        public string Brand;
        public string Model;
        public decimal Price;

        public Car(string brand, string model, decimal price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public void CarDetails()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Price: {Price}");

        }
    }
}
