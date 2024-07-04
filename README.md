# Improved Exception Handling for C#

## Overview

The aim of this project is to streamline and simplify the approach to exception handling in C#. This repository contains extensions and utility methods to enhance the readability, maintainability, and robustness of your exception handling code.

## Key Features

1. **Throwing Extensions**: Simplify and standardize the way exceptions are thrown based on null checks and predicate evaluations.
   - **ThrowArgumentNullExceptionIfNull**: Throws an `ArgumentNullException` if the value is null.
   - **ThrowArgumentExceptionIfNullOr**: Throws an `ArgumentException` if the value is null or does meet a specified condition.
   - **ThrowArgumentExceptionIf**: Throws an `ArgumentException` if the value does meet a specified condition.
   - **ThrowIf**: Throws a custom exception if the value does meet a specified condition.

2. **Exception Extensions**: Enhance exceptions by adding custom data in a structured and reusable way.
   - **AddData (Single Pair)**: Adds a single key-value pair to the exception's data.
   - **AddData (Multiple Pairs)**: Adds multiple key-value pairs to the exception's data.

Uses System.Text.Json to Serialize data objects.

## Example Usage

### Throwing Extensions

```csharp
string name = null;
name.ThrowArgumentNullExceptionIfNull(); // Throws ArgumentNullException if name is null.

int age = -1;
age.ThrowArgumentExceptionIf(x => x < 0); // Throws ArgumentException if age is less than 0.

string email = "example@domain.com";
email.ThrowArgumentExceptionIfNullOr(x => !x.Contains("@")); // Throws ArgumentException if email is null or does not contain '@'.

var p = new Person(Age:0);
p.ThrowIf(expression: x => x.Age < 1, factory: () => new ArgumentNullException("This is my CustomText"));
```
### Exception Extensions
```csharp
try
{
    string data = null;
    data.ThrowArgumentNullExceptionIfNull(); // This will throw an ArgumentNullException.
}
catch (ArgumentNullException ex)
{
    ex.AddData("AdditionalInfo", "This occurred in method X.");
    throw; // Re-throw the exception with additional data.
}

Other Example

string data = null ?? throw new ArgumentNullException().AddData("SomeData", "Example");

```
Getting Started

    Clone the repository:

    bash

git clone [url](https://github.com/nariolf111/ImprovedExceptionHandeling.git)

Add the project to your solution and reference it in your project.

or Download the Nuget Package at: [Nuget.Org](https://www.nuget.org/packages/ImprovedExceptionHandeling/)

Use the provided extension methods to enhance your exception handling logic.
