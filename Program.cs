using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Laby1-2.Tests")]


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of items: ");
        int itemCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter seed: ");
        int seed = int.Parse(Console.ReadLine());

        Problem problem = new Problem(itemCount, seed);
        Console.WriteLine(problem);

        Console.WriteLine("Enter knapsack capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        Result solution = problem.Solve(capacity);
        Console.WriteLine(solution);
    }
}

class Problem
{
    public int ItemCount { get; private set; }
    public int[] Weights { get; private set; }
    public int[] Values { get; private set; }

    public Problem(int n, int seed)
    {
        ItemCount = n;
        Weights = new int[n];
        Values = new int[n];

        Random rnd = new Random(seed);

        for (int i = 0; i < n; i++)
        {
            Weights[i] = rnd.Next(1, 11);
            Values[i] = rnd.Next(1, 11);
        }
    }

    public override string ToString()
    {
        string result = $"Number of items: {ItemCount}\n";
        for (int i = 0; i < ItemCount; i++)
        {
            result += $"Item {i + 1}: Weight = {Weights[i]}, Value = {Values[i]}\n";
        }
        return result;
    }

    public Result Solve(int capacity)
    {
        Result result = new Result();

        List<(int index, int weight, int value, double ratio)> items = new List<(int, int, int, double)>();

        for (int i = 0; i < ItemCount; i++)
        {
            double ratio = (double)Values[i] / Weights[i];
            items.Add((i, Weights[i], Values[i], ratio));
        }

        items.Sort((a, b) => b.ratio.CompareTo(a.ratio));

        foreach (var item in items)
        {
            if (result.TotalWeight + item.weight <= capacity)
            {
                result.TotalWeight += item.weight;
                result.TotalValue += item.value;
                result.SelectedItems.Add(item.index + 1);
            }
        }

        return result;
    }
}

class Result
{
    public int TotalValue { get; set; }
    public int TotalWeight { get; set; }
    public List<int> SelectedItems { get; set; }

    public Result()
    {
        SelectedItems = new List<int>();
    }

    public override string ToString()
    {
        return $"Total value: {TotalValue}, Total weight: {TotalWeight}, Selected items: {string.Join(", ", SelectedItems)}";
    }
}
