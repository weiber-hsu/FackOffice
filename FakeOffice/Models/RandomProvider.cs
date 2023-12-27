namespace FakeOffice.Models;

public class RandomProvider : Random
{
    public DateTime GetRandomDateAfter(DateTime start, int month)
    {
        var random = new Random();
        var endDate = start.AddMonths(18);
        var days = (endDate - start).Days;
        return start + TimeSpan.FromDays(random.Next(days));
    }

    // override the base object can easier to test logic
    public override int Next(int minValue, int maxValue)
    {
        return base.Next(minValue, maxValue);
    }
}