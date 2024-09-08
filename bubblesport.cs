using System;

class BubbleSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap array[j] and array[j + 1]
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    static void Main()
    {
        int[] array = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(", ", array));

        Sort(array);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(", ", array));
    }
}
