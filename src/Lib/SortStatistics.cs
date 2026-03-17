namespace Lib;

public class SortStatistics
{
    public int AmountOfComparison { get; set; }
    public int AmountOfIterations { get; set; }

    public override string ToString()
    {
        return $"Comparison: {AmountOfComparison}, Iterations: {AmountOfIterations}";
    }
}