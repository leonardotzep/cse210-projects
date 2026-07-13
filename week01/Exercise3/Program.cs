using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string response = "yes";

        while (response == "yes")
        {
            int magicNumb = randomGenerator.Next(1,100);
            int guess = -1;

            while (guess != magicNumb)
            {
                Console.Write("What is the number you would like to guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumb > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumb < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guess it! ");
                    Console.WriteLine("Would you like to play again? yes/no ");
                    response = Console.ReadLine();
                }

            }
        }

    }
}