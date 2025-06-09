internal class Program
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public static List<Employee> SortEmployees(List<Employee> employees)
    {
        return employees.OrderBy(e => e.Age).ThenBy(e => e.Name).ToList();
    }

    public static int BinarySearch<T>(List<T> sortedList, T item)
    {
        return sortedList.BinarySearch(item);
    }

    public static void InsertSorted<T>(List<T> sortedList, T item)
    {
        int index = sortedList.BinarySearch(item);
        index = index < 0 ? ~index : index;
        sortedList.Insert(index, item);
    }

    public static Dictionary<T, int> CountOccurence<T>(ICollection<T> collection)
    {
        return collection.GroupBy(item => item).ToDictionary(group => group.Key, group => group.Count());
    }

    public static void CommonItems<T>(ICollection<T> source, ICollection<T> reference)
    {
        var itemsToBeRemoved = source.Except(reference).ToList();
        foreach (var item in itemsToBeRemoved) {
            source.Remove(item);
        }
    }

    private static void Main(string[] args)
    {
        //1. Sort a Collection of Employees by Age and Then Name
        var employees = new List<Employee>
        {
        new Employee { Name = "Alice", Age = 30 },
        new Employee { Name = "Bob", Age = 25 },
        new Employee { Name = "Charlie", Age = 30 }
        };

        var sorted = SortEmployees(employees);
        foreach (var item in sorted)
        {
            Console.WriteLine($"Name: {item.Name} Age: {item.Age}");
        }

        // 2. Search for an Element in a Sorted Collection Using Binary Search
        var numList = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Element Found at Index using Binary Search: {BinarySearch(numList, 5)}");

        // 3. Insert an Item at a Specific Index and Maintain Sorted Order
        List<int> sortedNums = new List<int> { 1, 2, 3, 4, 6, 7, 9, 10 };
        InsertSorted(sortedNums, 5);
        Console.WriteLine($"After Inserting Item At Specified Index: {string.Join(", ", sortedNums)}");

        // 4. Count the Occurrences of Each Unique Element in a Collection
        var items = new List<string> { "apple", "banana", "apple", "cherry", "banana", "banana" };
        var counts = CountOccurence(items);
        foreach (var item in counts)
        {
            Console.WriteLine($"Item: {item.Key}, Count: {item.Value}");
        }

        // 5. Remove Items Not Present in Another Collection
        var list1 = new List<int> { 1, 2, 3, 4, 5 };
        var list2 = new List<int> { 3, 4, 5, 6, 7 };
        CommonItems(list1, list2); // Removing
        Console.Write("Items Not Present In Another Collection: ");
        foreach (var item in list1)
        {
            Console.Write($"{item} ");
        }
    }
}