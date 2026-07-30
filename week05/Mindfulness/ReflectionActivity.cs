using System;

// Shows the user a prompt about a meaningful experience, then walks them
// through a series of random follow up questions to reflect on it.
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions =
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random random = new Random();

    public ReflectionActivity()
        : base("Reflection",
            "This activity will help you reflect on times in your life when you have " +
            "shown strength and resilience. This will help you recognize the power you " +
            "have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write(questions[random.Next(questions.Length)] + " ");
            ShowSpinner(5);
            Console.WriteLine();
        }
    }
}