namespace InventoryManagement
{
    abstract class Product
    {
        private string _ProductID;
        private string _Name;
        private decimal _Price;
        private int _Stock;

        public string ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public decimal Price
        {
            get { return _Price; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Price Can not be negative");
                }
                _Price = value;
            }
        }
        public int Stock
        {
            get { return _Stock; }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Stock Can not be negative");

                }
                _Stock = value;
            }
        }

        protected Product(string name, decimal price, int stock)
        {
            ProductID = DateTime.Now.Ticks.ToString();
            Name = name;
            Price = price;
            Stock = stock;
        }

        abstract public double CalculateTax();
        abstract public double ApplyDiscount();
        public decimal CalculateTotalValue()
        { 
            return Price * Stock;    
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"\nProduct: {Name} (ID: {ProductID})");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Stock: {Stock}");
            Console.WriteLine($"Tax: {CalculateTax()}");
            Console.WriteLine($"Discount: {ApplyDiscount()}");
            Console.WriteLine($"Inventory Value: {CalculateTotalValue()} \n");
        }
    }

    class Electronics : Product
    {
        public Electronics(string name, decimal price, int stock): base(name, price, stock) { }

        public override double ApplyDiscount()
        {
            return Price > 5000 ? (double)(Price * 10 / 100) : 0;
        }

        public override double CalculateTax()
        {
            return (double)(Price * 18 / 100);
        }
    }
    class Grocerries : Product
    {
        public Grocerries(string name, decimal price, int stock) : base(name, price, stock) { }

        public override double ApplyDiscount()
        {
            return 0;
        }

        public override double CalculateTax()
        {
            return (double)(Price * 5 / 100);
        }
    }
    class Clothing : Product
    {
        public Clothing(string name, decimal price, int stock) : base(name, price, stock) { }

        public override double ApplyDiscount()
        {
            return Price > 2000 ? (double)(Price * 15 / 100) : 0;
        }

        public override double CalculateTax()
        {
            return (double)(Price * 12 / 100);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Grocerries("Maggie", 12, 20),
                new Grocerries("Madhur Sugar", 239, 50),
                new Grocerries("Salt", 18, 20),
                new Electronics("Keyboard", 1150, 10),
                new Electronics("Monitor", 25000, 10),
                new Clothing("Denim Jeans", 1200, 11),
                new Clothing("Shirt", 900, 6),
                new Clothing("Shoes", 2300, 10)
            };

            Console.WriteLine("=== Inventory Report ===");
            foreach (var product in products)
            {
                product.DisplayInfo();
            }

            Console.WriteLine("\n=== End of Report ===");
        }
    }
}