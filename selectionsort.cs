using System;

class SelectionSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            // Swap the found minimum element with the first element
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    static void Main()
    {
        int[] array = { 64, 25, 12, 22, 11 };
        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(", ", array));

        Sort(array);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(", ", array));
    }
}
