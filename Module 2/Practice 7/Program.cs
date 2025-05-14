using Classes;

internal class Program
{
    private static void Main(string[] args)
    {
        Product[] products = new Product[3];
        Order order = new Order(1, [0,1]);

        products[0] = new Product();
        products[1] = new Product();
        products[2] = new Product();

        products[0].SetName("Maggie");
        products[0].SetCategory("Grocerry");
        products[0].SetPrice(12);

        products[1].SetName("Mouse");
        products[1].SetCategory("Electronics");
        products[1].SetPrice(1150);

        products[2].SetName("Book");
        products[2].SetCategory("Utils");
        products[2].SetPrice(100);

        // Ordered Products
        foreach (var orderedProd in order.Products())
        {
            Console.WriteLine($"Product Details: Name: {products[orderedProd].Name()}, Category: {products[orderedProd].Category()}, Price: {products[orderedProd].Price()}, Discounted Price: {products[orderedProd].CalculateDiscount()}");
        }

        // For Taking Product Details Dynamically

        //for (int i = 0; i < products.Length; i++)
        //{
        //    products[i] = new Product();
        //    Console.Write($"Enter Product {i + 1} Name: ");
        //    products[i].SetName(Console.ReadLine());

        //    Console.Write($"Enter Product {i + 1} Category: ");
        //    products[i].SetCategory(Console.ReadLine());

        //    Console.Write($"Enter Product {i + 1} Price: ");
        //    products[i].SetPrice(Convert.ToDecimal(Console.ReadLine()));
        //}

        //foreach (var product in products)
        //{
        //Console.WriteLine($"Product Details: Name: {product.Name()}, Category: {product.Category()}, Price: {product.Price()}, Discounted Price: {product.CalculateDiscount()}");
        //}

    }
}