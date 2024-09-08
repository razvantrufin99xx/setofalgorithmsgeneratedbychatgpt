using System;

public class SearchAlgorithms
{
    // Linear Search: Search for the target element in the array
    public int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                return i; // Return index if found
            }
        }
        return -1; // Return -1 if not found
    }

    // Binary Search: Assumes the array is sorted
    public int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
            {
                return mid; // Return index if found
            }
            else if (array[mid] < target)
            {
                left = mid + 1; // Move to the right half
            }
            else
            {
                right = mid - 1; // Move to the left half
            }
        }

        return -1; // Return -1 if not found
    }
}

class Program
{
    static void Main(string[] args)
    {
        SearchAlgorithms searchAlgorithms = new SearchAlgorithms();
        
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15 };
        int target = 7;

        // Linear Search
        int linearSearchResult = searchAlgorithms.LinearSearch(array, target);
        if (linearSearchResult != -1)
        {
            Console.WriteLine($"Linear Search: Element {target} found at index {linearSearchResult}");
        }
        else
        {
            Console.WriteLine($"Linear Search: Element {target} not found");
        }

        // Binary Search
        int binarySearchResult = searchAlgorithms.BinarySearch(array, target);
        if (binarySearchResult != -1)
        {
            Console.WriteLine($"Binary Search: Element {target} found at index {binarySearchResult}");
        }
        else
        {
            Console.WriteLine($"Binary Search: Element {target} not found");
        }
    }
}
