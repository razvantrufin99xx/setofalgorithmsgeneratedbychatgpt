using System;
using System.Collections.Generic;

public class Item
{
    public int Weight { get; set; }
    public int Value { get; set; }

    public Item(int weight, int value)
    {
        Weight = weight;
        Value = value;
    }

    public double ValuePerWeight()
    {
        return (double)Value / Weight;
    }
}

public class FractionalKnapsack
{
    public double MaximizeValue(List<Item> items, int capacity)
    {
        // Sort items by value/weight ratio in descending order
        items.Sort((a, b) => b.ValuePerWeight().CompareTo(a.ValuePerWeight()));

        double totalValue = 0;
        int currentWeight = 0;

        foreach (var item in items)
        {
            if (currentWeight + item.Weight <= capacity)
            {
                // Take the whole item
                currentWeight += item.Weight;
                totalValue += item.Value;
            }
            else
            {
                // Take the fractional part of the item
                int remainingCapacity = capacity - currentWeight;
                totalValue += item.ValuePerWeight() * remainingCapacity;
                break;
            }
        }

        return totalValue;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            new Item(10, 60),
            new Item(20, 100),
            new Item(30, 120)
        };

        int capacity = 50;
        FractionalKnapsack knapsack = new FractionalKnapsack();
        double maxValue = knapsack.MaximizeValue(items, capacity);

        Console.WriteLine($"Maximum value in the knapsack = {maxValue}");
    }
}
