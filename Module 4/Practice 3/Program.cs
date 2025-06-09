internal class Program
{

    // 189. Rotate Array(Kadane's Algorithm)
    public int maxSumArray(int[] arr)
    {
        int currentSum = 0;
        int maxSum = int.MinValue;

        for (int i = 0; i < arr.Length; i++)
        {
            currentSum += arr[i];
            if (currentSum < 0)
            {
                currentSum = 0;
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }
        return maxSum;
    }

    public void RotateArray(int k, int[] arr)
    {
        int[] tempArr = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            tempArr[(i + k) % arr.Length] = arr[i];
        }
        foreach (var item in tempArr)
        {
            Console.WriteLine(item);
        }
    }

    // 905. Sort Array By Parity
    public void EvenNumbersBeforeOdd(int[] arr)
    {
        int[] evens = Array.Empty<int>();
        int[] odds = new int[] { };

        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[j] % 2 == 0)
            {
                evens.Append(arr[j]);
            }
            else
            {
                odds.Append(arr[j]);
            }
        }
        int i = 0;
        for (int j = 0; j < evens.Length; j++)
        {
            arr[i] = evens[j];
            i++;
            Console.WriteLine($"Evens: {evens[j]}");
        }
        for (int j = 0; j < odds.Length; j++)
        {
            arr[i] = odds[j];
            i++;
        }
        foreach (var item in arr)
        {
            Console.Write($"{item} ");
        }
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        int[] arr = { 1, 2, 3, 4, 5 };
        int[] arr1 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int[] arr2 = { 3, 1, 2, 4 };
        program.RotateArray(1, arr);
        Console.WriteLine($"Max Sum for an Array:  {program.maxSumArray(arr1)}");
        program.EvenNumbersBeforeOdd(arr2);
    }
}