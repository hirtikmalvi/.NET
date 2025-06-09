using Practice_2;

internal class Program
{
    private static void Main(string[] args)
    {
        // Single Inheritance
        Car car = new Car();
        car.Make = "Mahindra";
        car.Model = "XUV 700";
        car.FuelType = "Diesel";
        //Console.WriteLine($"Car Details: Make: {car.Make}, Model: {car.Model}, Fuel Type: {car.FuelType}");

        // Method Overriding
        Vehicle vehicle = car;
        vehicle.DisplayInfo();
        car.DisplayInfo();

        // Constructor Chaining
        Car car1 = new Car("Audi", "Q7", "Petrol");
        car1.DisplayInfo();

        // Multilevel Inheritance
        ElectricCar car2 = new ElectricCar("BMW", "M7", "Electric");
        car2.DisplayInfo();

        // Real-World Scenario
        GraduateStudent graduateStudent = new GraduateStudent();
        graduateStudent.Name = "Hirtik Malvi";
        graduateStudent.Age = 21;
        graduateStudent.StudentId = "210170107030";
        graduateStudent.Course = "Computer Engineering";
        graduateStudent.GraduationYear = "2025";
        graduateStudent.DisplayStudentInfo();


    }
}