internal class Program
{
    public static ICollection<T> RemoveWhere<T>(ICollection<T> collection, Predicate<T> predicate)
    {
        var itemsToBeRemoved = collection.Where(item => predicate(item)).ToList();
        foreach (var item in itemsToBeRemoved)
        {
            collection.Remove(item);
        }
        return collection;
    }

    public static int? SecondLargest(ICollection<int> collection)
    {
        if (collection == null || collection.Count < 2)
        {
            return null;
        }
        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        foreach (var num in collection)
        {
            if (num > largest)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest && num != largest)
            {
                secondLargest = num;
            }
        }
        return secondLargest == int.MinValue ? null : secondLargest;
    }

    public static ICollection<T> UnionCollections<T>(ICollection<T> firstCollection, ICollection<T> secondCollection)
    {
        return firstCollection.Union(secondCollection).ToList();
    }

    public static ICollection<T> CloneCollection<T>(ICollection<T> collection)
    {
        return new List<T>(collection);
    }

    public static ICollection<T> GetPage<T>(ICollection<T> collection, int pageNumber, int pageSize)
    {
        return collection.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    private static void Main(string[] args)
    {
        List<int> list = new List<int> {1,2,3,4,5,6,7,8,9,10 };
        List<string> listS = new List<string> { "Hirtik", "Hitesh", "Hardik"};
        // 1. Remove Items from a Collection Based on a Predicate
        var newList = RemoveWhere(list, n => n % 2 == 0);
        //var newList = RemoveWhere(listS, s => !s.StartsWith("H"));
        foreach (var item in newList)
        //foreach (var item in list) // This will also work because of reference
        {
            Console.Write($"{item} ");
        }

        // 2. Return the Second Largest Element from an ICollection
        Console.WriteLine($"\nSecond Largest: {SecondLargest(new List<int> { 1,2,3,4,5})}");

        // 3. Compute the Union of Two Collections
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 3, 4, 5 };
        var union = UnionCollections(list1, list2); // union = [1, 2, 3, 4, 5]
        Console.Write($"Union: ");
        foreach (var item in union)
        {
            Console.Write($"{item} ");
        }

        // 4. Clone an ICollection into a New Collection of the Same Type
        var original = new List<string> { "Hirtik", "Hitesh" };
        var clonned = CloneCollection(original);

        // 5. Implement Pagination for Large Data Sets
        var items = Enumerable.Range(1, 100).ToList();
        var page3 = GetPage(items, 3, 10);
        Console.Write("\nReturned Pages: ");
        foreach (var item in page3)
        {
            Console.Write($"Item: {item} ");
        }
    }
}