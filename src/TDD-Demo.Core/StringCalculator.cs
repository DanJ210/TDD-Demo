namespace TDD_Demo.Core;

/// <summary>
/// String Calculator - TDD Kata Example
/// This class will be built using Test-Driven Development
/// </summary>
public interface IStringCalculator
{
    /// <summary>
    /// Adds numbers from a string representation
    /// </summary>
    /// <param name="numbers">String containing numbers separated by delimiters</param>
    /// <returns>Sum of all numbers in the string</returns>
    int Add(string numbers);
}

/// <summary>
/// Implementation will be built step-by-step following TDD practices
/// </summary>
public class StringCalculator : IStringCalculator
{

    public int Add(string numbers)
    {
        throw new NotImplementedException("This method will be implemented step-by-step using TDD.");
    }
}

// Handle comma-separated numbers
// if (numbers.Contains(','))
// {
//     var parts = numbers.Split(',');
//     int sum = 0;
//     foreach (var part in parts)
//     {
//         sum += int.Parse(part);
//     }
//     return sum;
// }

// Handle commoas and lew line
// public int Add(string numbers)
//     {
//         if (string.IsNullOrEmpty(numbers))
//             return 0;

//         // Handle comma and newline delimiters
//         var delimiters = new char[] { ',', '\n' };
//         var parts = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

//         int sum = 0;
//         foreach (var part in parts)
//         {
//             sum += int.Parse(part.Trim());
//         }
//         return sum;
//     }
