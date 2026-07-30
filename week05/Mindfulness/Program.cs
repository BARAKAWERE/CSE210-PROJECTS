using System;
using System.Collections.Generic;

// To exceed the core requirements, this program keeps a simple log of the
// activities completed during the session and shows it from the menu.

public class Program
{
    public static void Main(string[] args)
    {
        List<string> log = new List<string>();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) View Log");
            Console.WriteLine("5) Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    ShowLog(log);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Not a valid choice.");
                    Console.ReadLine();
                    break;
            }

            if (activity != null)
            {
                activity.Run();
                log.Add(activity.GetType().Name);

                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static void ShowLog(List<string> log)
    {
        Console.Clear();
        Console.WriteLine("Activities completed this session:");
        if (log.Count == 0)
        {
            Console.WriteLine("None yet.");
        }
        else
        {
            for (int i = 0; i < log.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {log[i]}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}
