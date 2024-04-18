using System;

public class MyClass
{
    public decimal SplitAmountByPeople(decimal amount, int numberOfPeople)
    {
        if (numberOfPeople <= 0)
            throw new ArgumentException("Number of people must be greater than zero.");

        return Math.Round(amount / numberOfPeople, 2); // Round to 2 decimal places
    }

    public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (mealCosts == null)
            throw new ArgumentNullException(nameof(mealCosts), "Meal costs dictionary cannot be null.");

        if (tipPercentage < 0 || tipPercentage > 100)
            throw new ArgumentException("Tip percentage must be between 0 and 100.");

        decimal totalCost = mealCosts.Values.Sum();
        decimal tipAmount = totalCost * (decimal)(tipPercentage / 100);

        decimal totalAmountWithTip = totalCost + tipAmount;

        var tipPerPerson = new Dictionary<string, decimal>();
        foreach (var kvp in mealCosts)
        {
            decimal individualTip = kvp.Value / totalCost * tipAmount;
            tipPerPerson[kvp.Key] = individualTip;
        }

        return tipPerPerson;
    }

    public decimal CalculateTipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
    {
        if (numberOfPatrons <= 0)
            throw new ArgumentException("Number of patrons must be greater than zero.");

        decimal tipAmount = price * (decimal)(tipPercentage / 100);
        return Math.Round(tipAmount / numberOfPatrons, 2); // Round to 2 decimal places
    }
}
