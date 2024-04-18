using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

[TestClass]
public class MyTests
{
    [TestMethod]
    public void TestSplitAmountByPeople_WhenValidInputs_ReturnsCorrectSplit()
    {
        // Arrange
        var myClass = new MyClass();
        decimal amount = 100;
        int numberOfPeople = 5;

        // Act
        decimal result = myClass.SplitAmountByPeople(amount, numberOfPeople);

        // Assert
        Assert.AreEqual(20, result); // Assuming correct split for this example
    }

    [TestMethod]
    public void TestCalculateTipPerPerson_WhenValidInputs_ReturnsCorrectTipAmounts()
    {
        // Arrange
        var myClass = new MyClass();
        var mealCosts = new Dictionary<string, decimal>
        {
            { "Sanju", 50 },
            { "Abi", 70 },
            { "Tikam", 100 }
        };
        float tipPercentage = 15;
        decimal expectedSanjuTip = 11.25M;
        decimal expectedAbiTip = 15.75M;
        decimal expectedTip = 22.50M;

        // Act
        var result = myClass.CalculateTipPerPerson(mealCosts, tipPercentage);

        // Assert
        Assert.IsTrue(Math.Abs(result["Sanju"] - expectedSanjuTip) < 0.01M);
        Assert.IsTrue(Math.Abs(result["Abi"] - expectedAbiTip) < 0.01M);
        Assert.IsTrue(Math.Abs(result["Tikam"] - expectedTip) < 0.01M);
    }

    [TestMethod]
    public void TestSplitAmountByPeople_ZeroPeople_ThrowsArgumentException()
    {
        // Arrange
        var myClass = new MyClass();
        decimal amount = 100;
        int numberOfPeople = 0;

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => myClass.SplitAmountByPeople(amount, numberOfPeople));
    }

    [TestMethod]
    public void TestSplitAmountByPeople_NegativePeople_ThrowsArgumentException()
    {
        // Arrange
        var myClass = new MyClass();
        decimal amount = 100;
        int numberOfPeople = -1;

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => myClass.SplitAmountByPeople(amount, numberOfPeople));
    }

    [TestMethod]
    public void TestCalculateTipPerPerson_NullMealCosts_ThrowsArgumentNullException()
    {
        // Arrange
        var myClass = new MyClass();
        Dictionary<string, decimal>? mealCosts = null;
        float tipPercentage = 15;

        // Act and Assert
#pragma warning disable CS8604 // Possible null reference argument.
        _ = Assert.ThrowsException<ArgumentNullException>(() => myClass.CalculateTipPerPerson(mealCosts, tipPercentage));
#pragma warning restore CS8604 // Possible null reference argument.
    }

    [TestMethod]
    public void TestCalculateTipPerPerson_InvalidTipPercentage_ThrowsArgumentException()
    {
        // Arrange
        var myClass = new MyClass();
        var mealCosts = new Dictionary<string, decimal>
        {
            { "Alice", 50 }
        };
        float invalidTipPercentage = -5;

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => myClass.CalculateTipPerPerson(mealCosts, invalidTipPercentage));
    }
}
