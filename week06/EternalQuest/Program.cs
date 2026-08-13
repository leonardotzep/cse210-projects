using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

// I added a level leveling up method, the user can get into the next level by 
// scoring 500 point, so each level has to be 500 points and it is printing in the sytem
// the current level.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!\n");
        GoalManager goalManager = new GoalManager();

        int choice = 0;
        while (choice != 6)
        {
            goalManager.DisplayPlayerInfo();

            Console.WriteLine("\nMenu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Events");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                goalManager.CreateGoal();
            }

            else if (choice == 2)
            {
                goalManager.ListGoalNames();
            }

            else if (choice == 3)
            {
                goalManager.SaveGoals();
            }

            else if (choice == 4)
            {
                goalManager.LoadGoals();
            }

            else if (choice == 5 )
            {
                goalManager.ListGoalDetails();
                Console.Write("Which goal did you accomplish? ");
                int goalIndex = int.Parse(Console.ReadLine());

                goalManager.RecordEvent(goalIndex);
            }

            else if (choice == 6 )
            {
                Console.WriteLine("Thank you for participating, have a good day!");
            }
        }
    }
}
