// Abstract class
using Practice_5;

abstract class Appliance
{
    abstract public void TurnOn();
    abstract public void TurnOff();
}

class Fan : Appliance
{
    public override void TurnOff()
    {
        Console.WriteLine("Turning Off Fan");
    }

    public override void TurnOn()
    {
        Console.WriteLine("Turning On Fan");
    }
}

class WashingMachine : Appliance
{
    public override void TurnOff()
    {
        Console.WriteLine("Turning Off Washing Machine");
    }

    public override void TurnOn()
    {
        Console.WriteLine("Turning On Washing Machine");
    }
}

// Interface Implementation
interface IReport
{
    void GenerateReport();
}

class PDFReport : IReport
{
    public void GenerateReport()
    {
        Console.WriteLine($"Generating PDF Report");
    }
}

class ExcelReport : IReport
{
    public void GenerateReport()
    {
        Console.WriteLine($"Generating Excel Report");
    }
}

// Abstract Class with Business Logic
abstract class Shape
{
    abstract public void CalculatePerimeter();
    abstract public void CalculateArea();
}

class Square: Shape
{
    public float Length { get; set; }
    override public void CalculatePerimeter()
    {
        Console.WriteLine($"Square Perimeter: {4 * Length}");
    }
    override public void CalculateArea()
    {
        Console.WriteLine($"Square Area: {Length * Length}");
    }
}

class Triangle : Shape
{
    public float Side { get; set; }
    override public void CalculatePerimeter()
    {
        Console.WriteLine($"Triangle Perimeter: {3 * Side}");
    }
    override public void CalculateArea()
    {
        Console.WriteLine($"Square Area: {Side * Side * Side / 3}");
    }
}

// Combining Interface and Abstract Class
abstract class Vehicle
{
    public float Speed { get; set; }
    abstract public void DisplayDetails();
}

interface IFuelEfficiency
{
    float CalulateEfficiency();
}

class HybridClass : Vehicle, IFuelEfficiency
{
    public HybridClass(float speed)
    {
        Speed = speed;
    }
    public float CalulateEfficiency()
    {
        return Speed / 10;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Car Details: Model: Hybrid, Speed: {Speed}, Effieciency: {CalulateEfficiency()}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // Abstract Class
        WashingMachine machine = new WashingMachine();
        Fan fan = new Fan();
        machine.TurnOn();
        machine.TurnOff();
        fan.TurnOn();
        fan.TurnOff();

        // Interface
        PDFReport pdfReport = new PDFReport();
        ExcelReport excelReport = new ExcelReport();

        IReport iReportPDF = pdfReport;
        IReport iReportExcel = excelReport;

        Console.Write($"Generating Report From PDFReport Instance: ");
        pdfReport.GenerateReport();

        Console.Write($"Generating Report From ExcelReport Instance: ");
        excelReport.GenerateReport();

        Console.Write($"Generating Report From IReport Interface using instance of PDFReport: ");
        iReportPDF.GenerateReport();

        Console.Write($"Generating Report From IReport Interface using instance of ExcelReport: "); iReportExcel.GenerateReport();

        // Abstract Class With Business Logic
        Square square = new Square();   
        Triangle triangle = new Triangle();

        square.Length = 10;
        triangle.Side = 25;

        square.CalculatePerimeter();
        square.CalculateArea();

        triangle.CalculatePerimeter();
        triangle.CalculateArea();

        // Real World Scenario
        HomeLoan homeLoan = new HomeLoan();
        CarLoan carLoan = new CarLoan();

        homeLoan.LoanAmount = 50000;
        homeLoan.InterestRate = 10;
        Console.WriteLine($"Home Loan EMI: {homeLoan.CalculateEMI()}");

        carLoan.LoanAmount = 850000;
        carLoan.InterestRate = 15;
        Console.WriteLine($"Car Loan EMI: {carLoan.CalculateEMI()}");

        // Combining INterface and Abstract Class
        HybridClass hybridClass = new HybridClass(150);
        hybridClass.DisplayDetails();
    }
}