using System;

public class MergeSort
{
    public void Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            // Recursively sort the two halves
            Sort(array, left, middle);
            Sort(array, middle + 1, right);

            // Merge the sorted halves
            Merge(array, left, middle, right);
        }
    }

    private void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, middle + 1, rightArray, 0, n2);

        int i = 0, j = 0;
        int k = left;

        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        // Copy the remaining elements of leftArray, if any
        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        // Copy the remaining elements of rightArray, if any
        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };
        MergeSort ms = new MergeSort();

        Console.WriteLine("Given Array");
        Console.WriteLine(string.Join(" ", array));

        ms.Sort(array, 0, array.Length - 1);

        Console.WriteLine("\nSorted Array");
        Console.WriteLine(string.Join(" ", array));
    }
}
