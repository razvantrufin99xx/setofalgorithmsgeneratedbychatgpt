using System;

class Program
{
    static void Main()
    {
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        int target = 7;
        int result = BinarySearchIterative(array, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }

    static int BinarySearchIterative(int[] array, int target)
    {
        int left = 0, right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
                return mid;

            if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}


//recusrive 


using System;

class Program
{
    static void Main()
    {
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        int target = 7;
        int result = BinarySearchRecursive(array, target, 0, array.Length - 1);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }

    static int BinarySearchRecursive(int[] array, int target, int left, int right)
    {
        if (left > right)
            return -1;

        int mid = left + (right - left) / 2;

        if (array[mid] == target)
            return mid;

        if (array[mid] < target)
            return BinarySearchRecursive(array, target, mid + 1, right);
        else
            return BinarySearchRecursive(array, target, left, mid - 1);
    }
}



