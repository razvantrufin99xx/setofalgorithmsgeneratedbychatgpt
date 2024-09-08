using System;

public class BinarySearch
{
    public int Search(int[] array, int left, int right, int target)
    {
        if (right >= left)
        {
            int mid = left + (right - left) / 2;

            // If the element is present at the middle itself
            if (array[mid] == target)
                return mid;

            // If the element is smaller than mid, search the left subarray
            if (array[mid] > target)
                return Search(array, left, mid - 1, target);

            // Otherwise search the right subarray
            return Search(array, mid + 1, right, target);
        }

        // Target is not present in the array
        return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 2, 3, 4, 10, 40 };
        int target = 10;
        BinarySearch bs = new BinarySearch();

        int result = bs.Search(array, 0, array.Length - 1, target);

        if (result == -1)
            Console.WriteLine("Element not present in array");
        else
            Console.WriteLine("Element found at index " + result);
    }
}
