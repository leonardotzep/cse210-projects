using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Diego", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Moroni", "Fractions", "7.3", "9-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Diego Tzep", "Guatemalan History", "The good doctor");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}

