using System;
using System.Data;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // As additional, I added a 4th activity option called Stretching activity.
        // And also I added it in the main menu.
        while (true)
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Start stretching activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                if (choice == 1)
                {
                    BreathingActivity breathing =  new BreathingActivity(
                        "Breathing Activity",
                        "This activity will help you relax by walking your through breathing in" + 
                        "and out slowly. Clear your mind and focus on your breathing.\n"
                    );

                    breathing.Run();
                }


                else if (choice == 2)
                {
                    ReflectionActivity reflecting = new ReflectionActivity(
                        "Reflection Activity",
                        "This activity will help you reflect on times in your life when you have shown strength and resilience." + 
                        "This will help you recognize the power you have and how you can use it in other aspects of your life.\n"
                    );

                    reflecting.Run();
                }


                else if (choice == 3)
                {
                    ListingActivity listing = new ListingActivity(
                        "Listing Activity",
                        "This activity will help you reflect on the good things in your life by" + 
                        "having you list as many things as you can in a certain area.\n"
                    );

                    listing.Run();
                }


                else if (choice ==4)
                {
                    StretchingActivity stretching = new StretchingActivity(
                        "Stretching Activity",
                        "This activity will help you relax by stretching your body."
                    );

                    stretching.Run();
                }


                else if (choice == 5)
                {
                    Console.WriteLine("Thank you!");
                    break;
                }


                else
                {
                    Console.WriteLine("Invalid option, please try again.\n");
                }
            }


            else
            {
                Console.WriteLine("Invalid option, please try again.\n");
            }
        }
    }
}
