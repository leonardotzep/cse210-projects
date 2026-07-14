using System;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int numberEnter = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

        while (numberEnter != 0)
        {
            Console.Write("Enter number: ");
            numberEnter = int.Parse(Console.ReadLine());

            if (numberEnter != 0)
            {
                numbers.Add(numberEnter);
            }
        }

        int sum = 0;
        int largestNumber = numbers[0];
        int? smallestPositive_number = null;

        
        foreach (int number in numbers)
        {
            sum += number;
            
            if (number > largestNumber)
            {
                largestNumber = number;
            } 
            if (number > 0)
            {
                if (smallestPositive_number == null || number < smallestPositive_number)
                {
                    smallestPositive_number = number;
                }
            }
        }

        int numberCount = numbers.Count;
        double average = (double)sum / numberCount;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");

        if (smallestPositive_number != null)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive_number}");
            }

    }
}