using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                int mood = AskForMood();
                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry(date, prompt, response, mood);
                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                journal.LoadFromFile(Console.ReadLine());
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                journal.SaveToFile(Console.ReadLine());
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
            }
        }
    }

    static int AskForMood()
    {
        int mood;
        Console.Write("How are you feeling today (1-10)? ");
        while (!int.TryParse(Console.ReadLine(), out mood) || mood < 1 || mood > 10)
        {
            Console.Write("Please enter a number from 1 to 10: ");
        }
        return mood;
    }
}