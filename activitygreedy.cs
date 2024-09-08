using System;
using System.Collections.Generic;

public class Activity
{
    public int Start { get; set; }
    public int Finish { get; set; }

    public Activity(int start, int finish)
    {
        Start = start;
        Finish = finish;
    }
}

public class GreedyActivitySelector
{
    public void SelectActivities(List<Activity> activities)
    {
        // Sort activities by finish time
        activities.Sort((a, b) => a.Finish.CompareTo(b.Finish));

        // The first activity is always selected
        Console.WriteLine("Selected Activities:");
        int i = 0;
        Console.WriteLine($"Activity({activities[i].Start}, {activities[i].Finish})");

        for (int j = 1; j < activities.Count; j++)
        {
            // If the start time of the current activity is greater than or equal
            // to the finish time of the previously selected activity, select it
            if (activities[j].Start >= activities[i].Finish)
            {
                Console.WriteLine($"Activity({activities[j].Start}, {activities[j].Finish})");
                i = j;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Activity(1, 2),
            new Activity(3, 4),
            new Activity(0, 6),
            new Activity(5, 7),
            new Activity(8, 9),
            new Activity(5, 9)
        };

        GreedyActivitySelector selector = new GreedyActivitySelector();
        selector.SelectActivities(activities);
    }
}
