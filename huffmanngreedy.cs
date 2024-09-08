using System;
using System.Collections.Generic;

public class HuffmanNode : IComparable<HuffmanNode>
{
    public char Character { get; set; }
    public int Frequency { get; set; }
    public HuffmanNode Left { get; set; }
    public HuffmanNode Right { get; set; }

    public HuffmanNode(char character, int frequency)
    {
        Character = character;
        Frequency = frequency;
        Left = Right = null;
    }

    public int CompareTo(HuffmanNode other)
    {
        return Frequency.CompareTo(other.Frequency);
    }
}

public class HuffmanCoding
{
    public void BuildHuffmanTree(char[] characters, int[] frequencies)
    {
        PriorityQueue<HuffmanNode> pq = new PriorityQueue<HuffmanNode>();

        for (int i = 0; i < characters.Length; i++)
        {
            pq.Enqueue(new HuffmanNode(characters[i], frequencies[i]));
        }

        while (pq.Count > 1)
        {
            HuffmanNode left = pq.Dequeue();
            HuffmanNode right = pq.Dequeue();

            HuffmanNode newNode = new HuffmanNode('-', left.Frequency + right.Frequency)
            {
                Left = left,
                Right = right
            };

            pq.Enqueue(newNode);
        }

        HuffmanNode root = pq.Dequeue();
        PrintCodes(root, "");
    }

    private void PrintCodes(HuffmanNode root, string code)
    {
        if (root == null)
            return;

        if (root.Character != '-')
            Console.WriteLine($"{root.Character}: {code}");

        PrintCodes(root.Left, code + "0");
        PrintCodes(root.Right, code + "1");
    }
}

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> data;

    public PriorityQueue()
    {
        data = new List<T>();
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int childIndex = data.Count - 1;
        while (childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;
            if (data[childIndex].CompareTo(data[parentIndex]) >= 0)
                break;

            T tmp = data[childIndex];
            data[childIndex] = data[parentIndex];
            data[parentIndex] = tmp;
            childIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        int lastIndex = data.Count - 1;
        T frontItem = data[0];
        data[0] = data[lastIndex];
        data.RemoveAt(lastIndex);

        --lastIndex;
        int parentIndex = 0;
        while (true)
        {
            int childIndex = parentIndex * 2 + 1;
            if (childIndex > lastIndex) break;
            int rightChild = childIndex + 1;
            if (rightChild <= lastIndex && data[rightChild].CompareTo(data[childIndex]) < 0)
                childIndex = rightChild;
            if (data[parentIndex].CompareTo(data[childIndex]) <= 0) break;

            T tmp = data[parentIndex];
            data[parentIndex] = data[childIndex];
            data[childIndex] = tmp;
            parentIndex = childIndex;
        }
        return frontItem;
    }

    public int Count
    {
        get { return data.Count; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        char[] characters = { 'a', 'b', 'c', 'd', 'e', 'f' };
        int[] frequencies = { 5, 9, 12, 13, 16, 45 };

        HuffmanCoding huffman = new HuffmanCoding();
        huffman.BuildHuffmanTree(characters, frequencies);
    }
}
