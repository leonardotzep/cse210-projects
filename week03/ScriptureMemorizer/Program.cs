using System;
using System.Runtime.InteropServices;


// I added a list of scriptures and also I added a menu where the user can select or choose
// the scripture in the menu until the user types 'quit'.

class Program
{
    static void Main(string[] args)
    {

        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all thine heart;" + 
            "and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son," + 
            "that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Moses", 1, 39), "For behold, this is my work and my glory - to bring to" + 
            "pass the immortality and eternal life of man"),
            new Scripture(new Reference("Joshua", 3, 7), "Surely the Lord God will do nothing, but he revealeth his secret unto his servants the prophets."),
            new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things" + 
            "which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way" +
            "for them that they may accomplish the thing which he commandeth them.")
        };

        Console.WriteLine("Welcome to Scripture Memorizer Program!");

        while (true)
        {
            Console.WriteLine("Select one of the following options: ");
            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].Reference.GetDisplayText()}");
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish.");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "quit")
            {
                Console.WriteLine("Thank you, good bye!");
                break;
            }

            if (!int.TryParse(choice, out int index) || index < 1 || index > scriptures.Count)
            {
                Console.WriteLine("Invalid option. Try again.");
                continue;
            }

            Scripture scripture = scriptures[index - 1];
            Console.WriteLine($"\n {scripture.GetDisplayText()}");

            while (true)
{
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Thank you, good bye!");
                    return;
                }

                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());

                if (scripture.IsCompletelyHidden())
                {
                    break;
                }
            }
        }
    }
}
