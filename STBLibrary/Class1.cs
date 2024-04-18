using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A method that takes in an amount (currency) and the number of people, then returns the split amount.
/// </summary>
public class MyClass
{
    public decimal SplitAmountByPeople(decimal amount, int numberOfPeople)
    {
        if (numberOfPeople <= 0)
            throw new ArgumentException("Number of people must be greater than zero.");

        return Math.Round(amount / numberOfPeople, 2); // Round to 2 decimal places
    }

/// <summary>
/// A method with two arguments: a dictionary of <String, Decimal> and a float. The string will be the name, and the decimal will be the amount their meal costs. The float argument will represent the percentage for the Tip. This method will return a dictionary of names and the amount each person pays for the Tip. Use the URL in the description to see how to calculate a weighted average.
/// </summary>
/// <param name="mealCosts"></param>
/// <param name="tipPercentage"></param>
/// <returns></returns>
/// <exception cref="ArgumentNullException"></exception>
/// <exception cref="ArgumentException"></exception>
    public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (mealCosts == null)
            throw new ArgumentNullException(nameof(mealCosts), "Meal costs dictionary cannot be null.");

        if (tipPercentage < 0 || tipPercentage > 100)
            throw new ArgumentException("Tip percentage must be between 0 and 100.");

        decimal totalCost = mealCosts.Values.Sum();
        decimal tipAmount = totalCost * (decimal)(tipPercentage / 100);

        decimal totalAmountWithTip = totalCost + tipAmount;

        Dictionary<string, decimal> tipPerPerson = new Dictionary<string, decimal>();
        foreach (var kvp in mealCosts)
        {
            decimal individualTip = kvp.Value / totalCost * tipAmount;
            tipPerPerson[kvp.Key] = individualTip;
        }

        return tipPerPerson;
    }
}
