namespace Practice_2
{
    class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public Vehicle() { }
        public Vehicle(string make, string model)
        {
            Make = make;
            Model = model;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Car Details: Make: {Make}, Model: {Model}");
        }
    }
    class Car : Vehicle
    {
        public string FuelType { get; set; }

        // Constructor Chaining
        public Car() { }
        public Car(string make, string model, string fuelType): base(make, model)
        {
            FuelType = fuelType;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Car Details: Make: {Make}, Model: {Model}, Fuel Type: {FuelType}");
        }
    }

    class ElectricCar: Car
    {
        public ElectricCar() { }
        public ElectricCar(string make, string model, string fuelType) : base(make, model, fuelType)
        {

        }
    }
}
