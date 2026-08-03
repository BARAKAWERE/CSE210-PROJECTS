using System;
using System.Threading;

// Base class for the three mindfulness activities.
// Handles the parts that are the same for every activity: the start message,
// the end message, asking for the duration, and the pause/animation methods.
public abstract class MindfulnessActivity
{
    private string name;
    private string description;
    private int duration;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    protected int Duration
    {
        get { return duration; }
    }

    // Runs the activity from start to finish.
    public void Run()
    {
        StartMessage();
        PerformActivity();
        EndMessage();
    }

    private void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {name} Activity.");
        Console.WriteLine();
        Console.WriteLine(description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        duration = GetPositiveNumber();

        Console.WriteLine("Get ready...");
        ShowCountDown(3);
        Console.WriteLine();
    }

    private void EndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {name} activity for {duration} seconds.");
        ShowSpinner(2);
        Console.WriteLine();
    }

    // Each activity fills in its own steps here.
    protected abstract void PerformActivity();

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "/", "-", "\\", "|" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
    }

    private int GetPositiveNumber()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.Write("Please enter a number greater than 0: ");
        }
        return value;
    }
}