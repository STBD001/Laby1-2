using NUnit.Framework;

[TestFixture]
public class ProblemTests
{
    [Test]
    public void Problem1()
    {
        int itemCount = 10;
        int seed = 1;
        int capacity = 20;

        Problem problem = new Problem(itemCount, seed);

        Result result = problem.Solve(capacity);

        Assert.IsTrue(result.SelectedItems.Count > 0, "Expected at least one selected item.");
    }

    [Test]
    public void Problem2()
    {
        int itemCount = 10;
        int seed = 1;
        int capacity = 0;

        Problem problem = new Problem(itemCount, seed);

        Result result = problem.Solve(capacity);

        Assert.IsEmpty(result.SelectedItems, "Expected no selected items when capacity is too small.");
    }
    [Test]
    public void Problem3()
    {
        int itemCount = 5;
        int seed = 1;
        int capacity = 15;

        Problem problem = new Problem(itemCount, seed);

        Result solution = problem.Solve(capacity);

        Assert.LessOrEqual(solution.TotalWeight, capacity, "Total weight limited, backpack");

        int calculatedTotalValue = 0;
        int calculatedTotalWeight = 0;
        foreach (int itemIndex in solution.SelectedItems)
        {
            calculatedTotalValue += problem.Values[itemIndex - 1];
            calculatedTotalWeight += problem.Weights[itemIndex - 1];
        }
        Assert.AreEqual(calculatedTotalValue, solution.TotalValue, "The total value is not calculated correctly");
        Assert.AreEqual(calculatedTotalWeight, solution.TotalWeight, "The total weight is not calculated correctly");
    }

    [Test]
    public void Problem4() //Sprawdzenie, czy jeœli ¿aden przedmiot nie spe³nia ograniczeñ, to zwrócono puste rozwi¹zanie.
    {
        int itemCount = 3;
        int seed = 1;
        Problem problem = new Problem(itemCount, seed);

        int minWeight = problem.Weights.Min();
        int capacity = minWeight - 1;

        Result result = problem.Solve(capacity);

        Assert.IsTrue(result.SelectedItems.Count == 0, "Expected no selected items when all items are too heavy.");
        Assert.AreEqual(0, result.TotalValue, "Total value should be 0 when no items are selected.");
        Assert.AreEqual(0, result.TotalWeight, "Total weight should be 0 when no items are selected.");
    }

    [Test]
    public void Problem5() //Sprawdzenie, czy jeœli pojemnoœæ plecaka jest równa wadze najl¿ejszego przedmiotu, to wybrany zostanie przedmiot o najlepszym stosunku wartoœæ/waga
    {
        int itemCount = 5;
        int seed = 1;

        Problem problem = new Problem(itemCount, seed);

        int minWeight = problem.Weights.Min();
        int capacity = minWeight;

        List<int> minWeightItemIndices = new List<int>();
        for (int i = 0; i < problem.ItemCount; i++)
        {
            if (problem.Weights[i] == minWeight)
                minWeightItemIndices.Add(i);
        }
        int bestItemIndex = -1;
        double bestRatio = -1;
        foreach (int i in minWeightItemIndices)
        {
            double ratio = (double)problem.Values[i] / problem.Weights[i];
            if (ratio > bestRatio)
            {
                bestRatio = ratio;
                bestItemIndex = i;
            }
        }

        Result result = problem.Solve(capacity);

        Assert.AreEqual(1, result.SelectedItems.Count, "Expected exactly one item to be selected.");
        Assert.AreEqual(minWeight, problem.Weights[result.SelectedItems[0] - 1], "Selected item does not have the minimum weight.");
        Assert.AreEqual(bestItemIndex + 1, result.SelectedItems[0], "Selected item is not the one with best value/weight ratio among items with minimum weight.");
    }
}