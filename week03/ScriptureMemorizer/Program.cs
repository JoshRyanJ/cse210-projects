using System;
using System.Collections.Generic;

//To exceed requirement, I did a few things  
// 1 I selected random words only from words that are not already hidden so each Enter press hides new words.
// 2 I added a small scripture library (including single and multi-verse passages) and chose one at random.

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();

        Reference refOne = new Reference("Moroni", 7, 47);
        scriptures.Add(new Scripture(refOne, "But charity is the pure love of Christ, and it endureth forever; and whoso is found possessed of it at the last day, it shall be well with him"));

        Reference refTwo = new Reference(" 1 Nephi", 11, 17);
        scriptures.Add(new Scripture(refTwo, "I know that he loveth his children; nevertheless, I do not know the meaning of all things"));

        Random random = new Random();
        Scripture currentScripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();

            if (currentScripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            currentScripture.HideRandomWords(3);
        }
    }
}