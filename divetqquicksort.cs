using System;

public class QuickSort
{
    public void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);

            // Recursively sort elements before and after the partition
            Sort(array, low, pivotIndex - 1);
            Sort(array, pivotIndex + 1, high);
        }
    }

    private int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    private void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 10, 7, 8, 9, 1, 5 };
        QuickSort qs = new QuickSort();

        Console.WriteLine("Given Array");
        Console.WriteLine(string.Join(" ", array));

        qs.Sort(array, 0, array.Length - 1);

        Console.WriteLine("\nSorted Array");
        Console.WriteLine(string.Join(" ", array));
    }
}
