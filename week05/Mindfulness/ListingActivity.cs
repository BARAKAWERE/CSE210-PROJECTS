using System;
using System.Collections.Generic;

// Gives the user a prompt and has them list as many items as they can
// think of before time runs out.
public class ListingActivity : MindfulnessActivity
{
    private string[] prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt a moment of gratitude this month?",
        "Who are some of your personal heroes?"
    };

    private Random random = new Random();

    public ListingActivity()
        : base("Listing",
            "This activity will help you reflect on the good things in your life by " +
            "having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        Console.WriteLine();
        Console.Write("You will have a few seconds to think, then start listing. ");
        ShowCountDown(3);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("List as many items as you can. Press Enter after each one.");
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items. Great job!");
    }
}