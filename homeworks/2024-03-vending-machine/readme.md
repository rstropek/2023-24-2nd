# Vending Machine

## Introduction

In this exercise, you practice the following topics:

* Exceptions and exception handling
* Class inheritance, polymorphism, and encapsulation
* Unit testing

This exercise follows the principles introduced in [_2024-03-polymorphism_](https://github.com/rstropek/2023-24-2nd/tree/main/live/2024-03-polymorphism).

## Setting Up the Project

1. Create a new solution named `VendingMachine` in an empty folder: `dotnet new sln --name VendingMachine`
2. Create a console app inside the solution named `VendingMachine`: `dotnet new console --name VendingMachine --output VendingMachine`
3. Create an XUnit test project inside the solution named `VendingMachine.Tests`: `dotnet new xunit --name VendingMachine.Tests --output VendingMachine.Tests`
4. Add the console app and the test project to the solution: `dotnet sln add VendingMachine VendingMachine.Tests`

You are now ready to start the exercise.

## Problem Statement

You have to implement the coin logic of a vending machine. The vending machine accepts the following coins:

* 2 Euro (`2E`)
* 1 Euro (`1E`)
* 50 Cent (`50C`)
* 20 Cent (`20C`)
* 10 Cent (`10C`)

Implement a console app that performs the following tasks:

1. Ask the user to enter the total price of the product.
2. In a loop, ask the user to enter coins until the total amount is equal to or greater than the price of the product.
3. If the user enters an invalid coin, display an error message and ask the user to enter a valid coin.
4. If the user enters a valid coin, display the total amount entered so far.
5. At the end, display the change to be returned to the user.

Example output:

```plaintext
Price: 1.5E
Coin: 1E
Total: 1E
Coin: 50C
Total: 1.5E
Change: 0E
```

Example output 2:

```plaintext
Price: 1.5E
Coin: 1E
Total: 1E
Coin: 2E
Total: 3E
Change: 1.5E
```

Example output 3:

```plaintext
Price: 1.5E
Coin: 3E
Invalid coin
Coin: 1E
Total: 1E
Coin: 50C
Total: 1.5E
Change: 0E
```

## Step 1

* Implement a separate class called `Coin` that contains a method `Parse`. It takes a string as input and returns the corresponding coin value in Cents. If the input is invalid, the method should throw a `FormatException` exception.
* Write tests for `Coin` that cover the following cases.
  * Correct parsing of `2E`, `1E`, `50C`, `20C`, and `10C`.
  * Incorrect parsing of `3E`, `1D`, `50`, and `20Cents`.

**Tip**: Revisit the tests shown in [_NumberAdderTests.cs_](https://github.com/rstropek/2023-24-2nd/tree/main/live/2024-03-polymorphism/Adder.Tests/NumberAdderTests.cs) for inspiration.

## Step 2

* Implement a class called `ChangeCalculator`. It receives the product price in Cents in the constructor.
* The class offers a method `AddCoin` that takes a coin value in Cents as input and adds it to the total amount.
* From outside the class, the total amount should only be accessible through a read-only property `TotalAmount`.
* The class has a property `IsEnoughMoney` that returns `true` if the total amount is equal to or greater than the product price.
* The class has a method `GetChange` that returns the change to be returned to the user. If the total amount is less than the product price, the method should throw an `InvalidOperationException` exception.
* Write tests for `ChangeCalculator` that cover the following cases.
  * Total amount is initially 0.
  * Total amount is correctly updated when adding coins.
  * `AddCoins` throws an `OverflowException` if the total amount exceeds `int.MaxValue`.
  * `IsEnoughMoney` returns `true` if the total amount is equal to or greater than the product price.
  * `IsEnoughMoney` returns `false` if the total amount is less than the product price.
  * `GetChange` returns the correct change.
  * `GetChange` throws an `InvalidOperationException` if the total amount is less than the product price.

**Tip**: Revisit the tests shown in [_NumberAdderTests.cs_](https://github.com/rstropek/2023-24-2nd/tree/main/live/2024-03-polymorphism/Adder.Tests/NumberAdderTests.cs) for inspiration.

## Step 3

* Implement a class `CoinHandlingConsole` that contains the main logic of the console app.
* The class has a `HandleCoins` method that contains the user interaction logic (input/output) as shown above. The method returns the change to be returned to the user.
* Create `virtual` methods `WriteLine` and `ReadLine` that encapsulate the console input/output. These methods will be overridden in a derived class for testing purposes (as demonstrated in [_NumberAdderConsoleMock.cs_](https://github.com/rstropek/2023-24-2nd/tree/main/live/2024-03-polymorphism/Adder.Tests/NumberAdderConsoleMock.cs)).
* In the main program, create an instance of `CoinHandlingConsole` and call the `HandleCoins` method. Test your program manually.

## Step 4

* Implement a class `CoinHandlingConsoleMock` in the test project. It derives from `CoinHandlingConsole`.
* `CoinHandlingConsoleMock` gets the user input as an array of strings in the constructor. The `ReadLine` method returns the next string from the array.
* The `WriteLine` method writes the output to a list of strings.
* Write tests that use `CoinHandlingConsoleMock` to test the `CoinHandlingConsole` class. The tests should cover the following cases.
  * The user enters valid coins so that she reaches the product price exactly and gets no change.
  * The user enters valid coins so that the total amount exceeds the product price and therefore the user gets change.
  * The user enters an invalid coin.

**Tip**: Revisit the tests shown in [_NumberAdderConsoleMock.cs_](https://github.com/rstropek/2023-24-2nd/tree/main/live/2024-03-polymorphism/Adder.Tests/NumberAdderConsoleMock.cs) and [_NumberAdderConsoleTests.cs_](https://github.com/rstropek/2023-24-2nd/tree/main/live/2024-03-polymorphism/Adder.Tests/NumberAdderConsoleTests.cs) for inspiration.
