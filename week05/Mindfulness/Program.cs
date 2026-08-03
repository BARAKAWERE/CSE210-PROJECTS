using System;

// Extra credit: the duration prompt in Activity re-asks the user until they
// enter a valid positive number instead of crashing on bad input.

public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflecting Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                Console.ReadLine();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                Console.ReadLine();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                Console.ReadLine();
            }
            else if (choice == "4")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("That is not a valid choice.");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Goodbye!");
    }
}